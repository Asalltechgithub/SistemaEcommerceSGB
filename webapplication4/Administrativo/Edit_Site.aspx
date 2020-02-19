<%@ Page Title="" Language="C#" MasterPageFile="~/Administrativo/Adm.Master" AutoEventWireup="true" CodeBehind="Edit_Site.aspx.cs" Inherits="WebApplication4.Administrativo.ADM.Edit_Site" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
 
    <div class="products">    
     <table>
            <tr><td>
            <asp:Image ID="img_Logo" runat="server" Height="76px" Width="74px" /></td><td>
            <asp:FileUpload ID="f_up_logo" runat="server" /><asp:Button ID="Button1" runat="server" Text="Ok" OnClick="Button1_Click" /></td></tr></table>
   <h2><em>Alterar Frete</em></h2>
        <table>
           Valor do Frete  <tr>
            
               <td>
                        <asp:TextBox ID="txtVal_frete" runat="server" Enabled="False"></asp:TextBox></td>
              <td> <asp:Button ID="btnAlterar" runat="server" Text="Alterar" OnClick="btnAlterar_Click" /></td>
                 <td> <asp:Button ID="btnSalvar" runat="server" Text="Salvar" Enabled="False" OnClick="btnSalvar_Click" /></td>

            </tr>

        </table>
        
    </div>
</asp:Content>
