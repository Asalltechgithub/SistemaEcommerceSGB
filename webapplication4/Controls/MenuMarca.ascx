<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuMarca.ascx.cs" Inherits="WebApplication4.Controls.MenuMarca" %>
<asp:Repeater ID="RpCategoria" runat="server" DataSourceID="dsMarca">

    <ItemTemplate>
        <ul>
           
            <li>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#Eval ("Id_marca" , "~/Princ_Prod_marca.aspx?Id_marca={0}") %>' Text='<%# Eval("Nome_marca") %>'>
                    
                    </asp:HyperLink>
            </li>

        </ul>

    </ItemTemplate>
</asp:Repeater>
<asp:SqlDataSource ID="dsMarca" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT * FROM [Tb_marca]"></asp:SqlDataSource>