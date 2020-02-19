<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Boleto.aspx.cs" Inherits="WebApplication4.Boleto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style3 {
            width: 149px;
            height: 38px;
        }
        .auto-style4 {
        }
        .auto-style5 {
            height: 7px;
            width: 156px;
        }
        .auto-style6 {
            width: 402px;
        }
        .auto-style7 {
            width: 402px;
            font-size: xx-small;
        }
        .auto-style8 {
            width: 149px;
        }
        .auto-style9 {
            width: 227px;
        }
        .auto-style10 {
            width: 503px;
        }
        .auto-style11 {
            width: 361px;
        }
        .auto-style12 {
            width: 156px;
        }
        .auto-style13 {
            width: 550px;
        }
        .auto-style14 {
            width: 402px;
            height: 7px;
        }
        .auto-style15 {
            width: 270px;
            height: 7px;
        }
        .auto-style16 {
            font-size: xx-small;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
       
        
         <div>

              <asp:Panel ID="Panel1" runat="server" Enabled="False">
    
        <table runat="server" class="auto-style1" style="border-style: solid">
            <tr>
                <td class="auto-style4" colspan="3" style="border: medium groove #FFFF00;">
                    <img alt="" class="auto-style3" src="001.jpg" /></td>
                <td class="auto-style4" colspan="6" style="border: medium groove #FFFF00; text-align: right;">
                    <asp:TextBox ID="txtCOd_principal" runat="server" Width="449px" EnableTheming="False" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style6" colspan="8" style="border-style: inset; border-width: thin; font-size: xx-small;">Local de pagamento<br />
                    <asp:TextBox ID="txtLocal_pag" runat="server" Width="383px" EnableTheming="False"></asp:TextBox>
                </td>
                <td class="auto-style12" style="border-style: inset; border-width: thin; font-size: xx-small;">Vencimento
                    <asp:TextBox ID="txtVencimento" runat="server" Height="16px" style="text-align: center" Width="105px" EnableTheming="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style7" colspan="8" style="border-style: inset; border-width: thin">cedente<br />
                    <asp:TextBox ID="txtCedende" runat="server" Width="386px" EnableTheming="False"></asp:TextBox>
                </td>
                <td class="auto-style12" style="border-style: inset; border-width: thin"><span class="auto-style16">Agencia Côdigo cedente</span><asp:TextBox ID="txtAgencia" runat="server" EnableTheming="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style8" style="border-style: inset; border-width: thin; font-size: xx-small;">Data&nbsp; do Docuento<br />
                    <asp:TextBox ID="txtData_documento" runat="server" EnableTheming="False"></asp:TextBox>
                </td>
                <td class="auto-style9" colspan="2" style="border-style: inset; border-width: thin; font-size: xx-small;">Nº Documento<asp:TextBox ID="txtNum_doc" runat="server" Width="116px" EnableTheming="False"></asp:TextBox>
                </td>
                <td class="auto-style11" colspan="2" style="border-style: inset; border-width: thin; font-size: xx-small;">Espécie doc<br />
                    <asp:TextBox ID="txt_Especie_doc" runat="server"  Width="157px" EnableTheming="False"></asp:TextBox>
                </td>
                <td class="auto-style10" colspan="2" style="border-style: inset; border-width: thin; font-size: xx-small;">aceite<br />
                    <asp:TextBox ID="txtAceite" runat="server" Width="19px" EnableTheming="False"></asp:TextBox>
                </td>
                <td class="auto-style13" style="border-style: inset; border-width: thin; font-size: xx-small;">Data processamento<asp:TextBox ID="txtData_proce" runat="server" EnableTheming="False"></asp:TextBox>
                </td>
                <td class="auto-style12" style="border-style: inset; border-width: thin"><span class="auto-style16">Nosso numero</span><asp:TextBox ID="txtNosso_numero" runat="server" EnableTheming="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style15" colspan="2" style="border-style: inset; border-width: thin; font-size: xx-small;">cod do Banco<asp:TextBox ID="txtCod_banco" runat="server" BackColor="#FFFF66" Width="187px" EnableTheming="False"></asp:TextBox>
                </td>
                <td class="auto-style15" colspan="2" style="border-style: inset; border-width: thin; font-size: xx-small;">Carteira<asp:TextBox ID="txtCarteira" runat="server" EnableTheming="False"></asp:TextBox>
                </td>
                <td class="auto-style14" colspan="2" style="border-style: inset; border-width: thin; font-size: xx-small;">Espécie<asp:TextBox ID="txtEspecie" runat="server" EnableTheming="False"></asp:TextBox>
                </td>
                <td class="auto-style14" style="border-style: inset; border-width: thin; font-size: xx-small;">
                    Quantidade<asp:TextBox ID="txtQtd" runat="server" EnableTheming="False"></asp:TextBox>
                </td>
                <td class="auto-style14" style="border-style: inset; border-width: thin; font-size: xx-small;">
                    Valor<asp:TextBox ID="txtValor" runat="server" EnableTheming="False"></asp:TextBox>
                </td>
                <td class="auto-style5" style="border-style: inset; border-width: thin"><span class="auto-style16">(=)Valor documento</span><asp:TextBox ID="txtValor_Documento" runat="server" EnableTheming="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style6" colspan="8" rowspan="5" style="border-style: inset; border-width: thin">
                    <asp:TextBox ID="txt_descricao" runat="server" BorderColor="Yellow" Height="166px" Width="475px" EnableTheming="False"></asp:TextBox>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <asp:Image ID="Image1" runat="server" Height="45px" ImageUrl="~/009_o_que_e_boleto_bancario.jpg" Width="381px" />
                    <br />
                </td>
                <td class="auto-style12" style="border-style: inset; border-width: thin"><span class="auto-style16">(-)Desconto</span><asp:TextBox ID="txtDesconto" runat="server" EnableTheming="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style12" style="border-style: inset; border-width: thin; font-size: xx-small;">Outras deduções<asp:TextBox ID="txtOutras_deducoes" runat="server" EnableTheming="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style12" style="border-style: inset; border-width: thin; font-size: xx-small;">(+)Mora\Multa\Juros<asp:TextBox ID="txtMulta_juros" runat="server" EnableTheming="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style12" style="border-style: inset; border-width: thin; font-size: xx-small;">(+)Outros acrecimos<asp:TextBox ID="txt_acrecimos" runat="server" EnableTheming="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style12" style="border-style: inset; border-width: thin"><span class="auto-style16">(=)Valor Cobrado</span><asp:TextBox ID="txtValor_cobrado" runat="server" EnableTheming="False"></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>
    </div>
        <p style="text-align: center">
            &nbsp;</p>
    </form>
</body>
</html>
