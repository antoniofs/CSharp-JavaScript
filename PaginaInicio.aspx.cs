using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoEcommerce.Models;


namespace ProjetoEcommerce.View
{
    public partial class PaginaInicio : System.Web.UI.Page
    {
        #region Declarações de Variaveis
        ProjectContext bd;
        //public const string postEventArgumentID = "__EVENTARGUMENT2";
        #endregion

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.BtnLogin.Attributes.Add("onclick", "return preenchimento();");
            this.txtUsuario.Attributes.Add("onblur", " return myFunction(txtUsuario);");
            this.BtnLogin.Attributes.Add("onclick", "return loginClick(txtSenha);");

            //CarregaTeste teste = new Models.CarregaTeste("sdfjflsdjklfjasdkl");

            //Response.Write(teste.carrega());



        }
        #endregion

        #region Login
        protected void BtnLogin_Click(object sender, EventArgs e)
        {
           
            bd = new ProjectContext();
            try
            {

            
                if(txtUsuario.Text == String.Empty || txtSenha.Text == String.Empty)
                {
                    //Não Faz Nada
                }
                else //Senão
                {
                    //Procura no banco de dados cliente
                    ADMIN_USERS adminUser = (from admin in bd.ADMIN_USERS
                                             where admin.USER_LOGIN == txtUsuario.Text &&
                                                   admin.SENHA_LOGIN == txtSenha.Text
                                             select admin).FirstOrDefault();
                    //Se não encontrou nenhum usuario parecido, então sai fora nesse if
                    if(adminUser != null)
                    {
                        //ClientScript.RegisterClientScriptBlock(Page.GetType(), "userLogin", "alert('BEM VINDO ADMIN')", true);
                        string nomeAdmin = adminUser.NOME;
                        string idAdmin = adminUser.ID.ToString();
                        SalvarDados(nomeAdmin, idAdmin);
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "paginaLogin", "location.href = 'PaginaControleUsuario.aspx'", true);
                    }
                    else
                    {
                        //Criando o objeto cliente
                        CLIENTE cliente = new CLIENTE();

                        cliente = (from client in bd.CLIENTEs
                                   where client.USUARIO == txtUsuario.Text
                                      && client.SENHA == txtSenha.Text
                                   select client).FirstOrDefault();
                        if(cliente != null)
                        {
                            //ClientScript.RegisterClientScriptBlock(Page.GetType(), "clienteLogin", "alert('Bem vindo caro cliente')", true);
                            SalvarDados(cliente.NOME, cliente.ID.ToString());
                            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "paginaLogin", "location.href = 'PaginaControleUsuario.aspx'", true);
                            //Response.Redirect(@"PaginaControleUsuario.aspx");
                           
                        }
                        else
                        {
                            ClientScript.RegisterClientScriptBlock(Page.GetType(), "Erro441", "alert('Desculpa, Usuario não encontrado')", true);
                        }
                        
                    }

                }

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        #endregion

        #region SalvarDados
        private void SalvarDados(string nome, string id)
        {
            try
            {
                if(nome != String.Empty)
                {
                    Session["Salvar"] = nome;
                    Session["Id"] = id;
                if (nome == "Testelino Administrador Loja" && id == "1")
                {
                    Session["Admin"] = "ok";
                }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}