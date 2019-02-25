using backend.Models;
using backend.Repositories;
using backend.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace backend.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProdutoController
    {
        private readonly IProdutoRepository Repository;
        public ProdutoController(IProdutoRepository repository)
        {
            Repository = repository;
        }

        [HttpPost]
        public void Incluir([FromBody] ProdutoPostVM produto)
        {
            Repository.Incluir(new Produto()
            {
                Codigo = produto.Codigo,
                Descricao = produto.Descricao,
                Detalhes = produto.Detalhes,
                Valor = produto.Valor
            });
        }

        [HttpPut]
        public void Editar([FromBody] ProdutoPutVM produto)
        {
            Repository.Editar(new Produto()
            {
                Id = produto.Id,
                Codigo = produto.Codigo,
                Descricao = produto.Descricao,
                Detalhes = produto.Detalhes,
                Valor = produto.Valor,
            });
        }

        [HttpDelete("{id}")]
        public void Apagar([FromRoute] int id)
        {
            Repository.Apagar(id);
        }

        [HttpGet]
        public IEnumerable<Produto> Obter()
        {
            return Repository.ObterTodos();
        }

        [HttpGet("{id}")]
        public Produto Obter([FromRoute] int id)
        {
            if (id == null) return null;
            return Repository.Obter(id);
        }
    }
}