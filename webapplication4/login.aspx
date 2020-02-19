<%@ Page Title="" Language="C#" MasterPageFile="Site.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebApplication4.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <table style="width: 100%; height: 89px; font-size: medium; color: #000000; font-family: Calibri; background-color: #CCCCCC;">
    <tr>
        <td style="height: 18px">
            </td>
        <td style="width: 422px; height: 18px;">
            </td>
        <td style="width: 177px; height: 18px">
            Login</td>
        <span style="color: #66FF66">
        <td style="width: 58px; height: 18px;">
            </td>
        <td style="width: 136px; height: 18px;">
            </td>
        <td style="height: 18px">
            </td>
        <td style="height: 18px;">
            &nbsp;</td>
        <td style="height: 18px">
            </td>
        <td style="height: 18px">
            </td>
        <td style="height: 18px">
            </td>
        <td style="height: 18px">
            </td>
        <td style="height: 18px">
            </td>
    </tr>
    <tr>
        <td style="height: 24px">
            </td>
        <td style="width: 422px; height: 24px;">
            &nbsp;</td>
        <td style="height: 24px; width: 177px;">
            <asp:Label ID="lblMsgLogin" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
        <td style="width: 58px; height: 24px;">
            </td>
        <td style="width: 136px; height: 24px;">
            </td>
        <td style="height: 24px">
            </td>
        <td style="height: 24px;">
            </td>
        <td style="height: 24px">
            </td>
        <td style="height: 24px">
            </td>
        <td style="height: 24px">
            </td>
        <td style="height: 24px">
            </td>
        <td style="height: 24px">
            </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td style="width: 422px; text-align: right">
            Login</td>
        <td style="text-align: left; width: 177px;">
            <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" placeholder="Usuário/e-mail" TextMode="Email" />
        </td>
        <td style="width: 58px">
            <span style="color: #66FF66"></td>
        <td style="width: 136px">
            &nbsp;</td>
        </span>
        <td style="font-style: italic; font-weight: bold">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="height: 18px">
        </td>
        <td style="height: 18px; width: 422px; text-align: right">
            Senha</td>
        <td style="height: 18px; text-align: left; width: 177px;">
            <asp:TextBox ID="txtSenha" runat="server" CssClass="form-control" placeholder="Senha" TextMode="Password" />
        </td>
        <td style="height: 18px; width: 58px">
            <span style="color: #66FF66"></td>
        <td style="height: 18px; width: 136px">
            &nbsp;</td>
        </span>
        <td style="height: 18px; font-style: italic; font-weight: bold;">
            &nbsp;</td>
        <td style="height: 18px; ">
            &nbsp;</td>
        <td style="height: 18px">
        </td>
        <td style="height: 18px">
        </td>
        <td style="height: 18px">
        </td>
        <td style="height: 18px">
        </td>
        <td style="height: 18px">
        </td>
    </tr>
    <tr>
        <td style="height: 18px">
            &nbsp;</td>
        <td style="height: 18px; width: 422px; text-align: right">
            &nbsp;</td>
        <td style="height: 18px; text-align: left; width: 177px;">
            <asp:LinkButton ID="lnkCadastrar" runat="server" PostBackUrl="~/CadCliente.aspx">Cadastrar-se</asp:LinkButton>
        </td>
        <td style="height: 18px; width: 58px">
            &nbsp;</td>
        <td style="height: 18px; width: 136px">
            &nbsp;</td>
        <td style="height: 18px; font-style: italic; font-weight: bold;">
            &nbsp;</td>
        <td style="height: 18px; ">
            &nbsp;</td>
        <td style="height: 18px">
            &nbsp;</td>
        <td style="height: 18px">
            &nbsp;</td>
        <td style="height: 18px">
            &nbsp;</td>
        <td style="height: 18px">
            &nbsp;</td>
        <td style="height: 18px">
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td style="width: 422px">
            &nbsp;</td>
        <td style="width: 177px">
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Rec_Senha.aspx">Esqueci a Senha</asp:HyperLink>
        </td>
        <td style="width: 58px">
            <span style="color: #66FF66"></td>
        <td style="width: 136px">
            &nbsp;</td>
        </span>
        <td style="font-weight: bold">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td style="width: 422px">
            &nbsp;</td>
        <td style="width: 177px">
            <asp:LinkButton ID="btnEntrar" runat="server" CssClass="btn btn-primary" OnClick="btnEntrar_Click" Text="Entrar" />
        </td>
        <td style="width: 58px">
            <span style="color: #66FF66"></td>
        <td style="width: 136px">
            &nbsp;</td>
        </span>
        <td style="font-style: italic; font-weight: bold">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td style="width: 422px">
            <span style="color: #66FF66"></td>
        <td style="width: 177px">
            <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>
        </td>
        <td style="width: 58px">
            &nbsp;</td>
        <td style="width: 136px">
            &nbsp;</td>
        </span>
        <td style="font-style: italic; font-weight: bold">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td style="width: 422px">
            <span style="color: #66FF66"></td>
        <td style="width: 177px">
            &nbsp;</td>
        <td style="width: 58px">
            &nbsp;</td>
        <td style="width: 136px">
            &nbsp;</td>
        <td>
            </span></td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td style="width: 422px">
            <span style="color: #66FF66"></td>
        <td style="width: 177px">
            &nbsp;</td>
        <td style="width: 58px">
            &nbsp;</td>
        <td style="width: 136px">
            &nbsp;</td>
        <td style="font-weight: bold">
            &nbsp;</td>
        <td>
            </span></td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td colspan="5">
            <asp:Label ID="Label2" runat="server" Text="Label" Visible="False"></asp:Label>
            <asp:Label ID="Label3" runat="server" Text="Label" Visible="False"></asp:Label>
            <asp:Label ID="Label4" runat="server" Text="Label" Visible="False"></asp:Label>
            <asp:Label ID="Label5" runat="server" Text="Label" Visible="False"></asp:Label>
            <asp:Label ID="Label6" runat="server" Text="Label" Visible="False"></asp:Label>
            <asp:Label ID="Label7" runat="server" Text="Label" Visible="False"></asp:Label>
            <asp:Label ID="Label8" runat="server" Text="Label" Visible="False"></asp:Label>
            <asp:Label ID="Label9" runat="server" Text="Label" Visible="False"></asp:Label>
            <asp:Label ID="Label10" runat="server" Text="Label" Visible="False"></asp:Label>
            <asp:Label ID="Label11" runat="server" Text="Label" Visible="False"></asp:Label>
            <asp:Label ID="Label12" runat="server" Text="Label" Visible="False"></asp:Label>
            <asp:Label ID="Label13" runat="server" Text="Label" Visible="False"></asp:Label>
            <asp:Label ID="Label14" runat="server" Text="Label" Visible="False"></asp:Label>
            <asp:Label ID="Label15" runat="server" Text="Label" Visible="False"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>


</asp:Content>

