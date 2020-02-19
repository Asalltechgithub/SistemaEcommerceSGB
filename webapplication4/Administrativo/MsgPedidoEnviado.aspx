<%@ Page Title="" Language="C#" MasterPageFile="~/Administrativo/Adm.Master" AutoEventWireup="true" CodeBehind="MsgPedidoEnviado.aspx.cs" Inherits="WebApplication4.Administrativo.OPER.MsgPedidoEnviado" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table class="auto-style2">
        <tr>
            <td class="auto-style4"></td>
            <td class="auto-style5"></td>
            <td class="auto-style5"></td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td style="text-align: center">
                <h1 style="text-align: center">Pedido Enviado</h1>
                <br />
                <asp:LinkButton ID="LinkButton1" runat="server" Text="Volte para verificar pedidos em Confirmados" PostBackUrl="~/Administrativo/Produtos_para_Envio.aspx" OnClick="LinkButton1_Click"></asp:LinkButton>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
