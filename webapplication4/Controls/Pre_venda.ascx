<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Pre_venda.ascx.cs" Inherits="WebApplication4.Controls.Pre_venda" %>
<asp:Repeater ID="RpPre_venda" runat="server" DataSourceID="dsPre_venda">

    <ItemTemplate>
        <ul>
           
            <li>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#Eval ("Id_Tipo_Pedido" , "~/Princ_Prod_Prevenda.aspx?Id_Tipo_Pedido={0}") %>' Text='<%# Eval("Nome_tipo") %>'>
                    
                    </asp:HyperLink>
            </li>

        </ul>

    </ItemTemplate>
</asp:Repeater>
<asp:SqlDataSource ID="dsPre_venda" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT Id_Tipo_Pedido, Nome_tipo FROM vw_listar_Prevenda_menu WHERE (Nome_tipo = @Nome_tipo)">
    <SelectParameters>
        <asp:Parameter DefaultValue="Pré-Venda" Name="Nome_tipo" Type="String" />
    </SelectParameters>
</asp:SqlDataSource>