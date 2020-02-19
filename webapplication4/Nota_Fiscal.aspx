<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Nota_Fiscal.aspx.cs" Inherits="WebApplication4.Nota_Fiscal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
  
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {            width: 973px;
        }
        .auto-style3 {
            width: 82px;
        }
        .auto-style4 {
            width: 162px;
        }
        .auto-style5 {
            width: 502px;
        }
        .auto-style6 {
            height: 16px;
        }
        .auto-style7 {
            height: 16px;
            width: 314px;
        }
        .auto-style9 {
            width: 128px;
        }
        .auto-style10 {
            height: 92px;
        }
        .auto-style11 {
            height: 92px;
            width: 673px;
        }
        .auto-style12 {
            width: 674px;
        }
        .auto-style13 {
            height: 103px;
        }
        .auto-style14 {
            width: 130px;
        }
    </style>
  
</head>
<body>
    <form id="form1" runat="server">
       
             
    <div>
    <table style="border-style: groove; border-width: thin">
        <tr>
            <td>
        <table class="auto-style1" style="background-color: #CCFFFF">
            <tr>
                <td colspan="2" style="border-style: solid; border-width: thin">
                    <asp:Image ID="Image1" runat="server" Height="76px" ImageUrl="~/Imagens/Logotipos/logo.png" Width="224px" />
                </td>
                <td colspan="2" style="border-style: solid; border-width: thin">N:&nbsp;
                    <asp:TextBox ID="TextBox1" runat="server" Width="641px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4" style="border: medium groove #000000">&nbsp;</td>
                <td class="auto-style3" style="border: medium groove #000000">&nbsp;</td>
                <td style="border: medium groove #000000">&nbsp;</td>
                <td style="border: medium groove #000000">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4" style="border: thin groove #000000"></td>
                <td class="auto-style3" style="border: thin groove #000000"></td>
                <td style="border: thin groove #000000"></td>
                <td style="border: thin groove #000000"></td>
            </tr>
            </table>
            <table>
            <tr>
                <td class="auto-style2" colspan="4" style="border-style: groove; border-width: thin; background-color: #99CCFF;">Nome do Destinatário :
                    <asp:TextBox ID="txtDestinatario" runat="server" Width="791px"></asp:TextBox>
                </td>
            </tr>
            </table>
    
        <table class="auto-style1">
            <tr>
                <td class="auto-style5" style="border: thin groove #000000">Nome /Razão social:<asp:TextBox ID="txtRazao_social" runat="server" Width="362px"></asp:TextBox>
                </td>
                <td style="border: thin groove #000000">CNPJ/CPF: 
                    <asp:TextBox ID="Txt_CNPJ" runat="server"></asp:TextBox>
                </td>
                <td style="border: thin groove #000000">Data de Emissão:<asp:TextBox ID="txtDatad_emi" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <table class="auto-style1">
            <tr>
                <td style="border-style: double; border-width: thin" class="auto-style7">Endereço :<asp:TextBox ID="txtEndereco" runat="server" Width="229px"></asp:TextBox>
                </td>
                <td style="border-style: double; border-width: thin" class="auto-style6">Bairro /Distrito:<asp:TextBox ID="txtBairro" runat="server"></asp:TextBox>
                </td>
                <td style="border-style: double; border-width: thin" class="auto-style6">CEP:<asp:TextBox ID="txtCEP" runat="server"></asp:TextBox>
                </td>
                <td style="border-style: double; border-width: thin" class="auto-style6">Data de Saida:<asp:TextBox ID="txtDatadeSaida" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="border-style: double; border-width: thin" class="auto-style7">Municipio:<br />
                    <asp:TextBox ID="txtMunicipio" runat="server"></asp:TextBox>
                </td>
                <td style="border-style: double; border-width: thin" class="auto-style6">UF: <br />
                    <asp:TextBox ID="txtUF" runat="server"></asp:TextBox>
                </td>
                <td style="border-style: double; border-width: thin" class="auto-style6">Inscrição Estadual:<asp:TextBox ID="txtInscricaoEstadual" runat="server"></asp:TextBox>
                </td>
                <td style="border-style: double; border-width: thin" class="auto-style6">Hora de Saida:<asp:TextBox ID="txtHoraSaida" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    
        <table class="auto-style1">
            <tr>
                <td class="auto-style9" style="border-style: groove; border-width: thin; background-color: #000000; color: #FFFFFF;">
                    Numero do Pedido<br />
                    <asp:Label ID="lblNum_Pedido" runat="server"></asp:Label>
                </td>
                <td style="border-style: groove; border-width: thin; background-color: #000000; color: #FFFFFF; text-align: center;" class="auto-style12">Descrição dos Produtos<br />
                </td>
                <td style="border-style: groove; border-width: thin; background-color: #000000; color: #FFFFFF;">Total da compra :
                    <asp:TextBox ID="txtValor_total" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <table class="auto-style1">
            <tr>
                <td class="auto-style14"></td>
                <td class="auto-style11" style="border-style: groove">
                     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                         <Columns>
                             <asp:BoundField DataField="Cod_prd" HeaderText="Cod_prd" SortExpression="Cod_prd" />
                             <asp:BoundField DataField="Produto" HeaderText="Produto" SortExpression="Produto" />
                             <asp:BoundField DataField="Categoria" HeaderText="Categoria" SortExpression="Categoria" />
                             <asp:BoundField DataField="Marca" HeaderText="Marca" SortExpression="Marca" />
                             <asp:BoundField DataField="Qtd" HeaderText="Qtd" SortExpression="Qtd" />
                             <asp:BoundField DataField="Valor" HeaderText="Valor" SortExpression="Valor" DataFormatString="{0:C}" />
                             <asp:BoundField DataField="Total" HeaderText="Total" ReadOnly="True" SortExpression="Total" DataFormatString="{0:c}" />
                         </Columns>
                     </asp:GridView>
                     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT DISTINCT lh.Cod_prd, lh.Produto, lh.Categoria, lh.Marca, lh.Qtd, lh.Valor, lh.Total FROM Tb_lista_Historico AS lh INNER JOIN Tb_Pedido AS p ON lh.Cod_Pedido = p.Id_Pedido WHERE (lh.Cod_Pedido = @Param1)">
                         <SelectParameters>
                             <asp:ControlParameter ControlID="lblNum_Pedido" Name="Param1" PropertyName="Text" />
                         </SelectParameters>
                     </asp:SqlDataSource>

                </td>
                <td class="auto-style10" style="border-style: groove">
                     &nbsp;</td>
            </tr>
        </table>
                <table class="auto-style1">
                    <tr>
                        <td style="border: thick double #000000;">Valor do frete :<asp:Label ID="lblValorfrete" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td style="border: thick double #000000;">&nbsp;</td>
                        <td style="border: thick double #000000;">&nbsp;</td>
                        <td style="border: thick double #000000;">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style13" colspan="4" style="border: thick double #000000;">Observações :<br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style13" colspan="4" style="border: thick double #000000; text-align: center;">Ass: ______________________________________<br />
                            <asp:Label ID="lbl_Nome_Cliente" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                </table>
    </td>

        </tr>

    </table>
        <br />
    
    </div>
    </form>
</body>
</html>
