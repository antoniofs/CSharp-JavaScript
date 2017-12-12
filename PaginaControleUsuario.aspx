<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaginaControleUsuario.aspx.cs" Inherits="ProjetoEcommerce.View.PaginaControleUsuario" %>

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



     


        <br />
        <br />
        <asp:Label ID="lblmsg" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="35pt"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Button ID="btnNotas" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="15pt" Height="73px" PostBackUrl="~/View/PaginaComprasNotas.aspx" Text="Minhas Notas Fiscais" Width="231px" />
        <br />
        <br />
        <asp:Button ID="btnCompras" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="15pt" Height="73px" Text="Realizar Compras" Width="231px" OnClick="btnCompras_Click" />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Font-Names="Arial" Font-Size="15pt" Text="Caro Admin, para adicionar produto"></asp:Label>
        <asp:HyperLink ID="HyperLink1" runat="server" Font-Names="Arial" Font-Size="15pt" NavigateUrl="~/View/PaginaBuscaProdutoAdmin.aspx" Target="_blank">Click Aqui</asp:HyperLink>
        <br />
        <br />
        <br />
        <asp:Button ID="btnSair" runat="server" OnClick="btnSair_Click" Text="Sair" />
        <br />
        <br />
        <br />
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