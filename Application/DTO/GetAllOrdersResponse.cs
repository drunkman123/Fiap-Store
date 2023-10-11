using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class GetAllOrdersResponse
    {
        public int IdPedido { get; set; }
        public int IdCliente { get; set; }
        public DateTime DataPedido { get; set; }
        public decimal ValorTotal { get; set; }
        public bool Pago { get; set; } = false;
        public List<OrdersItemsResponse> Items { get; set; }
    }
    public class OrdersItemsResponse
    {
        public OrdersProdutosResponse Produto { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public decimal SubTotal { get; set; }
    }
    public class OrdersProdutosResponse
    {
        public string Nome { get; set; }
    }
}
