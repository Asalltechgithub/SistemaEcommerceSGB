using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Projeto.SGB.Dao;
using ProjetoSGB_Model;
namespace Projeto.SGB.Dao
{
    public abstract class Carrinho_de_compras
    {
        //public List<Produto> Selecionar_produto()
        //{

        //    DataTable Dt = new clsDAO().Selecionar_Produto();

        //    List<Produto> Lp = new List<Produto>();

        //    for (int i = 0; i < Dt.Rows.Count; i++)
        //    {

        //        Lp.Add(new Produto()
        //        {
        //            Id = Convert.ToInt32(Dt.Rows[i]["IdProd"]),
        //            _NProd = Convert.ToString(Dt.Rows[i]["NProduto"]),
        //            _Fabricante = Convert.ToString(Dt.Rows[i]["Fabricante"]),
        //            _QEstoque = Convert.ToInt32(Dt.Rows[i]["QEstoque"]),
        //            unidade = Convert.ToInt32(Dt.Rows[i]["PUnit"]),
        //            _Ativo = Convert.ToBoolean(Dt.Rows[i]["Ativo"]),
        //            categoria = new pCategoria()
        //            {

        //                _Id_Categoria1 = Convert.ToInt32(Dt.Rows[i]["IdCatg"]),
        //                _NCategoria1 = Convert.ToString(Dt.Rows[i]["NCatg"]),
        //                _Ativo = Convert.ToBoolean(Dt.Rows[i]["Ativo"]),
        //            }

        //        }
        //        );

        //    }
        //}
    }
}
