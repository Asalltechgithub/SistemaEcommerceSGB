<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Prod_item.aspx.cs" Inherits="WebApplication4.Prod_item" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DataList ID="DataList1" runat="server" DataKeyField="Id_Prod_Estq" DataSourceID="dsItem" RepeatColumns="1" OnItemDataBound="DataList1_ItemDataBound1" >
        <ItemTemplate>
            &nbsp;<table style="border-style: none; width: 100%; background-image: none; font-family: 'Rockwell Extra Bold'; color: #000000; background-color: #CCCCCC;">
                <tr>
                    <td rowspan="5" style="width: 103px">&nbsp;</td>
                    <td rowspan="5" style="width: 103px; text-align: left;">
                        <asp:Label ID="Label7" runat="server" Text='<%# Eval("Id_Prod_Estq") %>' Visible="False" />
                        <br />
                        <asp:Label ID="lblTipoVenda" runat="server" Text='<%# Eval("Tipo_Venda") %>' Visible="False"></asp:Label>
                    </td>
                    <td rowspan="5">
                        <asp:Image ID="Image2" runat="server" Height="198px" ImageUrl='<%# Eval("Foto_Prod_Estoq") %>' Width="307px" />
                        <br />
                        <asp:Label ID="Descricao_Prod_EstoqLabel" runat="server" style="font-size: medium; font-weight: bold; color: #000000" Text='<%# Eval("Descricao_Prod_Estoq") %>' />
                    </td>
                    <td style="border-style: none">
                        <asp:Label ID="Nome_Prod_EstqLabel" runat="server" style="font-size: medium; font-weight: bold; color: #000000" Text='<%# Eval("Nome_Prod_Estq") %>' />
                    </td>
                </tr>
                <tr>
                    <td style="border-style: none">
                        <asp:Label ID="Marca_Prod_EstoqLabel" runat="server" style="font-size: medium; font-weight: bold; color: #000000" Text='<%# Eval("Marca_Prod_Estoq") %>' />
                    </td>
                </tr>
                <tr>
                    <td style="border-style: none">
                        <asp:Label ID="Categoria_Prod_EstoqLabel" runat="server" style="font-size: medium; font-weight: bold; color: #000000" Text='<%# Eval("Categoria_Prod_Estoq") %>' />
                    </td>
                </tr>
                <tr>
                   <td style="border-style: none">
                        R$
                        <asp:Label ID="Label2" runat="server" style="font-size: medium; font-weight: bold; color: #000000" Text='<%# Eval("Valor_Venda_Prod_Estoq", "{0:0.00}") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="border-style: none">
                        &nbsp; 
                        
                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/css/images/slide-more.png" OnClick="ImageButton1_Click" Height="65px"  /></td>
                </tr>
            </table>
            <br />
            <br />
            &nbsp;<br />&nbsp;<br />&nbsp;<br />&nbsp;<br />&nbsp;<br />:
            <br />
            <br />
        </ItemTemplate>
    </asp:DataList>
                                           
     <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
    <asp:Label ID="Label3" runat="server" Text="Label" Visible="False"></asp:Label>
    <asp:Label ID="Label4" runat="server" Text="Label" Visible="False"></asp:Label>
    <asp:Label ID="Label5" runat="server" Text="Label" Visible="False"></asp:Label>
    <asp:Label ID="Label6" runat="server" Text="Label" Visible="False"></asp:Label>


    <asp:SqlDataSource ID="dsItem" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT Id_Prod_Estq, Nome_Prod_Estq, Marca_Prod_Estoq, Categoria_Prod_Estoq, Valor_Venda_Prod_Estoq, Descricao_Prod_Estoq, Foto_Prod_Estoq, Tipo_Venda FROM Tb_Prod_Estoque WHERE (Id_Prod_Estq = @Id_Prod_Estq)" InsertCommand="INSERT INTO Tb_carrinho() VALUES ()">
       
       
       
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="1" Name="Id_Prod_Estq" QueryStringField="Id_Prod_Estq" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
