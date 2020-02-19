<%@ Page Title="" Language="C#" MasterPageFile="Adm.Master" AutoEventWireup="true" CodeBehind="add_categorias_marcas.aspx.cs" Inherits="WebApplication4.add_categorias_marcas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
   
    <table style="width: 100%; height: 488px;">
        <tr>
            <td style="font-size: large;" class="auto-style4">
                <br />
                <h2>
                    Adicionar Marcas &amp; Categorias</h2>
                <br />
                <br />
            </td>
            <td class="auto-style5">
                <asp:Label ID="lblModo" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <br />
                <asp:DropDownList ID="ddlM_C" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlM_C_SelectedIndexChanged">
                    <asp:ListItem>Categoria</asp:ListItem>
                    <asp:ListItem>Marca</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
                CATEGORIA<br />
                <asp:Panel ID="PnCategoria" runat="server" Enabled="False">
                    <asp:DropDownList ID="ddlCategoria" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="Nome_Categoria" DataValueField="Nome_Categoria" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:TextBox ID="txtCategoria" runat="server" Enabled="False"></asp:TextBox>
                    <br />
                    <asp:Button ID="btnNovo" runat="server" Height="31px" OnClick="btnNovo_Click" Text="Novo" Width="53px" />
                    <asp:Button ID="Button3" runat="server" Text="Salvar" Height="31px" OnClick="Button3_Click" Width="53px" />
                    <asp:Button ID="Button1" runat="server" Text="Editar" Height="31px" OnClick="Button1_Click" Width="53px" />
                    <asp:Button ID="btnExcluir" runat="server" Enabled="False" Height="31px" OnClick="btnExcluir_Click" Text="Excluir" Width="53px" />
                </asp:Panel>
                <br />
                MARCA<br />
                <asp:Panel ID="PnMarca" runat="server" Enabled="False">
                    <asp:DropDownList ID="ddlMarca" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource2" DataTextField="Nome_marca" DataValueField="Nome_marca" OnSelectedIndexChanged="ddlMarca_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:TextBox ID="txtMarca" runat="server" Enabled="False"></asp:TextBox>
                    <br />
                    <asp:Button ID="Button5" runat="server"  Text="Novo" Height="31px" Width="53px" OnClick="Button5_Click" />
                    <asp:Button ID="Button6" runat="server"  Text="Salvar" Height="31px" Width="53px" OnClick="Button6_Click" />
                    <asp:Button ID="Button2" runat="server" Text="Editar" Height="31px" Width="53px" OnClick="Button2_Click" />
                    <asp:Button ID="btnexcluir_Marca" runat="server" Text="Excluir" Height="31px" Width="53px" OnClick="Button4_Click" />
                </asp:Panel>
                <br />
                <br />
            </td>
            <td class="auto-style3">
                <br />
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td style="height: 20px; width: 254px;">
                <asp:LinkButton ID="lbAdd_Cat" runat="server" OnClick="lbAdd_Cat_Click">Add Categoria</asp:LinkButton>
           
            </td>
            <td style="height: 20px">
                <asp:LinkButton ID="lbAdd_marca" runat="server" onclick="lbAdd_Cat_Click">Add Marca</asp:LinkButton>
           
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" 
                    SelectCommand="SELECT * FROM [Tb_Categoria]">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" 
                    SelectCommand="SELECT * FROM [Tb_marca]"></asp:SqlDataSource>
            </td>
        </tr>
        </table>
   
</asp:Content>




