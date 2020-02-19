<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Resumo.aspx.cs" Inherits="WebApplication4.Resumo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

       <script type="text/javascript">

           function janelaModal(url, nome, nrTamanho, nrLargura) {

               eval(window.showModalDialog(url, nome, 'Resizable:no;DialogHeight:' + nrTamanho + 'px; DialogWidth:' + nrLargura + 'px; Edge:raised; Help:no; Scroll:no, Status:no; Center:yes;'));

           }

         </script>
     <table style="width: 100%">
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
                <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                <NextPrevStyle VerticalAlign="Bottom" />
                <OtherMonthDayStyle ForeColor="#808080" />
                <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                <SelectorStyle BackColor="#CCCCCC" />
                <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                <WeekendDayStyle BackColor="#FFFFCC" />
            </asp:Calendar>
        </td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td style="text-align: center">
            <div style="text-align: center">
                <h2>
                    <br />
                    Pedidos<br /> (Boleto)</h2>
            </div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Nº Pedido" DataSourceID="dsPedido" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Height="180px" Width="499px">
                <Columns>
                    <asp:BoundField DataField="Nº Pedido" HeaderText="Nº Pedido" InsertVisible="False" ReadOnly="True" SortExpression="Nº Pedido" />
                    <asp:BoundField DataField="Data da Compra" HeaderText="Data da Compra" SortExpression="Data da Compra" DataFormatString="{0:d}" />
                    <asp:BoundField DataField="Data Máxima para entrega " HeaderText="Data Máxima para entrega " SortExpression="Data Máxima para entrega " DataFormatString="{0:d}" />
                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                    <asp:BoundField DataField="Valor R$ " HeaderText="Valor R$ " SortExpression="Valor R$ " />
                    <asp:CommandField HeaderText="Gerar Boleto" ShowSelectButton="True" />
                </Columns>
                <EmptyDataTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Session[total]", "{0:C}") %>'></asp:Label>
                </EmptyDataTemplate>
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
            <br />
            <h2>Pedidos
                <br />
                (Cartão)</h2>
            <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="Nº Pedido" DataSourceID="dsPedidoConfirmado" Height="180px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="499px">
                <Columns>
                    <asp:BoundField DataField="Nº Pedido" HeaderText="Nº Pedido" InsertVisible="False" ReadOnly="True" SortExpression="Nº Pedido" />
                    <asp:BoundField DataField="Data da Compra" HeaderText="Data da Compra" SortExpression="Data da Compra" DataFormatString="{0:d}" />
                    <asp:BoundField DataField="Data Máxima para entrega " HeaderText="Data Máxima para entrega " SortExpression="Data Máxima para entrega " DataFormatString="{0:d}" />
                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                    <asp:BoundField DataField="Valor R$ " HeaderText="Valor R$ " SortExpression="Valor R$ " />
                </Columns>
                <EmptyDataTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("Session[total]", "{0:C}") %>'></asp:Label>
                </EmptyDataTemplate>
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
            <h2>Pré Vendas<br /> (Boleto)</h2>
            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" DataKeyNames="Pedido" DataSourceID="dsPrevendas" ForeColor="Black" Height="180px" AllowPaging="True" OnSelectedIndexChanged="GridView3_SelectedIndexChanged" Width="499px">
                <Columns>
                    <asp:BoundField DataField="Pedido" HeaderText="Pedido" InsertVisible="False" ReadOnly="True" SortExpression="Pedido" />
                    <asp:BoundField DataField="Data da Compra" HeaderText="Data da Compra" SortExpression="Data da Compra" DataFormatString="{0:d}" />
                    <asp:BoundField DataField="Data Máxima para entrega" HeaderText="Data Máxima para entrega" SortExpression="Data Máxima para entrega" DataFormatString="{0:d}" />
                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                    <asp:BoundField DataField="Valor R$ " HeaderText="Valor R$ " SortExpression="Valor R$ " />
                    <asp:CommandField HeaderText="Gerar Boleto" ShowSelectButton="True" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                <RowStyle BackColor="White" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
            <asp:SqlDataSource ID="dsPrevendas" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT Id_Pre_Venda AS Pedido, Data_Venda_Ped AS 'Data da Compra', Data_Entrega_Ped AS 'Data Máxima para entrega', Status_Pre_Venda AS Status, Valor_Total AS 'Valor R$ ' FROM Tb_Pre_Venda AS p WHERE (Cod_cli = @Param1) AND (Data_Venda_Ped = @Param2) AND (Status_Pre_Venda = 'Aberto') ORDER BY 'Data da Compra'">
                <SelectParameters>
                    <asp:SessionParameter Name="Param1" SessionField="Cli_ID" DefaultValue="27" />
                    <asp:ControlParameter ControlID="Calendar1" Name="Param2" PropertyName="SelectedDate" DefaultValue="2015-11-29" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
            <asp:SqlDataSource ID="dsPedido" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT DISTINCT p.Id_Pedido AS 'Nº Pedido', p.Data_Venda_Ped AS 'Data da Compra', p.Data_Entrega_Ped AS 'Data Máxima para entrega ', p.Status_Ped AS Status, p.Valor_Total AS 'Valor R$ ' FROM Tb_lista_Historico AS c INNER JOIN Tb_Pedido AS p ON c.Cod_Pedido = p.Id_Pedido WHERE (c.cod_cli = @Param1) AND (p.Status_Ped = 'Aberto') AND (p.Data_Venda_Ped = @Param2) ORDER BY 'Data da Compra'">
                <SelectParameters>
                    <asp:SessionParameter Name="Param1" SessionField="Cli_ID" />
                    <asp:ControlParameter ControlID="Calendar1" Name="Param2" PropertyName="SelectedDate" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="dsPedidoConfirmado" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT DISTINCT p.Id_Pedido AS 'Nº Pedido', p.Data_Venda_Ped AS 'Data da Compra', p.Data_Entrega_Ped AS 'Data Máxima para entrega ', p.Status_Ped AS Status, p.Valor_Total AS 'Valor R$ ' FROM Tb_lista_Historico AS c INNER JOIN Tb_Pedido AS p ON c.Cod_Pedido = p.Id_Pedido WHERE (c.cod_cli = @Param1) AND (p.Status_Ped = 'Confirmado') AND (p.Data_Venda_Ped = @Param2) ORDER BY 'Data da Compra'">
                <SelectParameters>
                    <asp:SessionParameter Name="Param1" SessionField="Cli_ID" />
                    <asp:ControlParameter ControlID="Calendar1" Name="Param2" PropertyName="SelectedDate" />
                </SelectParameters>
            </asp:SqlDataSource>
            <h2>Pré Vendas<br /> (Cartão)</h2>
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="Pedido" DataSourceID="dsPedidoFinalizado" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" Height="180px" Width="499px">
                <Columns>
                    <asp:BoundField DataField="Pedido" HeaderText="Pedido" InsertVisible="False" ReadOnly="True" SortExpression="Pedido" />
                    <asp:BoundField DataField="Data da Compra" HeaderText="Data da Compra" SortExpression="Data da Compra" DataFormatString="{0:d}" />
                    <asp:BoundField DataField="Data Máxima para entrega" HeaderText="Data Máxima para entrega" SortExpression="Data Máxima para entrega" DataFormatString="{0:d}" />
                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                    <asp:BoundField DataField="Valor R$" HeaderText="Valor R$" SortExpression="Valor R$" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                <RowStyle BackColor="White" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
            <asp:SqlDataSource ID="dsPedidoFinalizado" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT Id_Pre_Venda AS Pedido, Data_Venda_Ped AS 'Data da Compra', Data_Entrega_Ped AS 'Data Máxima para entrega', Status_Pre_Venda AS Status, Valor_Total AS 'Valor R$' FROM Tb_Pre_Venda AS p WHERE (Cod_cli = @Param1) AND (Data_Venda_Ped = @Param2) AND (Status_Pre_Venda = 'Confirmado') ORDER BY 'Data da Compra'">
                <SelectParameters>
                    <asp:SessionParameter Name="Param1" SessionField="Cli_ID" DefaultValue="27" />
                    <asp:ControlParameter ControlID="Calendar1" Name="Param2" PropertyName="SelectedDate" DefaultValue="2015-11-29" />
                </SelectParameters>
            </asp:SqlDataSource>
        </td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>
            &nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
             </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
