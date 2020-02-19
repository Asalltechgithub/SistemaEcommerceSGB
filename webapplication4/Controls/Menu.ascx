<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Menu.ascx.cs" Inherits="WebApplication4.Menu" %>


<asp:Repeater ID="RpCategoria" runat="server" DataSourceID="dsCategoria">

    <ItemTemplate>
        <ul>
           
            <li>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#Eval ("Id_Categoria" , "~/Princ_Prod.aspx?Id_Categoria={0}") %>' Text='<%# Eval("Nome_Categoria") %>'>
                    
                    </asp:HyperLink>
            </li>

        </ul>

    </ItemTemplate>
</asp:Repeater>
<asp:SqlDataSource ID="dsCategoria" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT Id_Categoria, Nome_Categoria FROM vw_listar_categoria_menu"></asp:SqlDataSource>

