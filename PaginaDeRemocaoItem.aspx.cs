using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoEcommerce.Models;
using System.Data;
using ControleMessageBox;

namespace ProjetoEcommerce.View
{
    public partial class PaginaDeRemocaoItem : System.Web.UI.Page
    {
        protected ProjectContext bd;
        protected MessageBox ms;
        protected DataTable dt;
        protected DataTable dtInativos;
        protected decimal valorTotal = 0;
        protected bool possoRemover = false;
        protected decimal idProdutoRemover = 0;
        protected int total = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
              if(!Page.IsPostBack)
              {
                  popularGrid();
              }
                
        }

        protected void Grid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch(e.CommandName)
            {
                case "RemoverProduto":
                    decimal valorID = Convert.ToDecimal(e.CommandArgument);
                    bd = new ProjectContext();
                    decimal id = Convert.ToDecimal(Session["Id"]);
                    decimal codigoNF = Convert.ToDecimal(Session["CodNF"]);
                    Session["produto"] = valorID;
                    removerProduto();
                    Response.Redirect("PaginaDeRemocaoItem.aspx");
                    break;
                default:
                    break;

            }
        }

        #region PopularGridDeProdutos
        private void popularGrid()
        {
            try
            {
                bd = new ProjectContext();
                dt = new DataTable();
                dtInativos = new DataTable();

                decimal id = Convert.ToDecimal(Session["Id"]);
                decimal codigoNF = Convert.ToDecimal(Session["CodNF"]);

                List<ITEM_NF> ListadeProdutos = new List<ITEM_NF>();
                ListadeProdutos = bd.ITEM_NF.ToList();

                dt.Columns.Add("id");
                dt.Columns.Add("qtd");
                dt.Columns.Add("nome");
                dt.Columns.Add("VALOR_UNIT");
                #region Ativos
                foreach (ITEM_NF nota in ListadeProdutos)
                {
                    if (nota.ID_NF == codigoNF && nota.ST_ITEM == 1)
                    {
                        PRODUTO produto = bd.PRODUTOes.Where(p => p.ID == nota.ID_PRODUTO).FirstOrDefault();

                         total = (from valor in bd.ITEM_NF
                                     where valor.ID_NF == nota.ID_NF && valor.ID_PRODUTO == produto.ID && valor.ST_ITEM == 1
                                     select valor).Count();

                        if(id != produto.ID)
                        {
                            id = produto.ID;
                                dt.Rows.Add(produto.ID, total, produto.NOME, produto.VALOR_UNIT);
                                valorTotal = valorTotal + (total * produto.VALOR_UNIT); 
                        }
                    }
                }
                #endregion

                if (total == 0)
                {
                    Response.Redirect(@"PaginaCarrinho.aspx");
                }
                
                Label1.Text = "R$ " + valorTotal.ToString() + ",00";
                
                
                Grid.DataSource = dt;
                Grid.DataBind();

                
                
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        #endregion


        private void removerProduto()
        {
            if (possoRemover == true)
            {

            
                bd = new ProjectContext();
                List<ITEM_NF> ListadeProdutos = new List<ITEM_NF>();

                //ListadeProdutos = bd.ITEM_NF.ToList();
 
                decimal prod = Convert.ToDecimal(Session["produto"]);
                decimal notaFiscal = Convert.ToDecimal(Session["CodNF"]);
                ListadeProdutos = bd.ITEM_NF.Where(inf => inf.ID_NF == notaFiscal && inf.ID_PRODUTO == prod).ToList();
                try
                {
                    if(prod != 0)
                    {
                    
                        foreach(ITEM_NF lista in ListadeProdutos)
                        {
                            if(lista.ID_NF == notaFiscal && lista.ID_PRODUTO == prod)
                            {
                                if(lista.ST_ITEM != 0)
                                {

                                    lista.ST_ITEM = 0;
                                    bd.SaveChanges();
                                    bd.Dispose();
                                    break;
                                }
                              }
                            }

                        }
                    }
                catch (Exception)
                {
                
                    throw;
                }
            }
            else
            {

            }
        }

        protected void BtnVerDetalhes_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                possoRemover = true;
            }
            else
            {
                possoRemover = false;
            }

        }
    }
}