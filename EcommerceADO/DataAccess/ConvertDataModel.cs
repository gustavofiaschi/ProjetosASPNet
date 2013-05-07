using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityDataAccess;
using Model;
using Common;

namespace DataAccess
{
    public static class ConvertDataModel
    {
        //Criação de Extension Methods para conversão de dados
        public static EPessoa ToEPessoa(this Pessoa pessoa, EPessoa Epessoa = null)
        {
            if (Epessoa == null)
                Epessoa = new EPessoa();

            if (pessoa != null)
            {
                Epessoa.Id = pessoa.Id;
                Epessoa.Nome = pessoa.Nome;
                Epessoa.NomeFoto = pessoa.NomeFoto;
                Epessoa.CPF = pessoa.CPF;
                Epessoa.DataNascimento = pessoa.DataNascimento;
            }

            return Epessoa;
        }

        //Criação de Extension Methods para conversão de dados
        public static Pessoa ToPessoa(this EPessoa Epessoa)
        {
            Pessoa pessoa = new Pessoa();

            if (Epessoa != null)
            {
                pessoa.Id = Epessoa.Id;
                pessoa.Nome = Epessoa.Nome;
                pessoa.NomeFoto = Epessoa.NomeFoto;
                pessoa.CPF = Epessoa.CPF;
                pessoa.DataNascimento = Epessoa.DataNascimento == null ? DateTime.MinValue : Epessoa.DataNascimento.Value;
            }

            return pessoa;
        }

        public static EProduto ToEProduto(this Produto produto, EProduto Eproduto = null)
        {
            if(Eproduto == null)
                Eproduto = new EProduto();

            if (produto != null)
            {
                Eproduto.Id = produto.Id;
                Eproduto.CategoriaId = (short)produto.Categoria;
                Eproduto.Descricao = produto.Descricao;
                Eproduto.Foto = produto.Foto;
                Eproduto.Nome = produto.Nome;
                Eproduto.Preco = produto.Preco;
                Eproduto.QtdEstoque = produto.QtdEstoque;
            }

            return Eproduto;
        }

        public static Produto ToProduto(this EProduto Eproduto)
        {
            Produto produto = new Produto();
            if (Eproduto != null)
            {
                produto.Id = Eproduto.Id;
                produto.Categoria = (ProdutoCategorias)Eproduto.CategoriaId;
                produto.Descricao = Eproduto.Descricao;
                produto.Foto = Eproduto.Foto;
                produto.Nome = Eproduto.Nome;
                produto.Preco = Eproduto.Preco;
                produto.QtdEstoque = Eproduto.QtdEstoque;
            }

            return produto;
        }
    }

}
