using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;

namespace Business
{
    public class PedidoBusiness
    {
        public int CriarPedido(Model.Usuario usuario, List<Model.Produto> listaProdutos)
        {
            if (listaProdutos.Count <= 0)
                throw new Exception("Lista de Produtos está vazia");

            if (usuario == null)
                throw new Exception("Lista de Produtos está vazia");

            int idPedido = new PedidoDataAccess().CriarPedido(usuario.Id, listaProdutos);

            if (idPedido <= 0)
                throw new Exception("Numero de Pedido retornado é inválido");

            return idPedido;
        }
    }
}
