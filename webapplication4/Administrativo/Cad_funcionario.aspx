<%@ Page Title="" Language="C#" MasterPageFile="~/Administrativo/Adm.Master" AutoEventWireup="true" CodeBehind="Cad_funcionario.aspx.cs" Inherits="WebApplication4.Cad_funcionario" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
            <script type="text/javascript" src="../validacao.js">

            </script>

        
    <table style="border-width: inherit; border-color: #0000FF; border-style: solid; width: 100%; height: 764px;">
    <tr>
        <td colspan="3" style="height: 50px; text-align: left">
            <h2 style="text-align: left">
                Cadastro de Funcionário</h2>
        </td>
        <td style="height: 50px; text-align: left">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style17">
            <asp:DropDownList ID="ddlTipo" runat="server">
                <asp:ListItem Value="1">Adm</asp:ListItem>
                <asp:ListItem Value="2">Oper</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td style="text-align: left; height: 2px;">
            &nbsp;</td>
        <td style="height: 2px;">
            &nbsp;</td>
        <td style="height: 2px">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: left; " class="auto-style17">
            <asp:Label ID="lblModo" runat="server"></asp:Label>
        </td>
        <td style="width: 74px; height: 2px;">
            <asp:Label ID="lbl_message" runat="server"></asp:Label>
            <asp:Label ID="lblMensagem" runat="server"></asp:Label>
        </td>
        <td rowspan="2">
            <asp:Button ID="btnNovo" runat="server" Text="Novo" onclick="btnNovo_Click" />
&nbsp;<asp:Button ID="btnSalvar" runat="server" Text="Salvar" onclick="btnSalvar_Click" OnClientClick="return confirm('Deseja Salvar ?');" Enabled="False" />
&nbsp;<asp:Button ID="btnAlterar" runat="server" Text="Alterar" 
                onclick="btnAlterar_Click" Enabled="False" />
&nbsp;<asp:Button ID="btnExcluir" runat="server" Text="Excluir" 
                onclick="btnExcluir_Click" OnClientClick="return confirm('Deseja deletar ?')" Enabled="False" />
