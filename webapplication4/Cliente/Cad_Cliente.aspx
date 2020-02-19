<%@ Page Title="" Language="C#" MasterPageFile="Menu_cli.Master" AutoEventWireup="true" CodeBehind="Cad_Cliente.aspx.cs" Inherits="WebApplication4.Cad_Cliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script type="text/javascript" src="../validacao.js">

  </script>
     <table style="border-width: inherit; border-color: #0000FF; border-style: solid; width: 100%; height: 764px;">
    <tr>
        <td colspan="3" style="height: 50px; text-align: left">
            <h2 style="text-align: left">
                Meus Dados</h2>
        </td>
        <td style="height: 50px; text-align: left">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style17">
            <asp:Label ID="Label3" runat="server" Text="3" Visible="False"></asp:Label>
        </td>
        <td style="text-align: left; height: 2px;">
            &nbsp;</td>
        <td style="height: 2px;">
            &nbsp;</td>
        <td style="height: 2px">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: left; font-weight: bold;" class="auto-style17">
            <span style="color: #FFFFFF">
            <asp:Label ID="lblModo" runat="server"></asp:Label>
        </td>
        <td style="width: 74px; height: 2px;">
            <b>
            <asp:Label ID="lbl_message" runat="server"></asp:Label>
            <asp:Label ID="lblMensagem" runat="server"></asp:Label>
            </b></span>
        </td>
        <td rowspan="2">
&nbsp;<asp:Button ID="btnSalvar" runat="server" Text="Salvar" onclick="btnSalvar_Click" OnClientClick="return confirm('Deseja Salvar ?');" />
&nbsp;<asp:Button ID="btnAlterar" runat="server" Text="Alterar" 
                onclick="btnAlterar_Click" />
