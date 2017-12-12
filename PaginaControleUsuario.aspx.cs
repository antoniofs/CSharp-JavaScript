using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControleMessageBox;

namespace ProjetoEcommerce.View
{
    public partial class PaginaControleUsuario : System.Web.UI.Page
    {
        protected MessageBox ms = new MessageBox();
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Visible = false;
            HyperLink1.Visible = false;
            
            if(Session["Id"] == null)
            {
                lblmsg.Text = "Acesso Não Permitido";
                btnCompras.Visible = false;
                btnNotas.Visible = false;
            }
            else
            {
                VerificarAdmin();
                UsuarioLogado();
            }

        }

        private void UsuarioLogado()
        {
            try 
	        {	        
		        if(Session["Salvar"] != null )
                {
                    lblmsg.Text = "Olá senhor(a) " + Session["Salvar"] + " o'que você gostaria de fazer?";
                }
	        }
	        catch (Exception)
	        {
		
		        throw;
	        }

        }

        protected void btnCompras_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"PaginaCompras.aspx");
        }

       private bool VerificarAdmin()
       {
           if(Session["Admin"] == "ok")
           {
               Label1.Visible = true;
               HyperLink1.Visible = true;
               return true;
           }
           else
           {
               return false;
           }
       }

       protected void btnSair_Click(object sender, EventArgs e)
       {
           Session.Clear();
           Session.Abandon();
           //ms.ShowConfirmation("Condição: Ok ou Cancel", "Confirm", true, false);
           Response.Redirect(@"PaginaInicio.aspx");
       }

    }
}