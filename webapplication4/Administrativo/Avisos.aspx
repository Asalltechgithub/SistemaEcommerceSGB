<%@ Page Title="" Language="C#" MasterPageFile="~/Administrativo/Adm.Master" AutoEventWireup="true" CodeBehind="Avisos.aspx.cs" Inherits="WebApplication4.Administrativo.Avisos" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">



    <table class="auto-style2">
    <tr>
        <td>&nbsp;</td>
        <td class="auto-style4">&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td colspan="5" style="text-align: center"> <h2>Produtos com qtd Abaixo do limite</h2>
            <p>&nbsp;</p></td>
    </tr>
</table>
<hr style="height: 16px" />
<table class="auto-style2">
    <tr>
        <td>&nbsp;</td>
        <td class="auto-style3">&nbsp;</td>
        <td>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="dsProdutos" Width="355px" Height="144px" style="text-align: center">
                <Columns>
                    <asp:BoundField DataField="Produto" HeaderText="Produto" SortExpression="Produto" />
                    <asp:BoundField DataField="Categoria" HeaderText="Categoria" SortExpression="Categoria" />
                    <asp:BoundField DataField="Qtde" HeaderText="Qtde" SortExpression="Qtde" />
                    <asp:BoundField DataField="Fornecedor_a_contatar" HeaderText="Fornecedor_a_contatar" SortExpression="Fornecedor_a_contatar" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="dsProdutos" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT p.Nome_Prod_Estq AS Produto, p.Categoria_Prod_Estoq AS Categoria, p.Qtd_Prod_Estoq AS Qtde, f.For_Razao_Social AS Fornecedor_a_contatar FROM Tb_Prod_Estoque AS p INNER JOIN Tb_Fornecedor AS f ON p.Cod_For = f.Id_Fornecedor WHERE (p.Qtd_Prod_Estoq &lt; 10) ORDER BY Fornecedor_a_contatar"></asp:SqlDataSource>
        </td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>



</asp:Content>

