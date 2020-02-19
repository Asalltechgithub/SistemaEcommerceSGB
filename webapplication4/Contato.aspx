<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contato.aspx.cs" Inherits="WebApplication4.Contato" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    <table style="width: 100%">
        <tr>
            <td style="text-align: center">
                <h3><span style="color: #99FF33">Nome   </span></h3>
                &nbsp;<asp:TextBox ID="txtNome" runat="server" Width="173px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <h3 class="auto-style1" style="text-align: center"><span style="color: #99FF33">Email </span></h3>
                &nbsp;  <asp:TextBox ID="txtEmail" runat="server" Width="308px"></asp:TextBox>
            </td>
        </tr>
        
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td><asp:TextBox ID="txtMenssagem" runat="server" Height="214px" TextMode="MultiLine" Width="564px"></asp:TextBox></td>
        </tr>
    </table>
  
<td></td>
<br />
<asp:Button ID="btn_Enviar" runat="server" Text="Enviar" OnClick="btn_Enviar_Click" />
<br />
</asp:Content>
