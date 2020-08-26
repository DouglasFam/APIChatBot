using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly string _connectingString;
      //  private readonly PessoaContext _context;
        public PessoaRepository(string connectionString)
        {
            _connectingString = connectionString;
           // _context = context;
        }

        public IEnumerable<Pessoa> GetAll()
        {
            //  return _context.Pessoa.ToList();

            using (MySqlConnection connection = new MySqlConnection(_connectingString))
            {
                return connection.Query<Pessoa>("SELECT Codigo, Nome, Login, Endereco, Telefone, Equipe, Funcao FROM Pessoa ORDER BY Nome ASC");
            }
        }

        public IEnumerable<Pessoa> GetNome(string nome)
        {
            //  return _context.Pessoa.ToList();

            using (MySqlConnection connection = new MySqlConnection(_connectingString))
            {
                return connection.Query<Pessoa>("SELECT Codigo, Nome, Login, Endereco, Telefone, Equipe, Funcao FROM Pessoa WHERE NOME LIKE '%" + nome + "%';");
            }
        }

        public void Add(Pessoa pessoa)
        {
            
        }

        public Pessoa Find(long key)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectingString))
            {
                var MyQuery = connection.QueryFirstOrDefault<Pessoa>("SELECT Codigo, Nome, Login, Endereco, Telefone, Equipe, Funcao FROM Pessoa WHERE CODIGO = " + key);
                return MyQuery; 
            }
        }

        public Pessoa FindLogin(string login)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectingString))
            {
                var MyQuery = connection.QueryFirstOrDefault<Pessoa>("SELECT Codigo, Nome, Login, Endereco, Telefone, Equipe, Funcao FROM Pessoa WHERE LOGIN = '" + login + "'");
                return MyQuery;
            }
        }

        public Pessoa FindPessoa(string nome)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectingString))
            {
                var MyQuery = connection.QueryFirstOrDefault<Pessoa>("SELECT Codigo, Nome, Login, Endereco, Telefone, Equipe, Funcao FROM Pessoa WHERE NOME LIKE '%" + nome + "%';");
                return MyQuery;
            }
        }

        public void Remove(long key)
        {
            throw new NotImplementedException();
        }

        public void Update(Pessoa pessoa)
        {
            throw new NotImplementedException();
        }
    }
}
