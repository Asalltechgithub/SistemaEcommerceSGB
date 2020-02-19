<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="pesquisaProd.aspx.cs" Inherits="WebApplication4.pesquisaProd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="products">
               <asp:SqlDataSource ID="dsprodutos0" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT Id_Prod_Estq, Nome_Prod_Estq, Marca_Prod_Estoq, Categoria_Prod_Estoq, Dt_lancamento_Prod_Estoq, Valor_Compra_Prod, Valor_Venda_Prod_Estoq, Qtd_Prod_Estoq, Descricao_Prod_Estoq, Cod_For, Foto_Prod_Estoq, Tipo_Venda FROM Tb_Prod_Estoque WHERE (Nome_Prod_Estq LIKE @Param1 + '%') AND (Qtd_Prod_Estoq &gt; 0) AND (Tipo_Venda = 1)">
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="" Name="Param1" QueryStringField="Nome_Prod_Estq" />
            </SelectParameters>
        </asp:SqlDataSource>
        

                <asp:DataList ID="DataList1" runat="server" BorderColor="Black" DataSourceID="dsprodutos0" RepeatColumns="3" RepeatDirection="Horizontal">
                    <ItemTemplate>
                       <div class="product">
								<a href='<%#Eval ("Id_Prod_Estq" , "Prod_item.aspx?Id_Prod_Estq={0}") %>' title='<%# Eval("Nome_Prod_Estq") %>'>
									<span class="title">
                                         <asp:Label ID="Label2" runat="server" Text='<%# Eval("Nome_Prod_Estq") %>' style="font-weight: bold; font-size: medium"></asp:Label>
									</span>
                                            <asp:ImageButton ID="ImageButton1" runat="server" Height="94px" ImageUrl='<%# Eval("Foto_Prod_Estoq") %>' Width="100px" PostBackUrl= '<%#Eval ("Id_Prod_Estq" , "~/Prod_item.aspx?Id_Prod_Estq={0}") %>' />
									<span class="number">
                                      <img alt="" src="Imagens/american_express.png" style="width: 24px; height: 16px" />
                                            <img alt="" src="Imagens/mastercard.png" style="width: 24px; height: 16px" />
                                            <img alt="" src="Imagens/visa_electron.png" style="width: 24px; height: 16px" />
									</span>
									<span class="price">
                                        &nbsp;<asp:Label ID="Label3" runat="server" Text='<%# Eval("Valor_Venda_Prod_Estoq", "{0:C}") %>' style="font-weight: bold; font-size: medium"></asp:Label>
                                    </span> <br />      
                                    
								</a>
							</div>
                    </ItemTemplate>
                    <SeparatorStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" VerticalAlign="Top" />
                </asp:DataList>

    </div>

</asp:Content>


