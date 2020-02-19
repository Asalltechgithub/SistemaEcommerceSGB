<%@ Page Title="" Language="C#" MasterPageFile="~/Administrativo/Adm.Master" AutoEventWireup="true" CodeBehind="Cad_Promocao.aspx.cs" Inherits="WebApplication4.Administrativo.Cad_Promocao" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table>
        <tr>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="dsPromocao" DataTextField="Nome_Prod_Estq" DataValueField="Id_Prod_Estq" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
                <asp:SqlDataSource ID="dsPromocao" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT [Id_Prod_Estq], [Nome_Prod_Estq] FROM [Tb_Prod_Estoque]"></asp:SqlDataSource>
            </td>
            <td>
                <asp:Button ID="btnSalvar" runat="server" Text="Salvar" />
            </td>
        </tr>
        <tr>
            <td style="text-align: right">

                Nome</td>
            <td>

                <asp:TextBox ID="txtNome_Produto" runat="server" Enabled="False"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td style="text-align: right">

                Preço</td>
            <td>

                phonegap<asp:TextBox ID="txt_Valor" runat="server" Enabled="False"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td>

                Foto</td>
            <td>

                <asp:Image ID="img_Prod" runat="server" Height="117px" Width="150px" />

            </td>
        </tr>
    </table>
</asp:Content>
