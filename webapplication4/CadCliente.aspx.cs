using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Projeto.SGB.Dao;
using System.Data.SqlClient;
using ProjetoSGB_Model;
using System.Data;
using System.Text.RegularExpressions;

namespace WebApplication4
{
    public partial class CadCliente : System.Web.UI.Page
    {
        string cpf, cpfIn;
        char cdig;
        int dig1, dig2;
        bool Ok = true;
        bool senha;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Cli"] != null)
            {
                Response.Redirect("principal.aspx");
            }


        }


        protected void btnSalvar_Click(object sender, EventArgs e)
        {


            Valida_campos();
            Validarsenha(senha);
            Validar(txtDtNasc.Text);
            validarCPF();
            if (ValidaEmail(txtEmail.Text) == false)
            {
                MSG("Email Invalido ");
                return;

            }
            else
            {

                if (verificar_rg_existe() == true)
                {
                    MSG("RG Já utilizado !");
                    return;
                }
                else
                {
                    if (verificar_cpf_existe() == true)
                    {
                        MSG("CPF Já utilizado !");
                        return;
                    }
                    else
                    {
                        if (verifica_email() == true)
                        {
                            MSG("Email utilizado escolha outro !");
                            return;

                        }
                        else
                        {
                            inserir();

                            lblMensagem.Text = " Dados incluidos  com Sucesso !";
                            Limpar_campos();
                            Desabilita_campos();
                            btnSalvar.Enabled = false;
                            Response.Redirect("~/login.aspx");
                        }
                        


                    }
                }
            }
        }





        public void inserir()
        {

            Usuario u = new Usuario();
            u.Nome = txtNome.Text;
            u.CPF = txtCPF.Text;
            u.RG = txtRG.Text;

            try
            {
                
                u.Dt_Nascimento = Convert.ToDateTime(txtDtNasc.Text);
                
                
            }
            catch (Exception ex)
            {

                Ok = true;
                MSG("Nome Data Invalido");
                Focus();
                return;
            }






            u.CEP = txtCEP.Text;
            u.UF = ddlUF.SelectedValue;
            u.Endereco = txtEndereco.Text;
            u.Cidade = ddlCidade.SelectedValue;
            u.Estado_Civil = ddlEstadoCivil.Text;
            u.Sexo = ddlSexo.Text;
            u.Telefone = txtTelefone.Text;
            u.Email = txtEmail.Text;
            u.Senha = txtSenha.Text;
            u.Tipo = Convert.ToInt32(Label3.Text);
            new Business_Usuario().inserir_Usuario(u);
        }








        public void Habilita_campos()
        {
            txtNome.Enabled = true;
            txtCPF.Enabled = true;
            txtRG.Enabled = true;

            txtDtNasc.Enabled = true;
            txtCEP.Enabled = true;
            ddlUF.Enabled = true;
            txtEndereco.Enabled = true;
            ddlCidade.Enabled = true;
            ddlEstadoCivil.Enabled = true;
            ddlSexo.Enabled = true;
            txtTelefone.Enabled = true;
            txtEmail.Enabled = true;
            txtSenha.Enabled = true;
            txtConfirmaSenha.Enabled = true;
        }
        public void Desabilita_campos()
        {
            txtNome.Enabled = false;
            txtCPF.Enabled = false;
            txtRG.Enabled = false;

            txtDtNasc.Enabled = false;
            txtCEP.Enabled = false;
            ddlUF.Enabled = false;
            txtEndereco.Enabled = false;
            ddlCidade.Enabled = false;
            ddlEstadoCivil.Enabled = false;
            ddlSexo.Enabled = false;
            txtTelefone.Enabled = false;
            txtEmail.Enabled = false;
            txtSenha.Enabled = false;
            txtConfirmaSenha.Enabled = false;
        }
        public void Limpar_campos()
        {
            txtNome.Text = string.Empty;
            txtCPF.Text = string.Empty;
            txtRG.Text = string.Empty;

            txtDtNasc.Text = string.Empty;
            txtCEP.Text = string.Empty;
            txtEndereco.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtTelefone.Text = string.Empty;
            txtSenha.Text = string.Empty;
            txtConfirmaSenha.Text = string.Empty;

        }






        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpar_campos();

            lblModo.Text = "";

