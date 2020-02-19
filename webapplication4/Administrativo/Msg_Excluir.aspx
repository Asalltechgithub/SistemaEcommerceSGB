<%@ Page Title="" Language="C#" MasterPageFile="~/Administrativo/Adm.Master" AutoEventWireup="true" CodeBehind="Msg_Excluir.aspx.cs" Inherits="WebApplication4.Administrativo.Msg_Excluir" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table style="width: 100%">
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td> 
                <h2>Produto Excluido com sucesso </h2>
            </td>
            <td>
                <asp:Button ID="BtnVoltar" runat="server" Text="Voltar para produtos" OnClick="BtnVoltar_Click" /></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>