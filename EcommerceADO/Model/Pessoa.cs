using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Pessoa
    {
        public Pessoa()
        {
            
        }

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string NomeFoto { get; set; }
    }

    public class PessoaGasto
    {
        public Pessoa Pessoa { get; set; }
        public decimal Gastos { get; set; }
        public Produto ProdutoMaisConsumido { get; set; }
    }
}
