<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Princ_Prod_marca.aspx.cs" Inherits="WebApplication4.Princ_Prod_marca" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="products">
               <asp:SqlDataSource ID="dsprodutos0" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT TOP (10) vw_Princ_Prod.Id_Prod_Estq, vw_Princ_Prod.Categoria_Prod_Estoq, vw_Princ_Prod.Nome_Prod_Estq, vw_Princ_Prod.Descricao_Prod_Estoq, vw_Princ_Prod.Valor_Venda_Prod_Estoq, vw_Princ_Prod.Foto_Prod_Estoq FROM vw_Princ_Prod INNER JOIN Tb_marca ON vw_Princ_Prod.Marca_Prod_Estoq = Tb_marca.Nome_marca WHERE (Tb_marca.Id_marca = @Param1) AND (vw_Princ_Prod.Qtd_Prod_Estoq &gt; 0) AND (vw_Princ_Prod.Tipo_Venda &lt;&gt; 2) ORDER BY NEWID()">
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="" Name="Param1" QueryStringField="Id_marca" />
            </SelectParameters>
        </asp:SqlDataSource>
        

                <asp:DataList ID="DataList1" runat="server" BorderColor="Black" DataSourceID="dsprodutos0" RepeatColumns="3" CellPadding="0" Height="179px" RepeatDirection="Horizontal" Width="593px">
                    <ItemTemplate>

                          <div class="product">
								<a href='<%#Eval ("Id_Prod_Estq" , "Prod_item.aspx?Id_Prod_Estq={0}") %>' title='<%# Eval("Nome_Prod_Estq") %>'>
									<span class="title">
                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Nome_Prod_Estq") %>' style="font-size: medium; font-weight: bold"></asp:Label>
									</span>
                                    <asp:ImageButton ID="ImageButton2" runat="server" Height="110px" ImageUrl='<%# Eval("Foto_Prod_Estoq") %>' PostBackUrl= '<%# Eval ("Id_Prod_Estq" , "~/Prod_item.aspx?Id_Prod_Estq={0}") %>' Width="128px" />
									<span class="number">
                                      <img alt="" src="Imagens/american_express.png" style="width: 24px; height: 16px" />
                                            <img alt="" src="Imagens/mastercard.png" style="width: 24px; height: 16px" />
                                            <img alt="" src="Imagens/visa_electron.png" style="width: 24px; height: 16px" />
									</span>
									<span class="price">
                                        <span> R$</span>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("Valor_Venda_Prod_Estoq", "{0:C}") %>' style="font-size: medium; font-weight: bold"></asp:Label>
                                    </span> <br />      
                                    
								</a>
							</div>
                        
                    </ItemTemplate>
                    <SeparatorStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" VerticalAlign="Top" />
                </asp:DataList>

    </div>
</asp:Content>
