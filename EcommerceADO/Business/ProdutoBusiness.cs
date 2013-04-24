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

        public Dictionary<short, ProdutoCategorias> RetornaCategorias()
        {
            Dictionary<short, ProdutoCategorias> listaCategorias = new Dictionary<short, ProdutoCategorias>();

            foreach (var item in Enum.GetValues(typeof(ProdutoCategorias)))
            {
                ProdutoCategorias valor = (ProdutoCategorias)item;
                short chave = (short)item;

                listaCategorias.Add(chave, valor);
            }

            return listaCategorias;
        }

        public void Salvar(Produto produto)
        {
            //Validações
            if (produto == null)
            {
                throw new Exception("Objeto pessoa está nulo.");
            }
            else if (string.IsNullOrWhiteSpace(produto.Nome))
            {
                throw new Exception("Campo Nome está vazio.");
            }

            ProdutoDataAccess access = new ProdutoDataAccess();
            //Verificação do id para Salvar/Atualizar
            if (produto.Id == 0)
                access.Salvar(produto);
            else if (produto.Id > 0)
                access.Atualizar(produto);
        }

        public Produto RetornaProduto(int idProduto)
        {
            if (idProduto > 0)
            {
                ProdutoDataAccess access = new ProdutoDataAccess();
                return access.RetornaProduto(idProduto);
            }
            else
            {
                throw new Exception("Id da produto é 0.");
            }
        }
    }
}
