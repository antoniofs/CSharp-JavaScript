<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaginaBuscaProdutoAdmin.aspx.cs" Inherits="ProjetoEcommerce.View.PaginaBuscaProdutoAdmin" %>

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
<aside id="side">  
</aside>  
  
  
    <div id="con">  

         <asp:Label ID="lblnome" runat="server" Text="Nome: 
            "></asp:Label>
        <asp:TextBox ID="txtPesquisar" runat="server" Width="305px"></asp:TextBox>
    
        <asp:Button ID="BtnBuscar" runat="server" Text="   Buscar   " OnClick="BtnBuscar_Click" />
    
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BtnNovo" runat="server" Text="  novo   " Enabled="False" OnClick="BtnNovo_Click" Width="93px" />
        <asp:Label ID="lblDisponibilidade" runat="server" Text="Disponivel após a pesquisa"></asp:Label>
        <br />
        <br />
        <br />
        <br />
        <asp:GridView ID="gdvProdutos" runat="server" AutoGenerateColumns ="false" AllowPaging ="true" OnPageIndexChanging ="gdvProdutos_PageIndexChanging">
            <Columns>
                <asp:BoundField DataField ="Nome" HeaderText ="Nome do Produto" />
                <asp:BoundField DataField ="valor_unit" DataFormatString="{0:c}" HeaderText ="Valor Unitario" />
            </Columns>
        </asp:GridView>
         <br />
         <asp:Button ID="btnSair" runat="server" Text="sair" />
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