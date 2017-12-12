using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoEcommerce.Models;

namespace ProjetoEcommerce.View
{
    public partial class PaginaCadastroProduto : System.Web.UI.Page
    {
        //Declarãções de variaveis
        #region Declarações de Variaveis
        protected Boolean IsUpdate = false;
        protected ProjectContext bd;

        #endregion

        //Page load da pagina 
        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {

            string RecuperarValor = RadioButtonList1.SelectedValue;

            if (RecuperarValor == "1")
            {
                this.divImagemSim.Attributes.Add("style", "display:block");
            }
            else
            {
                this.divImagemSim.Attributes.Add("style", "display:none");
            }
        }

        #endregion

        //Evento / Metódo para cadastrar produto se e somente se não tiver ele no banco de dados
        #region Botão Cadastrar

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            validarProdutos();
            if(IsUpdate != false)
            { 
                bd = new ProjectContext();
                decimal categoria = DropDownList1.SelectedIndex;

                String nome = cxNome.Text;
                String valor = CxValor.Text;
                IMG_PRODUTO img = new IMG_PRODUTO();
                PRODUTO pr = new PRODUTO();

                pr.NOME = nome;
                pr.VALOR_UNIT = Convert.ToDecimal(valor);
                pr.ID_CATEGORIA_PROD = categoria;
                pr.DATAALTERACAO = DateTime.Now;
                pr.DATACRIACAO = DateTime.Now;
                int TotalID = bd.PRODUTOes.Count() + 1;
                pr.ID = TotalID;
                int TotalImg = bd.IMG_PRODUTO.Count() + 1;
                pr.ID_IMAGEM = TotalImg;
                string RecuperarValor = RadioButtonList1.SelectedValue;

                bd.PRODUTOes.Add(pr);


                if (RecuperarValor == "1")
                {
                    if (FileUp.HasFile)
                    {
                        img.IMAGEM = FileUp.FileBytes;
                        img.DESCRICAO = cxNome.Text;
                        img.ID = TotalImg;
                        bd.IMG_PRODUTO.Add(img);


                    }
                }
                else
                {
                    img.ID = 12;
                }
                bd.SaveChanges();
                //  bd.Dispose();
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "mudarpage", "location.href = 'PaginaCompras.aspx'", true);
                //Response.Redirect("WebForm1.aspx");
            }
        }

        #endregion

        //Metódo para validar se existe um produto no banco de dados ou não
        #region Validar Produtos

        private void validarProdutos()
        {
            bd = new ProjectContext();
            string aux = cxNome.Text;

            var produto = from Produto in bd.PRODUTOes
                          where Produto.NOME.Contains(aux)
                          select Produto;

            if (produto.Count() > 1)
            {
                lblCNome.Text = "Esse produto Já existe, colocar outro";
            }
            else if(aux == string.Empty)
            {
                lblCNome.Text = "Campo Obrigatorio";
            }

            if (CxValor.Text == string.Empty || CxValor.Text == "0")
            {
                lblCValor.Text = "Valor em branco";
            }

            if(CxValor.Text != string.Empty &&
                CxValor.Text != "0" &&
                produto.Count() == 0 &&
                aux != string.Empty)
            {
                IsUpdate = true;
            }
        }

        #endregion

        //Evento para redirecionar para a pagina principal do usuario
        #region Evento de Click
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"PaginaControleUsuario.aspx");
        }
        #endregion

    }
}