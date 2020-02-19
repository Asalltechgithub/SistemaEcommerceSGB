<%@ Page Title="" Language="C#" MasterPageFile="~/Cliente/Menu_cli.Master" AutoEventWireup="true" CodeBehind="Msg_Erro.aspx.cs" Inherits="WebApplication4.Cliente.Msg_Erro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table style="width: 100%">
        <tr>
            <td>&nbsp;</td>
            <td>
                <h2>
                <asp:Label ID="LblMSG" runat="server" Text="Label"></asp:Label></h2>
                <h2>
                    <asp:Label ID="LblMSGSenha" runat="server" Text="Label"></asp:Label>
                </h2>
            </td>
            <td>
                <asp:Button ID="Btnvoltar" runat="server" Text="Voltar Para meus dados" OnClick="Btnvoltar_Click" /></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
