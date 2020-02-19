<%@ Page Title="" Language="C#" MasterPageFile="~/Administrativo/Adm.Master" AutoEventWireup="true" CodeBehind="Control_prevenda.aspx.cs" Inherits="WebApplication4.Administrativo.Control_prevenda" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="142px" NextPrevFormat="ShortMonth" Width="182px">
    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />
    <DayStyle BackColor="#CCCCCC" />
    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
    <OtherMonthDayStyle ForeColor="#999999" />
    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
    <TitleStyle BackColor="#333399" BorderStyle="Solid" Font-Bold="True" Font-Size="12pt" ForeColor="White" Height="12pt" />
    <TodayDayStyle BackColor="#999999" ForeColor="White" />
</asp:Calendar>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="Id_Pre_Venda" DataSourceID="dsPrevenda" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AllowPaging="True">
        <Columns>
            <asp:BoundField DataField="Id_Pre_Venda" HeaderText="Id_Pre_Venda" InsertVisible="False" ReadOnly="True" SortExpression="Id_Pre_Venda" />
            <asp:BoundField DataField="Cod_cli" HeaderText="Cod_cli" SortExpression="Cod_cli" />
            <asp:BoundField DataField="Cod_Prod" HeaderText="Cod_Prod" SortExpression="Cod_Prod" />
            <asp:BoundField DataField="Data_Venda_Ped" HeaderText="Data_Venda_Ped" SortExpression="Data_Venda_Ped" />
            <asp:BoundField DataField="Data_Envio_Ped" HeaderText="Data_Envio_Ped" SortExpression="Data_Envio_Ped" />
            <asp:BoundField DataField="Data_Entrega_Ped" HeaderText="Data_Entrega_Ped" SortExpression="Data_Entrega_Ped" />
            <asp:BoundField DataField="Status_Pre_Venda" HeaderText="Status_Pre_Venda" SortExpression="Status_Pre_Venda" />
            <asp:BoundField DataField="Forma_de_pagamento" HeaderText="Forma_de_pagamento" SortExpression="Forma_de_pagamento" />
            <asp:BoundField DataField="Quantidade" HeaderText="Quantidade" SortExpression="Quantidade" />
            <asp:BoundField DataField="Valor_Total" HeaderText="Valor_Total" SortExpression="Valor_Total" />
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
        <RowStyle BackColor="White" ForeColor="#003399" />
        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
        <SortedAscendingCellStyle BackColor="#EDF6F6" />
        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
        <SortedDescendingCellStyle BackColor="#D6DFDF" />
        <SortedDescendingHeaderStyle BackColor="#002876" />
</asp:GridView>
<asp:SqlDataSource ID="dsPrevenda" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT p.Id_Pre_Venda, p.Cod_cli, p.Cod_Prod, p.Data_Venda_Ped, p.Data_Envio_Ped, p.Data_Entrega_Ped, p.Status_Pre_Venda, p.Forma_de_pagamento, pr.Qtd AS Quantidade, p.Valor_Total FROM Tb_Pre_Venda AS p INNER JOIN Tb_Historico_prevenda AS pr ON p.Id_Pre_Venda = pr.Cod_Pedido WHERE (p.Data_Venda_Ped = @Param1) AND (p.Status_Pre_Venda = 'Aberto') ">
    <SelectParameters>
        <asp:ControlParameter ControlID="Calendar1" Name="Param1" PropertyName="SelectedDate" />
    </SelectParameters>
</asp:SqlDataSource>
    <asp:Panel ID="Pdetalhes" runat="server" Visible="False">
        <asp:GridView ID="GvDetalhe" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="dsLIsta">
            <Columns>
                <asp:BoundField DataField="Cod_Pedido" HeaderText="Cod_Pedido" SortExpression="Cod_Pedido" />
                <asp:BoundField DataField="Produto" HeaderText="Produto" SortExpression="Produto" />
                <asp:BoundField DataField="Marca" HeaderText="Marca" SortExpression="Marca" />
                <asp:BoundField DataField="Qtd" HeaderText="Qtd" SortExpression="Qtd" />
                <asp:BoundField DataField="Categoria" HeaderText="Categoria" SortExpression="Categoria" />
                <asp:BoundField DataField="Valor" HeaderText="Valor" SortExpression="Valor" />
            </Columns>
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SortedAscendingCellStyle BackColor="#EDF6F6" />
            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
            <SortedDescendingCellStyle BackColor="#D6DFDF" />
            <SortedDescendingHeaderStyle BackColor="#002876" />
        </asp:GridView>
        &nbsp;
        <asp:DropDownList ID="DdlStatus" runat="server">
            <asp:ListItem>Confirmado</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" Text="OK" />
        &nbsp;<asp:SqlDataSource ID="dsLIsta" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT [Cod_Pedido], [Produto], [Marca], [Qtd], [Categoria], [Valor] FROM [Tb_Historico_prevenda] WHERE ([Cod_Pedido] = @Cod_Pedido)">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="" Name="Cod_Pedido" SessionField="pre_venda" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        </asp:Panel>
</asp:Content>
