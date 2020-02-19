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



namespace WebApplication4
{
    public partial class Cad_funcionario : System.Web.UI.Page
    {
        string cpf, cpfIn;
        char cdig;
        int dig1, dig2;

        protected void Page_Load(object sender, EventArgs e)
        {
         
            if (Session["admin"] == null)
            {
                Session.Clear();
                Response.Redirect("~/login.aspx");


            }

            if (lblModo.Text == "") { btnSalvar.Enabled = false; }

        }



        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Habilita_campos();
            Limpar_campos();
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnSalvar.Enabled = true;
            lblModo.Text = "Modo de Inclusão";
        }
        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (lblModo.Text == "Modo de Inclusão")
            {

                if (Valida_campos() != true)
                {
                    MSG("Verifique os dados ! ");
                    return;

                }
                if (ValidaEmail(txtEmail.Text) == false)
                {
                    MSG("Email Invalido ");
                    return;
                }

                if (verificar_rg_existe() == true)
                {
                    MSG("RG Já utilizado !");
                    return;
                }
                if (verificar_cpf_existe() == true)
                {
                    MSG("CPF Já utilizado !");
                    return;
                }
                if (verifica_email() == true)
                {
                    MSG("Email utilizado escolha outro !");
                    return;
                }
                if (inserirVerificador() == false)
                {

                    MSG("Data invalida");
                }
                else
                {

                    validarCPF();
                    inserir();
                    gvFuncionario.DataBind();
                    Limpar_campos();
                    Desabilita_campos();
                    btnSalvar.Enabled = false;
                    btnNovo.Enabled = true;
                    MSG(" Dados incluidos  com Sucesso !");


                }



            }



