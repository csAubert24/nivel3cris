using bussines;
using dominio;
using System;
using System.Collections.Generic;

namespace Articulos_Web
{
    public partial class Formulario : System.Web.UI.Page
    {
        public bool confirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            confirmaEliminacion = false;
            //configuración inicial de la pantalla.
            try
            {
                if (!IsPostBack)
                {
                    ElementoNegocio negocio = new ElementoNegocio();
                    List<elemento> lista = negocio.listar();
                    List<elemento> lista2 = negocio.listar2();

                    ddlmarca.DataSource = lista;
                    ddlmarca.DataValueField = "Id";
                    ddlmarca.DataTextField = "Descripcion";
                    ddlmarca.DataBind();

                    ddlcategoria.DataSource = lista2;
                    ddlcategoria.DataValueField = "Id";
                    ddlcategoria.DataTextField = "Descripcion";
                    ddlcategoria.DataBind();
                }

                //si modifico..
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != null && !IsPostBack)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();


                    Articulo seleccinado = (negocio.listar(id))[0];
                    //pre cargar
                    txtId.Text = id;
                    txtcodigo.Text = seleccinado.codigo;
                    txtNombre.Text = seleccinado.nombre;
                    TxtDescripcion.Text = seleccinado.descrpcion;
                    txtImagenUrl.Text = seleccinado.Imagen;
                    txtprecio.Text = Convert.ToString(seleccinado.precio);

                    ddlmarca.SelectedValue = seleccinado.marca.id.ToString();
                    ddlcategoria.SelectedValue = seleccinado.categoria.id.ToString();

                    txtImagenUrl_TextChanged(sender, e);


                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }




        }
        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtImagenUrl.Text;
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Articulo nuevo = new Articulo();
                ArticuloNegocio neg = new ArticuloNegocio();


                nuevo.codigo = txtcodigo.Text;
                nuevo.nombre = txtNombre.Text;
                nuevo.descrpcion = TxtDescripcion.Text;
                nuevo.Imagen = txtImagenUrl.Text;
                nuevo.precio = Convert.ToDecimal(txtprecio.Text);

                nuevo.marca = new elemento();
                nuevo.marca.id = int.Parse(ddlmarca.SelectedValue);

                nuevo.categoria = new elemento();
                nuevo.categoria.id = int.Parse(ddlcategoria.SelectedValue);

                if (txtId.Text != null)
                {


                    nuevo.id = int.Parse(txtId.Text);
                    neg.modificarConSp(nuevo);

                }
                else
                    neg.agregarConSP(nuevo);


                Response.Redirect("listas.aspx", false);

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw;
            }
        }
        protected void btnCancelar_Click(Object sender, EventArgs e)
        {
            Response.Redirect("listas.aspx", false);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            confirmaEliminacion = true;
        }

        protected void ConfirmarEliminacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkEliminacion.Checked)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    negocio.EliminarFisico(int.Parse(txtId.Text));
                    Response.Redirect("Listas.aspx");
                }
            }
            catch (Exception ex)
            {

                Session.Add("Eror", ex);
            }
        }
    }
}