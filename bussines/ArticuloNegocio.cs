using dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace bussines
{

    public class ArticuloNegocio
    {
        public List<Articulo> listar(string id = "")
        {
            List<Articulo> lista = new List<Articulo>();
            SqlCommand comando = new SqlCommand();
            SqlConnection conexion = new SqlConnection();
            SqlDataReader lector;
            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_WEB_DB; integrated security = true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select a.Id,Codigo,Nombre,a.Descripcion, m.Descripcion marca,c.Descripcion categoria ,ImagenUrl,Precio,a.IdMarca,a.IdCategoria from ARTICULOS a,MARCAS m,CATEGORIAS c  where m.Id = a.IdMarca and c.Id = A.IdCategoria  ";
                if (id != "")
                {
                    comando.CommandText += " and a.Id = " + id;
                }
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();


                while (lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.id = (int)lector["Id"];
                    aux.codigo = (string)lector["Codigo"];
                    aux.nombre = (string)lector["Nombre"];
                    aux.descrpcion = (string)lector["Descripcion"];

                    if (!(lector["ImagenUrl"] is DBNull))
                        aux.Imagen = (string)lector["ImagenUrl"];

                    aux.marca = new elemento();
                    aux.marca.id = (int)lector["IdMarca"];
                    aux.marca.descripcion = (string)lector["marca"];
                    aux.categoria = new elemento();
                    aux.categoria.id = (int)lector["IdCategoria"];
                    aux.categoria.descripcion = (string)lector["categoria"];

                    if (!(lector["Precio"] is DBNull))
                        aux.precio = (decimal)lector["Precio"];

                    lista.Add(aux);

                }
                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<Articulo> listarConSp()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("storedListar");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.id = (int)datos.Lector["Id"];
                    aux.codigo = (string)datos.Lector["Codigo"];
                    aux.nombre = (string)datos.Lector["Nombre"];
                    aux.descrpcion = (string)datos.Lector["Descripcion"];

                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.Imagen = (string)datos.Lector["ImagenUrl"];
                    else aux.Imagen = ("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTtMQE6sfANVXaPHKe5Wq9rei2V7anrDYjY7g&usqp=CAU");

                    if (!(datos.Lector["Precio"] is DBNull))
                        aux.precio = (decimal)datos.Lector["Precio"];

                    aux.marca = new elemento();
                    aux.marca.id = (int)datos.Lector["IdMarca"];
                    aux.marca.descripcion = (string)datos.Lector["marca"];
                    aux.categoria = new elemento();
                    aux.categoria.id = (int)datos.Lector["IdCategoria"];
                    aux.categoria.descripcion = (string)datos.Lector["categoria"];
                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into ARTICULOS (Codigo,Nombre,Descripcion,ImagenUrl,Precio,IdMarca,IdCategoria)values('" + nuevo.codigo + "','" + nuevo.nombre + "','" + nuevo.descrpcion + "','" + nuevo.Imagen + "','" + nuevo.precio + "',@IdMarca,@IdCategoria)");
                datos.setearParametro("@IdMarca", nuevo.marca.id);
                datos.setearParametro("@IdCategoria", nuevo.categoria.id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void agregarConSP(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("storedAltaArticulo");
                datos.setearParametro("@Codigo", nuevo.codigo);
                datos.setearParametro("@Nombre", nuevo.nombre);
                datos.setearParametro("@Descripcion", nuevo.descrpcion);
                datos.setearParametro("@idMarca", nuevo.marca.id);
                datos.setearParametro("@Idcategoria", nuevo.categoria.id);
                datos.setearParametro("@ImagenUrl", nuevo.Imagen);
                datos.setearParametro("@precio", nuevo.precio);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void modificar(Articulo Articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update ARTICULOS set Codigo = @cod,Nombre = @Nom,Descripcion=@des, ImagenUrl = @img, IdMarca = @IdM,IdCategoria = @Idc,Precio=@pre where Id = @Id");
                datos.setearParametro("@cod", Articulo.codigo);
                datos.setearParametro("@nom", Articulo.nombre);
                datos.setearParametro("@des", Articulo.descrpcion);
                datos.setearParametro("@img", Articulo.Imagen);
                datos.setearParametro("@IdM", Articulo.marca.id);
                datos.setearParametro("@Idc", Articulo.categoria.id);
                datos.setearParametro("@pre", Articulo.precio);
                datos.setearParametro("@Id", Articulo.id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificarConSp(Articulo Articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("modificarConSp");
                datos.setearParametro("@codigo", Articulo.codigo);
                datos.setearParametro("@nombre", Articulo.nombre);
                datos.setearParametro("@descripcion", Articulo.descrpcion);
                datos.setearParametro("@imagen", Articulo.Imagen);
                datos.setearParametro("@IdMarca", Articulo.marca.id);
                datos.setearParametro("@Idcategoria", Articulo.categoria.id);
                datos.setearParametro("@precio", Articulo.precio);
                datos.setearParametro("@Id", Articulo.id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void EliminarFisico(int Id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("delete from ARTICULOS where Id = @Id");
                datos.setearParametro("@Id", Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "select a.Id,Codigo,Nombre,a.Descripcion, m.Descripcion marca,c.Descripcion categoria ,ImagenUrl,Precio,a.IdMarca,a.IdCategoria from ARTICULOS a,MARCAS m,CATEGORIAS c  where m.Id = a.IdMarca and c.Id = A.IdCategoria And ";
                if (campo == "Precio")
                {
                    switch (criterio)
                    {
                        case "Mayor a ":
                            consulta += " Precio > " + filtro;
                            break;
                        case "Menor a ":
                            consulta += " Precio < " + filtro;
                            break;
                        default:
                            consulta += " Precio = " + filtro;
                            break;
                    }
                }
                else if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Nombre like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "Nombre like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "Nombre like '%" + filtro + "%'";
                            break;
                    }
                }
                else
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "M.Descripcion like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "M.Descripcion like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "M.Descripcion like '%" + filtro + "%'";
                            break;
                    }
                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.id = (int)datos.Lector["Id"];
                    aux.codigo = (string)datos.Lector["Codigo"];
                    aux.nombre = (string)datos.Lector["Nombre"];
                    aux.descrpcion = (string)datos.Lector["Descripcion"];

                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.Imagen = (string)datos.Lector["ImagenUrl"];
                    aux.precio = (decimal)datos.Lector["Precio"];
                    aux.marca = new elemento();
                    aux.marca.id = (int)datos.Lector["IdMarca"];
                    aux.marca.descripcion = (string)datos.Lector["marca"];
                    aux.categoria = new elemento();
                    aux.categoria.id = (int)datos.Lector["IdCategoria"];
                    aux.categoria.descripcion = (string)datos.Lector["categoria"];
                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}