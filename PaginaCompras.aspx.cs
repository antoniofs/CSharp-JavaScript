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
    public partial class PaginaCompras : System.Web.UI.Page
    {
        protected int id;
        protected DataTable dt = new DataTable();
        protected Boolean IsPageRefresh;
        protected ProjectContext bd;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.IsPostBack == false)
            {
                ViewState["estado"] = System.Guid.NewGuid().ToString();
                Session["estado"] = ViewState["estado"].ToString();
                Session["carrinhoDeCompras"] = new List<PRODUTO>();
                CarregarProdutos();
            
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
        }
        #region CarregarProdutos
        private void CarregarProdutos()
        {
            try
            {
                dt.Columns.Add("id");
                dt.Columns.Add("nome");
                dt.Columns.Add("valor_unit");
                dt.Columns.Add("imagem1");

                bd = new ProjectContext();
                List<PRODUTO> produtos = bd.PRODUTOes.ToList();
                List<IMG_PRODUTO> imagem = bd.IMG_PRODUTO.ToList();

                foreach (PRODUTO pr in produtos)
                {
                    IMG_PRODUTO im = bd.IMG_PRODUTO.Find(pr.ID_IMAGEM);

                    if (im != null && pr.ID_IMAGEM != 0)
                    {
                        byte[] byteImagem = im.IMAGEM;
                        string imagConvert = Convert.ToBase64String(byteImagem);
                        string imagemDataUrl = String.Format("data:imagem/png;base64, {0}", imagConvert);

                        dt.Rows.Add(pr.ID, pr.NOME, pr.VALOR_UNIT, imagemDataUrl);
                    }
                }

                GridProdutos.DataSource = dt;
                GridProdutos.DataBind();

                
            }
            catch (Exception)
            {
                
                throw;
            }finally
            {
                bd.Dispose();
            }
            

        }
        #endregion


        protected void GridProdutos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if(IsPageRefresh != true)
                {
                    switch(e.CommandName)
                    {
                        case "AddItem":

                            decimal idProduto = Convert.ToDecimal(e.CommandArgument);

                            bd = new ProjectContext();

                            PRODUTO itemSelecionado = bd.PRODUTOes.Where(prod => prod.ID == idProduto).FirstOrDefault();

                            List<PRODUTO> carrinho = (List<PRODUTO>)Session["carrinhoDeCompras"];

                            carrinho.Add(itemSelecionado);

                            Session["carrinhoDeCompras"] = carrinho;

                            break;
                        default:
                            break;
                    }
                }


            }
            catch (Exception)
            {
                
                throw;
            }
            IsPageRefresh = false;
        }

        #region dropDown
        private void dropDown()
        {
            bd = new ProjectContext();

            List<CATEGORIA_PRODUTO> categoria = new List<CATEGORIA_PRODUTO>();

            categoria = bd.CATEGORIA_PRODUTO.ToList();

            DropDownList1.DataSource = categoria;
            DropDownList1.DataValueField = "ID";
            DropDownList1.DataBind();
        }
        #endregion

        protected void GridProdutos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridProdutos.PageIndex = e.NewPageIndex;

            CarregarProdutos();
        }

        protected void btnCarrinho_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"PaginaCarrinho.aspx");
        }
        #region PesquisarDropDown
        private void Pesquisa()
        {
            bd = new ProjectContext();
            string teste = DropDownList1.SelectedItem.ToString();
            decimal categoria = Convert.ToDecimal(DropDownList1.SelectedValue);

            String pesquisar = txtsearch.Text;

            dt.Columns.Add("id");
            dt.Columns.Add("nome");
            dt.Columns.Add("valor_unit");
            dt.Columns.Add("imagem1");

            var produto = from pr in bd.PRODUTOes

                          where pr.NOME.Contains(pesquisar) && pr.ID_CATEGORIA_PROD == categoria

                          join cate in bd.CATEGORIA_PRODUTO
                          on pr.ID_CATEGORIA_PROD equals cate.ID

                          join img in bd.IMG_PRODUTO
                          on pr.ID_IMAGEM equals img.ID

                          select new
                          {
                              pr.ID,
                              pr.NOME,
                              pr.VALOR_UNIT,
                              img.IMAGEM
                          };

            foreach (var pr in produto)
            {
                byte[] byteImagem = pr.IMAGEM;
                string img64Frente = Convert.ToBase64String(byteImagem);
                string imagemDataUrl = String.Format("data:image/png;base64, {0}", img64Frente);
                dt.Rows.Add(pr.ID, pr.NOME, pr.VALOR_UNIT, imagemDataUrl);
            }

            GridProdutos.DataSource = dt;
            GridProdutos.DataBind();

        }
        #endregion

        protected void Pesquisar_Click(object sender, EventArgs e)
        {
            Pesquisa();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void btnOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect(@"PaginaInicio.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"PaginaControleUsuario.aspx");
        }
    }
}