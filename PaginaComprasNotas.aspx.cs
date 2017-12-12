using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoEcommerce.Models;
using System.Data;

namespace ProjetoEcommerce.View
{
    public partial class PaginaComprasNotas : System.Web.UI.Page
    {
        protected ProjectContext bd;
        protected DataTable dt;
        protected Boolean EstaCancelada = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                PopularGrid();
            }

        }
        #region PopularGrid
        private void PopularGrid()
        {
            try
            {
                dt = new DataTable();
                bd = new ProjectContext();
                decimal id;
                id = Convert.ToDecimal(Session["Id"]);
                decimal quantidade = 0;
                List<ITEM_NF> totalDeItem = (from item in bd.ITEM_NF select item).ToList();
                List<NOTA_FISCAL> registroNF = (from nota in bd.NOTA_FISCAL where nota.ID_CLIENTE == id select nota).ToList();


                dt.Columns.Add("id");
                dt.Columns.Add("CD_NOTA");
                dt.Columns.Add("DATAHORA");
                dt.Columns.Add("qtd");
                dt.Columns.Add("status");

                foreach(NOTA_FISCAL nf in registroNF)
                {
                    foreach(ITEM_NF tditem in totalDeItem)
                    {
                        if(tditem.ID_NF == nf.ID && tditem.ST_ITEM == 1)
                        {
                           quantidade = quantidade + tditem.VALOR_UNIT;
                        }
                        EstaCancelada = (from item in bd.ITEM_NF where item.ID_NF == nf.ID && item.ST_ITEM == 1 select item).Any();
                    }
                    if(EstaCancelada == true)
                    {
                        dt.Rows.Add(nf.ID, nf.CD_NOTA, nf.DATACRIACAO, quantidade, "ativo");
                    }
                    else
                    {
                        dt.Rows.Add(nf.ID, nf.CD_NOTA, nf.DATACRIACAO, quantidade, "Cancelada");
                    }
                    EstaCancelada = false;
                   quantidade = 0;
                }


                GridView1.DataSource = dt;
                GridView1.DataBind();

                bd.Dispose();
            }
            catch (Exception)
            {
                
                throw;
            }

        }

        #endregion
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch(e.CommandName)
            {
                case "VerDetalhes":

                    decimal idNF = Convert.ToDecimal(e.CommandArgument);

                    bd = new ProjectContext();

                    NOTA_FISCAL nfSelecionada = bd.NOTA_FISCAL.Where(nota => nota.ID == idNF).FirstOrDefault();

                    Session["CodNF"] = idNF;

                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "Detalhes", "location.href = 'PaginaNotaFiscal.aspx'", true);
                    break;
                case "Cancelar":
                   decimal idnota = Convert.ToDecimal(e.CommandArgument);
                    Session["CodNF"] = idnota;
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "RemoverProd", "location.href = 'PaginaDeRemocaoItem.aspx'", true);
                    break;
                default:
                    break;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"PaginaControleUsuario.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect(@"PaginaInicio.aspx");
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                string time = e.Row.Cells[3].Text;
                DateTime x1 = Convert.ToDateTime(time);
                DateTime x2 = DateTime.Now;

                TimeSpan tempo = x2 - x1;



                if (e.Row.Cells[4].Text == "Cancelada" || Convert.ToInt16(tempo.Days) > 3)
                {
                    if(e.Row.Cells[2].Text == "0")
                    {
                        e.Row.Cells[2].Text = "<center>" + "-" + "</center>";
                    
                    }
                    Button btnCancelar = (Button)e.Row.FindControl("Cancelar");
                    btnCancelar.Enabled = false;

                }
                else
                {
                    e.Row.Cells[2].Text = "<center>" + e.Row.Cells[2].Text + "</center>";
                }

            }
        }
    }
}