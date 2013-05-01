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
        public static EPessoa PessoaToEPessoa(Pessoa pessoa, EPessoa Epessoa = null)
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

        public static Pessoa EPessoaToPessoa(EPessoa Epessoa)
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
