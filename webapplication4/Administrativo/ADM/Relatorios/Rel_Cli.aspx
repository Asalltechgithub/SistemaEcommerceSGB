<%@ Page Title="" Language="C#" MasterPageFile="../../Adm.Master" AutoEventWireup="true" CodeBehind="Rel_Cli.aspx.cs" Inherits="WebApplication4.Administrativo.ADM.Relatorios.Rel_Cli" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Imagens/print.gif" OnClick="ImageButton2_Click" />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="dscliente" style="color: #000000; background-color: #CCCCCC">
        <Columns>
            <asp:BoundField DataField="Nome" HeaderText="Nome" SortExpression="Nome" />
            <asp:BoundField DataField="CPF" HeaderText="CPF" SortExpression="CPF" />
            <asp:BoundField DataField="RG" HeaderText="RG" SortExpression="RG" />
            <asp:BoundField DataField="UF" HeaderText="UF" SortExpression="UF" />
            <asp:BoundField DataField="Cidade" HeaderText="Cidade" SortExpression="Cidade" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="dscliente" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT [Nome], [CPF], [RG], [UF], [Cidade] FROM [Tb_Usuario] WHERE ([TipoUsuario] &gt; @TipoUsuario) ORDER BY [Nome]">
        <SelectParameters>
            <asp:Parameter DefaultValue="2" Name="TipoUsuario" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>

</asp:Content>
       