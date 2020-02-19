<%@ Page Title="" Language="C#" MasterPageFile="../../Adm.Master" AutoEventWireup="true" CodeBehind="Rel_Produtos.aspx.cs" Inherits="WebApplication4.Administrativo.ADM.Relatórios" %>

<%@ Register assembly="WebApplication4" namespace="DevMedia" tagprefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Imagens/print.gif" OnClick="ImageButton2_Click" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate> 
      <div style="height: 378px; width: 695px;">
        <table><tr><td>    <asp:GridView ID="GridView1" runat="server" DataSourceID="dsProdutos" AllowPaging="True" AutoGenerateColumns="False" Height="169px" Width="612px" style="color: #000000; background-color: #FFFFFF; font-weight: 700; text-align: center;" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
            <Columns>
                <asp:BoundField DataField="Nome" HeaderText="Nome" SortExpression="Nome" />
                <asp:BoundField DataField="Marca" HeaderText="Marca" SortExpression="Marca" />
                <asp:BoundField DataField="Categoria" HeaderText="Categoria" SortExpression="Categoria" />
                <asp:BoundField DataField="Valor" HeaderText="Valor" SortExpression="Valor" />
            </Columns>
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" Font-Size="Larger" ForeColor="#CCCCFF" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SortedAscendingCellStyle BackColor="#EDF6F6" />
            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
            <SortedDescendingCellStyle BackColor="#D6DFDF" />
            <SortedDescendingHeaderStyle BackColor="#002876" />
            </asp:GridView>
            <asp:SqlDataSource ID="dsProdutos" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT Nome_Prod_Estq AS Nome, Marca_Prod_Estoq AS Marca, Categoria_Prod_Estoq AS Categoria, Valor_Compra_Prod AS Valor FROM Tb_Prod_Estoque"></asp:SqlDataSource>
</td></tr></table>
        </div>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
