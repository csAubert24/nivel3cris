﻿using bussines;
using dominio;
using System;
using System.Drawing;
using System.Security.Policy;


namespace Articulos_Web
{
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)

        {
            try
            {
                if (!IsPostBack)
                {
                    if (Security.sesionActiva(Session["usuario"]))
                    {
                        Usuario usuario = (Usuario)Session["usuario"];
                        txtEmail.Text = usuario.email;
                        txtEmail.ReadOnly = true;
                        TxtNombre.Text = usuario.Nombre;
                        TxtApellido.Text = usuario.Apellido;
                        TxtContraseña.Text = usuario.Pass;
                        if (!string.IsNullOrEmpty(usuario.ImagenPerfil))
                            imgNuevoPerfil.ImageUrl = "~/imagenes/" + usuario.ImagenPerfil;
                        else
                            imgNuevoPerfil.ImageUrl = "https://www.palomacornejo.com/wp-content/uploads/2021/08/no-image.jpg";
                    }
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioBussines negocio = new UsuarioBussines();
                
                Usuario usuario = (Usuario)Session["usuario"];

                if (txtImagen.PostedFile.FileName != "")
                {
                    string ruta = MapPath("./imagenes/");
                    txtImagen.PostedFile.SaveAs(ruta + "perfil-" + usuario.Id + ".jpg");
                    usuario.ImagenPerfil = "perfil-" + usuario.Id + ".jpg";
                }
               

                
                usuario.email = txtEmail.Text;
                usuario.Nombre = TxtNombre.Text;
                usuario.Apellido = TxtApellido.Text;
                usuario.Pass = TxtContraseña.Text;
                
                negocio.Actualizar(usuario);
                //Response.Redirect("Default.aspx");


            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
            }
        }
    }
}