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
    }
}