&nbsp;<asp:Button ID="btnCancelar" runat="server" Text="Cancelar" 
                onclick="btnCancelar_Click" />
        </td>
    </tr>
    <tr>
        <td style="text-align: left; " class="auto-style18">
            Matricula</td>
        <td style="width: 74px; height: 6px;">
            <asp:TextBox ID="txtMatricula" runat="server" Width="43px"></asp:TextBox>
            <asp:SqlDataSource ID="dsidUsu" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT [Id] FROM [Tb_Usuario]"></asp:SqlDataSource>
        </td>
    </tr>
    <tr>
        <td style="text-align: left; " class="auto-style19">
            Nome</td>
        <td style="width: 74px; height: 19px;">
            <asp:TextBox ID="txtNome" runat="server" Enabled="False"></asp:TextBox>
        </td>
        <td style="text-align: right; " rowspan="14">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: left; " class="auto-style33">
            CPF</td>
        <td class="auto-style32">
            <asp:TextBox ID="txtCPF" runat="server" MaxLength="14" Enabled="False" onkeyup="MascaraCPF(this,event)" onBlur= "ValidarCPF(this.Text,event);" onkeypress="return PermiteSomenteNumeros(event);"></asp:TextBox>
        &nbsp;
        </td>
    </tr>
    <tr>
        <td style="text-align: left; " class="auto-style17">
            RG</td>
        <td style="width: 74px; height: 2px;">
            <asp:TextBox ID="txtRG" runat="server" MaxLength="12" Enabled="False" Height="20px" onkeyup="MascaraRG(this,event);" onkeypress="return PermiteSomenteNumeros(event);"></asp:TextBox>
          
        </td>
    </tr>
    <tr>
        <td style="text-align: left; " class="auto-style21">
            Data de Nascimeto</td>
        <td style="width: 74px; height: 26px;">
            <asp:TextBox ID="txtDtNasc" runat="server" MaxLength="10" Enabled="False" onkeyup="MascaraData(this,event);" TextMode="SingleLine" onkeypress="return PermiteSomenteNumeros(event);"></asp:TextBox>
           
           
        </td>
    </tr>
    <tr>
        <td style="text-align: left; height: 27px;" class="auto-style21">
            Endereço</td>
        <td style="width: 74px; height: 27px;">
            <asp:TextBox ID="txtEndereco" runat="server" Enabled="False"></asp:TextBox>
          
        </td>
    </tr>
    <tr>
        <td style="text-align: left; " class="auto-style21">
            Cidade</td>
        <td style="width: 74px; height: 26px;">
            <asp:TextBox ID="txtCidade" runat="server" Enabled="False" Height="22px"></asp:TextBox>
          
        </td>
    </tr>
    <tr>
        <td style="text-align: left; " class="auto-style22">
            CEP</td>
        <td style="width: 74px; height: 15px;">
            <asp:TextBox ID="txtCEP" runat="server" MaxLength="10" Enabled="False" onkeyup="MascaraCep(this,event);" onBlur="ValidaCep(this, event);" onkeypress="return PermiteSomenteNumeros(event);"></asp:TextBox>
           
            </td>
    </tr>
    <tr>
        <td style="text-align: left; " class="auto-style23">
            UF</td>
        <td style="width: 74px; height: 46px;">
            <asp:DropDownList ID="ddlUF" runat="server" Enabled="False">
                <asp:ListItem>AC</asp:ListItem>
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
    </tr>
    <tr>
        <td style="text-align: left; " class="auto-style24">
            Estado Civil</td>
        <td style="width: 74px; height: 17px;">
            <asp:DropDownList ID="ddlEstadoCivil" runat="server" Enabled="False" DataSourceID="dsEstado_civil" DataTextField="Estado_civil" DataValueField="Estado_civil">
            </asp:DropDownList>
            <asp:SqlDataSource ID="dsEstado_civil" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT * FROM [Tb_Estado_Civil]"></asp:SqlDataSource>
            
        </td>
    </tr>
    <tr>
        <td style="text-align: left; " class="auto-style25">
            Sexo</td>
        <td class="auto-style28">
            <asp:DropDownList ID="ddlSexo" runat="server" Enabled="False" DataSourceID="dsSexo" DataTextField="Genero" DataValueField="Genero">
                <asp:ListItem>Masculino</asp:ListItem>
                <asp:ListItem>Feminino</asp:ListItem>
            </asp:DropDownList>
            <asp:SqlDataSource ID="dsSexo" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT * FROM [Tb_Sexo]"></asp:SqlDataSource>
           
        </td>
    </tr>
    <tr>
        <td style="text-align: left; " class="auto-style17">
            Telefone</td>
        <td style="width: 74px; height: 2px;">
            <asp:TextBox ID="txtTelefone" runat="server" MaxLength="15" Enabled="False" onBlur= "ValidaTelefone(this, event);" onkeyup="MascaraTelefone(this,event);" onkeypress="return PermiteSomenteNumeros(event);"></asp:TextBox>
           
        </td>
    </tr>
    <tr>
        <td style="text-align: left; " class="auto-style26">
            Email</td>
        <td style="width: 74px; height: 5px;">
            <asp:TextBox ID="txtEmail" runat="server" Width="221px" Enabled="False"></asp:TextBox>
            </td>
    </tr>
    <tr>
        <td style="text-align: left; " class="auto-style27">
            Senha</td>
        <td style="width: 74px; height: 30px;">
            <asp:TextBox ID="txtSenha" runat="server" Enabled="False" MaxLength="8" TextMode="Password"></asp:TextBox>
            </td>
    </tr>
    <tr>
        <td style="text-align: left; " class="auto-style27">
            Confirma Senha</td>
        <td style="width: 74px; height: 30px;">
            <asp:TextBox ID="txtConfirmaSenha" runat="server" MaxLength="8" TextMode="Password" 
                Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style27">
            &nbsp;</td>
        <td style="text-align: left; height: 30px;">
            &nbsp;</td>
        <td style="height: 30px;">
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" 
                SelectCommand="SELECT U.Id AS Matricula, U.Nome, TP.Tipo AS Cargo FROM Tb_Usuario AS U INNER JOIN Tb_Tipo_usuario AS TP ON U.TipoUsuario = TP.ID_TipoUsuario WHERE (U.TipoUsuario &lt;= 2) ORDER BY Matricula">
            </asp:SqlDataSource>
            <asp:GridView ID="gvFuncionario" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" DataKeyNames="Matricula" 
                DataSourceID="SqlDataSource1" 
                onselectedindexchanged="GridView1_SelectedIndexChanged" BackColor="White" 
                BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
                ForeColor="Black" GridLines="Vertical" Height="247px" Width="30px">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="Matricula" HeaderText="Matricula" 
                        InsertVisible="False" ReadOnly="True" SortExpression="Matricula" />
                    <asp:BoundField DataField="Nome" HeaderText="Nome" 
                        SortExpression="Nome" />
                    <asp:BoundField DataField="Cargo" HeaderText="Cargo" 
                        SortExpression="Cargo" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
            </td>
        <td style="width: 183px; text-align: left; height: 30px;">
            &nbsp;</td>
    </tr>
</table>
    <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>

    </asp:Content>




