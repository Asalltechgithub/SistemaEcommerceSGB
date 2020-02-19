<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pre_venda.aspx.cs" Inherits="WebApplication4.Pre_venda" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function PermiteSomenteNumeros(event) {
            var charCode = (event.which) ? event.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
      </script>
     <asp:DataList ID="DataList1" runat="server" DataKeyField="Id_Prod_Estq" DataSourceID="dsItem" RepeatColumns="1" OnItemDataBound="DataList1_ItemDataBound1" Height="185px" >
        <ItemTemplate>
            &nbsp;<table style="border-style: none; width: 100%; background-image: none; font-family: 'Rockwell Extra Bold'; color: #000000; background-color: #CCCCCC;">
                <tr>
                    <td rowspan="6" style="width: 103px">&nbsp;</td>
                    <td rowspan="6" style="width: 103px; text-align: left;">
                        <asp:Label ID="Label7" runat="server" Text='<%# Eval("Id_Prod_Estq") %>' Visible="False" />
                        <br />
                        <asp:Label ID="lblTipoVenda" runat="server" Text='<%# Eval("Tipo_Venda") %>' Visible="False"></asp:Label>
                    </td>
                    <td rowspan="6">
                        <asp:Image ID="Image2" runat="server" Height="198px" ImageUrl='<%# Eval("Foto_Prod_Estoq") %>' Width="307px" />
                        <br />
                        <asp:Label ID="Descricao_Prod_EstoqLabel" runat="server" style="font-size: medium; font-weight: bold; color: #000000" Text='<%# Eval("Descricao_Prod_Estoq") %>' />
                    </td>
                    <td style="border-style: none">
                        <asp:Label ID="Nome_Prod_EstqLabel" runat="server" style="font-size: medium; font-weight: bold; color: #000000" Text='<%# Eval("Nome_Prod_Estq") %>' />
                    </td>
                </tr>
                <tr>
                    <td style="border-style: none; height: 30px;">
                        <asp:Label ID="Marca_Prod_EstoqLabel" runat="server" style="font-size: medium; font-weight: bold; color: #000000" Text='<%# Eval("Marca_Prod_Estoq") %>' />
                    </td>
                </tr>
                <tr>
                    <td style="border-style: none">
                        <asp:Label ID="Categoria_Prod_EstoqLabel" runat="server" style="font-size: medium; font-weight: bold; color: #000000" Text='<%# Eval("Categoria_Prod_Estoq") %>' />
                    </td>
                </tr>
                <tr>
                    <td style="border-style: none">&nbsp;</td>
                </tr>
                <tr>
                   <td style="border-style: none">
                        R$
                        <asp:Label ID="Label2" runat="server" style="font-size: medium; font-weight: bold; color: #000000" Text='<%# Eval("Valor_Venda_Prod_Estoq", "{0:0.00}") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="border-style: none">
                        &nbsp; 
                        
                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/css/images/slide-more.png" OnClick="ImageButton1_Click" Height="56px" Width="172px"  /></td>
                </tr>
            </table>
            <br />
            <br />
            &nbsp;<br />&nbsp;<br />&nbsp;<br />&nbsp;<br />&nbsp;<br />:
            <br />
            <br />
        </ItemTemplate>
    </asp:DataList>

                                           
     <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
    <asp:Label ID="Label3" runat="server" Text="Label" Visible="False"></asp:Label>
    <asp:Label ID="Label4" runat="server" Text="Label" Visible="False"></asp:Label>
    <asp:Label ID="Label5" runat="server" Text="Label" Visible="False"></asp:Label>
    <asp:Label ID="Label6" runat="server" Text="Label" Visible="False"></asp:Label>


    <asp:SqlDataSource ID="dsItem" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT Id_Prod_Estq, Nome_Prod_Estq, Marca_Prod_Estoq, Categoria_Prod_Estoq, Valor_Venda_Prod_Estoq, Descricao_Prod_Estoq, Foto_Prod_Estoq, Tipo_Venda, Qtd_Prod_Estoq FROM Tb_Prod_Estoque WHERE (Id_Prod_Estq = @Id_Prod_Estq) " InsertCommand="INSERT INTO Tb_carrinho() VALUES ()">
       
       
       
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="1" Name="Id_Prod_Estq" QueryStringField="Id_Prod_Estq" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:Panel ID="Panel1" runat="server">
         <table style="font-size: small"><tr>
         <td style="border-style: inherit; background-color: #FFFFFF; height: 32px; font-size: small; font-weight: 700;">
         Valor total da Compra: R$   <asp:Label ID="lblValorTotal" runat="server" Text="Label"></asp:Label>
        </td>
            <td style="font-style: italic; height: 32px; color: #FFFFFF; font-size: small;">
                <strong>Quantidade :&nbsp; </strong></td>
             
             <td>
                    <asp:TextBox ID="txtQTd" runat="server" AutoPostBack="True" onkeypress="return PermiteSomenteNumeros(event);" OnTextChanged="txtQTd_TextChanged" Text='<%# Eval("Qtd_Prod_Estoq") %>' style="font-size: small"></asp:TextBox>
             </td>
         </tr>
             <tr>
                 <td style="border-style: inherit; background-color: #FFFFFF; height: 32px; font-size: medium; font-weight: 700;">
                     <asp:Label ID="lblForma_de_Pagamento" runat="server" Text="Forma de Pagamento" Visible="False" style="font-size: small" />
                     <asp:DropDownList ID="ddlForma_de_pagamento" runat="server" AutoPostBack="True" DataSourceID="dsForma_de_pagamento" DataTextField="Tipo_Pagamento" DataValueField="Id_Forma_de_Pagamento" style="font-size: small">
                     </asp:DropDownList>
                 </td>
                 <td style="font-style: italic; " rowspan="3">&nbsp;<br /> </td>
                 <td>
                     <asp:Label ID="LblNunCartao" runat="server" Text=" Numero do seu Cartão" Visible="False" style="color: #FFFFFF; font-weight: 700; background-color: #000000"></asp:Label>
                     <br />
                     &nbsp;<asp:TextBox ID="txtNun_Cartao" runat="server" Height="16px" Visible="False" Width="162px" style="font-size: small"></asp:TextBox>
                     <br />
                 </td>
             </tr>
             <tr>
        <td style="border-style: none; background-color: #FFFFFF; height: 32px; font-size: small;">
            <b>Valor do Frete: R$<asp:Label ID="lblVal_Frete" runat="server"></asp:Label>
            </b>
        </td>
             
                 <asp:Panel ID="Panelcartao" runat="server" Visible="False">
                 <td style="font-weight: 700; font-size: medium; background-color: #FFFFFF">&nbsp;&nbsp; Parcelas
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
                            &nbsp; R$ <asp:Label ID="lblVal_Parcela" runat="server" Text="0"></asp:Label>
                            <br />
                            Bandeira&nbsp;&nbsp;
                            <asp:DropDownList ID="ddlBandeira" runat="server" Visible="False">
                                <asp:ListItem>American Express</asp:ListItem>
                                <asp:ListItem>Cielo</asp:ListItem>
                                <asp:ListItem>Master Card</asp:ListItem>
                                <asp:ListItem>Visa</asp:ListItem>
                            </asp:DropDownList>
                     
                        </td>  
                 </asp:Panel>
             
         </tr><tr>
        <td style="border-style: none; background-color: #FFFFFF; height: 32px; font-size: small;">
            
                <b>Endereço para o Envio 
                <br />
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                    <asp:ListItem>Endereço Cadastrado</asp:ListItem>
                    <asp:ListItem Value="Opcional"></asp:ListItem>
                </asp:DropDownList>
                <br />
                Endereço&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtEndereco" runat="server" Enabled="False"></asp:TextBox>
                <br />
                CEP&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtCEP" runat="server" Enabled="False" MaxLength="10"></asp:TextBox>
                <br />
                Bairro&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="TxtBairro" runat="server"></asp:TextBox>
                <br /> UF&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtUF" runat="server"></asp:TextBox>
                <br />
                Cidade&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;<asp:TextBox ID="txtCidade" runat="server"></asp:TextBox>
                &nbsp;<br /> Destinátario<asp:TextBox ID="txtDestinatario" runat="server"></asp:TextBox>
                </b>
            
        </td>
             
             <td>
                    <asp:TextBox ID="TxtValores" runat="server" Enabled="False" Font-Bold="True" Font-Italic="True" Font-Size="Medium" Height="144px" ReadOnly="True" style="font-weight: 700; font-size: small;" TextMode="MultiLine" Width="172px"></asp:TextBox>
                 </td>
         </tr></table>

        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         
        <asp:SqlDataSource ID="dsEndereco" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT Endereco, Cidade, UF FROM Tb_Usuario WHERE (Id = @Param1)">
            <SelectParameters>
                <asp:SessionParameter Name="Param1" SessionField="Cli_ID" />
            </SelectParameters>
        </asp:SqlDataSource>
<asp:SqlDataSource ID="dsProduto" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT Cod_Pedido, Cod_prd ,cod_cli, Produto, Marca, Qtd , Categoria, Valor,  Foto ,Total FROM Tb_carrinho_Pre_Venda WHERE (cod_cli = @Param1)">
          <SelectParameters>
              <asp:SessionParameter Name="Param1" SessionField="Cli_ID" />
          </SelectParameters>
      </asp:SqlDataSource>
       
        <asp:SqlDataSource ID="dsForma_de_pagamento" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT * FROM [Tb_Forma_de_Pagamento]"></asp:SqlDataSource>
    </asp:Panel>
</asp:Content>
