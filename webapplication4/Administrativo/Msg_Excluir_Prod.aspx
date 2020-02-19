<%@ Page Title="" Language="C#" MasterPageFile="Adm.Master" AutoEventWireup="true" CodeBehind="~/Administrativo/Msg_Excluir_Prod.aspx.cs" Inherits="WebApplication4.Msg_Excluir_Prod" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table style="width: 100%">
        <tr>
            <td>&nbsp;</td>
            <td>
                <h2> Produto Excluido com Sucesso </h2>
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