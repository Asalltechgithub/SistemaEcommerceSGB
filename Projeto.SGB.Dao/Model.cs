using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Projeto.SGB.Dao;
using System.Data;
using ProjetoSGB_Model;
using System.Collections.Generic;

namespace ProjetoSGB_Model
{
    #region classe Usuarios
    public class Usuario : clsDAO
    {
        private int Id_Usuario;

        public int Id
        {
            get { return Id_Usuario; }
            set { Id_Usuario = value; }
        }
        private string Nome_Usuario;

        public string Nome
        {
            get { return Nome_Usuario; }
            set { Nome_Usuario = value; }
        }
        private string Endereco_Usuario;

        public string Endereco
        {
            get { return Endereco_Usuario; }
            set { Endereco_Usuario = value; }
        }
        private string CEP_Usuario;

        public string CEP
        {
            get { return CEP_Usuario; }
            set { CEP_Usuario = value; }
        }
        private string UF_Usuario;

        public string UF
        {
            get { return UF_Usuario; }
            set { UF_Usuario = value; }
        }
        private string Cidade_Usuario;

        public string Cidade
        {
            get { return Cidade_Usuario; }
            set { Cidade_Usuario = value; }
        }
        private string Telefone_Usuario;

        public string Telefone
        {
            get { return Telefone_Usuario; }
            set { Telefone_Usuario = value; }
        }
        private string Email_Usuario;

        public string Email
        {
            get { return Email_Usuario; }
            set { Email_Usuario = value; }
        }
        private string Senha_Usuario;

        public string Senha
        {
            get { return Senha_Usuario; }
            set { Senha_Usuario = value; }
        }
        private string CPF_Usuario;

        public string CPF
        {
            get { return CPF_Usuario; }
            set { CPF_Usuario = value; }
        }
        private string RG_Usuario;

        public string RG
        {
            get { return RG_Usuario; }
            set { RG_Usuario = value; }
        }
        private string Sexo_Usuario;

        public string Sexo
        {
            get { return Sexo_Usuario; }
            set { Sexo_Usuario = value; }
        }
        private string Estado_Civil_Usuario;

        public string Estado_Civil
        {
            get { return Estado_Civil_Usuario; }
            set { Estado_Civil_Usuario = value; }
        }
        private DateTime Dt_Nascimento_Usuario;

        public DateTime Dt_Nascimento
        {
            get { return Dt_Nascimento_Usuario; }
            set { Dt_Nascimento_Usuario = value; }
        }
        private int Tipo_Usuario;

        public int Tipo
        {
            get { return Tipo_Usuario; }
            set { Tipo_Usuario = value; }
        }







    }
    public class Business_Usuario : Usuario
    {
        public void inserir(Usuario u)
        {
            inserir_Usuario(u);
        }
        public void Alterar(Usuario u)
        {
            alterar_Usuario(u);
        }
        public void deletar(int id)
        {
            deletar_Usuario(id);
        }




    }
    #endregion

    #region classe Produto
    public class Produto : clsDAO
    {
        private int Id_Prod;
        public int Id
        {
            get { return Id_Prod; }
            set { Id_Prod = value; }
        }


        private string Nome_Prod;
        public string Nome
        {
            get { return Nome_Prod; }
            set { Nome_Prod = value; }
        }


        private string Marca_Prod;
        public string Marca
        {
            get { return Marca_Prod; }
            set { Marca_Prod = value; }
        }



        private string Categoria_Prod;
        public string Categoria
        {
            get { return Categoria_Prod; }
            set { Categoria_Prod = value; }
        }


        private DateTime Dt_Lancamento_Prod;
        public DateTime Data
        {
            get { return Dt_Lancamento_Prod; }
            set { Dt_Lancamento_Prod = value; }
        }

        private double Valor_Compra_Prod;
        public double Valor_Compra
        {
            get { return Valor_Compra_Prod; }
            set { Valor_Compra_Prod = value; }
        }


