using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityDataAccess;
using Model;

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
    }
}
