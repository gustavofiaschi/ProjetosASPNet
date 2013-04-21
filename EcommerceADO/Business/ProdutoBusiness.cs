using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Common;
using DataAccess;

namespace Business
{
    public class ProdutoBusiness
    {
        public List<Produto> RetornaProdutos(ProdutoCategorias categoria = ProdutoCategorias.Todos)
        {
            return new ProdutoDataAccess().RetornaProdutos(categoria);
        }
    }
}
