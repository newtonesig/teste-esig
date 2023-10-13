using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteEsig.Model
{
    public class Usuario
    {
        public int PessoaId { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public Usuario(string login, string senha)
        {
            Login = login;
            Senha = senha;
        }

        public Usuario()
        {
            
        }
    }
}