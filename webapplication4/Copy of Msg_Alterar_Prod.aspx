<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Msg_Alterar_Prod.aspx.cs" Inherits="WebApplication4.Msg_Alterar_Prod" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%">
        <tr>
            <td>&nbsp;</td>
            <td>
                <h2> Produto Alterado com Sucesso </h2>
            </td>
            <td>
                <asp:Button ID="btnVoltar" runat="server" Text="Voltar para Produtos" OnClick="btnVoltar_Click" /></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
