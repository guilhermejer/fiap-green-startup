using System;
using Fiap.Green.Startup.Domain.Entitidades;
using Fiap.Green.Startup.Domain.Infrastructure.Repository;

namespace Fiap.Green.Startup.Domain.Services
{
    public class PessoaServices
    {

        private readonly PessoaRepository _pessoaRepository;

        public PessoaServices()
        {
            _pessoaRepository = new PessoaRepository();
        }
        public Pessoa CadastrarPessoa(Pessoa pessoa)
        {

            if (pessoa == null)
                return null;

            _pessoaRepository.Inserir(pessoa);

            return pessoa;
        }
    }
}
