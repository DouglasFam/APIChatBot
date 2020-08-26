using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Pessoa
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Login { get; set; }
        public string Telefone { get; set; }
        public string Equipe { get; set; }
        public string Funcao { get; set; }
    }
}
