using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace Model
{
    public class Produto
    {
        public Produto()
        {
            this.Quantidade = 1;
        }    

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int QtdEstoque { get; set; }
        public int Quantidade { get; set; }
        public ProdutoCategorias Categoria { get; set; }
        public string Foto { get; set; }
    }
}
