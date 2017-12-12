<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaginaCarrinho.aspx.cs" Inherits="ProjetoEcommerce.View.PaginaCarrinho" %>

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

                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns ="false" OnRowCommand ="GridView1_RowCommand">
            <Columns>
                <asp:BoundField DataField ="id" HeaderText="Codigo" />
                <asp:BoundField DataField ="nome" HeaderText ="Nome do Produto" />
                <asp:BoundField DataField ="valor_unit" DataFormatString="{0:c}" HeaderText ="Preço do Produto" />
                <asp:TemplateField>
                     <ItemTemplate>
                         <asp:Button ID ="btnRemover" runat="server" CommandName="removeItem" Text="Remover do Carrinho" CommandArgument='<%# Bind("id") %>' />
                     </ItemTemplate>

                </asp:TemplateField>

            </Columns>
        </asp:GridView>

        <asp:Label ID="txtValorTotal" runat="server" Font-Size="20pt"></asp:Label>

        <br />
        <br />
        <br />
        <br />
        <asp:Button ID="btnfinal" runat="server" OnClick="btnfinal_Click" Text="Finalizar Compra" />
                <br />
                <br />
                <br />
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Sair" />
        <br />

    


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