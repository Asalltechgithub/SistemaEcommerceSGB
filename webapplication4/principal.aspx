<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="principal.aspx.cs" Inherits="WebApplication4.principal" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server"> 

    <div id="slider">
			<div class="slider-outer">
				<div class="slider-inner shell">
					<!-- Begin Slider Items -->
					<ul class="slider-items">
						<li>
							<img src="Imagens/Imagem%20banner/ps3slide.png" alt="Slide Image 1" />
							<div class="slide-entry">
								<h2>Ps3 Super Slim </h2>
								<h3>Sed condimentum metus at risus </h3>
								<p>Maecenas eget purus arcu, in vestibulum libero. Ali-quam facilisis rhoncus eros, quis rutrum dolor tincid-unt ac. Duis vel consequat justo.</p>
							</div>
							
						</li>
						<li>
							<img src="Imagens/Imagem banner/ps4slide.png" alt="Slide Image 2" />
							<div class="slide-entry">
								<h2>Ps4 Completo</h2>
								<h3>Sed condimentum metus at risus </h3>
								<p>Maecenas eget purus arcu, in vestibulum libero. Ali-quam facilisis rhoncus eros, quis rutrum dolor tincid-unt ac. Duis vel consequat justo.</p>
							</div>
							
						</li>
						<li>
							<img src="Imagens/Imagem banner/psvitaslide.png" alt="Slide Image 3" />
							<div class="slide-entry">
								<h2>Ps Vita</h2>
								<h3>Sed condimentum metus at risus </h3>
								<p>Maecenas eget purus arcu, in vestibulum libero. Ali-quam facilisis rhoncus eros, quis rutrum dolor tincid-unt ac. Duis vel consequat justo.</p>
							</div>
							
						</li>
						<li>
							<img src="Imagens/Imagem banner/slidexbox360.png" alt="Slide Image 4" />
							<div class="slide-entry">
								<h2>XBox 360</h2>
								<h3>Sed condimentum metus at risus </h3>
								<p>Maecenas eget purus arcu, in vestibulum libero. Ali-quam facilisis rhoncus eros, quis rutrum dolor tincid-unt ac. Duis vel consequat justo.</p>
							</div>
							
						</li>
						<li>
							<img src="Imagens/Imagem banner/XOneslide.png" alt="Slide Image 5" />
							<div class="slide-entry">
								<h2>XBox One</h2>
								<h3>Sed condimentum metus at risus </h3>
								<p>Maecenas eget purus arcu, in vestibulum libero. Ali-quam facilisis rhoncus eros, quis rutrum dolor tincid-unt ac. Duis vel consequat justo.</p>
							</div>
							
						</li>
					</ul>
					<!-- End Slider Items -->
					<div class="cl">&nbsp;</div>
					<div class="slider-controls">
						
					</div>
				</div>
			</div>
			<div class="cl">&nbsp;</div>
		</div>
    

</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
      
    <div id="content">
        <div class="post">
							<h2>Bem vindo a The Globo Games<span class="title-bottom">&nbsp;</span></h2>
							
                           <a href="#" title="Featured Product 1">
							  <span class="info">
                                 <span class="title">
                                Somos uma empresa voltada ao mercado de  games  buscando o melhor atendimento e facilidade para nossos clientes 
                                     todos os nossos produtos possuem garantia de 6 meses.
                                     Nossa sede fica situada no Rio de Janeiro .
                                     trabalhamos com os melhores fornecedores .
                               
                                 </span>
                               
                              </span>
                                   </a>
						</div>
        <div id="products">
        <div>


        </div>
       
				      <asp:SqlDataSource ID="dsprodutos0" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT Id_Prod_Estq, Categoria_Prod_Estoq, Nome_Prod_Estq, Descricao_Prod_Estoq, Valor_Venda_Prod_Estoq, Foto_Prod_Estoq, Qtd_Prod_Estoq, Tipo_Venda FROM vw_Produtos_random WHERE (Qtd_Prod_Estoq &gt; @Qtd_Prod_Estoq) AND (Tipo_Venda &lt;&gt; 2)">
                          <SelectParameters>
                              <asp:Parameter DefaultValue="0" Name="Qtd_Prod_Estoq" Type="Int32" />
                          </SelectParameters>
        </asp:SqlDataSource>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
                        <asp:DataList ID="DataList1" runat="server" BorderColor="Black" DataSourceID="dsprodutos0" RepeatColumns="3" Height="157px" Width="16px" CellPadding="0" RepeatDirection="Horizontal" style="text-align: center">
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
                    
              </ContentTemplate> </asp:UpdatePanel>
		</div>
   </div>
    
</asp:Content>

   






