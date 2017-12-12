<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaginaCadastroProduto.aspx.cs" Inherits="ProjetoEcommerce.View.PaginaCadastroProduto" %>

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
&nbsp;<asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="15pt" Text="Nome: *"></asp:Label>
                <asp:TextBox ID="cxNome" runat="server" Height="22px" Width="446px" OnTextChanged="cxNome_TextChanged"></asp:TextBox>
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblCNome" runat="server" Text="*"></asp:Label>
        <br />
                <br />
                &nbsp;<asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="15pt" Text="Valor(Inteiro): *"></asp:Label>
                <asp:TextBox ID="CxValor" runat="server" TextMode="Number" Width="82px"></asp:TextBox>
                <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblCValor" runat="server" Text="*"></asp:Label>
                <br />
                <br />
                &nbsp; <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="15pt" Text="Categorias:  *"></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server" Width="162px">
                    <asp:ListItem Text ="Eletro Eletrônicos" Value ="1"></asp:ListItem>
                    <asp:ListItem Text ="Informática" Value ="2"></asp:ListItem>
                    <asp:ListItem Text ="Celulares e Smartphones" Value ="3"></asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
                <hr />
                <div style="height: 52px">
                    &nbsp;
                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="15pt" Text="Tem imagem ?"></asp:Label>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" Font-Size="15pt" Height="79px" Width="109px" AutoPostBack ="true">
                        <asp:ListItem Value="1">Sim</asp:ListItem>
                        <asp:ListItem Value="0">Não</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                &nbsp;<br />
                <br />
                <br />
                <br />
                <div id="divImagemSim" style="display:block; height: 64px;" runat="server">
                    
                    &nbsp;
                    
                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="15pt" Text="Inserir Imagem"></asp:Label>
                    <br />
                    <asp:FileUpload ID="FileUp" runat="server" Width="348px" />
                    
                </div>
                <br />
                <asp:Button ID="btnCadastrar" runat="server" OnClick="btnCadastrar_Click" Text="Cadastrar Produto" />
                <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Voltar" OnClick="Button1_Click" />
                <br />
                <br />
            </div>
        </div>
        <p>     
               <br />
                <br />
            </p>

    


    </div>  
  
  
<footer id="footer">  
    copyright @Antonio.Abtra  
</footer>  
    </form>
</body>  
</html>  
      
</body>  
</html>