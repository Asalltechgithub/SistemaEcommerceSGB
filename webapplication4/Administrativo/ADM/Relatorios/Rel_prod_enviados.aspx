<%@ Page Title="" Language="C#" MasterPageFile="../../Adm.Master" AutoEventWireup="true" CodeBehind="Rel_prod_enviados.aspx.cs" Inherits="WebApplication4.Administrativo.ADM.Relatorios.Rel_prod_enviados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table align="center" style="width: 100%">
        <tr>
            <td>
                <h2>Relatório de Pedidos enviados</h2>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Imagens/print.gif" OnClick="ImageButton3_Click" />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Nº do Pedido" DataSourceID="dsPed_prod_enviados" style="color: #000000; background-color: #66FF33; font-size: small; text-align: center;" CellSpacing="3" Height="189px" Width="631px">
    <Columns>
        <asp:BoundField DataField="Nº do Pedido" HeaderText="Nº do Pedido" InsertVisible="False" ReadOnly="True" SortExpression="Nº do Pedido" />
        <asp:BoundField DataField="Nome do Clente" HeaderText="Nome do Clente" SortExpression="Nome do Clente" />
        <asp:BoundField DataField="Endereço de entrega" HeaderText="Endereço de entrega" SortExpression="Endereço de entrega" />
        <asp:BoundField DataField="Cidade" HeaderText="Cidade" SortExpression="Cidade" />
        <asp:BoundField DataField="UF" HeaderText="UF" SortExpression="UF" />
        <asp:BoundField DataField="CEP" HeaderText="CEP" SortExpression="CEP" />
        <asp:BoundField DataField="Data da Venda " HeaderText="Data da Venda " SortExpression="Data da Venda " DataFormatString="{0:d}" />
        <asp:BoundField DataField="Data do Envio" HeaderText="Data do Envio" SortExpression="Data do Envio" DataFormatString="{0:d}" />
        <asp:BoundField DataField="Status do Pedido" HeaderText="Status do Pedido" SortExpression="Status do Pedido" />
    </Columns>
</asp:GridView>
<asp:SqlDataSource ID="dsPed_prod_enviados" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT p.Id_Pedido AS 'Nº do Pedido', u.Nome AS 'Nome do Clente', u.Endereco AS 'Endereço de entrega', u.Cidade, u.UF, u.CEP, p.Data_Venda_Ped AS 'Data da Venda ', p.Data_Envio_Ped AS 'Data do Envio', p.Status_Ped AS 'Status do Pedido' FROM Tb_Pedido AS p INNER JOIN Tb_Usuario AS u ON u.Id = p.Cod_cli WHERE (p.Data_Venda_Ped BETWEEN @Param1 AND @Param2) AND (p.Status_Ped = 'Enviado') ORDER BY 'Data do Envio'">
    <SelectParameters>
        <asp:ControlParameter ControlID="Cl_Inicio" Name="Param1" PropertyName="SelectedDate" />
        <asp:ControlParameter ControlID="Cl_Fim" Name="Param2" PropertyName="SelectedDate" />
    </SelectParameters>
    </asp:SqlDataSource>
    <table style="width: 111%">
        <tr>
            <td style="text-align: center">
                <h2>Inicio</h2>
            </td>
            <td>&nbsp;</td>
            <td style="text-align: center">
                <h2>Fim</h2>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Calendar ID="Cl_Inicio" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px">
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
            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Calendar ID="Cl_Fim" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px">
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
</asp:Content>
