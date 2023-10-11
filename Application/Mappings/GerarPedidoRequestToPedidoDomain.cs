using Application.DTO;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public static class GerarPedidoRequestToPedidoDomain
    {
        public static Pedido ToPedidoDomain(this GerarPedidoRequest gerarPedidoRequest, int idCliente)
        {
            Pedido pedido = new Pedido();
            pedido.IdCliente = idCliente;
            pedido.DataPedido = DateTime.Now;
            pedido.Items = new List<Item>();

            foreach (var item in gerarPedidoRequest.IdProdutoXQuantidade)
            {
                Item itemToAdd = new Item();
                itemToAdd.Produto = new Produto();
                itemToAdd.Produto.IdProduto = item.IdProduto;
                itemToAdd.Quantidade = item.Quantidade;
                pedido.Items.Add(itemToAdd);
            }


            return pedido;

        }
    }
}
