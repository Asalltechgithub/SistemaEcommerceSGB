<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrinho_de_Compras.aspx.cs" Inherits="WebApplication4.Carrinho_de_Compras" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="validacao.js" type="text/javascript"></script>

    
            <div>
                <h3>Carrinho</h3>


                </script>  
                <asp:Repeater ID="rptProdutos" runat="server" DataSourceID="dsProduto" OnItemDataBound="rptProdutos_ItemDataBound">

                    <HeaderTemplate>
                        <table border="0" cellpadding="2" cellspacing="1" summary="The globo games" style="border-style: none; border-width: thick; font-size: medium; color: #FFFFFF; background-color: #C0C0C0; font-weight: bold; background-image: url('css/images/wrapper-bg.png'); font-style: italic; font-family: 'Franklin Gothic Medium Cond';">
                            <caption>
                            </caption>
                            <thead>
                                <tr>
                                    <th></th>
                                    <th></th>
                                    <th>Produto
                                    </th>
                                    <th>Marca
                                    </th>
                                    <th>Categoria
                                    </th>
                                    <th>Valor
                                    </th>
                                    <th>Qtd
                                    </th>
                                    <th>Foto
                                    </th>
                                    <th>Total
                                    </th>
                                    <th>+
                                    </th>
                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Label ID="Lblcodpedido" runat="server" Text='<%# Eval("Cod_Pedido") %>' Visible="False" />
                            </td>
                            <td>
                                <asp:Label ID="Lblcodprod" runat="server" Text='<%# Eval("Cod_prd") %>' Visible="False" />
                            </td>

                            <td>&nbsp;
                                <asp:Label ID="lblNomeProd" runat="server" Text='<%# Eval("Produto") %>' />
                            </td>
                            <td>&nbsp; 
                                <asp:Label ID="lblMarca" runat="server" Text='<%# Eval("Marca") %>' />
                            </td>
                            <td>&nbsp; 
                                <asp:Label ID="lblCategoria" runat="server" Text='<%# Eval("Categoria") %>' />
                            </td>
                            <td>&nbsp;   R$
                                <asp:Label ID="lblPrecoVenda" runat="server" Text='<%# Eval("Valor","{0:0.00}") %>' />
                            </td>

                            <td>&nbsp;     
                                <asp:TextBox ID="txtQtde" runat="server" Text='<%# Eval("Qtd") %>' Width="40px"
                                    AutoPostBack="true" Enabled="true" onkeypress="return PermiteSomenteNumeros(event);" OnTextChanged="txtQtde_TextChanged" />

                            </td>
                            <td>&nbsp;
                                <asp:Image ID="ImgProd" runat="server" ImageUrl='<%# Eval("Foto") %>' Width="100px" Height="94px" />
                            </td>
                            <td>&nbsp;  R$
                                <asp:Label ID="lblTotal" runat="server" Text='<%# Eval("Total", "{0:0.00}")%>' />
                            </td>
                            <td>&nbsp; 
                                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Delete</asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        <tfoot>
                            <tr>
                            </tr>
                        </tfoot>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>

                <h2>

                <asp:Label ID="lblMsgCar_vazio" runat="server" Visible="False" style="text-align: center; font-weight: 700; color: #99FF33"></asp:Label>
               
                </h2>
               
                <table>
                    <tr>
                        <td colspan="4" style="font-weight: 700; background-color: #FFFFFF">Volumes:
                                    <asp:Label ID="lblQtdeVol" runat="server" Text="0"></asp:Label>
                            &nbsp; Valor Total: R$
                                    <asp:Label ID="lblValorTotal" runat="server" Text="0,00"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar Carrinho" CommandName="Cancelar"
                                OnClientClick="return confirm('Confirma Cancelar esse Carrinho?')" OnClick="btnCancelar_Click" />
                        </td>
                        <td colspan="3">
                            <asp:Button ID="btnFinalizar" runat="server" Text="Finalizar Carrinho" CommandName="Finalizar"
                                OnClientClick="return confirm('Confirma Finalizar esse Carrinho?')" OnClick="btnFinalizar_Click" />
                        </td>

                    </tr>

                </table>
                <asp:Panel ID="Panelcartao" runat="server" Height="57px" Visible="False">
                 <table style="border-style: double; border-width: thin">
                   
                      <tr>

                        <td colspan="2"> <asp:Label ID="LblNunCartao" runat="server" Text=" Numero do seu Cartão" Visible="False" style="font-weight: 700; background-color: #FFFFFF"></asp:Label>
                         </td>
                        <td colspan="2"> 
                            <asp:TextBox ID="txtNun_Cartao"  runat="server" onkeypress="return PermiteSomenteNumeros(event);" MaxLength="19" Height="16px" Visible="False" Width="162px"></asp:TextBox>
                         </td>
                           <td style="background-color: #FFFFFF" >Digito Verificador <asp:TextBox ID="txtDigitoverificador" runat="server" Width="50px"></asp:TextBox> </td>
                          
                        </tr>
                     <tr>
                          <td style="background-color: #FFFFFF">  Parcelas</td>
                         <td style="background-color: #FFFFFF">
                            <asp:DropDownList ID="ddlParcelas" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlParcelas_SelectedIndexChanged" Visible="False">
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem>6</asp:ListItem>
                                <asp:ListItem>7</asp:ListItem>
                                <asp:ListItem>8</asp:ListItem>
                                <asp:ListItem>9</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>11</asp:ListItem>
                                <asp:ListItem>12</asp:ListItem>
                                </asp:DropDownList>

                         </td>
                                <td style="background-color: #FFFFFF"> 
                                R$  <asp:Label ID="lblVal_Parcela" runat="server" Text="0"></asp:Label>
                                  </td>
                                <td style="background-color: #FFFFFF">   </td>
                                     <td style="background-color: #FFFFFF">
                                         Bandeira                                     
                                         <asp:DropDownList ID="ddlBandeira" runat="server" Visible="False">
                                             <asp:ListItem>American Express</asp:ListItem>
                                             <asp:ListItem>Cielo</asp:ListItem>
                                             <asp:ListItem>Master Card</asp:ListItem>
                                             <asp:ListItem>Visa</asp:ListItem>
                                         </asp:DropDownList>
                                     </td>
                                 </tr>
                          
                  
                         

                        
                  

                </table>
                   </asp:Panel>

                <table>
                    <tr>
                        <td style="border-style: inherit; background-color: #FF3300; height: 32px;">
                            <asp:Label ID="lblForma_de_Pagamento" runat="server" Text="Forma de Pagamento" Visible="False" />
                            <asp:DropDownList ID="ddlForma_de_pagamento" runat="server" AutoPostBack="True" DataSourceID="dsForma_de_pagamento" DataTextField="Tipo_Pagamento" DataValueField="Id_Forma_de_Pagamento" Visible="False"></asp:DropDownList>
                        </td>
                        <td style="font-style: italic; height: 32px;">&nbsp;<br />

                        </td>

                        
                    </tr>
                    <tr>
                        <td style="border-style: none; background-color: #CCFFCC; height: 32px;">Valor do Frete: R$<asp:Label ID="lblVal_Frete" runat="server"></asp:Label>
                        </td>
                       
                             <td style="font-style: italic; height: 32px;">
                    
                         


                  </td>
                    </tr>
                    <tr>
                        <td style="border-style: none; background-color: #CCFFCC; height: 32px;">

                            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                <asp:ListItem>Endereço Cadastrado</asp:ListItem>
                                <asp:ListItem Value="Opcional"></asp:ListItem>
                            </asp:DropDownList>
                            <br />

                            Novo Endereço para envio(Opcional)<br />
                            <br />
                            Endereço&nbsp;&nbsp;
                <asp:TextBox ID="txtEndereco" runat="server" Enabled="False"></asp:TextBox>
                            <br />
                            CEP&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtCEP" runat="server" MaxLength="10" Enabled="False"></asp:TextBox>
                            <br />
                            UF&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtUF" runat="server"></asp:TextBox>
                            &nbsp;<br />
                            Cidade&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtCidade" runat="server"></asp:TextBox>
                            &nbsp;<br />
                            Bairro&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="txtBairro" runat="server"></asp:TextBox>
                            <br />
                            Destinátario<asp:TextBox ID="txtDestinatario" runat="server"></asp:TextBox>
                            Endereço para o Envio
            
                <br />

                        </td>
                        <td style="font-style: italic; height: 32px;">&nbsp;</td>

                        <td>
                            <asp:TextBox ID="TxtValores" runat="server" Enabled="False" Font-Bold="True" Font-Italic="True" Font-Size="Medium" Height="357px" ReadOnly="True" TextMode="MultiLine" Width="172px"></asp:TextBox>
                        </td>
                    </tr>
                </table>

                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         
        <asp:SqlDataSource ID="dsProduto" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT Cod_Pedido, Cod_prd ,cod_cli, Produto, Marca, Qtd , Categoria, Valor,  Foto ,Total FROM Tb_carrinho WHERE (cod_cli = @Param1)">
            <SelectParameters>
                <asp:SessionParameter Name="Param1" SessionField="Cli_ID" />
            </SelectParameters>
        </asp:SqlDataSource>

                <asp:SqlDataSource ID="dsForma_de_pagamento" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT * FROM [Tb_Forma_de_Pagamento]"></asp:SqlDataSource>

            </div>
       

</asp:Content>