        private double Valor_Venda_Prod;
        public double Valor_Venda
        {
            get { return Valor_Venda_Prod; }
            set { Valor_Venda_Prod = value; }
        }


        private int Qtd_Estoque_Prod;
        public int Quantidade
        {
            get { return Qtd_Estoque_Prod; }
            set { Qtd_Estoque_Prod = value; }
        }

        private string Descricao_Prod;
        public string Descricao
        {
            get { return Descricao_Prod; }
            set { Descricao_Prod = value; }
        }

        private string Foto_Prod;
        public string Foto
        {
            get { return Foto_Prod; }
            set { Foto_Prod = value; }
        }

        private int Cod_for;
        public int codigo
        {
            get { return Cod_for; }
            set { Cod_for = value; }
        }
        private int Tipo_Venda;

        public int Tipo
        {
            get { return Tipo_Venda; }
            set { Tipo_Venda = value; }
        } 
        
    }
    public class Business_Produto : Produto
    {
        public void incluir(Produto c)
        {


            Inserir_Produto(c);

        }
        public void Alterar(Produto c)
        {

            Alterar_Produto(c);

        }
        public void Excluir(int id)
        {

            excluir_produto(id);


        }


    }
    #endregion

    #region classe marca
    public class marca : clsDAO
    {
        private int id_marca;
        public int ID
        {
            get { return id_marca; }
            set { id_marca = value; }
        }
        private string marca_prod;
        public string Marca
        {
            get { return marca_prod; }
            set { marca_prod = value; }
        }
    }
    public class Business_marca : marca
    {
        public void inserir(marca m)
        {
            inserir_Marca(m);

        }
        public void alterar(marca m)
        {
            alterar_marca(m);
        }
        public void deletar(int id)
        {
            deletar_marca(id);
        }
    }


    #endregion

    #region Classe Categoria
    public class categoria : clsDAO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string Nome_categoria;

