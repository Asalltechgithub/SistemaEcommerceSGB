<%@ Page Title="" Language="C#" MasterPageFile="~/Administrativo/Adm.Master" AutoEventWireup="true" CodeBehind="Detalhe_Pedido.aspx.cs" Inherits="WebApplication4.Administrativo.Detalhe_Pedido" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table class="auto-style2">
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td colspan="4" rowspan="8"> 
                Cliente :&nbsp; 
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
<asp:Repeater ID="rptProdutos" runat="server" DataSourceID="dsLista_pedido" OnItemDataBound="rptProdutos_ItemDataBound"  >
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
                                <asp:CheckBox ID="ChkSelecionar" runat="server" />
                            </td>
                            
                            
                            
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        <tfoot>
                            <tr>
                                
                                <td>
                              
                                <td colspan="3">
                                   <asp:Button ID="btnFinalizar" runat="server" Text="Finalizar pedido" CommandName="Finalizar"
                                        OnClientClick="return confirm('Confirma Finalizar esse Carrinho?')" OnClick="btnFinalizar_Click1"/>
                                </td>
                            </tr>
                        </tfoot>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="dsEndereco_Envio">
                    <Columns>
                        <asp:BoundField DataField="Endereco" HeaderText="Endereco" SortExpression="Endereco" />
                        <asp:BoundField DataField="UF" HeaderText="UF" SortExpression="UF" />
                        <asp:BoundField DataField="CEP" HeaderText="CEP" SortExpression="CEP" />
                        <asp:BoundField DataField="Cidade" HeaderText="Cidade" SortExpression="Cidade" />
                        <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="dsEndereco_Envio" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT [Endereco], [UF], [CEP], [Cidade], [Email] FROM [Tb_Usuario] WHERE ([Id] = @Id)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="Label1" Name="Id" PropertyName="Text" Type="Int32" />
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
                        <asp:ListItem>Aberto</asp:ListItem>
                        <asp:ListItem>Cancelado</asp:ListItem>
                        <asp:ListItem>Confirmado</asp:ListItem>
                        </asp:DropDownList>
                                    Volumes:
                                    <asp:Label ID="lblQtdeVol" runat="server" Text="0"></asp:Label>
                                    &nbsp; Valor Total:
                                    <asp:Label ID="lblValorTotal" runat="server" Text="0,00"></asp:Label>
                                </div>
      
       
</asp:Content>
