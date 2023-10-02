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
        public static Pedido ToPedidoDomain(this GerarPedidoRequest gerarPedidoRequest)
        {
            Pedido pedido = new Pedido();
            pedido.IdCliente = gerarPedidoRequest.IdCliente;
            pedido.DataPedido = DateTime.Now;
            
            return pedido;

        }
    }
}
