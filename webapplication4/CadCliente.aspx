<%@ Page Title="" Language="C#" MasterPageFile="Site.Master" AutoEventWireup="true" CodeBehind="CadCliente.aspx.cs" Inherits="WebApplication4.CadCliente" %>



<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


   <script type="text/javascript" src="validacao.js">


   </script>

    <table id="CadCli" style="border-width: inherit; border-color: #0000FF; border-style: solid; width: 100%; height: 764px;" onsubmit="return Validacao();">

        <tr>


            <td colspan="3" style="height: 50px; text-align: left">
                <h2 style="text-align: left; top: 0px; left: 0px;">Cadastro de Cliente </h2>
            </td>
            <td style="height: 50px; text-align: left">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style17" style="width: 121px">
                <asp:Label ID="Label3" runat="server" Text="3" Visible="False"></asp:Label>
            </td>
            <td style="text-align: left; height: 2px; width: 8px;">&nbsp;</td>
            <td style="height: 2px;">&nbsp;</td>
            <td style="height: 2px">&nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: left; width: 121px;" class="auto-style17">
                <asp:Label ID="lblModo" runat="server"></asp:Label>
            </td>
            <td style="width: 8px; height: 2px;">
                <asp:Label ID="lbl_message" runat="server"></asp:Label>
                <asp:Label ID="lblMensagem" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; width: 121px;" class="auto-style18">&nbsp;</td>
            <td style="width: 8px; height: 6px;">&nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: left; width: 121px; color: #FFFFFF; font-size: medium; font-weight: 700;" class="auto-style19">Nome</td>
            <td style="width: 8px; height: 19px;">
                <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; width: 121px; height: 24px; color: #FFFFFF; font-size: medium; font-weight: bold;" class="auto-style33">CPF</td>
            <td class="auto-style32" style="width: 8px; height: 24px">
                <br />
                <asp:TextBox ID="txtCPF" runat="server" MaxLength="14" onkeyup="MascaraCPF(this,event)"  Height="17px" Width="120px"></asp:TextBox>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="text-align: left; width: 121px; color: #FFFFFF; font-size: medium; font-weight: bold; height: 4px;" class="auto-style17">RG</td>
            <td style="width: 8px; height: 4px;">

                <asp:TextBox ID="txtRG" runat="server" MaxLength="12" onkeyup="MascaraRG(this,event);" onkeypress="return PermiteSomenteNumeros(event);"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td style="text-align: left; width: 121px; color: #FFFFFF; font-size: medium; font-weight: bold;" class="auto-style21">Data de Nascimeto</td>
            <td style="width: 8px; height: 26px;">
                <asp:TextBox ID="txtDtNasc" runat="server" TextMode="SingleLine" MaxLength="10" onkeypress="return PermiteSomenteNumeros(event);" CausesValidation="True" onkeyup="MascaraData(this,event);"></asp:TextBox>


            </td>
        </tr>
        <tr>
            <td style="text-align: left; width: 121px; color: #FFFFFF; font-size: medium; font-weight: bold;" class="auto-style21">Endereço</td>
            <td style="width: 8px; height: 26px;">
                <asp:TextBox ID="txtEndereco" runat="server"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td style="text-align: left; width: 121px; color: #FFFFFF; font-size: medium; font-weight: bold;" class="auto-style21">Uf</td>
            <td style="width: 8px; height: 26px;">
                <asp:DropDownList ID="ddlUF" runat="server" AutoPostBack="True" DataSourceID="dsUf" DataTextField="uf" DataValueField="uf">
                </asp:DropDownList>
                <asp:SqlDataSource ID="dsUf" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT uf, nome FROM tb_estados"></asp:SqlDataSource>

            </td>
        </tr>
        <tr>
            <td style="text-align: left; width: 121px; height: 10px; color: #FFFFFF; font-size: medium; font-weight: bold;" class="auto-style23">Cidade</td>
            <td style="width: 8px; height: 10px;">
                <asp:DropDownList ID="ddlCidade" runat="server" AutoPostBack="True" DataSourceID="dscidade" DataTextField="nome" DataValueField="nome">
                </asp:DropDownList>
                <asp:SqlDataSource ID="dscidade" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT * FROM [tb_cidades] WHERE ([uf] = @uf)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlUF" Name="uf" PropertyName="SelectedValue" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; width: 121px; height: 10px; color: #FFFFFF; font-size: medium; font-weight: bold;" class="auto-style23">Cep</td>
            <td style="width: 8px; height: 10px;">
                <asp:TextBox ID="txtCEP" runat="server" MaxLength="10" onBlur="ValidaCep(this,event);" onkeyup="return MascaraCep(this,event);"  ></asp:TextBox>


            </td>
        </tr>
        <tr>
            <td style="text-align: left; width: 121px; color: #FFFFFF; font-size: medium; font-weight: bold;" class="auto-style24">Estado Civil</td>
            <td style="width: 8px; height: 17px;">
                <asp:DropDownList ID="ddlEstadoCivil" runat="server" DataSourceID="dsEstado_civil" DataTextField="Estado_civil" DataValueField="Estado_civil">
                </asp:DropDownList>
                <asp:SqlDataSource ID="dsEstado_civil" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT * FROM [Tb_Estado_Civil]"></asp:SqlDataSource>

            </td>
        </tr>
        <tr>
            <td style="text-align: left; width: 121px; height: 37px; color: #FFFFFF; font-size: medium; font-weight: bold;" class="auto-style25">Sexo</td>
            <td class="auto-style28" style="width: 8px; height: 37px">
                <asp:DropDownList ID="ddlSexo" runat="server" DataSourceID="dsSexo" DataTextField="Genero" DataValueField="Genero">
                    <asp:ListItem>Masculino</asp:ListItem>
                    <asp:ListItem>Feminino</asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="dsSexo" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT * FROM [Tb_Sexo]"></asp:SqlDataSource>

            </td>
        </tr>
        <tr>
            <td style="text-align: left; width: 121px; color: #FFFFFF; font-size: medium; font-weight: bold;" class="auto-style17">Telefone</td>
            <td style="width: 8px; height: 2px;">
                <asp:TextBox ID="txtTelefone" runat="server" MaxLength="14" onBlur="ValidaTelefone(this, event);" onkeyup="MascaraTelefone(this,event);" onkeypress="return PermiteSomenteNumeros(event);"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td style="text-align: left; width: 121px; color: #FFFFFF; font-size: medium; font-weight: bold;" class="auto-style26">Email</td>
            <td style="width: 8px; height: 5px;">
                <asp:TextBox ID="txtEmail" runat="server" Width="221px" onBlur="validacaoEmail(f1.email)"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; width: 121px; color: #FFFFFF; font-size: medium; font-weight: bold;" class="auto-style27">Senha</td>
            <td style="width: 8px; height: 30px;">
                <asp:TextBox ID="txtSenha" runat="server" MaxLength="8" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; width: 121px; color: #FFFFFF; font-size: medium; font-weight: bold;" class="auto-style27">Confirma Senha</td>
            <td style="width: 8px; height: 30px;">
                <asp:TextBox ID="txtConfirmaSenha" runat="server" MaxLength="8" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style27" style="width: 121px">&nbsp;</td>
            <td style="text-align: left; height: 30px; width: 8px;">
                <asp:Button ID="btnSalvar" runat="server" Text="Cadastrar" OnClick="btnSalvar_Click" OnClientClick="return confirm ('Deseja Cadastrar ?');" BackColor="Green" Height="35px" Width="101px" Font-Size="Medium" ForeColor="Black" />

            </td>

            <td style="height: 30px;">&nbsp;</td>
            <td style="width: 183px; text-align: left; height: 30px;">&nbsp;</td>
        </tr>
    </table>


</asp:Content>


