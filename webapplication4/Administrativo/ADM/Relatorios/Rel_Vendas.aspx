<%@ Page Title="" Language="C#" MasterPageFile="../../Adm.Master" AutoEventWireup="true" CodeBehind="Rel_Vendas.aspx.cs" Inherits="WebApplication4.Administrativo.ADM.Relatorios.Rel_Vendas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
    <table style="width: 100%">
        <tr>
            <td style="width: 258px">
                Inicio
                <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
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
            <td>
                Fim
                <asp:Calendar ID="Calendar2" runat="server" OnSelectionChanged="Calendar2_SelectionChanged" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
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
        </tr>
        <tr>
            <td colspan="2" >
                <asp:ImageButton ID="imgb_Receita" runat="server" ImageUrl="~/Imagens/print.gif" OnClick="imgb_Receita_Click" />
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="dsValor_Total_Ganho" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4"  >
                    <Columns>
                        <asp:BoundField DataField="Receita_Total" DataFormatString="{0:C}" HeaderText="Receita_Total" ReadOnly="True" SortExpression="Receita_Total" />
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
            
                <asp:SqlDataSource ID="dsValor_Total_Ganho" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT SUM(Valor_Total) AS Receita_Total FROM Tb_Pedido WHERE (Status_Ped = 'Confirmado')"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td colspan="2" >
                <asp:Button ID="Button1" runat="server" Text="Imprimir" OnClick="Button1_Click" />
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Pedido" DataSourceID="dsVendas" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                    <Columns>
                        <asp:BoundField DataField="Pedido" HeaderText="Pedido" InsertVisible="False" ReadOnly="True" SortExpression="Pedido" />
                        <asp:BoundField DataField="Cod_cli" HeaderText="Cod_cli" SortExpression="Cod_cli" />
                        <asp:BoundField DataField="Valor_Total" HeaderText="Valor_Total" SortExpression="Valor_Total" DataFormatString="{0:C}" />
                        <asp:BoundField DataField="Data_Venda_Ped" HeaderText="Data_Venda_Ped" SortExpression="Data_Venda_Ped" />
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
            </td>
        </tr>
        <tr>
            <td colspan="2">Vendas&nbsp;&nbsp; por Cartão<br />
                <asp:Button ID="BtnVisualizar" runat="server" OnClick="BtnVisualizar_Click" Text="Vendas por Cartão" />
                &nbsp;<asp:Button ID="btnFechar_venda_Cartao" runat="server" OnClick="btnFechar_venda_Cartao_Click" Text="Fechar" />
                <br />
                <asp:ImageButton ID="img_btn_Cartao" runat="server" ImageUrl="~/Imagens/print.gif" OnClick="img_btn_Cartao_Click" />
                <asp:GridView ID="gvVendas_Cartao" runat="server" AutoGenerateColumns="False" DataSourceID="dsVenda_cartao" Visible="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                    <Columns>
                        <asp:BoundField DataField=" Pagamentos Com Cartão" HeaderText=" Pagamentos Com Cartão" ReadOnly="True" SortExpression=" Pagamentos Com Cartão" />
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
                <asp:SqlDataSource ID="dsVenda_cartao" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT COUNT(p.Id_Pedido) AS ' Pagamentos Com Cartão' FROM Tb_Pedido AS p INNER JOIN Tb_Forma_de_Pagamento AS fp ON p.Forma_de_pagamento = fp.Id_Forma_de_Pagamento WHERE (p.Forma_de_pagamento = 2)"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                Vendas por Boleto<br />
                <asp:Button ID="BtnVisualizarb" runat="server" OnClick="BtnVisualizarb_Click" Text="Vendas por Boleto" />
                &nbsp;<asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Fechar" />
                <br />
                <asp:ImageButton ID="img_btn_Boleto" runat="server" ImageUrl="~/Imagens/print.gif" OnClick="img_btn_Boleto_Click" />
                <asp:GridView ID="gvVendas_Boleto" runat="server" AutoGenerateColumns="False" DataSourceID="dsVendas_Boleto"  Visible="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                    <Columns>
                        <asp:BoundField DataField="Pagamentos Com Boleto " HeaderText="Pagamentos Com Boleto " ReadOnly="True" SortExpression="Pagamentos Com Boleto " />
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
                <asp:SqlDataSource ID="dsVendas_Boleto" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT COUNT(p.Id_Pedido) AS 'Pagamentos Com Boleto ' FROM Tb_Pedido AS p INNER JOIN Tb_Forma_de_Pagamento AS fp ON p.Forma_de_pagamento = fp.Id_Forma_de_Pagamento WHERE (p.Forma_de_pagamento = 1)"></asp:SqlDataSource>
            </td>
        </tr>
    </table>
    <asp:SqlDataSource ID="dsVendas" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT Pedido, Cod_cli, Valor_Total, Data_Venda_Ped FROM vw_vendas WHERE (Data_Venda_Ped BETWEEN @Param1 AND @Param2)">
        <SelectParameters>
            <asp:ControlParameter ControlID="Calendar1" Name="Param1" PropertyName="SelectedDate" />
            <asp:ControlParameter ControlID="Calendar2" Name="Param2" PropertyName="SelectedDate" />
        </SelectParameters>
    </asp:SqlDataSource>
     
  
    <asp:Image ID="Image1" runat="server" Height="43px" Width="40px" />
     
  
</asp:Content>
