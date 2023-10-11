using Application.DTO;
using Domain.Models;

namespace Application.Mappings
{
    public static class GetAllOrdersByIdResponse
    {
        public static IList<GetAllOrdersResponse> ToOrdersResponse(this IEnumerable<Pedido> pedidoResponse)
        {
            List<GetAllOrdersResponse> listaRetorno = new List<GetAllOrdersResponse>();
            foreach (var pedido in pedidoResponse)
            {
                GetAllOrdersResponse ordersResponse = new GetAllOrdersResponse();
                ordersResponse.Items = new List<OrdersItemsResponse>();
                ordersResponse.IdCliente = pedido.IdCliente;
                ordersResponse.IdPedido = pedido.IdPedido;
                ordersResponse.DataPedido = pedido.DataPedido;
                ordersResponse.Pago = pedido.Pago;
                ordersResponse.ValorTotal = pedido.ValorTotal;
                foreach(var items in pedido.Items)
                {
                    var itemsToAdd = new OrdersItemsResponse();
                    itemsToAdd.SubTotal = items.SubTotal;
                    itemsToAdd.Quantidade = items.Quantidade;
                    itemsToAdd.Preco = items.Preco;
                    itemsToAdd.Produto = new OrdersProdutosResponse();
                    itemsToAdd.Produto.Nome = items.Produto.Nome;
                    ordersResponse.Items.Add(itemsToAdd);
                }
                listaRetorno.Add(ordersResponse);
            }

            return listaRetorno;

        }
    }
}
