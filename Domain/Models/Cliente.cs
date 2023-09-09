namespace Domain.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Endereco>? Endereco { get; set; }
        public ICollection<Pedido>? Pedidos { get; set; }
    }
}
