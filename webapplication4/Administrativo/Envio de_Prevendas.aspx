<%@ Page Title="" Language="C#" MasterPageFile="~/Administrativo/Adm.Master" AutoEventWireup="true" CodeBehind="Envio de_Prevendas.aspx.cs" Inherits="WebApplication4.Administrativo.Envio_de_Prevendas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
    
    <br />
    <asp:Calendar ID="Calendar1" runat="server" Height="180px" Width="200px" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" OnSelectionChanged="Calendar1_SelectionChanged">
        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
        <NextPrevStyle VerticalAlign="Bottom" />
        <OtherMonthDayStyle ForeColor="#808080" />
        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
        <SelectorStyle BackColor="#CCCCCC" />
        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
        <WeekendDayStyle BackColor="#FFFFCC" />
    </asp:Calendar>
    <asp:SqlDataSource ID="dsPedidos" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT DISTINCT p.Id_Pre_Venda AS Pedido, u.Id AS Cliente, u.Email AS 'Email do Cliente', p.Status_Pre_Venda AS 'Status', p.Endereco_Envio AS 'Endereço para envio', p.UF_Envio AS ' UF ', p.Cidade_Envio AS 'Cidade', p.Valor_Frete AS 'Valor Frete', p.Data_Venda_Ped AS 'Data da Venda ', p.Valor_Total AS 'Valor total' FROM Tb_Pre_Venda AS p INNER JOIN Tb_Usuario AS u ON p.Cod_cli = u.Id WHERE (p.Status_Pre_Venda = 'Confirmado') AND (p.Data_Venda_Ped = @Param1)">
        <SelectParameters>
            <asp:ControlParameter ControlID="Calendar1" Name="Param1" PropertyName="SelectedDate" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Pedido,Cliente" DataSourceID="dsPedidos" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" AllowPaging="True" Height="120px" Width="623px">
        <Columns>
            <asp:BoundField DataField="Pedido" HeaderText="Pedido" ReadOnly="True" SortExpression="Pedido" InsertVisible="False" />
            <asp:BoundField DataField="Cliente" HeaderText="Cliente" ReadOnly="True" SortExpression="Cliente" InsertVisible="False" />
            <asp:BoundField DataField="Email do Cliente" HeaderText="Email do Cliente" SortExpression="Email do Cliente" />
            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
            <asp:BoundField DataField="Endereço para envio" HeaderText="Endereço para envio" SortExpression="Endereço para envio" />
            <asp:BoundField DataField=" UF " HeaderText=" UF " SortExpression=" UF " />
            <asp:BoundField DataField="Cidade" HeaderText="Cidade" SortExpression="Cidade" />
            <asp:BoundField DataField="Valor Frete" HeaderText="Valor Frete" SortExpression="Valor Frete" />
            <asp:BoundField DataField="Data da Venda " HeaderText="Data da Venda " SortExpression="Data da Venda " />
            <asp:BoundField DataField="Valor total" HeaderText="Valor total" SortExpression="Valor total" />
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
     
    Cliente :&nbsp; 
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

    
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="dsEndereco_Envio" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="Cod_Pedido" HeaderText="Cod_Pedido" SortExpression="Cod_Pedido" />
                        <asp:BoundField DataField="Produto" HeaderText="Produto" SortExpression="Produto" />
                        <asp:BoundField DataField="Marca" HeaderText="Marca" SortExpression="Marca" />
                        <asp:BoundField DataField="Qtd" HeaderText="Qtd" SortExpression="Qtd" />
                        <asp:BoundField DataField="Categoria" HeaderText="Categoria" SortExpression="Categoria" />
                        <asp:BoundField DataField="Valor" HeaderText="Valor" SortExpression="Valor" />
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
                <asp:SqlDataSource ID="dsEndereco_Envio" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT Cod_Pedido, Produto, Marca, Qtd, Categoria, Valor FROM Tb_Historico_prevenda WHERE (Cod_Pedido = @Param1)">
                    <SelectParameters>
                        <asp:SessionParameter Name="Param1" SessionField="pre_vendas" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="dsLista_pedido" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT Distinct lh.Cod_prd, lh.Produto, lh.Categoria, lh.Marca, lh.Qtd, lh.Valor, lh.Total, p.Status_Ped FROM Tb_lista_Historico AS lh INNER JOIN Tb_Pedido AS p ON lh.Cod_Pedido = p.Id_Pedido WHERE (lh.Cod_Pedido = @Param1)">
                    <SelectParameters>
                        <asp:SessionParameter Name="Param1" SessionField="pedido" />
                    </SelectParameters>
                </asp:SqlDataSource>
                 </tr>
    </table>
                <div>
                    
                       STATUS <asp:DropDownList ID="DdlStatus" runat="server">
                        <asp:ListItem>Enviado</asp:ListItem>
                    </asp:DropDownList>
                                    <asp:Button ID="btnOk" runat="server" OnClick="btnOk_Click" Text="OK" Enabled="False" />
                                <asp:Button ID="btnGerarboleto" runat="server" Enabled="False" OnClick="btnGerarboleto_Click" Text="Gerar Boleto" />
                                </div>
        
</asp:Content>