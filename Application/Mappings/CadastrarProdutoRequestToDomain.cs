using Application.DTO;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public static class CadastrarProdutoRequestToDomain
    {
        public static Produto ToProdutoDomain(this CadastrarProdutoRequest cadastrarProdutoRequest)
        {
            Produto produto = new Produto();
            produto.IdProduto = 0;
            produto.Nome = cadastrarProdutoRequest.Nome;
            produto.Descricao = cadastrarProdutoRequest.Descricao;
            produto.IdTipoProduto = cadastrarProdutoRequest.IdTipoProduto;
            produto.Preco = cadastrarProdutoRequest.Preco;
            produto.Quantidade = cadastrarProdutoRequest.Quantidade;

            return produto;

        }
    }
}
