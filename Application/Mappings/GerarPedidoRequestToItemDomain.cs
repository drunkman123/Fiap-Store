using Application.DTO;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public static class GerarPedidoRequestToItemDomain
    {
        public static IEnumerable<Item> ToItemDomain(this GerarPedidoRequest gerarPedidoRequest)
        {
            List<Item> items = new List<Item>();

            foreach(var item in gerarPedidoRequest.IdProdutoXQuantidade)
            {
                Item itemToAdd = new Item();
                itemToAdd.IdProduto = item.IdProduto;
                itemToAdd.Quantidade = item.Quantidade;
                items.Add(itemToAdd);
            }
            
            return items;
        }
    }
}