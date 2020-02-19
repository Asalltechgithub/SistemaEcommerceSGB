<%@ Page Title="" Language="C#" MasterPageFile="../../Adm.Master" AutoEventWireup="true" CodeBehind="Prod_mais_Vend.aspx.cs" Inherits="WebApplication4.Administrativo.ADM.Relatorios.Prod_mais_Vend" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:ImageButton ID="img_Rel_Prod_mais_Vend" runat="server" ImageUrl="~/Imagens/print.gif" OnClick="img_Rel_Prod_mais_Vend_Click" />
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="dsProd_Mais_Vend" style="color: #000000; background-color: #CCCCCC">
    <Columns>
        <asp:BoundField DataField="Produto" HeaderText="Produto" SortExpression="Produto" />
        <asp:BoundField DataField="Quantidade" HeaderText="Quantidade" ReadOnly="True" SortExpression="Quantidade" />
    </Columns>
</asp:GridView>
<asp:SqlDataSource ID="dsProd_Mais_Vend" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT u.Nome_Prod_Estq AS Produto , COUNT(p.Produto) AS Quantidade FROM Tb_lista_Historico AS p INNER JOIN Tb_Prod_Estoque AS u ON u.Id_Prod_Estq = p.Cod_prd WHERE (p.Cod_Pedido &lt;&gt; 0) GROUP BY u.Nome_Prod_Estq ORDER BY Quantidade DESC"></asp:SqlDataSource>
</asp:Content>
