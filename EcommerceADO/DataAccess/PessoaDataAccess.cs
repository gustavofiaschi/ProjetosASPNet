using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using EntityDataAccess;

namespace DataAccess
{
    public class PessoaDataAccess : Conexao
    {
        public PessoaDataAccess() : base()
        {
            
        }

        public void Salvar(Pessoa pessoa)
        {
            SqlCommand cmd = new SqlCommand("Insert into Pessoa (Nome, CPF, DataNascimento, NomeFoto) values (@Nome, @CPF, @DataNascimento, @NomeFoto)", this.Connection);
            
            cmd.Parameters.AddWithValue("@Nome", pessoa.Nome);
            cmd.Parameters.AddWithValue("@CPF", pessoa.CPF);
            cmd.Parameters.AddWithValue("@DataNascimento", pessoa.DataNascimento);
            cmd.Parameters.AddWithValue("@NomeFoto", pessoa.NomeFoto);

            this.Connect();
            int linhas = cmd.ExecuteNonQuery();
            this.Disconnect();
        }

        public void SalvarEntity(Pessoa pessoa)
        {
            EPessoa pessoaEntity = ConvertDataModel.PessoaToEPessoa(pessoa);            
            this.EntityContext.Pessoa.AddObject(pessoaEntity);
            this.EntityContext.SaveChanges();            
        }
        
        public List<Pessoa> RetornaPessoas()
        {
            SqlCommand cmd = new SqlCommand("Select * From Pessoa", this.Connection);

            this.Connect();
            SqlDataReader dr = cmd.ExecuteReader();

            List<Pessoa> listaPessoas = new List<Pessoa>();

            while (dr.Read())
            {
                Pessoa pessoa = new Pessoa();
                pessoa.Nome = dr["Nome"].ToString();
                pessoa.CPF = dr["CPF"].ToString();
                pessoa.DataNascimento = Convert.ToDateTime(dr["DataNascimento"]);
                pessoa.Id = int.Parse(dr["Id"].ToString());
                pessoa.NomeFoto = dr["NomeFoto"] == null ? string.Empty : dr["NomeFoto"].ToString();

                listaPessoas.Add(pessoa);
            }

            return listaPessoas;
        }

        public List<Pessoa> RetornaPessoasEntity()
        {
            List<Pessoa> listaPessoas = new List<Pessoa>();
            
            foreach (var item in this.EntityContext.Pessoa)
                listaPessoas.Add(ConvertDataModel.EPessoaToPessoa(item));            

            return listaPessoas;
        }

        public Pessoa RetornaPessoa(int idPessoa)
        {
            SqlCommand cmd = new SqlCommand("Select * From Pessoa where Id = @id", this.Connection);
            cmd.Parameters.AddWithValue("@id", idPessoa);

            this.Connect();
            SqlDataReader dr = cmd.ExecuteReader();

            Pessoa pessoa = new Pessoa();
            
            while (dr.Read())
            {                
                pessoa.Nome = dr["Nome"].ToString();
                pessoa.CPF = dr["CPF"].ToString();
                pessoa.DataNascimento = Convert.ToDateTime(dr["DataNascimento"]);
                pessoa.Id = int.Parse(dr["Id"].ToString());
                pessoa.NomeFoto = dr["NomeFoto"] == null ? string.Empty : dr["NomeFoto"].ToString();
            }

            return pessoa;
        }

        public Pessoa RetornaPessoaEntity(int idPessoa)
        {
            //LAMBDA EXPRESSION
            return ConvertDataModel.EPessoaToPessoa(this.EntityContext.Pessoa.Where(p => p.Id == idPessoa).FirstOrDefault());

            //LINQ
            //var resultado = from pessoa in this.EntityContext.Pessoa
            //                where pessoa.Id == idPessoa
            //                select ConvertDataModel.EPessoaToPessoa(pessoa);

            //return resultado.FirstOrDefault();
        }
        
        public void Atualizar(Pessoa pessoa)
        {
            SqlCommand cmd = new SqlCommand("Update Pessoa set Nome = @Nome, CPF = @CPF, DataNascimento = @DataNasc, NomeFoto = @NomeFoto where Id = @Id", this.Connection);
            cmd.Parameters.AddWithValue("@Nome", pessoa.Nome);
            cmd.Parameters.AddWithValue("@CPF", pessoa.CPF);
            cmd.Parameters.AddWithValue("@DataNasc", pessoa.DataNascimento);
            cmd.Parameters.AddWithValue("@NomeFoto", pessoa.NomeFoto);
            cmd.Parameters.AddWithValue("@Id", pessoa.Id);

            this.Connect();
            cmd.ExecuteNonQuery();
            this.Disconnect();
        }

        public void AtualizarEntity(Pessoa pessoa)
        {
            EPessoa pessoaEntity = this.EntityContext.Pessoa.Where(p => p.Id == pessoa.Id).FirstOrDefault();
            pessoaEntity = ConvertDataModel.PessoaToEPessoa(pessoa, pessoaEntity);
            this.EntityContext.SaveChanges();
        }
    }
}
