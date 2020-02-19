<%@ Page Title="" Language="C#" MasterPageFile="Adm.Master" AutoEventWireup="true" CodeBehind="Msg_Campo_requerido.aspx.cs" Inherits="WebApplication4.Administrativo.Msg_Campo_requerido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table style="width: 100%">
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>
            <h2 style="color: #FFFFFF">Todos os campos devem ser preenchidos !!!</h2>
        </td>
        <td>
            <asp:Button ID="BtnVoltar" runat="server" OnClick="BtnVoltar_Click" Text="Voltar Para Produtos" />
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>

