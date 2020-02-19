<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Princ_Prod_Prevenda.aspx.cs" Inherits="WebApplication4.Princ_Prod_Prevenda" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="products">
               <asp:SqlDataSource ID="dsprodutos0" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT TOP (10) Tb_Prod_Estoque.Id_Prod_Estq, Tb_Prod_Estoque.Categoria_Prod_Estoq, Tb_Prod_Estoque.Nome_Prod_Estq, Tb_Prod_Estoque.Descricao_Prod_Estoq, Tb_Prod_Estoque.Valor_Venda_Prod_Estoq, Tb_Prod_Estoque.Foto_Prod_Estoq, Tb_Prod_Estoque.Tipo_Venda FROM Tb_Prod_Estoque INNER JOIN Tb_Tipo_Pedido ON Tb_Prod_Estoque.Tipo_Venda = Tb_Tipo_Pedido.Id_Tipo_Pedido WHERE (Tb_Prod_Estoque.Tipo_Venda = @Param1) and Qtd_Prod_Estoq &lt;&gt;0 ORDER BY NEWID()">
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="2" Name="Param1" QueryStringField="Id_Tipo_Pedido" />
            </SelectParameters>
        </asp:SqlDataSource>
        

                <asp:DataList ID="DataList1" runat="server" BorderColor="Black" DataSourceID="dsprodutos0" RepeatColumns="3">
                    <ItemTemplate>

                        <div class="product">
								<a href= '<%# Eval ("Id_Prod_Estq" , "Pre_venda.aspx?Id_Prod_Estq={0}") %>' title='<%# Eval("Nome_Prod_Estq") %>'>
									<span class="title">
                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Nome_Prod_Estq") %>' style="font-size: medium; font-weight: bold"></asp:Label>
									</span>
                                    <asp:ImageButton ID="ImageButton2" runat="server" Height="110px" ImageUrl='<%# Eval("Foto_Prod_Estoq") %>' PostBackUrl= '<%# Eval ("Id_Prod_Estq" , "~/Pre_venda.aspx?Id_Prod_Estq={0}") %>' Width="128px" OnClick="ImageButton2_Click"/>
									<span class="number">
                                      <img alt="" src="Imagens/american_express.png" style="width: 24px; height: 16px" />
                                            <img alt="" src="Imagens/mastercard.png" style="width: 24px; height: 16px" />
                                            <img alt="" src="Imagens/visa_electron.png" style="width: 24px; height: 16px" />
									</span>
									<span class="price">
                                        <span> </span>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("Valor_Venda_Prod_Estoq", "{0:C}") %>' style="font-size: medium; font-weight: bold"></asp:Label>
                                    </span> <br />      
                                    
								</a>
							</div>
                    </ItemTemplate>
                    <SeparatorStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" VerticalAlign="Top" />
                </asp:DataList>
                                            

    </div>
</asp:Content>
