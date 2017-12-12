<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaginaCompras.aspx.cs" Inherits="ProjetoEcommerce.View.PaginaCompras" %>

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
    
    </div>
        <asp:TextBox ID="txtsearch" runat="server" Width="387px"></asp:TextBox>
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged ="DropDownList1_SelectedIndexChanged1"  Height ="28px" Width="155px"> 
            <asp:ListItem Text ="Eletro Eletrônicos" Value ="1"></asp:ListItem>
            <asp:ListItem Text ="Informática" Value ="2"></asp:ListItem>
            <asp:ListItem Text ="Celulares e Smartphones" Value ="3"></asp:ListItem>
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Pesquisar" runat="server" OnClick="Pesquisar_Click" style="margin-left: 0px" Text="Pesquisar" />
        <br />
        <br />



        <asp:GridView ID="GridProdutos" runat="server" AutoGenerateColumns ="false" AllowPaging="true" OnPageIndexChanging ="GridProdutos_PageIndexChanging" OnRowCommand ="GridProdutos_RowCommand">
            <columns>
                <asp:BoundField DataField ="id" HeaderText="Index" />
                <asp:BoundField DataField ="nome" HeaderText="Nome do Produto" />
                <asp:BoundField DataField ="valor_unit" DataFormatString="{0:c}" HeaderText="Valor Unitario" />
                <asp:TemplateField>
                    <ItemTemplate>
                         <asp:Image ID="Image1" runat="server" Width="100" Height="100" ImageUrl='<%# Bind("imagem1") %>' />
                        <asp:Button ID ="btnAdiciona" runat="server" CommandName="AddItem" Text="Add Carrinho" CommandArgument='<%# Bind("id") %>'/>
                    </ItemTemplate>
                </asp:TemplateField>

            </columns>
        </asp:GridView>



        <br />
        <asp:Button ID="btnCarrinho" runat="server" OnClick="btnCarrinho_Click" Text="Carrinho de Compras" />
        <br />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Voltar" />
        <asp:Button ID="btnOut" runat="server" Text="Sair" OnClick="btnOut_Click" />
        <br />

    


    </div>  
  
  
    </form>
</body>  
</html>  
   
</body>  
</html>