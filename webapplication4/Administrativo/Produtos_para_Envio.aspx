<%@ Page Title="" Language="C#" MasterPageFile="~/Administrativo/Adm.Master" AutoEventWireup="true" CodeBehind="Produtos_para_Envio.aspx.cs" Inherits="WebApplication4.Administrativo.Produtos_para_Envio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
    
    <br />
    <asp:Calendar ID="Calendar1" runat="server" Height="180px" Width="200px" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black">
        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
        <NextPrevStyle VerticalAlign="Bottom" />
        <OtherMonthDayStyle ForeColor="#808080" />
        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
        <SelectorStyle BackColor="#CCCCCC" />
        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
        <WeekendDayStyle BackColor="#FFFFCC" />
    </asp:Calendar>
    <asp:SqlDataSource ID="dsPedidos" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT Pedido, Cliente, Valor_Total AS 'Valor total', Frete, Email_Cliente AS 'Email do Cliente ', Status_Ped AS 'Status' FROM vw_Pedidos WHERE (Data_Venda_Ped = @Param1) AND (Status_Ped = 'Confirmado')">
        <SelectParameters>
            <asp:ControlParameter ControlID="Calendar1" Name="Param1" PropertyName="SelectedDate" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Pedido,Cliente" DataSourceID="dsPedidos" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
        <Columns>
            <asp:BoundField DataField="Pedido" HeaderText="Pedido" ReadOnly="True" SortExpression="Pedido" />
            <asp:BoundField DataField="Cliente" HeaderText="Cliente" ReadOnly="True" SortExpression="Cliente" />
            <asp:BoundField DataField="Valor total" HeaderText="Valor total" SortExpression="Valor total" />
            <asp:BoundField DataField="Frete" HeaderText="Frete" SortExpression="Frete" />
            <asp:BoundField DataField="Email do Cliente " HeaderText="Email do Cliente " SortExpression="Email do Cliente " />
            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
            <asp:CommandField HeaderText="Selecionar Pedido" ShowSelectButton="True" />
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

    <asp:Repeater ID="rptProdutos" runat="server" DataSourceID="dsLista_pedido" OnItemDataBound="rptProdutos_ItemDataBound" Visible="False"  >
                    <HeaderTemplate>
                        <table border="1" cellpadding="2" cellspacing="1" summary="The globo games" style="font-size: medium; color: #000000; background-color: #CCFFCC; font-weight: bold;">
                            <caption>
                                Pedido
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
                                <asp:CheckBox ID="ChkSelecionar" runat="server" Visible="False" />
                            </td>
                            
                            
                            
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        <tfoot>
                            <tr>
                                
                                <td>
                              
                                <td colspan="3">
                                  
                                </td>
                                     <td colspan="3">
                                
                                </td>
                            </tr>
                        </tfoot>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
       <asp:Button ID="btnFinalizar" runat="server" Text="Enviar Produtos" CommandName="Finalizar"
                                        OnClientClick="return confirm('Confirma Envio de Produtos ?')" OnClick="btnFinalizar_Click1" Enabled="False" Visible="False" />
       <asp:Button ID="BtnGerarNOta" runat="server" Text="Gerar Nota Fiscal " CommandName="Finalizar" OnClick="BtnGerarNOta_Click"  OnClientClick="return confirm('Gerar Nota Fiscal ?')" Visible="False" />            
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="dsEndereco_Envio" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="Nome do destinatário" HeaderText="Nome do destinatário" SortExpression="Nome do destinatário" />
                        <asp:BoundField DataField="Endereço de Envio" HeaderText="Endereço de Envio" SortExpression="Endereço de Envio" />
                        <asp:BoundField DataField="CEP" HeaderText="CEP" SortExpression="CEP" />
                        <asp:BoundField DataField="UF" HeaderText="UF" SortExpression="UF" />
                        <asp:BoundField DataField="Cidade" HeaderText="Cidade" SortExpression="Cidade" />
                        <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                        <asp:CommandField HeaderText="Selecionar o  Endereço" ShowSelectButton="True" />
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
                <asp:SqlDataSource ID="dsEndereco_Envio" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT Nome_Destinatario AS 'Nome do destinatário', Endereco_Envio AS 'Endereço de Envio', CEP_Envio AS 'CEP', UF_Envio AS UF, Cidade_Envio AS 'Cidade', Status_Ped AS Status FROM Tb_Pedido WHERE (Id_Pedido = @Id_Pedido) AND (Status_Ped = 'Confirmado')">
                    <SelectParameters>
                        <asp:SessionParameter Name="Id_Pedido" SessionField="pedido" Type="Int32" />
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
                    
                       &nbsp;<asp:DropDownList ID="DdlStatus" runat="server" Visible="False">
                        <asp:ListItem>Enviado</asp:ListItem>
                    </asp:DropDownList>
                                </div>
        
</asp:Content>
