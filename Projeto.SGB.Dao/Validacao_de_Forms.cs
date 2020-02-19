using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace Projeto.SGB.Dao
{
    class Validacao_de_Forms
    {
        string Msg;

        private bool Validar(string Data )
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

               Msg = "Formatação Invalida da Data";
            }
            return false;
        }


    }
}
