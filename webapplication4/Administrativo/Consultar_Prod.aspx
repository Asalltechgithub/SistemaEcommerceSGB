<%@ Page Title="" Language="C#" MasterPageFile="Adm.Master" AutoEventWireup="true" CodeBehind="Consultar_Prod.aspx.cs" Inherits="WebApplication4.Consul_Estoque" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
        <table style="width: 100%">
            <tr>
                <td style="text-align: center; " class="auto-style2">&nbsp;</td>
                <td style="height: 21px; text-align: center">
                    <h2>
                        <span style="font-weight: normal; font-family: 'Baskerville Old Face'; font-size: xx-large">Consultar Estoque</span></h2>
                </td>
            </tr>
            <tr>
                <td style="text-align: center; " class="auto-style2">&nbsp;</td>
                <td style="height: 21px; text-align: center">
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="dsCategoria" DataTextField="Nome_Categoria" DataValueField="Nome_Categoria">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="dsCategoria" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT * FROM [Tb_Categoria]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td style="text-align: center; " class="auto-style2">&nbsp;</td>
                <td style="height: 21px; text-align: left">
                    <asp:TextBox ID="txtPesquisa" runat="server" Width="199px" AutoPostBack="True"></asp:TextBox>
                    &nbsp;<asp:Button ID="btnPesquisar" runat="server" Height="21px" Text="Pesquisar"
                        Width="65px" OnClick="btnPesquisar_Click" />
                </td>
            </tr>
            <tr>
                <td style="text-align: center; " class="auto-style2">&nbsp;</td>
                <td style="height: 21px; text-align: center">
                    <hr />
                </td>
            </tr>
            <tr>
                <td style="text-align: center; " class="auto-style3">&nbsp;</td>
                <td style="height: 99px;">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" DataSourceID="dsProduto" style="text-align: center" Width="376px" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                        <Columns>
                            <asp:BoundField DataField="Nome" HeaderText="Nome" SortExpression="Nome" />
                            <asp:BoundField DataField="Marca" HeaderText="Marca" SortExpression="Marca" />
                            <asp:BoundField DataField="Qtde" HeaderText="Qtde" SortExpression="Qtde" />
                        </Columns>
                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                        <RowStyle BackColor="White" ForeColor="#003399" />
                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <SortedAscendingCellStyle BackColor="#EDF6F6" />
                        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                        <SortedDescendingCellStyle BackColor="#D6DFDF" />
                        <SortedDescendingHeaderStyle BackColor="#002876" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="dsProduto" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT Nome_Prod_Estq AS Nome, Marca_Prod_Estoq AS Marca, Qtd_Prod_Estoq AS Qtde FROM Tb_Prod_Estoque WHERE (Nome_Prod_Estq LIKE @Param1 + '%')">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="txtPesquisa" Name="Param1" PropertyName="Text" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    &nbsp;&nbsp;
                </td>
            </tr>
        </table>
   
  
</asp:Content>




