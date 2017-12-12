<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaginaNotaFiscal.aspx.cs" Inherits="ProjetoEcommerce.View.PaginaNotaFiscal" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 402px">

    <form id="form1" runat="server">
        
        &nbsp;<asp:Label ID="Label1" runat="server" Text="Detalhes da Nota Fiscal" Font-Bold="True" Font-Italic="True" Font-Size="20pt"></asp:Label>
        
        <br />
        <br />
        
        <br /><asp:DetailsView ID="DetailsView1" GridLines ="None" runat="server" Height="100px" Width="800px" AutoGenerateRows ="false" Font-Size="20pt" style="margin-top: 0px" >
        <Fields>
            <asp:BoundField DataField ="nome" HeaderText = "Nome" />
            <asp:BoundField DataField = "endereco" HeaderText = "Endereço" />
            <asp:BoundField DataField = "cep" HeaderText ="CEP" />
            <asp:BoundField DataField ="bairro" HeaderText ="Bairro" />
            <asp:BoundField DataField ="cidade" HeaderText ="Cidade" />
            <asp:BoundField DataField ="uf" HeaderText ="UF" />
            <asp:BoundField DataField ="telefone" HeaderText ="Telefone" />
            <asp:BoundField DataField ="usuario" HeaderText ="Usuario" />
            <asp:BoundField DataField ="cd_nota" HeaderText ="Código da Nota" />
            <asp:BoundField DataField ="DATACRIACAO" HeaderText ="Data do Pedido" />
        </Fields>
        
        
        </asp:DetailsView>
        <br />
        
        <div>
                    <asp:Label ID ="Valor" runat="server" Text="Valor Total:  " Font-Size="20pt">
        </asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Font-Size="20pt"></asp:Label>
        
        </div>


        _____________________________________________________________________________________________________<br />
        <asp:Label ID="Label5" runat="server" Text="_________________________"></asp:Label>
        <br />
        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="20px" Text="Produtos Ativos:"></asp:Label>
        <br />
        <asp:GridView ID="GridView1" runat="server" GridLines ="Vertical" AutoGenerateColumns ="False" Width="808px" Font-Size="16pt" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                <asp:BoundField DataField = "qtd" HeaderText ="Quantidade" />
                <asp:BoundField DataField = "nome" HeaderText ="Nome do Produto" />
                <asp:BoundField DataField = "valor_unit" HeaderText="Valor Unitario" DataFormatString = " {0:c}" />
            </Columns>

        

      

            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="Black" HorizontalAlign="Center" BackColor="#999999" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />

        

      

        </asp:GridView>

        
            
        
        
        _____________________________________________________________________________________________________<br />
        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="20px" Text="Produtos Cancelados" Visible="False"></asp:Label>
        <br />
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns ="False" Width="808px" Font-Size="16pt" BorderWidth="1px" CellPadding="4" BackColor="White" BorderColor="#CC9966" BorderStyle="None">
                    <Columns>
                <asp:BoundField DataField = "qtd" HeaderText ="Quantidade" />
                <asp:BoundField DataField = "nome" HeaderText ="Nome do Produto" />
                <asp:BoundField DataField = "valor_unit" HeaderText="Valor Unitario" DataFormatString = " {0:c}" />
            </Columns>
                    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                    <RowStyle BackColor="White" ForeColor="#330099" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                    <SortedAscendingCellStyle BackColor="#FEFCEB" />
                    <SortedAscendingHeaderStyle BackColor="#AF0101" />
                    <SortedDescendingCellStyle BackColor="#F6F0C0" />
                    <SortedDescendingHeaderStyle BackColor="#7E0000" />
        </asp:GridView>

        
            
        
        
    </form>
</body>
</html>
