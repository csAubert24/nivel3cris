using bussines;
using dominio;
using System;

namespace Articulos_Web
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            try
            {

                Usuario usuario = new Usuario();
                UsuarioBussines bussines = new UsuarioBussines();
                EmailService emailService = new EmailService();

                usuario.email = txtEmail.Text;
                usuario.Pass = txtContraseña.Text;
                usuario.Id = bussines.insertar(usuario);
                Session.Add("usuario", usuario);


                emailService.armarCorreo(usuario.email, "Registrado correctamente", "se ha generado su usuario de forma correcta");
                emailService.enviarEmail();
                Response.Redirect("Default.aspx");

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());

            }
        }

        protected void btnCencelarRegistro_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}