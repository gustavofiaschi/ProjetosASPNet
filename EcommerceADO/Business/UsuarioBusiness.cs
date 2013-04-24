using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DataAccess;
using Common;

namespace Business
{
    public class UsuarioBusiness
    {
        /// <summary>
        /// Metodo responsavel pelo cadastro de pessoas
        /// </summary>
        /// <param name="pessoa">pessoa para cadastro</param>
        public void Salvar(Usuario usuario)
        {
            //Validações
            if (usuario == null)
            {
                throw new Exception("Objeto pessoa está nulo.");
            }
            else if (string.IsNullOrWhiteSpace(usuario.Login))
            {
                throw new Exception("Campo Login está vazio.");
            }
            else if (string.IsNullOrWhiteSpace(usuario.Senha))
            {
                throw new Exception("Campo Senha está vazio.");
            }

            UsuarioDataAccess access = new UsuarioDataAccess();

            if (usuario.Id == 0)
                access.Salvar(usuario);
            else if (usuario.Id > 0)
                access.Atualizar(usuario);
        }

        public List<Usuario> RetornaUsuarios()
        {
            return new UsuarioDataAccess().RetornaUsuarios();
        }

        public Dictionary<StatusUsuario, string> RetornaStatus()
        {
            Dictionary<StatusUsuario, string> listaStatus = new Dictionary<StatusUsuario, string>();

            foreach (var item in Enum.GetValues(typeof(StatusUsuario)))
            {
                StatusUsuario chave = (StatusUsuario)item;
                string valor = ((StatusUsuario)item).ToString();

                listaStatus.Add(chave, valor);
            }

            return listaStatus;
        }

        public void Excluir(int id)
        {
            if (id > 0)
            {
                new UsuarioDataAccess().Excluir(id);
            }
            else
                throw new Exception("Id do Usuário invalido!");
        }

        public Usuario RetornaUsuario(int id)
        {
            return new UsuarioDataAccess().RetornaUsuario(id);
        }

        public Usuario RealizarLogin(string usuario, string senha)
        {
            if (string.IsNullOrWhiteSpace(usuario))
            {
                throw new Exception("Usuário inválido");
            }

            if (string.IsNullOrWhiteSpace(senha))
            {
                throw new Exception("Senha inválida");
            }

            return new UsuarioDataAccess().RealizarLogin(usuario, senha);
        }
    }
}
