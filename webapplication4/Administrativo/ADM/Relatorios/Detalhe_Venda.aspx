<%@ Page Title="" Language="C#" MasterPageFile="~/Administrativo/Relatorios.master" AutoEventWireup="true" CodeBehind="Detalhe_Venda.aspx.cs" Inherits="WebApplication4.Administrativo.ADM.Relatorios.Detalhe_Venda" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    Cliente&nbsp; :&nbsp; <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <br />
    Pedido&nbsp; :&nbsp;
    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
    <asp:Repeater ID="rptProdutos" runat="server" DataSourceID="dsLista_pedido" OnItemDataBound="rptProdutos_ItemDataBound"  >
        <HeaderTemplate>
            <table border="1" cellpadding="2" cellspacing="1" summary="The globo games" style="font-size: medium; color: #FFFFFF; background-color: #CCFFCC; font-weight: bold; background-image: url('../../../css/images/dd-item.png');">
                <caption>
                                Pedido 
                            </caption>
                <thead>
                    <tr>
                        <th>cod
                                    </th>
                        <th>Produto
                                    </th>
                        <th>Categoria
                                    </th>
                        <th>Marca
                                    </th>
                        <th>Qtd 
                                    </th>
                        <th>Valor
                                    </th>
                        <th>Total
                                    </th>
                        <th>Selecionar
                                    </th>
                        <th>+
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
                <td>R$ 
                    <asp:Label ID="lblPrecoVenda" runat="server" Text= '<%# Eval("Valor","{0:0.00}") %>'/>
                </td>
                <td>
                    <asp:Label ID="lblTOTAL" runat="server"  Text='<%# Eval("Total") %>'/>
                </td>
                <td>
                    
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            <tfoot>
                <tr>
                    <td>
                        <td colspan="3">
                            
                        </td>
                </tr>
            </tfoot>
            </table>
        </FooterTemplate>
    </asp:Repeater>
                <asp:SqlDataSource ID="dsLista_pedido" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT lh.Cod_prd, lh.Produto, lh.Categoria, lh.Marca, lh.Qtd, lh.Valor, lh.Total, p.Status_Ped FROM Tb_lista_Historico AS lh INNER JOIN Tb_Pedido AS p ON lh.Cod_Pedido = p.Id_Pedido WHERE (lh.Cod_Pedido = @Param1)">
                    <SelectParameters>
                        <asp:SessionParameter Name="Param1" SessionField="pedido" />
                    </SelectParameters>
                </asp:SqlDataSource>
                 </asp:Content>
