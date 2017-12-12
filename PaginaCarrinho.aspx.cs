using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoEcommerce.Models;

namespace ProjetoEcommerce.View
{
    public partial class PaginaCarrinho : System.Web.UI.Page
    {
        ProjectContext bd;
        protected decimal idProd = 0;
        protected bool IsPageRefresh;
        public static double valorTotal = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                ViewState["estado"] = System.Guid.NewGuid().ToString();
                Session["estado"] = ViewState["estado"].ToString();
                GridView1.DataSource = (List<PRODUTO>)Session["carrinhoDeCompras"];
                recuperarValor();
                GridView1.DataBind();
            }
            else
            {
                if(ViewState["estado"].ToString() != Session["estado"].ToString())
                {
                    IsPageRefresh = true;  
                }
                Session["estado"] = System.Guid.NewGuid().ToString();
                ViewState["estado"] = Session["estado"].ToString();
            }
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
        }
        #region recuperarValor
        private void recuperarValor()
        {
            List<PRODUTO> carrinho = (List<PRODUTO>)Session["carrinhoDeCompras"];

            valorTotal = 0;
            if(carrinho != null)
            {

            
            foreach (PRODUTO produto in carrinho)
            {
                valorTotal += Convert.ToDouble(produto.VALOR_UNIT);
                if (carrinho.Count() == 0)
                {
                    valorTotal = 0;
                }
            }

            txtValorTotal.Text = "Valor Total da Compra: " + "R$ " + Convert.ToDouble(valorTotal).ToString();
            }
            else
            {
                Response.Redirect(@"PaginaComprasNotas.aspx");
            }
        }
        #endregion
        #region InserirNota
        private void InserirNotaFiscal()
        {
            try
            {
                bd = new ProjectContext();

                NOTA_FISCAL notaFiscal = new NOTA_FISCAL();
                

                int idUsuario = Convert.ToInt16(Session["id"]);

                if(valorTotal != 0)
                {
                    notaFiscal.ID_CLIENTE = Convert.ToInt32(idUsuario);
                    notaFiscal.CD_NOTA = Convert.ToInt32((bd.NOTA_FISCAL.Count() + 1) * 100);
                    notaFiscal.DATACRIACAO = DateTime.Now;
                    bd.NOTA_FISCAL.Add(notaFiscal);
                    bd.SaveChanges();

                    decimal n = bd.NOTA_FISCAL.Count();

                    NOTA_FISCAL notinha = bd.NOTA_FISCAL.Where(nf => nf.ID == notaFiscal.ID).FirstOrDefault();

                    List<PRODUTO> listaDeProdutos = (List<PRODUTO>)Session["carrinhoDeCompras"];

                    foreach(PRODUTO prod in listaDeProdutos)
                    {
                        PRODUTO produto = bd.PRODUTOes.Where(p => p.ID == prod.ID).FirstOrDefault();

                        ITEM_NF ItemNota = new ITEM_NF();

                        ItemNota.ID_NF = notinha.ID;
                        ItemNota.VALOR_UNIT = produto.VALOR_UNIT;
                        ItemNota.ID_PRODUTO = produto.ID;
                        ItemNota.ST_ITEM = 1;


                        //ItemNota.ID_NF = 1;
                        //ItemNota.ID_PRODUTO = 1;

                        bd.ITEM_NF.Add(ItemNota);

                        //bd.ITEM_NF.Add(ItemNota);
                    }

                    //bd.NOTA_FISCAL.Add(notaFiscal);

                    bd.SaveChanges();

                    bd.Dispose();

                    Response.Redirect(@"PaginaControleUsuario.aspx");


                }


            }
            catch (Exception)
            {
                
                throw;
            }


        }

        #endregion

        protected void btnfinal_Click(object sender, EventArgs e)
        {
            InserirNotaFiscal();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (IsPageRefresh != true)
                {
                    switch (e.CommandName)
                    {
                        case "removeItem":
                            decimal idProduto = Convert.ToDecimal(e.CommandArgument);


                            List<PRODUTO> carrinho = (List<PRODUTO>)Session["carrinhoDeCompras"];

                            foreach (PRODUTO c in carrinho)
                            {
                                if (c.ID == idProduto)
                                {
                                    carrinho.Remove(c);
                                    break;
                                }

                            }
                            Session["carrinhoDeCompras"] = carrinho;

                            GridView1.DataSource = (List<PRODUTO>)Session["carrinhoDeCompras"];
                            recuperarValor();
                            GridView1.DataBind();
                            break;
                        default:
                            break;

                    }
                }
                else
                {
                    GridView1.DataSource = (List<PRODUTO>)Session["carrinhoDeCompras"];
                    recuperarValor();
                    GridView1.DataBind();

                }
            }
            catch (Exception)
            {
                
                throw;
            }
            IsPageRefresh = false;
        }

        protected void BtnVoltar_Click(object sender, EventArgs e)
        {
       
            Response.Redirect(@"PaginaCompras.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect(@"PaginaInicio.aspx");
        }

        protected List<PRODUTO> ordenarProdutos()
        {
            List<PRODUTO> listProduto = (List<PRODUTO>)Session["carrinhoDeCompras"];

            listProduto.Sort((x, y) => string.Compare(x.NOME, y.NOME));


            return listProduto;
        }

        private int quantidade(List<PRODUTO> listProduto, string nomeBusca)
        {
            int quant = 0;
            foreach (PRODUTO pr in listProduto)
            {
                if(pr.NOME == nomeBusca)
                {
                    quant += 1;
                }
            }
            return quant;
        }

    }
}