&nbsp;&nbsp;<asp:Button ID="btnCancelar" runat="server" Text="Cancelar" 
                onclick="btnCancelar_Click" />
        </td>
    </tr>
    <tr>
        <td style="text-align: left; font-weight: bold; color: #FFFFFF;" class="auto-style18">
            Matricula</td>
        <td style="width: 74px; height: 6px;">
            <asp:TextBox ID="txt_matricula" runat="server" Enabled="False" Height="16px" ReadOnly="True" Width="29px"></asp:TextBox>
            <asp:SqlDataSource ID="dsidUsu" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT [Id] FROM [Tb_Usuario]"></asp:SqlDataSource>
        </td>
    </tr>
    <tr>
        <td style="text-align: left; font-weight: bold; color: #FFFFFF;" class="auto-style19">
            Nome</td>
        <td style="width: 74px; height: 19px;">
            <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
        </td>
        <td style="text-align: right; " rowspan="17">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: left; font-weight: bold; color: #FFFFFF;" class="auto-style33">
            CPF</td>
        <td class="auto-style32">
            <asp:TextBox ID="txtCPF" runat="server" Enabled="False" MaxLength="14" onkeyup="MascaraCPF(this,event)" onBlur= "ValidarCPF(this.Text,event);" onkeypress="return PermiteSomenteNumeros(event);"></asp:TextBox>
        &nbsp;
        </td>
    </tr>
    <tr>
        <td style="text-align: left; font-weight: bold; color: #FFFFFF;" class="auto-style17">
            RG</td>
        <td style="width: 74px; height: 2px;">
            <asp:TextBox ID="txtRG" runat="server" Enabled="false" onkeyup="MascaraRG(this,event);" onkeypress="return PermiteSomenteNumeros(event);"></asp:TextBox>
          
        </td>
    </tr>
    <tr>
        <td style="text-align: left; font-weight: bold; color: #FFFFFF;" class="auto-style21">
            Data de Nascimeto</td>
        <td style="width: 74px; height: 26px;">
            <asp:TextBox ID="txtDtNasc" runat="server" MaxLength="10" onkeyup="MascaraData(this,event)" Enabled="False"></asp:TextBox>
           
        </td>
    </tr>
    <tr>
        <td style="text-align: left; font-weight: bold; color: #FFFFFF;" class="auto-style21">
            Endereço</td>
        <td style="width: 74px; height: 26px;">
            <asp:TextBox ID="txtEndereco" runat="server"></asp:TextBox>
          
        </td>
    </tr>
    <tr>
        <td style="text-align: left; font-weight: bold; color: #FFFFFF;" class="auto-style22">
            CEP</td>
        <td style="width: 74px; height: 15px;">
            <asp:TextBox ID="txtCEP" runat="server" maxlength="9" onBlur= "ValidaCep(this, event);" onkeyup="MascaraCep(this,event);" onkeypress="return PermiteSomenteNumeros(event);"></asp:TextBox>
           
            </td>
    </tr>
    <tr>
        <td style="text-align: left; font-weight: bold; color: #FFFFFF;" class="auto-style23">
            UF</td>
        <td style="width: 74px; height: 46px;">
            <asp:DropDownList ID="ddlUF" runat="server" DataSourceID="dsUf" AutoPostBack="True" DataTextField="uf" DataValueField="uf">
                
            </asp:DropDownList>
            <asp:SqlDataSource ID="dsUf" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT [uf] FROM [tb_estados]"></asp:SqlDataSource>
          
        </td>
    </tr>
    <tr>
        <td style="text-align: left; font-weight: bold; color: #FFFFFF;" class="auto-style23">
            Cidade</td>
        <td style="width: 74px; height: 46px;">
            <asp:DropDownList ID="ddlCidade" runat="server" DataSourceID="dscidade" AutoPostBack="True" DataTextField="nome" DataValueField="nome" Height="16px" Visible="False">
            </asp:DropDownList>
            <asp:TextBox ID="txtCidade" runat="server" Enabled="False"></asp:TextBox>
            <asp:SqlDataSource ID="dscidade" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT [nome] FROM [tb_cidades] WHERE ([uf] = @uf)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ddlUF" Name="uf" PropertyName="SelectedValue" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
        </td>
    </tr>
    <tr>
        <td style="text-align: left; font-weight: bold; color: #FFFFFF;" class="auto-style24">
            Estado Civil</td>
        <td style="width: 74px; height: 17px;">
            <asp:DropDownList ID="ddlEstadoCivil" runat="server" DataSourceID="dsEstado_civil" DataTextField="Estado_civil" DataValueField="Estado_civil">
            </asp:DropDownList>
            <asp:SqlDataSource ID="dsEstado_civil" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT * FROM [Tb_Estado_Civil]"></asp:SqlDataSource>
            
        </td>
    </tr>
    <tr>
        <td style="text-align: left; font-weight: bold; color: #FFFFFF;" class="auto-style25">
            Sexo</td>
        <td class="auto-style28">
            <asp:DropDownList ID="ddlSexo" runat="server" DataSourceID="dsSexo" DataTextField="Genero" DataValueField="Genero">
                <asp:ListItem>Masculino</asp:ListItem>
                <asp:ListItem>Feminino</asp:ListItem>
            </asp:DropDownList>
            <asp:SqlDataSource ID="dsSexo" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT * FROM [Tb_Sexo]"></asp:SqlDataSource>
           
        </td>
    </tr>
    <tr>
        <td style="text-align: left; font-weight: bold; color: #FFFFFF;" class="auto-style17">
            Telefone</td>
        <td style="width: 74px; height: 2px;">
            <asp:TextBox ID="txtTelefone" runat="server" maxlength="14" onBlur= "ValidaTelefone(this, event);" onkeyup="MascaraTelefone(this,event);" onkeypress="return PermiteSomenteNumeros(event);" Height="22px"></asp:TextBox>
           
        </td>
    </tr>
    <tr>
        <td style="text-align: left; font-weight: bold; color: #FFFFFF;" class="auto-style26">
            Email</td>
        <td style="width: 74px; height: 5px;">
            <asp:TextBox ID="txtEmail" runat="server" Width="221px"></asp:TextBox>
            </td>
    </tr>
    <tr>
        <td style="text-align: left; font-weight: bold; color: #FFFFFF;" class="auto-style27">
            Senha</td>
        <td style="width: 74px; height: 30px;">
            <asp:TextBox ID="txtSenha" runat="server" TextMode="Password"></asp:TextBox>
            </td>
    </tr>
    <tr>
        <td style="text-align: left; font-weight: bold; color: #FFFFFF;" class="auto-style27">
            Confirma Senha</td>
        <td style="width: 74px; height: 30px;">
            <asp:TextBox ID="txtConfirmaSenha" runat="server" TextMode="Password"></asp:TextBox>
        </td>
    </tr>
    </table>
    

    </asp:Content>



