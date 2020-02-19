<%@ Page Title="" Language="C#" MasterPageFile="Adm.Master" AutoEventWireup="true" CodeBehind="Cad_Fornecedor.aspx.cs" Inherits="WebApplication4.Cad_Fornecedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
    
            <script type="text/javascript" src="../validacao.js">


            </script>
            
    <table style="width: 100%">
        <tr>
            <td colspan="5">
                <h2>
                    Cadastro de Fornecedor</h2>
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
            <td style="width: 39px">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Label ID="lbl_message" runat="server" Text="Label"></asp:Label>
            </td>
            <td>
                <asp:Button ID="btnNovo" runat="server" Text="Novo" onclick="btnNovo_Click" />
                <asp:Button ID="btnSalvar" runat="server" Text="Salvar" 
                 OnClientClick="return confirm('Deseja Salvar ?');"   onclick="btnSalvar_Click" Enabled="False" />
                <asp:Button ID="btnEditar" runat="server" Text="Alterar" onclick="btnEditar_Click" Enabled="False" />
                <asp:Button ID="btnExcluir" runat="server" Text="Excluir" onclick="btnExcluir_Click" OnClientClick="return confirm('Deseja Excluir ?');" Enabled="False" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" onclick="btnCancelar_Click" />
            </td>
            <td style="width: 8px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
&nbsp;&nbsp;&nbsp;</td>
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
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td style="width: 39px">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Codigo</td>
            <td>
                <asp:DropDownList ID="ddlCodFornecedor" runat="server" 
                    DataSourceID="SqlDataSource4" DataTextField="Id_Fornecedor" 
                    DataValueField="Id_Fornecedor">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" 
                    SelectCommand="SELECT [Id_Fornecedor] FROM [Tb_Fornecedor]">
                </asp:SqlDataSource>
            </td>
            <td>
                <asp:SqlDataSource ID="SqlDataSource5" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" 
                    SelectCommand="SELECT [For_Status] FROM [Tb_Fornecedor]">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" 
                    SelectCommand="SELECT [Status] FROM [Tb_Status]"></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" 
                    
                    
                    SelectCommand="SELECT [Id_Fornecedor], [For_Razao_Social], [For_CNPJ], [For_Telefone], [For_Email], [For_CEP], [For_Endereco], [For_UF], [For_Cidade], [For_Status] FROM [Tb_Fornecedor]">
                </asp:SqlDataSource>
            </td>
            <td style="width: 8px">
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
            <td style="width: 39px">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_Modo" runat="server"></asp:Label>
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
            <td style="width: 39px">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Razão Social</td>
            <td>
                <asp:TextBox ID="txtRazao_social" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td style="width: 8px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td colspan="12" rowspan="6">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                CNPJ</td>
            <td>
                <asp:TextBox ID="txtCnpj" runat="server" MaxLength="18" onkeypress="return PermiteSomenteNumeros(event);" onkeyup="MascaraCNPJ(this,event)" ></asp:TextBox>
            </td>
            <td>
                </td>
            <td class="auto-style2">
                &nbsp;</td>
            <td>
                
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Status</td>
            <td class="auto-style4">
                <asp:DropDownList ID="ddlStatus" runat="server" DataSourceID="SqlDataSource2" 
                    DataTextField="Status" DataValueField="Status">
                </asp:DropDownList>
                </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Telefone</td>
            <td>
                <asp:TextBox ID="txtTelefone" runat="server" MaxLength="14" onkeypress="return PermiteSomenteNumeros(event);" onkeyup="MascaraTelefone(this,event);" ></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td style="width: 8px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Email</td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td style="width: 8px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                CEP</td>
            <td>
                <asp:TextBox ID="txtCEP" runat="server" MaxLength="10" onBlur= "ValidaCep(this, event);" onkeyup="MascaraCep(this,event);" onkeypress="return PermiteSomenteNumeros(event);"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td style="width: 8px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Endereço</td>
            <td>
                <asp:TextBox ID="TxtEndereco" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td style="width: 8px">
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
            <td style="width: 39px">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                UF</td>
            <td>
            <asp:DropDownList ID="ddlUF" runat="server" Enabled="False">
                <asp:ListItem>AC </asp:ListItem>
                <asp:ListItem>AL</asp:ListItem>
                <asp:ListItem>AP</asp:ListItem>
                <asp:ListItem>AM</asp:ListItem>
                <asp:ListItem>BA</asp:ListItem>
                <asp:ListItem>CE</asp:ListItem>
                <asp:ListItem>DF</asp:ListItem>
                <asp:ListItem>ES</asp:ListItem>
                <asp:ListItem>GO</asp:ListItem>
                <asp:ListItem>MA</asp:ListItem>
                <asp:ListItem>MT</asp:ListItem>
                <asp:ListItem>MS</asp:ListItem>
                <asp:ListItem>MG</asp:ListItem>
                <asp:ListItem>PA</asp:ListItem>
                <asp:ListItem>PB</asp:ListItem>
                <asp:ListItem>PR</asp:ListItem>
                <asp:ListItem>PE</asp:ListItem>
                <asp:ListItem>PI</asp:ListItem>
                <asp:ListItem>RJ</asp:ListItem>
                <asp:ListItem>RN</asp:ListItem>
                <asp:ListItem>RS</asp:ListItem>
                <asp:ListItem>RO</asp:ListItem>
                <asp:ListItem>RR </asp:ListItem>
                <asp:ListItem>SC</asp:ListItem>
                <asp:ListItem>SP</asp:ListItem>
                <asp:ListItem>SE</asp:ListItem>
                <asp:ListItem>TO</asp:ListItem>
            </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
            <td style="width: 8px">
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
            <td style="width: 39px">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Cidade</td>
            <td>
                
                <asp:TextBox ID="txtCidade" runat="server"></asp:TextBox>
                
            </td>
            <td>
                &nbsp;</td>
            <td style="width: 8px">
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
            <td style="width: 39px">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td colspan="3">
                <asp:GridView ID="gvFornecedores" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False" DataKeyNames="Id_Fornecedor" 
                    DataSourceID="SqlDataSource1" BackColor="#CCCCCC" BorderColor="#999999" 
                    BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" 
                    ForeColor="Black" onselectedindexchanged="gv_produtos_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="For_Razao_Social" HeaderText="For_Razao_Social" 
                            SortExpression="For_Razao_Social" />
                        <asp:BoundField DataField="Id_Fornecedor" HeaderText="Id_Fornecedor" 
                            SortExpression="Id_Fornecedor" InsertVisible="False" ReadOnly="True" />
                        <asp:BoundField DataField="For_CNPJ" HeaderText="For_CNPJ" 
                            SortExpression="For_CNPJ" />
                        <asp:BoundField DataField="For_Email" HeaderText="For_Email" 
                            SortExpression="For_Email" />
                        <asp:BoundField DataField="For_Status" HeaderText="For_Status" 
                            SortExpression="For_Status" />
                        <asp:BoundField DataField="For_UF" HeaderText="For_UF" 
                            SortExpression="For_UF" />
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>
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
            <td style="width: 39px">
                &nbsp;</td>
        </tr>
    </table>
   
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
     
</asp:Content>




