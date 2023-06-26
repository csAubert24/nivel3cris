using bussines;
using dominio;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Articulos_Web
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulo> listaArticulos;

        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            listaArticulos = negocio.listarConSp();
            if (!IsPostBack)
            {
                IdRepetidor.DataSource = listaArticulos;
                IdRepetidor.DataBind();
            }

        }

        protected void btnEjemplo_Click(object sender, EventArgs e)
        {
            string valor = ((Button)sender).CommandArgument;
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();
            if (ddlCampo.SelectedItem.ToString() == "Precio")
            {
                ddlCriterio.Items.Add("Menor a ");
                ddlCriterio.Items.Add("Mayor a ");
                ddlCriterio.Items.Add("Igual a ");
            }
            else
            {
                ddlCriterio.Items.Add("Comienza con ");
                ddlCriterio.Items.Add("Termina con ");
                ddlCriterio.Items.Add("Contiene ");
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            try
            {
                if( validacion.taxtoVacio(ddlCampo) || validacion.taxtoVacio(txtFiltroAvanzado) || validacion.taxtoVacio(ddlCriterio))
                {
                    Session.Add("Error", "campos sin cubrir");
                    Response.Redirect("error.aspx");
                } 


                IdRepetidor.DataSource = negocio.filtrar
                (ddlCampo.SelectedItem.ToString(),ddlCriterio.SelectedItem.ToString(), txtFiltroAvanzado.Text);
                IdRepetidor.DataBind();

            }
            catch(System.Threading.ThreadAbortException ex) { }
            catch (Exception)
            {

                Session.Add("Error en la busqueda. Intente nuevamente",false );
                Response.Redirect("error.aspx",false);

            }
        }
    }
}