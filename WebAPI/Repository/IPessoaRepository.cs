using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repository
{
    public interface IPessoaRepository
    {
        void Add(Pessoa pessoa);
        IEnumerable<Pessoa> GetAll();
        IEnumerable<Pessoa> GetNome(string nome);
        Pessoa Find(long key);
        Pessoa FindLogin(string login);
        Pessoa FindPessoa(string nome);
        void Remove(long key);
        void Update(Pessoa pessoa);
    }
}
