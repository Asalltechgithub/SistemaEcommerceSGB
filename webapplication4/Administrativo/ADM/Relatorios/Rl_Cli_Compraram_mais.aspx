<%@ Page Title="" Language="C#" MasterPageFile="../../Adm.Master" AutoEventWireup="true" CodeBehind="Rl_Cli_Compraram_mais.aspx.cs" Inherits="WebApplication4.Administrativo.ADM.Relatorios.Rl_Cli_Compraram_mais" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <table>
        <tr>
            <td>
    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Imagens/print.gif" OnClick="ImageButton2_Click" />
                <table style="width: 100%">
                    <tr>
                        <td style="width: 186px">&nbsp;</td>
                        <td rowspan="2" style="width: 6px">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 186px">&nbsp;</td>
                        <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ds_Cli_compra_mais" style="color: #000000; background-color: #CCCCCC; font-weight: 700;">
                    <Columns>
                        <asp:BoundField DataField="Nome" HeaderText="Nome" SortExpression="Nome" />
                        <asp:BoundField DataField="qtde" HeaderText="qtde" ReadOnly="True" SortExpression="qtde" />
                    </Columns>
                </asp:GridView>
                        </td>
                    </tr>
                </table>
                <table style="width: 100%">
                    <tr>
                        <td style="text-align: center">
                            <h2>Inicio</h2>
                        </td>
                        <td style="text-align: center">
                            <h2>Fim</h2>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px">
                                <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                                <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                                <OtherMonthDayStyle ForeColor="#999999" />
                                <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                                <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                                <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                                <WeekendDayStyle BackColor="#CCCCFF" />
                            </asp:Calendar>
                        </td>
                        <td>
                            <asp:Calendar ID="Calendar2" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px">
                                <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                                <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                                <OtherMonthDayStyle ForeColor="#999999" />
                                <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                                <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                                <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                                <WeekendDayStyle BackColor="#CCCCFF" />
                            </asp:Calendar>
                        </td>
                    </tr>
                </table>
                <asp:SqlDataSource ID="ds_Cli_compra_mais" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT u.Nome, COUNT(p.Cod_cli) AS qtde FROM Tb_Pedido AS p INNER JOIN Tb_Usuario AS u ON u.Id = p.Cod_cli WHERE (p.Data_Venda_Ped BETWEEN @Param1 AND @Param2) GROUP BY u.Nome ORDER BY qtde DESC">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="Calendar1" Name="Param1" PropertyName="SelectedDate" />
                        <asp:ControlParameter ControlID="Calendar2" Name="Param2" PropertyName="SelectedDate" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>

</asp:Content>
