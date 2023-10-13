using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteEsig.Model
{
    public class PessoaSalario
    {
        public int PessoaId { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public decimal Salario { get; set; }
    }
}