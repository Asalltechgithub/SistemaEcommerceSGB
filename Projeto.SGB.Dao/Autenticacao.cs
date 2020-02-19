using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto.SGB.Dao
{
   
    public static class Autenticacao
    {
       static string Nome;
        static string Senha;
        

        public static void Login(string nome1, string senha1)
       { 
       
       Nome = nome1;
       Senha = senha1;
       
       
       }

        public static void Logout()
        {
            Nome = null;
            Senha = null;
           
        
        }

        public static String getUsuario()
        { 
        
        return "Nome: " + Nome + "\nSenha: " + Senha ;
        
        }

        public static void Logar(string nome2)
        {

            Nome = nome2;
       }
    }
}
