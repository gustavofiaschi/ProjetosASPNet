using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DataAccess;

namespace Business
{
    public class PessoaBusiness
    {
        /// <summary>
        /// Metodo responsavel pelo cadastro de pessoas
        /// </summary>
        /// <param name="pessoa">pessoa para cadastro</param>
        public void Salvar(Pessoa pessoa)
        {
            //Validações
            if (pessoa == null)
            {
                throw new Exception("Objeto pessoa está nulo.");
            }
            else if (string.IsNullOrWhiteSpace(pessoa.Nome))
            {
                throw new Exception("Campo Nome está vazio.");
            }

            PessoaDataAccess access = new PessoaDataAccess();
            //Verificação do id para Salvar/Atualizar
            if (pessoa.Id == 0)
                access.Salvar(pessoa);
            else if (pessoa.Id > 0)
                access.Atualizar(pessoa);
        }

        public List<Pessoa> RetornaPessoas()
        {
            return new PessoaDataAccess().RetornaPessoas();
        }

        public Pessoa RetornaPessoa(int idPessoa)
        {
            if (idPessoa > 0)
            {
                PessoaDataAccess access = new PessoaDataAccess();
                return access.RetornaPessoa(idPessoa);
            }
            else
            {
                throw new Exception("Id da pessoa é 0.");
            }
        }
    }
}
