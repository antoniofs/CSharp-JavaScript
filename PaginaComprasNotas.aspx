<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaginaComprasNotas.aspx.cs" Inherits="ProjetoEcommerce.View.PaginaComprasNotas" %>

<!DOCTYPE html>

<html>  
<head>  
    <title>my layout</title>  
    <link rel="stylesheet" type="text/css" href="Estilo.css">  
</head>  
<body>  
    <form id="form1" runat="server">
<header id="header">  
<h1>LOJINHA DO ANTONIO</h1>  
</header>  
<nav id="nav">  
    <ul>  
        <li><a href="PaginaInicio.aspx">Inicio</a></li>  
        <li><a href="PaginaCadastro.aspx">Cadastro</a></li>   
        <li><a href="PaginaSobre.aspx">Sobre</a></li>  
    </ul>  
</nav>  
  
  
    <div id="con">  



              <h1><asp:Label ID="Label1" runat="server" Text="Compras Efetuadas"></asp:Label></h1>
        <p>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns ="false" OnRowCommand ="GridView1_RowCommand" OnRowDataBound ="GridView1_RowDataBound"> 
                <Columns>
                    <asp:BoundField DataField = "id" HeaderText="id" Visible ="false" />
                    <asp:BoundField DataField = "CD_NOTA" HeaderText="CÓDIGO DA NOTA" />
                    <asp:BoundField DataField = "qtd" HeaderText="VALOR TOTAL" />
                    <asp:BoundField DataField = "DATAHORA" HeaderText="DATA DA COMPRA" />
                    <asp:BoundField DataField = "status" HeaderText="" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID ="BtnVerDetalhes" runat ="server" CommandName = "VerDetalhes" Text ="Ver Detalhes" 
                                CommandArgument = '<%# Bind("id") %>' />
                            <asp:Button ID ="Cancelar" runat ="server" CommandName = "Cancelar" Text ="Cancelar" 
                                CommandArgument = '<%# Bind("id") %>' />
                        </ItemTemplate>

                    </asp:TemplateField>


                </Columns>

            </asp:GridView>
        </p>
        <p>&nbsp;</p>
              <p>
                  <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Voltar" />
                  <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Sair" />
              </p>
        <p>&nbsp;</p>


      

     


    </div>  
  
  
<footer id="footer">  
    copyright @Antonio.Abtra  
</footer>  
    </form>
</body>  
</html>  
      
    </form>  
</body>  
</html>