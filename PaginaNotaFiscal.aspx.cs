using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoEcommerce.Models;

namespace ProjetoEcommerce.View
{
    public partial class PaginaNotaFiscal : System.Web.UI.Page
    {
        protected ProjectContext bd;
        protected int tamanhoDeItem = 1;
        protected int id = 0;
        protected decimal valoresTotal = 0;
        protected Boolean temIntem = false;
        DataTable dt;
        DataTable dtcancelados;
        protected void Page_Load(object sender, EventArgs e)
        {
            popularGrid();
            popularGridCancelados();
            

        }
        #region PopularGrid
        private void popularGrid()
        {
            try
            {
                bd = new ProjectContext();
                dt = new DataTable();

                decimal id = Convert.ToDecimal(Session["Id"]);
                decimal codigoNF = Convert.ToDecimal(Session["CodNF"]);

                List<ITEM_NF> ListadeProdutos = new List<ITEM_NF>();
                ListadeProdutos = bd.ITEM_NF.ToList();

                dt.Columns.Add("qtd");
                dt.Columns.Add("nome");
                dt.Columns.Add("VALOR_UNIT");

                var info = from nf in bd.NOTA_FISCAL

                           join c in bd.CLIENTEs
                           on nf.ID_CLIENTE equals c.ID

                           where c.ID == id && nf.ID == codigoNF

                           select new
                           {
                               c.NOME,
                               c.ENDERECO,
                               c.CEP,
                               c.BAIRRO,
                               c.CIDADE,
                               c.UF,
                               c.TELEFONE,
                               c.USUARIO,
                               nf.CD_NOTA,
                               nf.DATACRIACAO

                           };

                DetailsView1.DataSource = info.ToList();
                DetailsView1.DataBind();
       
                foreach(ITEM_NF nota in ListadeProdutos)
                {
                    if(codigoNF == nota.ID_NF)
                    {
                        PRODUTO produto = bd.PRODUTOes.Where(p => p.ID == nota.ID_PRODUTO).FirstOrDefault();

                        int total = (from valor in bd.ITEM_NF
                                     where valor.ID_NF == nota.ID_NF && valor.ID_PRODUTO == produto.ID && valor.ST_ITEM == 1
                                     select valor).Count();

                        if(id != produto.ID && nota.ST_ITEM == 1)
                        {
                            id = produto.ID;
                           dt.Rows.Add(total, produto.NOME, produto.VALOR_UNIT);
                           valoresTotal = valoresTotal + (total * produto.VALOR_UNIT); 
                        }
                    }
                }

                if(valoresTotal == 0)
                {
                    Label2.Text = "";
                    Valor.Visible = false;
                    Label4.Visible = false;
                  
                }
                else
                {
                    Label2.Text = "R$ " + valoresTotal.ToString() + ",00";
                }

                
               
                
                GridView1.DataSource = dt;
                GridView1.DataBind();

                
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        #endregion 

        #region PopularGridProdutosCancelados
        private void popularGridCancelados()
        {
            try
            {
                bd = new ProjectContext();
                dtcancelados = new DataTable();

                decimal id = Convert.ToDecimal(Session["Id"]);
                decimal codigoNF = Convert.ToDecimal(Session["CodNF"]);

                List<ITEM_NF> ListadeProdutos = new List<ITEM_NF>();
                ListadeProdutos = bd.ITEM_NF.ToList();

                dtcancelados.Columns.Add("qtd");
                dtcancelados.Columns.Add("nome");
                dtcancelados.Columns.Add("VALOR_UNIT");

                foreach (ITEM_NF nota in ListadeProdutos)
                {
                    if (codigoNF == nota.ID_NF)
                    {
                        PRODUTO produto = bd.PRODUTOes.Where(p => p.ID == nota.ID_PRODUTO).FirstOrDefault();

                        int total = (from valor in bd.ITEM_NF
                                     where valor.ID_NF == nota.ID_NF && valor.ID_PRODUTO == produto.ID && valor.ST_ITEM == 0
                                     select valor).Count();

                        if (id != produto.ID && nota.ST_ITEM == 0)
                        {
                            id = produto.ID;
                            dtcancelados.Rows.Add(total, produto.NOME, produto.VALOR_UNIT);
                            valoresTotal = valoresTotal + (total * produto.VALOR_UNIT);
                            temIntem = true;
                        }
                    }
                }

                
                if(temIntem == true)
                {
                    Label3.Visible = true;
                    GridView2.DataSource = dtcancelados;
                    GridView2.DataBind();
                
                }

               


            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion 

    }
}