<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaginaInicio.aspx.cs" Inherits="ProjetoEcommerce.View.PaginaInicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">  
<head runat="server">  
    <title>Lojinha</title>  
     <link rel="stylesheet" type="text/css" href="Estilo.css"/>
          <script>

              function myFunction(elemento) {
                  if (elemento.value == "") {
                      alert('Preencha o campo Login!');
                      return false;
                  }
                  return true;
              }

              function loginClick(elemento) {
                  if (elemento.value == "") {
                      alert('Preencha o campos senha');
                      return false;
                  }
                  return true;
              }
    </script> 
</head>  
<body>  
    <!DOCTYPE html>  
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
        <asp:Label ID="lblMensagem" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Bauhaus 93" Font-Size="20pt" Text="OLÁ  CARO USUARIO, BEM VINDO O LOJA"></asp:Label>
        <br />
        <asp:Label ID="lblLogin" runat="server" Font-Names="Arial" Font-Size="15pt" Text="Para fazer login utilize os campos abaixo:"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblUsuario" runat="server" Font-Names="Arial" Font-Size="18pt" Text="Usuario: "></asp:Label>
        <asp:TextBox ID="txtUsuario" runat="server" Width="231px"></asp:TextBox>
        <br />
        <asp:Label ID="lblSenha" runat="server" Font-Names="Arial" Font-Size="18pt" Text="Senha: "></asp:Label>
        <asp:TextBox ID="txtSenha" runat="server" style="margin-left: 15px" TextMode="Password" Width="230px"></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BtnLogin" runat="server" BackColor="#666666" Font-Bold="True" Font-Names="Arial" style="margin-left: 0px" Text="Login" Width="67px" OnClick="BtnLogin_Click" />
        <br />
        <br />
        <br />
        <asp:Label ID="txtCadastro" runat="server" Font-Names="Arial" Font-Size="15pt" Text="Click para efetuar seu cadastro:"></asp:Label>
        <br />
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Image/cadastro-i9-life-i9life-santa-catarina-inove-life.png" Width="463px" PostBackUrl="~/View/PaginaCadastro.aspx" />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />

    </div>  
  
   </form> 
<footer id="footer">  
    copyright @Antonio.Abtra  
</footer>  
</body>  
</html>  
      
    