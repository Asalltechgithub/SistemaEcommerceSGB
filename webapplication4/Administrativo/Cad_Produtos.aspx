<%@ Page Title="" Language="C#" MasterPageFile="~/Administrativo/Adm.Master" AutoEventWireup="true" CodeBehind="Cad_Produtos.aspx.cs" Inherits="WebApplication4.Cad_Produtos" %>
 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">  
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <script type="text/javascript" src="../validacao.js">

                    </script>
    <table><tr>
     <td style="width: 279px;">
            &nbsp;
            <asp:Button ID="btnNovo" runat="server" Text="Novo" onclick="btnNovo_Click" />
       <asp:Button ID="btnSalvar" runat="server" Text="Salvar" 
                onclick="btnSalvar_Click" OnClientClick="return confirm('Deseja Salvar ?');" Enabled="False" />
        &nbsp;<asp:Button ID="btnExcluir" runat="server" Text="Excluir" 
                onclick="btnExcluir_Click" OnClientClick="return confirm('Deseja excluir o produto ?');" Enabled="False" />
        &nbsp;<asp:Button ID="btnCancelar" runat="server" Text="Cancelar" Width="51px" 
                onclick="btnCancelar_Click" />
        &nbsp;<asp:Button ID="btnEditar0" runat="server" onclick="btnEditar_Click" Text="Editar" />

        </td>
      </tr>
      </table>
    
       <div id="main">
    <table style="width: 100%; height: 736px;">
    <tr>
        <td style="text-align: center; height: 14px;" colspan="2" class="auto-style10">
            <h1 style="font-size: medium; font-family: 'Arial Black'; top: 0px; left: 0px; height: 30px"><em class="auto-style10" style="font-family: Arial; ">Cadatro de Produtos</em></h1>
        </td>
        <td style="text-align: center; height: 14px; width: 13px;">
            &nbsp;</td>
        <td style="text-align: center; " rowspan="17">
            &nbsp;</td>
        <td style="text-align: center; " rowspan="18">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: center; height: 14px;" colspan="2" class="auto-style10">
            &nbsp;</td>
        <td style="text-align: center; height: 14px; width: 13px;">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: center; " class="auto-style2">
            </td>
        
        <td style="width: 13px">
        </td>
    </tr>
    <tr>
        <td style="text-align: center; " class="auto-style3">
            Pesquisar por nome</td>
        <td style="height: 47px; width: 279px; text-align: left;">
            <asp:TextBox ID="txtPesquisar" runat="server" Width="192px"></asp:TextBox>
            <asp:Button ID="btnOk_pesquisar" runat="server" Height="19px" Text="OK" 
                Width="39px" OnClick="btnOk_pesquisar_Click" />
        </td>
        <td style="width: 13px;" rowspan="14">
            <asp:GridView ID="gv_produtos" runat="server" onselectedindexchanged="gv_produtos_SelectedIndexChanged" AllowPaging="True" DataSourceID="dsprod" EnableSortingAndPagingCallbacks="True" Visible="False">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="dsprod" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT Id_Prod_Estq AS Cod, Nome_Prod_Estq AS Produto, Marca_Prod_Estoq AS Marca, Categoria_Prod_Estoq AS Categoria, Qtd_Prod_Estoq AS Qtd FROM Tb_Prod_Estoque WHERE (Nome_Prod_Estq LIKE  @Param1 + '%' )">
                <SelectParameters>
                    <asp:ControlParameter ControlID="txtPesquisar" DefaultValue="" Name="Param1" PropertyName="Text" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="dsprod2" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT Id_Prod_Estq AS Cod, Nome_Prod_Estq AS Produto, Marca_Prod_Estoq AS Marca, Categoria_Prod_Estoq AS Categoria, Qtd_Prod_Estoq AS Qtd FROM Tb_Prod_Estoque"></asp:SqlDataSource>
            <asp:GridView ID="gv_produtos2" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="Cod" DataSourceID="dsprod2" EnableSortingAndPagingCallbacks="True" onselectedindexchanged="gv_produtos2_SelectedIndexChanged" Visible="False">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="Cod" HeaderText="Cod" InsertVisible="False" ReadOnly="True" SortExpression="Cod" />
                    <asp:BoundField DataField="Produto" HeaderText="Produto" SortExpression="Produto" />
                    <asp:BoundField DataField="Marca" HeaderText="Marca" SortExpression="Marca" />
                    <asp:BoundField DataField="Categoria" HeaderText="Categoria" SortExpression="Categoria" />
                    <asp:BoundField DataField="Qtd" HeaderText="Qtd" SortExpression="Qtd" />
                </Columns>
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td style="text-align: center; " class="auto-style4">
            <asp:Label ID="lbl_Modo" runat="server" CssClass="auto-style10"></asp:Label>
        </td>
        <td style="height: 40px; width: 279px; text-align: left;">
            <asp:Label ID="lbl_message" runat="server" Text="Mensagen informativa"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: center; " class="auto-style5">
            Codigo</td>
        <td style="height: 30px; width: 279px; text-align: left;">
            <asp:DropDownList ID="ddlCodigo_prod" runat="server" 
                DataSourceID="SqlDataSource4" DataTextField="Id_Prod_Estq" 
                DataValueField="Id_Prod_Estq">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: center; " class="auto-style5">
            Tipo Venda</td>
        <td style="height: 30px; width: 279px; text-align: left;">
            <asp:DropDownList ID="ddlTipovenda" runat="server" DataSourceID="dsTipoVenda" DataTextField="Nome_tipo" DataValueField="Id_Tipo_Pedido" Height="16px" Width="87px" Enabled="False">
            </asp:DropDownList>
            <asp:SqlDataSource ID="dsTipoVenda" runat="server" ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" SelectCommand="SELECT * FROM [Tb_Tipo_Pedido]"></asp:SqlDataSource>
        </td>
    </tr>
    <tr>
        <td style="text-align: center; " class="auto-style6">
            Nome do produto</td>
        <td style="width: 279px; text-align: left; height: 46px;">
            <asp:TextBox ID="txtNome" runat="server" Width="181px" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: center; " class="auto-style7">
            Marca</td>
        <td style="width: 279px; height: 32px; text-align: left;">
            <asp:DropDownList ID="ddlMarca" runat="server" 
                DataSourceID="SqlDataSource2" DataTextField="Nome_marca" 
                DataValueField="Nome_marca" Enabled="False" AutoPostBack="True">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: center; " class="auto-style8">
            Quantidade</td>
        <td style="width: 279px; height: 4px; text-align: left;">
            <asp:TextBox ID="txtQtdEstoque" runat="server" Enabled="False" MaxLength="3" onkeypress="return PermiteSomenteNumeros(event);"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: center;" class="auto-style9">
            Categoria</td>
        <td style="width: 279px; text-align: left;">
            <asp:DropDownList ID="ddlCategoria" runat="server" 
                DataSourceID="SqlDataSource3" DataTextField="Nome_Categoria" 
                DataValueField="Nome_Categoria" Enabled="False" AutoPostBack="True">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: center;" class="auto-style9">
            Data de lançamento </td>
        <td style="width: 279px; text-align: left;">
            <asp:TextBox ID="TxtDTlancamento" runat="server" Enabled="False" MaxLength="10" onBlur= "ValidaData(this, event)" onkeyup="MascaraData(this,event);" onkeypress="return PermiteSomenteNumeros(event);"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: center; height: 33px;" class="auto-style9">
            Valor de Compra </td>
        <td style="width: 279px; text-align: left; height: 33px;">
            <asp:TextBox ID="txtValor_compra" runat="server" MaxLength="7" Enabled="False" onkeypress="return PermiteSomenteNumeros(event);"  />
        </td>
    </tr>
    <tr>
        <td style="text-align: center;" class="auto-style9">
            Valor de Venda</td>
        <td style="width: 279px; text-align: left;">
            <asp:TextBox ID="txtValor" runat="server" Enabled="False" MaxLength="7" onkeypress="return PermiteSomenteNumeros(event);"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: center;" class="auto-style9">
            Fornecedor</td>
        <td style="width: 279px; text-align: left;">
            <asp:DropDownList ID="ddlFornecedor" runat="server" 
                DataSourceID="SqlDataSource5" DataTextField="For_Razao_Social" 
                DataValueField="Id_Fornecedor" Enabled="False">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: center;" class="auto-style9">
            Descrição</td>
        <td style="width: 279px; text-align: left;">
            <asp:TextBox ID="txtDescricao" runat="server" Height="214px" Enabled="False" 
                TextMode="MultiLine" Width="154px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: center; " class="auto-style9">
            Imagem</td>
        <td style="width: 279px; text-align: left;">
        &nbsp; 
          
                    
             
        </td>
    </tr>
    <tr>
        <td style="text-align: center; height: 22px;" colspan="4">
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" 
                SelectCommand="SELECT [Nome_Categoria] FROM [Tb_Categoria]">
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
                ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" 
                SelectCommand="SELECT [Id_Prod_Estq] FROM [Tb_Prod_Estoque]">
            </asp:SqlDataSource>
            
           
        </td>
    </tr>
    </table> 

       </div>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" 
                SelectCommand="SELECT * FROM [Tb_marca]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource5" runat="server" 
                ConnectionString="<%$ ConnectionStrings:BD_SGBConnectionString %>" 
                SelectCommand="SELECT [Id_Fornecedor], [For_Razao_Social] FROM [Tb_Fornecedor]">
            </asp:SqlDataSource>
            </ContentTemplate>
            </asp:UpdatePanel>
     <br />
                        <asp:Button ID="Button1" runat="server" Height="18px" onclick="Button1_Click" Text="Ok" />
   
        
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
          
               
            &nbsp;<br />
    <asp:FileUpload ID="FileUpload1" runat="server" />
            <br />
            
               
    
     <asp:Image ID="imagem_prod" runat="server" Height="110px" Width="160px" />
           </ContentTemplate>
                   </asp:UpdatePanel>
             
        

</asp:Content>