            btnSalvar.Enabled = false;
        }


        private void validarCPF()
        {



            if (txtCPF.Text.Length == 11)
            {
                try
                {
                    //tirar os pontos e barras
                    cpf = txtCPF.Text.Trim();
                    //guardar cpf original para comprar no fim
                    cpfIn = cpf;
                    //tirar os digitos
                    cpf = cpf.Remove(cpf.Length - 2);

                    //Verificar digito 1 com a forumla dada
                    for (int i = 0; i < 9; i++)
                    {
                        cdig = char.Parse(cpf.Substring(i, 1));
                        int temp = int.Parse(cdig.ToString()) * (10 - i);
                        dig1 += temp;
                    }
                    dig1 = dig1 % 11;

                    if (dig1 < 2)
                    {
                        dig1 = 0;
                    }
                    else
                    {
                        dig1 = 11 - dig1;
                    }

                    //acrescenta o dígito obtido
                    cpf += dig1.ToString();

                    //Verificar digito 2 com a forumla dada
                    for (int i = 0; i < 10; i++)
                    {
                        cdig = char.Parse(cpf.Substring(i, 1));
                        int temp = int.Parse(cdig.ToString()) * (11 - i);
                        dig2 = dig2 + temp;
                    }
                    dig2 = dig2 % 11;

                    if (dig2 < 2)
                    {
                        dig2 = 0;
                    }
                    else
                    {
                        dig2 = 11 - dig2;
                    }

                    //acrescenta o dígito obtido
                    cpf += dig2;

                    //se o cpf modificado for igual ao inserido mostra mensagem de ok
                    if (cpfIn == cpf)
                    {
                        MSG("CPF Válido");
                        return;
                    }
                    //caso contrário mensagem de inválido
                    else
                    {
                        MSG("CPF Inválido");
                        return;

                    }
                }
                catch (Exception ex)
                {
                    MSG(ex.ToString() + "Erro");
                    //MessageBox.Show(ex.ToString(), "Erro");
                }
                finally
                {
                    //zerar variáveis para não dar problema nas próximas verificações
                    dig1 = 0;
                    dig2 = 0;
                }
            }
            else
            {
                MSG("CPF com formato inválido\n Insira 11 números, sem pontos, vírgulas ou barras.");
                //MessageBox.Show("CPF com formato inválido\n Insira 11 números, sem pontos, vírgulas ou barras.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }
        public bool verifica_email()
        {

            SqlConnection con = new SqlConnection();
            con = clsDAO.conexao();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = ("Select * from Tb_Usuario where Email = " + "'" + txtEmail.Text + "'");
            cmd.Connection = con;
            SqlDataReader dr;
            dr = cmd.ExecuteReader();

            return dr.HasRows;


        }
        public void MSG(string msg)
        {
            Response.Write("<script>alert('" + msg + "');</script>");

        }
        public void Valida_campos()
        {

            if (txtNome.Text == string.Empty)
            {
                MSG("Campo (Nome) esta em branco");
                return;
            }
            else if (txtCPF.Text == string.Empty)
            {
                MSG("Campo (CPF) esta em branco");
                return;
            }
            else if (txtRG.Text == string.Empty)
            {
                MSG("Campo (RG) esta em branco");
                return;
            }

            else if (txtDtNasc.Text == string.Empty)
            {
                MSG("Campo (Data) esta em branco");
                return;

            }
            else
                if (txtCEP.Text == string.Empty)
                {
                    MSG("Campo (Cep) esta em branco");
                    return;
                }
                else
                    if (ddlUF.Text == string.Empty)
                    {
                        MSG("Campo (UF) esta em branco");
                        return;
                    }
                    else if (txtEndereco.Text == string.Empty)
                    {
                        MSG("Campo (Endereco) esta em branco");
                        return;
                    }
                    else if (txtEmail.Text == string.Empty)
                    {
                        MSG("Campo Email esta vazio");
                        return;
                    }
                    else if (txtSenha.Text == string.Empty)
                    {
                        MSG("Campo (Senha) esta vazio");
                        return;
                    }
                    else
                        if (txtConfirmaSenha.Text == string.Empty)
                        {
                            MSG("Campo (Confirma Senha) esta vazio");
                            return;
                        }
        }
        public bool  Validarsenha( bool senha)
        {
            if (txtSenha.Text != txtConfirmaSenha.Text)
            {
               

                senha = false;
                if (senha == false) 
                {
                    MSG("Senhas não confere");
                    
                }
                
            }
            return senha;
        }

    
        public bool verificar_cpf_existe()
        {
            SqlConnection con = new SqlConnection();
            con = clsDAO.conexao();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = ("Select * from Tb_Usuario where CPF = " + "'" + txtCPF.Text + "'");
            cmd.Connection = con;
            SqlDataReader dr;
            dr = cmd.ExecuteReader();

            return dr.HasRows;
        }
        public bool verificar_rg_existe()
        {
            SqlConnection con = new SqlConnection();
            con = clsDAO.conexao();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = ("Select * from Tb_Usuario where RG = " + "'" + txtRG.Text + "'");
            cmd.Connection = con;
            SqlDataReader dr;
            dr = cmd.ExecuteReader();

            return dr.HasRows;
        }

        public static bool ValidaEmail(string email)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(email, ("(?<user>[^@]+)@(?<host>.+).(?<host>.+)"));
        }


        private bool Validar(string Data)
        {
            bool retorno = true;
            try
            {
                if ((!String.IsNullOrEmpty(Data) && Data.Length.Equals(10)))
                {
                    if (Regex.IsMatch(Data, @"^\d{2}/\d{2}/\d{4}$"))
                    {
                        return retorno;
                    }

                }
            }
            catch (Exception)
            {
                MSG ("Formatação Invalida da Data");
            }
            return false;
        }

       


    }
}