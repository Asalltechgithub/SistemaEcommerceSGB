<%@ Page Title="" Language="C#" MasterPageFile="../../Adm.Master" AutoEventWireup="true" CodeBehind="Rel_func.aspx.cs" Inherits="WebApplication4.Administrativo.ADM.R_func" %>
<%@ Register assembly="WebApplication4" namespace="DevMedia" tagprefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table class="auto-style2" align="center">
    <tr>
        <td style="text-align: center">
            <h2>Funcionarios Cadastrados</h2>
            <br />
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Imagens/print.gif" OnClick="ImageButton2_Click1" />
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="dsAdm" AllowPaging="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                <Columns>
                    <asp:BoundField DataField="Nome" HeaderText="Nome" SortExpression="Nome" />
                    <asp:BoundField DataField="Cargo" HeaderText="Cargo" SortExpression="Cargo" />
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>
            <asp:SqlDataSource ID="dsAdm" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT Nome, Cargo FROM relatorio_Func WHERE (TipoUsuario &lt;= 2)"></asp:SqlDataSource>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="2">&nbsp;</td>
    </tr>
</table>
</asp:Content>
