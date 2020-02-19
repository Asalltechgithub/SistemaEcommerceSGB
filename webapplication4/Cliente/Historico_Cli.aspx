<%@ Page Title="" Language="C#" MasterPageFile="~/Cliente/Menu_cli.Master" AutoEventWireup="true" CodeBehind="Historico_Cli.aspx.cs" Inherits="WebApplication4.Cliente.Historico_Cli" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
<div style="bottom: auto; text-align: center;">
    <table style="right: auto">
        <tr>
            <td>
                <h2>Inicio</h2>
                <asp:Calendar ID="ClInicio" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px">
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
                <h2>Fim</h2>
                <asp:Calendar ID="ClFim" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px">
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
        <tr>
            <td>
                &nbsp;</td>
            <td>

                &nbsp;</td>
        </tr>
    </table>

    <br />
    <h1>&nbsp;</h1>
    <h1>&nbsp;</h1>
    <h1 style="height: 26px; color: #FFFFFF"> Pedidos</h1>
    <br />

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Pedido" DataSourceID="dsPedido" Width="298px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" AllowPaging="True" PageSize="3" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
        <Columns>
            <asp:BoundField DataField="Pedido" HeaderText="Pedido" InsertVisible="False" ReadOnly="True" SortExpression="Pedido" />
            <asp:BoundField DataField="Data" HeaderText="Data" SortExpression="Data" >
            <HeaderStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
            <asp:BoundField DataField="Valor_Total" HeaderText="Valor_Total" SortExpression="Valor_Total" DataFormatString="{0:C}" />
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
     <asp:Repeater ID="rptProdutos" runat="server" DataSourceID="dsLista_pedido" OnItemDataBound="rptProdutos_ItemDataBound" Visible="False"  >
                    <HeaderTemplate>
                        <table border="1" cellpadding="2" cellspacing="1" summary="The globo games" style="font-size: medium; color: #000000; background-color: #CCFFCC; font-weight: bold;">
                            <caption>
                             <h2>Itens do Pedido</h2>   
                            </caption>
                            <thead>
                                <tr>
                                    <th>
                                        cod
                                    </th>
                                    <th>
                                        Produto
                                    </th>
                                    <th>
                                        Categoria
                                    </th>
                                    <th>
                                      Marca
                                    </th>
                                    <th>
                                       Qtd 
                                    </th>
                                    
                                    <th>
                                        Valor
                                    </th>
                                    
                                    <th>
                                        Total
                                    </th>
                                    <th>
                                        Selecionar
                                    </th>
                                    <th>
                                        +
                                    </th>
                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            
                            <td>
                                <asp:Label ID="Lblcodprod" runat="server" Text= '<%# Eval("Cod_prd") %>'/>
                            </td>
                            
                            <td>
                                <asp:Label ID="lblNomeProd" runat="server" Text= '<%# Eval("Produto") %>'/>
                            </td>
                            <td>
                                <asp:Label ID="lblCategoria" runat="server" Text= '<%# Eval("Categoria") %>'/>
                            </td>
                            <td>
                                <asp:Label ID="lblMarca" runat="server" Text= '<%# Eval("Marca") %>'/>
                            </td>
                           <td>
                                <asp:Label ID="Lblqtd" runat="server" Text= '<%# Eval("Qtd") %>'/>
                            </td>
                            <td>
                                R$ <asp:Label ID="lblPrecoVenda" runat="server" Text= '<%# Eval("Valor","{0:0.00}") %>'/>
                            </td>
                            <td>
                               <asp:Label ID="lblTOTAL" runat="server"  Text='<%# Eval("Total") %>'/> 
                            </td>
                            <td>
                                <asp:CheckBox ID="ChkSelecionar" runat="server" />
                            </td>
                            
                            
                            
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        <tfoot>
                            <tr>
                                
                                <td>
                              
                               
                            </tr>
                        </tfoot>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
     <asp:Button ID="btnFecharrpt" runat="server" OnClick="btnFecharrpt_Click" Text="Fechar painel" Visible="False" />
    <asp:SqlDataSource ID="dsLista_pedido" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT lh.Cod_prd, lh.Produto, lh.Categoria, lh.Marca, lh.Qtd, lh.Valor, lh.Total, p.Status_Ped FROM Tb_lista_Historico AS lh INNER JOIN Tb_Pedido AS p ON lh.Cod_Pedido = p.Id_Pedido WHERE (lh.Cod_Pedido = @Param1)">
        <SelectParameters>
            <asp:SessionParameter Name="Param1" SessionField="pedido" />
        </SelectParameters>
    </asp:SqlDataSource>
    <h1 style="color: #FFFFFF">
        <br />
        Pré Vendas</h1>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <asp:GridView ID="GridView2" runat="server" DataSourceID="dsPre_venda" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="Pré_Venda" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="Pré_Venda" HeaderText="Pré_Venda" InsertVisible="False" ReadOnly="True" SortExpression="Pré_Venda" />
            <asp:BoundField DataField="Codigo do Cliente " HeaderText="Codigo do Cliente " SortExpression="Codigo do Cliente " />
            <asp:BoundField DataField="Codigo do Produto" HeaderText="Codigo do Produto" SortExpression="Codigo do Produto" />
            <asp:BoundField DataField="Data da Venda" HeaderText="Data da Venda" SortExpression="Data da Venda" DataFormatString="{0:D}" />
            <asp:BoundField DataField="Data de Envio" HeaderText="Data de Envio" SortExpression="Data de Envio" DataFormatString="{0:D}" />
            <asp:BoundField DataField="Data de previsão de Entrega" HeaderText="Data de previsão de Entrega" SortExpression="Data de previsão de Entrega" DataFormatString="{0:D}" />
            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
            <asp:BoundField DataField=" Forma de Pagamento" HeaderText=" Forma de Pagamento" SortExpression=" Forma de Pagamento" />
            <asp:BoundField DataField="Valor do Frete " HeaderText="Valor do Frete " SortExpression="Valor do Frete " />
            <asp:BoundField DataField="Valor Total R$ " HeaderText="Valor Total R$ " SortExpression="Valor Total R$ " />
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
    <h2>
        <asp:Label ID="lblItensprevenda" runat="server" Text="Itens de Pré Venda" Visible="False"></asp:Label>
    </h2>
    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="dsitensPrevenda">
        <Columns>
            <asp:BoundField DataField="Codigo Pre-venda" HeaderText="Codigo Pre-venda" SortExpression="Codigo Pre-venda" />
            <asp:BoundField DataField="Produto" HeaderText="Produto" SortExpression="Produto" />
            <asp:BoundField DataField="Marca" HeaderText="Marca" SortExpression="Marca" />
            <asp:BoundField DataField="Quantidade" HeaderText="Quantidade" SortExpression="Quantidade" />
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
    <asp:Button ID="btnFecharrpt2" runat="server" OnClick="btnFecharrpt2_Click" Text="Fechar painel" Visible="False" />
    <asp:SqlDataSource ID="dsitensPrevenda" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT Cod_prd AS 'Codigo Pre-venda', Produto, Marca, Qtd AS Quantidade, Categoria, Valor FROM Tb_Historico_prevenda WHERE (Cod_Pedido = @Param1)">
        <SelectParameters>
            <asp:SessionParameter Name="Param1" SessionField="prevenda" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dsPre_venda" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT Id_Pre_Venda AS Pré_Venda, Cod_cli AS 'Codigo do Cliente ', Cod_Prod AS 'Codigo do Produto', Data_Venda_Ped AS 'Data da Venda', Data_Envio_Ped AS 'Data de Envio', Data_Entrega_Ped AS 'Data de previsão de Entrega', Status_Pre_Venda AS Status, Forma_de_pagamento AS ' Forma de Pagamento', Valor_Frete AS 'Valor do Frete ', Valor_Total AS 'Valor Total R$ ' FROM Tb_Pre_Venda AS p WHERE (Cod_cli = @Param1) AND (Data_Venda_Ped BETWEEN @Param2 AND @Param3)">
        <SelectParameters>
            <asp:SessionParameter Name="Param1" SessionField="Cli_ID" />
            <asp:ControlParameter ControlID="ClInicio" Name="Param2" PropertyName="SelectedDate" />
            <asp:ControlParameter ControlID="ClFim" Name="Param3" PropertyName="SelectedDate" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
    <asp:SqlDataSource ID="dsPedido" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT DISTINCT p.Id_Pedido AS Pedido, p.Data_Venda_Ped AS Data, p.Status_Ped AS Status, p.Valor_Total FROM Tb_lista_Historico AS c INNER JOIN Tb_Pedido AS p ON c.Cod_Pedido = p.Id_Pedido WHERE (c.cod_cli = @Param1) AND (p.Data_Venda_Ped BETWEEN @Param2 AND @Param3) ORDER BY Data">
        <SelectParameters>
            <asp:SessionParameter Name="Param1" SessionField="Cli_ID" />
            <asp:ControlParameter ControlID="ClInicio" Name="Param2" PropertyName="SelectedDate" />
            <asp:ControlParameter ControlID="ClFim" Name="Param3" PropertyName="SelectedDate" />
        </SelectParameters>
    </asp:SqlDataSource>

   

   

    <h1>&nbsp;</h1>

</div>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

