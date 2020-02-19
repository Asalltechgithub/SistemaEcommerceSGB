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
    public partial class Cad_Cliente : System.Web.UI.Page
    {
        int Id;
        string cpf, cpfIn;
        char cdig;
        int dig1, dig2;

        protected void Page_Load(object sender, EventArgs e)
        {
            Id = Convert.ToInt32(Session["Cli_ID"]);
            if (!IsPostBack)
            {
                if (Session["cli"] == null)
                {
                    Session.Clear();
                    Response.Redirect("~/login.aspx");


                }

                //carrega_Cred();
                prenche_campos();

            }
        }


        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Habilita_campos();
            Limpar_campos();
            btnAlterar.Enabled = false;

            btnSalvar.Enabled = true;
            lblModo.Text = "Modo de Inclusão";
        }
        protected void btnSalvar_Click(object sender, EventArgs e)
        {



            validarCPF();
            Valida_campos();
            if (ValidaEmail(txtEmail.Text) == false)
            {
                MSG("Email Invalido ");
                return;

            }
            alterar();
            //Manter_campos();
            MSG(" Dados salvos com Sucesso !");
            Desabilita_campos();






        }
        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            lblModo.Text = "Modo de Alteração";
            Habilita_campos();
            ddlCidade.Text = txtCidade.Text;
            btnSalvar.Enabled = true;
            txtCPF.Enabled = false;
            txtRG.Enabled = false;
            txtEmail.Enabled = false;

            ddlCidade.Visible = true;
            txtCidade.Visible = false;
        }



        public void alterar()
        {

            lblModo.Text = "Modo de Alteração";
            Usuario u = new Usuario();
            u.Id = Convert.ToInt32(txt_matricula.Text);
            u.Nome = txtNome.Text;
            u.CPF = txtCPF.Text;
            u.RG = txtRG.Text;
            u.Dt_Nascimento = Convert.ToDateTime(txtDtNasc.Text);
            u.CEP = txtCEP.Text;
            u.UF = ddlUF.SelectedValue;
            u.Endereco = txtEndereco.Text;
            u.Cidade = ddlCidade.SelectedValue;
            u.Estado_Civil = ddlEstadoCivil.SelectedValue;
            u.Sexo = ddlSexo.SelectedValue;
            u.Telefone = txtTelefone.Text;
            u.Email = txtEmail.Text;
            u.Senha = txtSenha.Text;
            u.Tipo = Convert.ToInt32(Label3.Text);
            new Business_Usuario().alterar_Usuario(u);



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
            ddlCidade.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtTelefone.Text = string.Empty;
            txtSenha.Text = string.Empty;
            txtConfirmaSenha.Text = string.Empty;

        }


        protected void btnCancelar_Click(object sender, EventArgs e)
        {

            Desabilita_campos();
            lblModo.Text = "";
            btnAlterar.Enabled = true;
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
        public void Valida_campos()
        {

            if (txtNome.Text == string.Empty)
            {
                MSG("Campo requerido");
                return;
            }
            if (txtCPF.Text == string.Empty)
            {
                MSG("Campo requerido");
                return;
            }
            if (txtRG.Text == string.Empty)
            {
                MSG("Campo requerido");
                return;
            }

            if (txtDtNasc.Text == string.Empty)
            {
                MSG("Campo requerido");
                return;
            }
            if (txtCEP.Text == string.Empty)
            {
                MSG("Campo requerido");
                return;
            }
            if (ddlUF.Text == string.Empty)
            {
                MSG("Campo requerido");
                return;
            }
            if (txtEndereco.Text == string.Empty)
            {
                MSG("Campo requerido");
                return;
            }
            if (ddlCidade.Text == string.Empty)
            {
                MSG("Campo requerido");
                return;
            }
            if (ddlEstadoCivil.Text == string.Empty)
            {
                MSG("Campo requerido");
                return;
            }
            if (ddlSexo.Text == string.Empty)
            {
                MSG("Campo requerido");
                return;
            }
            if (txtEmail.Text == string.Empty)
            {
                MSG("Campo requerido");
                return;
            }
            if (txtSenha.Text == string.Empty)
            {
                MSG("Campo requerido");
                return;
            }
            if (txtConfirmaSenha.Text == string.Empty)
            {
                MSG("Campo requerido");
                return;
            }
            if (txtSenha.Text != txtConfirmaSenha.Text)
            {
                MSG("Senhas não confere");
                return;

            }

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

        public void prenche_campos()
        {

            SqlConnection con = clsDAO.conexao();

            SqlCommand cmd = new SqlCommand("select Id, Nome , CPF, RG , Sexo, Estado_civil,Dt_Nascimento , Endereco,UF,CEP, Cidade, Telefone,Email,Senha,ID_TipoUsuario from  Tb_Usuario inner join Tb_Tipo_usuario on TipoUsuario = ID_TipoUsuario where Tb_Usuario.Id =" + "'" + Id + "'");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                txt_matricula.Text = Convert.ToString(dr["Id"]);
                txtNome.Text = Convert.ToString(dr["Nome"]);
                txtCPF.Text = Convert.ToString(dr["CPF"]);
                txtRG.Text = Convert.ToString(dr["RG"]);
                ddlSexo.Text = Convert.ToString(dr["Sexo"]);
                ddlEstadoCivil.Text = Convert.ToString(dr["Estado_civil"]);
                txtDtNasc.Text = Convert.ToString(dr["Dt_Nascimento"]);
                txtEndereco.Text = Convert.ToString(dr["Endereco"]);
                ddlUF.Text = Convert.ToString(dr["UF"]);
                txtCEP.Text = Convert.ToString(dr["CEP"]);
                txtCidade.Text = Convert.ToString(dr["Cidade"]);

                txtTelefone.Text = Convert.ToString(dr["Telefone"]);
                txtEmail.Text = Convert.ToString(dr["Email"]);
                txtSenha.Text = Convert.ToString(dr["Senha"]);
                Label3.Text = Convert.ToString(dr["ID_TipoUsuario"]);




            }
        }

        /// <summary>
        /// mantem os campos atualizados apos o post da pagina  carregando as variaveis de sessao 
        /// </summary>
        public void Manter_campos()
        {
            Session["Cli_Id"] = txt_matricula.Text;
            Session["Cli_Nome"] = txtNome.Text;
            Session["Cli_CPF"] = txtCPF.Text;
            Session["Cli_RG"] = txtRG.Text;
            Session["Cli_Dt_Nascimento"] = txtDtNasc.Text;
            Session["Cli_CEP"] = txtCEP.Text;
            Session["Cli_UF"] = ddlUF.Text;
            Session["Cli_Endereco"] = txtEndereco.Text;
            Session["Cli_Cidade"] = ddlCidade.Text;
            Session["Cli_Estado_Civil"] = ddlEstadoCivil.Text;
            Session["Cli_Sexo"] = ddlSexo.Text;
            Session["Cli_Telefone"] = txtTelefone.Text;
            Session["Cli_Email"] = txtEmail.Text;
            Session["Cli_Senha"] = txtSenha.Text;
            Session["Cli_Tipo"] = Label3.Text;
        }
        public static bool ValidaEmail(string email)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(email, ("(?<user>[^@]+)@(?<host>.+).(?<host>.+)"));
        }

    }
}

        //protected void btnCadCartao_Click(object sender, EventArgs e)
        //{
        //    if (lbltroc_card.Text == "Modo Novo") 
        //    {
        //        if (Verifica_cartao() == false)
        //        {
        //            inserir_cartao(); 
        //            MSG("Cartão inserido com sucesso!");
        //            btnCadCartao.Enabled = false;
        //            btnTroca_Cartao.Enabled = true;
        //        }
        //        else 
        //        {
        //            MSG("Cartão já utilizado");
        //        }
        //    }
        //    if (lbltroc_card.Text == "Modo troca")
        //    {
        //        if (Verifica_cartao()== false)
        //        {
        //            alterar_cartao();
        //            MSG("Cartão trocado com sucesso!");
        //        }
        //        else
        //        {
        //            MSG("Cartão já utilizado");
        //        }
            
        //    }

        //}
        //public void carrega_Cred() 
        //{
        //    SqlConnection con = clsDAO.conexao();

        //    SqlCommand cmd = new SqlCommand(" Select  Nun_Cartao, Valor_credito , Bandeira from Tb_credito  where Cod_Cli=@Cod_Cli");
        //    cmd.CommandType = CommandType.Text;
        //    cmd.Parameters.AddWithValue("@Cod_Cli", Id);
        //    cmd.Connection = con;
        //    SqlDataReader dr;
        //    dr = cmd.ExecuteReader();
        //    dr.Read();
        //    if (dr.HasRows == true)
        //    {
        //        btnAddCred.Enabled = true;
        //        btnCadCartao.Enabled = false;
        //        txt_Nun_cartao.Text = Convert.ToString(dr["Nun_Cartao"]);
        //        txtCredito.Text = Convert.ToString(dr["Valor_credito"]);
        //        ddlBandeira.Text = Convert.ToString(dr["Bandeira"]);
        //    }
        //    else 
        //    {
        //        lbltroc_card.Text = "Modo Novo";
        //        btnTroca_Cartao.Enabled = false;
        //        txt_Nun_cartao.Text = string.Empty;
        //        txtCredito.Text = string.Empty;
        //    }
           
        //}

        //protected void btnTroca_Cartao_Click(object sender, EventArgs e)
        //{
        //    lbltroc_card.Text = "Modo troca";
        //    btnCadCartao.Enabled = true;
        //    txt_Nun_cartao.Text = string.Empty;
        //}

        //public void inserir_cartao() 
        //{
        //    SqlConnection con = clsDAO.conexao();

        //    SqlCommand cmd = new SqlCommand(" insert into Tb_credito (Cod_Cli , Nun_Cartao, Valor_credito , Bandeira) Values (@Cod_Cli, @Nun_Cartao,@Valor_credito,@Bandeira) ");
        //    cmd.CommandType = CommandType.Text;
        //    cmd.Parameters.AddWithValue("@Cod_Cli", Id);
        //    cmd.Parameters.AddWithValue("@Nun_Cartao", txt_Nun_cartao.Text);
        //    cmd.Parameters.AddWithValue("@Valor_credito", txtCredito.Text);
        //    cmd.Parameters.AddWithValue("@Bandeira", ddlBandeira.Text);
        //    cmd.Connection = con;
        //    cmd.ExecuteNonQuery();
        //}

        //public void alterar_cartao() 
        //{
        //    SqlConnection con = clsDAO.conexao();

        //    SqlCommand cmd = new SqlCommand(" update Tb_credito set Nun_Cartao =@Nun_Cartao , Valor_credito = @Valor_credito , Bandeira = @Bandeira where Cod_Cli = @Cod_Cli ");
        //    cmd.CommandType = CommandType.Text;
        //    cmd.Parameters.AddWithValue("@Cod_Cli", Id);
        //    cmd.Parameters.AddWithValue("@Nun_Cartao", txt_Nun_cartao.Text);
        //    cmd.Parameters.AddWithValue("@Valor_credito", txtCredito.Text);
        //    cmd.Parameters.AddWithValue("@Bandeira", ddlBandeira.Text);
        //    cmd.Connection = con;
        //    cmd.ExecuteNonQuery();
        //}
        //public bool Verifica_cartao() 
        //{ 
        // SqlConnection con = clsDAO.conexao();

        //    SqlCommand cmd = new SqlCommand(" Select * from Tb_credito  where Nun_Cartao=@Nun_Cartao");
        //    cmd.CommandType = CommandType.Text;
        //    cmd.Parameters.AddWithValue("@Nun_Cartao", txt_Nun_cartao.Text);
        //    cmd.Connection = con;
        //    SqlDataReader dr;
        //    dr = cmd.ExecuteReader();
        //    dr.Read();
           
        //    return dr.HasRows;

           
           
        //}
//        public void add_Credito() 
//        {
//            SqlConnection con = clsDAO.conexao();

//            SqlCommand cmd = new SqlCommand(" update Tb_credito set Valor_credito = @Valor_credito  where Nun_Cartao = @Nun_Cartao and Cod_Cli = @Cod_Cli  ");
//            cmd.CommandType = CommandType.Text;
//            cmd.Parameters.AddWithValue("@Cod_Cli", Id);
//            cmd.Parameters.AddWithValue("@Nun_Cartao", txt_Nun_cartao.Text);
//            cmd.Parameters.AddWithValue("@Valor_credito", txtCredito.Text);
//            cmd.Connection = con;
//            cmd.ExecuteNonQuery();
//        }

//        protected void btnAddCred_Click(object sender, EventArgs e)
//        {
//            add_Credito();
//            MSG("Credito inserido Com Sucesso !!!");
//        }

//    }
//}