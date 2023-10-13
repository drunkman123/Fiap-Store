using Application.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PedidoService : IPedidoService
    {

        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }
        public void Update(Pedido entidade)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Register(Pedido pedido)
        {
            pedido.Items = (List<Item>)await GetPriceProductsOrder(pedido.Items);

            CalculateOrderTotal(pedido, pedido.Items);

            return await _pedidoRepository.Register(pedido);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Pedido> GetById(int id)
        {
            throw new NotImplementedException();
        }

        private async Task<IEnumerable<Item>> GetPriceProductsOrder(List<Item> items)
        {
            var precosProdutos = await _pedidoRepository.GetOrderProductsPrices(items);
            var contador = 0;
            foreach(var item in precosProdutos)
            {
                items[contador].Preco = item.Preco;
                items[contador].SubTotal = item.Preco* items[contador].Quantidade;
                contador++;
            }
                
                    
            return items;
        }

        public async Task<IEnumerable<Pedido>> GetAll()
        {
            return await _pedidoRepository.GetAll();
        }

        private void CalculateOrderTotal(Pedido pedido, List<Item> items)
        {
            var valorTotalPedido = items.Sum(x => x.SubTotal);
            pedido.ValorTotal = valorTotalPedido;
        }

        public async Task<IEnumerable<Pedido>> GetAllById(int id)
        {
            return await _pedidoRepository.GetAllOrderById(id);
        }
    }
}
