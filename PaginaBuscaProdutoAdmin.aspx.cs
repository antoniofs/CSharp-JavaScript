using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoEcommerce.Models;

namespace ProjetoEcommerce.View
{
    public partial class PaginaBuscaProdutoAdmin : System.Web.UI.Page
    {
        #region Delcarações de Variaveis
        ProjectContext bd;
        #endregion

        //Page Load da pagina
        #region Page Load da página
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fazerBuildDoGrind();
            }
        }
        #endregion

        //Evento do Gridview de Produtos, faz a paginação
        #region Evento para mudar a index do gridview
        protected void gdvProdutos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gdvProdutos.PageIndex = e.NewPageIndex;

            //Fazer o build do grind view
            fazerBuildDoGrind();
        }
        #endregion

        #region Fazer a criação do grid
        private void fazerBuildDoGrind()
        {
            bd = new ProjectContext();
            List<PRODUTO> produtos = bd.PRODUTOes.ToList();

            gdvProdutos.DataSource = produtos;
            gdvProdutos.DataBind();

        }
        #endregion

        //Metódo para fazer a busca no grindview, retorna o produto e a categoria escolhida pelo usuario
        #region Metódo para fazer a busca no grindview, retorna o produto e a categoria escolhida pelo usuario
        private void FazerBusca()
        {
            if (txtPesquisar.Text == string.Empty)
            {

            }
            else
            {
                bd = new ProjectContext();
                string aux = txtPesquisar.Text;

                var produto = from Produto in bd.PRODUTOes
                              where Produto.NOME.Contains(aux)
                              select Produto;

                gdvProdutos.DataSource = produto.ToList();
                gdvProdutos.DataBind();

                if (produto.Count() == 0)
                {
                    BtnNovo.Enabled = true;
                    lblDisponibilidade.Text = "Produto inexistente, click para adicionar";
                }
                else
                {
                    lblDisponibilidade.Text = "Botão disponivel após a pesquisa";
                    BtnNovo.Enabled = false;
                }
            }
        }
        #endregion

        #region Botão que faz a busca
        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            FazerBusca();
        }
        #endregion

        #region Botao Click
        protected void BtnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"PaginaCadastroProduto.aspx");
        }
        #endregion

        //Botão de saída
        #region Botao de saida
        protected void btnSair_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect(@"PaginaInicio.aspx");
        }
        #endregion

    }
}