using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ProjetoSGB_Model;



namespace Projeto.SGB.Dao
{
    public class clsDAO
    {

        #region conexao com BD

        public static SqlConnection conexao()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=GEOVANE-NOTE\SQLEXPRESS;Initial Catalog=BD_SGB;User ID=sa;Password=gege46";
            cn.Open();
            return cn;
        }
        #endregion

        public void inserir_Usuario(Usuario u) 
        {
            try
            {
                SqlConnection cn = conexao();
                SqlCommand cmd = new SqlCommand("p_inserir_usuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nome", u.Nome);
                cmd.Parameters.AddWithValue("@CPF", u.CPF);
                cmd.Parameters.AddWithValue("@RG", u.RG);
                cmd.Parameters.AddWithValue("@Sexo", u.Sexo);
                cmd.Parameters.AddWithValue("@Estado_civil", u.Estado_Civil);
                cmd.Parameters.AddWithValue("@Dt_Nascimento", u.Dt_Nascimento.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Endereco", u.Endereco);
                cmd.Parameters.AddWithValue("@Uf", u.UF);
                cmd.Parameters.AddWithValue("@CEP", u.CEP);
                cmd.Parameters.AddWithValue("@Cidade", u.Cidade);
                cmd.Parameters.AddWithValue("@Telefone", u.Telefone);
                cmd.Parameters.AddWithValue("@Email", u.Email);
                cmd.Parameters.AddWithValue("@Senha", u.Senha);
                cmd.Parameters.AddWithValue("@TipoUsuario", u.Tipo);

                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch(Exception ex) 
            { 
            
            }
        }
        public void alterar_Usuario(Usuario u)
        {
            try
            {
                SqlConnection cn = conexao();
                SqlCommand cmd = new SqlCommand("p_alterar_usuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", u.Id);
                cmd.Parameters.AddWithValue("@Nome", u.Nome);
                cmd.Parameters.AddWithValue("@CPF", u.CPF);
                cmd.Parameters.AddWithValue("@RG", u.RG);
                cmd.Parameters.AddWithValue("@Sexo", u.Sexo);
                cmd.Parameters.AddWithValue("@Estado_civil", u.Estado_Civil);
                cmd.Parameters.AddWithValue("@Dt_Nascimento", u.Dt_Nascimento);
                cmd.Parameters.AddWithValue("@Endereco", u.Endereco);
                cmd.Parameters.AddWithValue("@Uf", u.UF);
                cmd.Parameters.AddWithValue("@CEP", u.CEP);
                cmd.Parameters.AddWithValue("@Cidade", u.Cidade);
                cmd.Parameters.AddWithValue("@Telefone", u.Telefone);
                cmd.Parameters.AddWithValue("@Email", u.Email);
                cmd.Parameters.AddWithValue("@Senha", u.Senha);
                cmd.Parameters.AddWithValue("@TipoUsuario", u.Tipo);

                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
               
            } 
        }
        public void deletar_Usuario(int Id)
        {
            try
            {
                SqlConnection cn = conexao();
                SqlCommand cmd = new SqlCommand("p_deletar_usuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id",Id);
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {

            }  
        }

        #region Dados de produtos
        #region Crud Produtos
        public void Inserir_Produto(Produto p)
        {
            try
            {
                SqlConnection ic = conexao();


                SqlCommand cmd = new SqlCommand("p_inserir_produto", ic);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nome_Prod_Estq", p.Nome);
                cmd.Parameters.AddWithValue("@Marca_Prod_Estoq", p.Marca);
                cmd.Parameters.AddWithValue("@Categoria_Prod_Estoq", p.Categoria);
                cmd.Parameters.AddWithValue("@Dt_lancamento_Prod_Estoq", p.Data);
                cmd.Parameters.AddWithValue("@Valor_Compra_Prod_Estoq", p.Valor_Compra);
                cmd.Parameters.AddWithValue("@Valor_Venda_Prod_Estoq", p.Valor_Venda);
                cmd.Parameters.AddWithValue("@Qtd_Prod_Estoq", p.Quantidade);
                cmd.Parameters.AddWithValue("@Descricao_Prod_Estoq", p.Descricao);
                cmd.Parameters.AddWithValue("@Foto_Prod_Estoq ", p.Foto);
                cmd.Parameters.AddWithValue("@Cod_For", p.codigo);
                cmd.Parameters.AddWithValue("@Tipo_Venda", p.Tipo);
                cmd.ExecuteNonQuery();
                ic.Close();
            }
            catch (Exception ex)
            {
                String.Format(" erro na inserção {0}", ex);
            }
        }
        public void Alterar_Produto(Produto pa)
        {
            try
            {
                SqlConnection ic = conexao();
                SqlCommand cmd = new SqlCommand("p_alterar_produto", ic);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Prod_Estq", pa.Id);
                cmd.Parameters.AddWithValue("@Nome_Prod_Estq ", pa.Nome);
                cmd.Parameters.AddWithValue("@Marca_Prod_Estoq ", pa.Marca);
                cmd.Parameters.AddWithValue("@Categoria_Prod_Estoq ", pa.Categoria);
                cmd.Parameters.AddWithValue("@Dt_lancamento_Prod_Estoq ", pa.Data);
                cmd.Parameters.AddWithValue("@Valor_Compra_Prod_Estoq", pa.Valor_Compra);
                cmd.Parameters.AddWithValue("@Valor_Venda_Prod_Estoq ", pa.Valor_Venda);
                cmd.Parameters.AddWithValue("@Qtd_Prod_Estoq", pa.Quantidade);
                cmd.Parameters.AddWithValue("@Descricao_Prod_Estoq ", pa.Descricao);
                cmd.Parameters.AddWithValue("@Cod_For", pa.codigo);
                cmd.Parameters.AddWithValue("@Foto_Prod_Estoq",pa.Foto);
                cmd.Parameters.AddWithValue("@Tipo_Venda", pa.Tipo);


                cmd.ExecuteNonQuery();
                ic.Close();
            }
            catch (Exception ex)
            {
                String.Format("erro ao alterar {0}", ex.Message);
            }
        }
        public void excluir_produto(int ID)
        {
            SqlConnection ic = conexao();
            SqlCommand cmd = new SqlCommand("p_deletar_produto", ic);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id_Prod_Estq", ID);
            cmd.ExecuteNonQuery();
            ic.Close();

        }
        public static DataTable Carrega_Produtos()
        {
            conexao();
            DataTable dg = new DataTable();
            SqlCommand cmd = new SqlCommand("p_listar_produtos", conexao());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexao();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            dg.Load(dr);
            conexao().Close();
            return dg;
        }
        public static DataView carregaID()
        {
            clsDAO.conexao();
            DataTable dt = new DataTable();
            String SQL = "Select Id_Prod_Estq  from Tb_Prod_Estoque ";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SQL;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = clsDAO.conexao();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            dt.Load(dr);
            DataView dv = new DataView(dt, "", " Id_Prod_Estq ", DataViewRowState.OriginalRows);
            clsDAO.conexao().Close();
            return dv;
        }
        public DataTable Selecionar_Produto()
        {
            SqlConnection cn = conexao();
            StringBuilder sb = new StringBuilder();
            sb.Append("Select P.Id_Prod_Estq ,P.Nome_Prod_Estq ,P.Categoria_Prod_Estoq , C.Nome_Categoria , P.Qtd_Prod_Estoq");
            sb.Append("from Tb_Prod_Estoque as P inner join Tb_Categoria as C ");
            sb.Append("on C.Nome_Categoria = P.Categoria_Prod_Estoq");

            SqlCommand cmd = new SqlCommand(sb.ToString(), cn);
            SqlDataAdapter Adp = new SqlDataAdapter(cmd);
            DataTable Dt = new DataTable();
            Adp.Fill(Dt);
            cn.Close();
            return Dt;



        }
        #endregion
        #region crud marca
        public void inserir_Marca(marca m)
        {
            try
            {
                SqlConnection ic = conexao();


                SqlCommand cmd = new SqlCommand("p_inserir_marca", ic);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nome_marca", m.Marca);
                cmd.ExecuteNonQuery();
                ic.Close();
            }
            catch (Exception ex)
            {
                String.Format(" erro na inserção {0}", ex);
            }

        }
        public void alterar_marca(marca m)
        {
            try
            {
                SqlConnection ic = conexao();
                SqlCommand cmd = new SqlCommand("p_alterar_marca", ic);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", m.ID);
                cmd.Parameters.AddWithValue("@nome_marca", m.Marca);
                cmd.ExecuteNonQuery();
                ic.Close();
            }
            catch (Exception ex)
            {
                String.Format(" erro na Alteração {0}", ex);
            }

        }
        public void deletar_marca(int id)
        {
            try
            {
                SqlConnection cn = new SqlConnection();
                cn = conexao();
                SqlCommand cmd = new SqlCommand("p_deletar_marca", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@id_Marca",id);
                cmd.ExecuteNonQuery();
                cn.Close();

            }
            catch (Exception ex)
            {
                String.Format(" erro na Alteração {0}", ex);
            }
        }
        public static DataView carregaMarca()
        {
            SqlConnection ic = conexao();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("p_listar_marca", ic);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            dt.Load(dr);
            DataView dv = new DataView(dt, "", " Nome_marca ", DataViewRowState.OriginalRows);
            ic.Close();
            return dv;
        }
        #endregion
        #region crud categoria
        public void inserir_categoria(categoria c)
        {
            try
            {
                   SqlConnection cn = new SqlConnection();
                   SqlCommand cmd = new SqlCommand("p_inserir_categoria",cn);
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.AddWithValue("nome_categoria",c._categoria);
                   cmd.Connection = cn;
                   cmd.ExecuteNonQuery();
                   cn.Close();
            }
            catch (Exception ex)
            {
                String.Format(" erro ao inserir {0}", ex);
            }
        }
        public void alterar_categoria(categoria c) 
        {
            try
            {
                SqlConnection cn = new SqlConnection();
                SqlCommand cmd = new SqlCommand("p_alterar_categoria", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Id_categoria",c._categoria);
                cmd.Parameters.AddWithValue("nome_categoria",c._categoria);
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                String.Format(" erro na Alteração {0}", ex);
            }
        }
        public void deletar_categoria(int id) 
        {
            try
            {
                SqlConnection cn = new SqlConnection();
                SqlCommand cmd = new SqlCommand("p_deletar_categoria", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Id_categoria",id);
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                String.Format(" erro ao Deletar {0}", ex);
            }
        }
        public static DataView carregacategoria()
        {
            clsDAO.conexao();
            DataTable dt = new DataTable();
            String SQL = "Select Id_Categoria , Nome_Categoria from Tb_Categoria ";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SQL;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = clsDAO.conexao();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            dt.Load(dr);
            DataView dv = new DataView(dt, "", " Nome_Categoria ", DataViewRowState.OriginalRows);
            clsDAO.conexao().Close();
            return dv;
        }
        #endregion
        #endregion
        
        #region Dados de Fornecedores
        #region crud Fornecedor
        #region Manter Funcionario
        public void Inserir_Fornecedor(Fornecedor f)
        {
            try
            {
                SqlConnection ic = conexao();
                SqlCommand cmd = new SqlCommand("Sp_inserir_fornecedor", ic);
                cmd.Parameters.AddWithValue("@For_Razao_Social", f.Razao_Social);
                cmd.Parameters.AddWithValue("@For_CNPJ", f.CNPJ);
                cmd.Parameters.AddWithValue("@For_Telefone", f.Telefone);
                cmd.Parameters.AddWithValue("@For_Email", f.Email_Fornecedor);
                cmd.Parameters.AddWithValue("@For_CEP", f.CEP);
                cmd.Parameters.AddWithValue("@For_Endereco", f.Endereco);
                cmd.Parameters.AddWithValue("@For_UF", f.UF);
                cmd.Parameters.AddWithValue("@For_Cidade", f.Cidade);
                cmd.Parameters.AddWithValue("@For_Status", f.Status_Fornecedor);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                ic.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no método inserir pessoa fisica : " + Environment.NewLine + ex.Message + (ex.InnerException != null ? ex.InnerException.ToString() : String.Empty));
            }
        }
        public void Alterar_Fornecedor(Fornecedor f)
        {
            try
            {
                SqlConnection ic = conexao();
                SqlCommand cmd = new SqlCommand("Sp_alterar_fornecedor", ic);
                cmd.Parameters.AddWithValue("@Id_Fornecedor", f.Cod);
                cmd.Parameters.AddWithValue("@For_Razao_Social", f.Razao_Social);
                cmd.Parameters.AddWithValue("@For_CNPJ", f.CNPJ);
                cmd.Parameters.AddWithValue("@For_Telefone", f.Telefone);
                cmd.Parameters.AddWithValue("@For_Email", f.Email_Fornecedor);
                cmd.Parameters.AddWithValue("@For_CEP", f.CEP);
                cmd.Parameters.AddWithValue("@For_Endereco", f.Endereco);
                cmd.Parameters.AddWithValue("@For_UF", f.UF);
                cmd.Parameters.AddWithValue("@For_Cidade", f.Cidade);
                cmd.Parameters.AddWithValue("@For_Status", f.Status_Fornecedor);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                ic.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no método inserir pessoa fisica : " + Environment.NewLine + ex.Message + (ex.InnerException != null ? ex.InnerException.ToString() : String.Empty));
            }
        }
        public void excluir_Fornecedor(int ID)
        {
            SqlConnection ic = conexao();
            SqlCommand cmd = new SqlCommand("Sp_deletar_fornecedor", ic);
            cmd.Parameters.AddWithValue("@Id_Fornecedor", ID);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = ic;
            cmd.ExecuteNonQuery();
            ic.Close();

        }
        #endregion
        #region Carregamentos
        public DataTable Consultar_Fornecedor(int ID)
        {
            SqlConnection cn = conexao();

            string SQL = "SELECT   ";
            SQL += " Id_Fornecedor, For_Razão_social, For_CNPJ, For_Produto, For_Valor_Compra_Prod, For_Marca,For_Categoria_Prod,For_Teleforne,For_Email,For_CEP,For_Endereco,For_UF,For_Cidade,For_Status FROM Tb_Fornrcedor";
            if (ID > 0)
                SQL += "WHERE Id_Fornecedor =" + ID;
            SqlCommand cmd = new SqlCommand(SQL, cn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            cn.Close();
            return dt;
        }
        #endregion
        #endregion
        #endregion



       
    }


}
        