            if (lblModo.Text == "Modo de Alteração")
            {
                if (Valida_campos() != true)
                {
                    MSG("Verifique os dados ! ");
                    return;
                }
                else
                {
                    if (alterarVerificador() == false)
                    {

                        MSG("Data invalida");
                    }
                    else
                    {



                        alterar();
                        gvFuncionario.DataBind();
                       
                        Limpar_campos();
                        Desabilita_campos();
                        btnSalvar.Enabled = false;
                        btnNovo.Enabled = true;
                        MSG(" Dados alterados com Sucesso !");
                    }
                }
            }
        }













        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            lblModo.Text = "Modo de Alteração";
            Habilita_campos();
            btnNovo.Enabled = false;
            btnExcluir.Enabled = false;
            btnSalvar.Enabled = true;
            txtCPF.Enabled = false;
            txtRG.Enabled = false;
            txtEmail.Enabled = false;
            btnNovo.Enabled = true;


        }
        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            int mat;
            mat = Convert.ToInt16(txtMatricula.Text);
            lblModo.Text = "Modo de Exclusão";
            btnSalvar.Enabled = true;
            deletar_Usuario(mat);
            MSG(" Dados Excluidos  com Sucesso !");
            
            gvFuncionario.DataBind();
            Limpar_campos();
            Desabilita_campos();
            btnSalvar.Enabled = false;

        }

        public bool inserir()
        {
            bool retorno;
            retorno = true;

            lblModo.Text = "Modo de Inclusão";
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
                string msg;

                msg = ex.Message;
                if (msg != null)
                {
                    msg = " data invalida !";
                    MSG(msg);
                    retorno = false;
                }



            }
            u.CEP = txtCEP.Text;
            u.UF = ddlUF.Text;
            u.Endereco = txtEndereco.Text;
            u.Cidade = txtCidade.Text;
            u.Estado_Civil = ddlEstadoCivil.Text;
            u.Sexo = ddlSexo.Text;
            u.Telefone = txtTelefone.Text;
            u.Email = txtEmail.Text;
            u.Senha = txtSenha.Text;
            u.Tipo = Convert.ToInt32(ddlTipo.SelectedValue);
            new Business_Usuario().inserir_Usuario(u);

            return retorno;
        }
        public bool inserirVerificador()
        {
            bool retorno;
            retorno = true;

            lblModo.Text = "Modo de Inclusão";
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
                string msg;

                msg = ex.Message;
                if (msg != null)
                {
                    msg = " data invalida !";
                    MSG(msg);
                    retorno = false;
                }
            }
            u.CEP = txtCEP.Text;
            u.UF = ddlUF.Text;
            u.Endereco = txtEndereco.Text;
            u.Cidade = txtCidade.Text;
            u.Estado_Civil = ddlEstadoCivil.Text;
            u.Sexo = ddlSexo.Text;
            u.Telefone = txtTelefone.Text;
            u.Email = txtEmail.Text;
            u.Senha = txtSenha.Text;
            u.Tipo = Convert.ToInt32(ddlTipo.SelectedValue);

            return retorno;
        }
        public bool alterar()
        {
            bool retorno;

            retorno = true;

            lblModo.Text = "Modo de Alteração";
            Usuario u = new Usuario();
            u.Id = Convert.ToInt32(txtMatricula.Text);
            u.Nome = txtNome.Text;
            u.CPF = txtCPF.Text;
            u.RG = txtRG.Text;
            try
            {
                u.Dt_Nascimento = Convert.ToDateTime(txtDtNasc.Text);
            }
            catch (Exception ex)
            {
                string msg;

                msg = ex.Message;
                if (msg != null)
                {
                    msg = " data invalida !";
                    MSG(msg);

                    retorno = false;
                }



            }
            u.CEP = txtCEP.Text;
            u.UF = ddlUF.Text;
            u.Endereco = txtEndereco.Text;
            u.Cidade = txtCidade.Text;
            u.Estado_Civil = ddlEstadoCivil.Text;
            u.Sexo = ddlSexo.Text;
            u.Telefone = txtTelefone.Text;
            u.Email = txtEmail.Text;
            u.Senha = txtSenha.Text;
            u.Tipo = Convert.ToInt32(ddlTipo.SelectedValue);
            new Business_Usuario().alterar_Usuario(u);

            return retorno;

        }
        public bool alterarVerificador()
        {
            bool retorno;

            retorno = true;

            lblModo.Text = "Modo de Alteração";
            Usuario u = new Usuario();
            u.Id = Convert.ToInt32(txtMatricula.Text);
            u.Nome = txtNome.Text;
            u.CPF = txtCPF.Text;
            u.RG = txtRG.Text;
            try
            {
                u.Dt_Nascimento = Convert.ToDateTime(txtDtNasc.Text);
            }
            catch (Exception ex)
            {
                string msg;

                msg = ex.Message;
                if (msg != null)
                {
                    msg = " data invalida !";
                    MSG(msg);

                    retorno = false;
                }



            }
            u.CEP = txtCEP.Text;
            u.UF = ddlUF.Text;
            u.Endereco = txtEndereco.Text;
            u.Cidade = txtCidade.Text;
            u.Estado_Civil = ddlEstadoCivil.Text;
            u.Sexo = ddlSexo.Text;
            u.Telefone = txtTelefone.Text;
            u.Email = txtEmail.Text;
            u.Senha = txtSenha.Text;
            u.Tipo = Convert.ToInt32(ddlTipo.SelectedValue);


            return retorno;

        }
        public void excluir()
        {
            lblModo.Text = "Modo de Exclusão";
            int matricula = Convert.ToInt32(txtMatricula.Text);
            new Business_Usuario().deletar_Usuario(matricula);

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
            txtCidade.Enabled = true;
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
            txtCidade.Enabled = false;
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
            txtCidade.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtTelefone.Text = string.Empty;
            txtSenha.Text = string.Empty;
            txtConfirmaSenha.Text = string.Empty;

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            Desabilita_campos();
            btnSalvar.Enabled = false;
            btnAlterar.Enabled = true;
            btnExcluir.Enabled = true;
            int codigo = Convert.ToInt16(gvFuncionario.SelectedRow.Cells[1].Text);
            clsDAO.conexao();
            try
            {
                clsDAO.conexao();
                lbl_message.Text = "conexao ok";

            }
            catch (Exception ex)
            {
                lbl_message.Text = String.Format(" Erro {0}", ex.Message);
            }
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Select * from Tb_Usuario where Id = " + codigo;
            cmd.Connection = clsDAO.conexao();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                txtMatricula.Text = Convert.ToString(codigo);
                //ddlMatricula.Text = Convert.ToString(dr["Id"]);
                txtNome.Text = Convert.ToString(dr["Nome"]);
                txtCPF.Text = Convert.ToString(dr["CPF"]);
                txtRG.Text = Convert.ToString(dr["RG"]);
                txtDtNasc.Text = Convert.ToString(dr["Dt_Nascimento"]);
                txtCEP.Text = Convert.ToString(dr["CEP"]);
                ddlUF.Text = Convert.ToString(dr["UF"]);
                txtEndereco.Text = Convert.ToString(dr["Endereco"]);
                txtCidade.Text = Convert.ToString(dr["Cidade"]);
                ddlEstadoCivil.Text = Convert.ToString(dr["Estado_civil"]);
                ddlSexo.Text = Convert.ToString(dr["Sexo"]);
                txtTelefone.Text = Convert.ToString(dr["Telefone"]);
                txtEmail.Text = Convert.ToString(dr["Email"]);
                txtSenha.Text = Convert.ToString(dr["Senha"]);
                ddlTipo.SelectedValue = Convert.ToString(dr["TipoUsuario"]);

            }



        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpar_campos();
            Desabilita_campos();
            lblModo.Text = "";
            btnAlterar.Enabled = true;
            btnExcluir.Enabled = true;
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
        public bool Valida_campos()
        {
            bool trava;

            if (txtNome.Text == string.Empty)
            {
                MSG("Campo (Nome) esta em branco");
                trava = false;
            }
            if (txtCPF.Text == string.Empty)
            {
                MSG("Campo (CPF) esta em branco");
                trava = false;
            }
            if (txtRG.Text == string.Empty)
            {
                MSG("Campo (RG) esta em branco");
                trava = false;
            }



            if (txtDtNasc.Text == string.Empty)
            {
                MSG("Campo (Data) esta em branco");
                trava = false;

            }


            if (txtCEP.Text == string.Empty)
            {
                MSG("Campo (Cep) esta em branco");
                trava = false;
            }
            if (txtEndereco.Text == string.Empty)
            {
                MSG("Campo (Endereço) esta em branco");
                trava = false;
            }
            if (txtCidade.Text == string.Empty)
            {
                MSG("Campo (Cidade) esta em branco");
                trava = false;
            }
            if (txtEmail.Text == string.Empty)
            {
                MSG("Campo (Email) esta em branco");
                trava = false;
            }
            if (txtSenha.Text == string.Empty)
            {
                MSG("Campo (Senha) esta em branco");
                trava = false;
            }
            if (txtConfirmaSenha.Text == string.Empty)
            {
                MSG("Campo (Confirma Senha) esta em branco");
                trava = false;
            }
            if (txtSenha.Text != txtConfirmaSenha.Text)
            {
                MSG("Senhas não confere");
                trava = false;

            }
            else
            {
                trava = true;
            }

            return trava;


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


        //public bool ValidateDate(object source, ServerValidateEventArgs args)
        //{

        //    bool trava;
        //    DateTime dt;
        //    DateTime dtNascimentoMax = DateTime.Now.AddYears(-18);
        //    DateTime dtMax = DateTime.Parse("1/1/1973 12:00:00");
        //    if (DateTime.TryParse(args.Value, out dt) == false)
        //        args.IsValid = false;



        //    //Valida se é maior de idade

        //    if (dt >= dtNascimentoMax)

        //        args.IsValid = false;



        //    //Valida a data para não dar SqlDateTime overflow       

        //    if (dt <= dtMax)

        //        args.IsValid = false;

        //}

        //return trava;

        public void deletar_Usuario(int Id)
        {
           
                SqlConnection cn =clsDAO.conexao();
                SqlCommand cmd = new SqlCommand("Delete from  Tb_Usuario where Id =  "+ Id);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            
        }
    }


