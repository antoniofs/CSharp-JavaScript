<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaginaDeRemocaoItem.aspx.cs" Inherits="ProjetoEcommerce.View.PaginaDeRemocaoItem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>


        <script type = "text/javascript">
            function Confirm() {
                var confirm_value = document.createElement("INPUT");
                confirm_value.type = "hidden";
                confirm_value.name = "confirm_value";
                if (confirm("Gostaria de Remover o produto ?")) {
                    confirm_value.value = "Yes";
                } else {
                    confirm_value.value = "No";
                }
                document.forms[0].appendChild(confirm_value);
            }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="Label2" runat="server" Font-Size="20pt" Text="Produtos da Nota:"></asp:Label>
        <br />
        
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:GridView ID="Grid" runat="server" AutoGenerateColumns ="false" Width="808px" Font-Size="16pt" OnRowCommand ="Grid_RowCommand" >
            <Columns>
				<asp:BoundField DataField = "id" HeaderText="id" Visible ="false" />
                <asp:BoundField DataField = "qtd" HeaderText ="Quantidade" />
                <asp:BoundField DataField = "nome" HeaderText ="Nome do Produto" />
                <asp:BoundField DataField = "valor_unit" HeaderText="Valor Unitario" DataFormatString = "{0:C2}" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID ="BtnVerDetalhes" runat ="server" OnClick ="BtnVerDetalhes_Click" OnClientClick="Confirm()" CommandName = "RemoverProduto" Text ="RemoverProduto" 
                                CommandArgument = '<%# Bind("id") %>' />
                        </ItemTemplate>

                    </asp:TemplateField>

            </Columns>


        </asp:GridView>
        <br />
        <br />
        <asp:Label ID="ValorTotal" runat="server" Text="Valor Total:  " Font-Size="20pt"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="20pt" Text="Detalhes da Nota Fiscal"></asp:Label>
        <br />
     
    
        <br />
        <br />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Voltar" PostBackUrl="~/View/PaginaNotaFiscal.aspx" />
        <br />
        
        <br />
        <br />
        
        <br />
        <br />
        <br />
    
    </div>
    </form>
    <p>
        &nbsp;</p>
</body>
</html>