        public string _categoria
        {
            get { return Nome_categoria; }
            set { Nome_categoria = value; }
        }
    }
    public class bussiness_categoria : categoria
    {
        public void inserir(categoria c)
        {
            inserir_categoria(c);

        }
        public void alterar(categoria c)
        {
            alterar_categoria(c);
        }
        public void deletar(int id)
        {
            deletar_categoria(id);
        }
    }

    #endregion

    #region classe Fornecedor
    public class Fornecedor : clsDAO
    {
        private int For_cod;
        private string Forn_Marca;
        private string Forn_Razao_Social;
        private string Forn_CNPJ;
        private string Forn_Telefone;
        private string Forn_Endereco;
        private string Forn_CEP;
        private string Forn_UF;
        private string Forn_Cidade;
        private string Forn_Produto;
        private string Forn_Categoria_Prod;
        private double Forn_Valor_Compra_Prod;
        private string Forn_Email;
        private string Forn_Status;

        public int Cod
        {

            get { return For_cod; }
            set { For_cod = value; }
        }

        public string Marca
        {
            get { return Forn_Marca; }
            set { Forn_Marca = value; }
        }
        public string Razao_Social
        {
            get { return Forn_Razao_Social; }
            set { Forn_Razao_Social = value; }
        }
        public string CNPJ
        {
            get { return Forn_CNPJ; }
            set { Forn_CNPJ = value; }
        }
        public string Telefone
        {
            get { return Forn_Telefone; }
            set { Forn_Telefone = value; }
        }
        public string Endereco
        {
            get { return Forn_Endereco; }
            set { Forn_Endereco = value; }
        }
        public string CEP
        {
            get { return Forn_CEP; }
            set { Forn_CEP = value; }
        }
        public string UF
        {
            get { return Forn_UF; }
            set { Forn_UF = value; }
        }
        public string Cidade
        {
            get { return Forn_Cidade; }
            set { Forn_Cidade = value; }
        }
        public string Produto_Fornecedor
        {
            get { return Forn_Produto; }
            set { Forn_Produto = value; }
        }
        public string Categoria_Produto_Fornecedor
        {
            get { return Forn_Categoria_Prod; }
            set { Forn_Categoria_Prod = value; }
        }
        public double Valor_Compra
        {
            get { return Forn_Valor_Compra_Prod; }
            set { Forn_Valor_Compra_Prod = value; }
        }
        public string Email_Fornecedor
        {
            get { return Forn_Email; }
            set { Forn_Email = value; }
        }
        public string Status_Fornecedor
        {
            get { return Forn_Status; }
            set { Forn_Status = value; }
        }
    }
    public class Bussines_Fornecedor : Fornecedor
    {
        public void Inserir_Fornecedor_cl(Fornecedor f)
        {

            Inserir_Fornecedor(f);

        }
        public void Alterar_Fornecedor_cl(Fornecedor f)
        {
            Alterar_Fornecedor(f);
        }
        public void excluir_Fornecedor_cl(int ID)
        {
            excluir_Fornecedor(ID);
        }



    }
    #endregion

   

    public class Pedido
    {
        private string Nome_Ped;
        private DateTime Dt_Venda_Ped;
        private DateTime Dt_Entrega_Ped;
        private double Valor_Venda_Ped;
        private bool Status_Ped;

        public string Nome_Produto_Pedido
        {
            get { return Nome_Ped; }
            set { Nome_Ped = value; }

        }
        public DateTime Data_da_Venda
        {
            get { return Dt_Venda_Ped; }
            set { Dt_Venda_Ped = value; }

        }
        public DateTime Data_de_Entrega
        {
            get { return Dt_Entrega_Ped; }
            set { Dt_Entrega_Ped = value; }

        }
        public double Valor_da_Venda
        {
            get { return Valor_Venda_Ped; }
            set { Valor_Venda_Ped = value; }

        }
        public bool Status_do_Pedido
        {
            get { return Status_Ped; }
            set { Status_Ped = value; }

        }

    }

    public class Pre_venda
    {

        private string Nome_Pre_Venda;
        private DateTime Dt_Compra_Pre_Venda;
        private DateTime Dt_Entrega_Pre_Venda;
        private double Valor_Compra_Pre_Venda;
        private bool Status_Pre_Venda;

        public string Nome_Produto_Pedido
        {
            get { return Nome_Pre_Venda; }
            set { Nome_Pre_Venda = value; }

        }
        public DateTime Data_da_Compra
        {
            get { return Dt_Compra_Pre_Venda; }
            set { Dt_Compra_Pre_Venda = value; }

        }
        public DateTime Data_de_Entrega
        {
            get { return Dt_Entrega_Pre_Venda; }
            set { Dt_Entrega_Pre_Venda = value; }

        }
        public double Valor_da_Compra
        {
            get { return Valor_Compra_Pre_Venda; }
            set { Valor_Compra_Pre_Venda = value; }

        }
        public bool Status_do_Pedido
        {
            get { return Status_Pre_Venda; }
            set { Status_Pre_Venda = value; }

        }
    }

    public class Forma_de_pagamento
    {
        private bool Tipo_de_Pagamento;

        public bool Tipo_Pagamento
        {
            get { return true; }

        }

        public class Pagamento_Cartao : Forma_de_pagamento
        {
            private int Numero_Cartao;
            private string Bandeira_Cartao;
            private int Assinatura_Autorizada_Cartao;
            private int Parcelas_Cartao;

            public int Numero_do_Cartao
            {
                get { return Numero_Cartao; }
                set { Numero_Cartao = value; }
            }
            public string Bandeira
            {
                get { return Bandeira_Cartao; }
                set { Bandeira_Cartao = value; }
            }
            public int Assinatura_Autorizada
            {
                get { return Assinatura_Autorizada_Cartao; }
                set { Assinatura_Autorizada_Cartao = value; }
            }
            public int Parcelas
            {
                get { return Parcelas_Cartao; }
                set { Parcelas_Cartao = value; }
            }

        }
    }

    public class Histórico_de_Transacoes
    {
        private DateTime Hist_Dt_Entrega;
        private string Hist_Nome_Cliente;
        private string Hist_Observacoes;
        private bool Hist_Status;

        public DateTime Data_Entrega
        {
            get { return Hist_Dt_Entrega; }

        }
        public string Nome_cliente
        {
            get { return Hist_Nome_Cliente; }
        }
        public string Observacoes
        {
            get { return Hist_Observacoes; }
        }
        public bool Staus
        {
            get { return Hist_Status; }
        }
    }


    
       
        public class item_carrinho
        {
            private int Id_Prod;
            private string Nome_Prod;
            private string Img_Prod;
            private int Qtd_Prod;
            private double Preco_Prod;

            public item_carrinho() 
            { 
            
            }
            public item_carrinho(int Id , string nome , string img, int qtd , double preco) 
            {
                Id_Prod = Id;
                Nome_Prod = nome;
                Img_Prod = img;
                Qtd_Prod = qtd;
                Preco_Prod = preco;
            }

            public int id 
            {
                get { return Id_Prod; }
                set {  Id_Prod = value ; }
            }
            public string nome
            {
                get { return Nome_Prod; }
                set { Nome_Prod = value; }
            }
            public string img 
            {
                get { return Img_Prod; }
                set { Img_Prod = value;}
            }
            public int qtd 
            {
                get { return Qtd_Prod; }
                set { Qtd_Prod = value;     }
            }
            public double preco 
            {
                get { return Preco_Prod; } 
                set {Preco_Prod = value; } 
            }

            public double preco_total 
            {
                get { return Qtd_Prod * preco;}
            }
        }
    
    
    
    public class carrinho 
    {
        private DateTime Data_Criacao;
        private DateTime Data_Atualizacao;
        private List<item_carrinho> _item;

        public carrinho() 
        {
            if (_item == null) 
            {
                _item = new List<item_carrinho>();
                Data_Criacao = DateTime.Now;
            }
        }
            public List<item_carrinho> itens
            {
                 get{return _item;  }
                set{_item  = value ;}
            }
            public void Inserir(int Id_Produto, double Preco,
                              int Qtd, string nome,
                              string img_prod)
            {
                int ItemIndex = ItemIndexOfID(Id_Produto);
                if (ItemIndex == -1)
                {
                   item_carrinho NovoItem = new item_carrinho();
                   NovoItem.id = Id_Produto;
                   NovoItem.nome = nome;
                   NovoItem.qtd = Qtd;
                   NovoItem.preco = Preco;
                   NovoItem.img = img_prod;
                   itens.Add(NovoItem);
                    
                }
                else
                {
                   _item[ItemIndex].qtd += 1;
                }
                Data_Atualizacao = DateTime.Now;
            }

            public void Update(int RowID, int Id_Produto, double Preco,
                              int Qtd)
            {
                item_carrinho Item = _item[RowID];
                Item.id = Id_Produto;
                Item.qtd = Qtd;
                Item.preco = Preco;
                Data_Atualizacao = DateTime.Now;
            }

            public void DeleteItem(int rowID)
            {
                _item.RemoveAt(rowID);
                Data_Atualizacao = DateTime.Now;
            }

            private int ItemIndexOfID(int id_produto)
            {
                int index = 0;
                foreach (item_carrinho item in _item)
                {
                    if (item.id == id_produto)
                    {
                        return index;
                    }
                    index += 1;
                }
                return -1;
            }

            public double Total
            {
                get
                {
                    double t = 0;

                    if (_item == null)
                    {
                        return 0;
                    }

                    foreach (item_carrinho Item in _item)
                    {
                        t += Item.preco_total;
                    }

                    return t;
                }
            }
        
        }
    
    
    }


     
    

