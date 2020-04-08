using System.Collections.Generic;
using System.Linq;
using Fiap.Green.Startup.Domain.Entitidades;
using Fiap.Green.Startup.Domain.Infrastructure.OracleContext;

namespace Fiap.Green.Startup.Domain.Infrastructure.Repository
{
    public class PessoaRepository
    {

        private readonly MyContextDb _contextDb;

        public PessoaRepository()
        {
            _contextDb = new MyContextDb();
        }

        public IList<Pessoa> Getpessoas()
        {
            return _contextDb.Pessoa.ToList();
        }

        public Pessoa Listar(int id)
        {
            return _contextDb.Pessoa.Find(id);
        }

        public Pessoa Consultar(int id)
        {
            return _contextDb.Pessoa.Find(id);
        }

        public void Inserir(Pessoa pessoa)
        {
            _contextDb.Pessoa.Add(pessoa);
            _contextDb.SaveChanges();
        }

        public void Alterar(Pessoa pessoa)
        {
            _contextDb.Pessoa.Update(pessoa);
            _contextDb.SaveChanges();
        }


        public void Excluir(int id)
        {
            var pessoa = new Pessoa()
            {
                IdPessoa = id
            };

            _contextDb.Pessoa.Remove(pessoa);
            _contextDb.SaveChanges();
        }


    }
}