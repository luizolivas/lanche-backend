namespace Lanche.Application.DTOs.Cliente
{
    public class CreateOrderDto
    {
        public List<ItemOrderDto> Itens { get; set; }
        public string Observations { get; set; }
    }

    public class ItemOrderDto
    {
        public int ProdutoId { get; set; }
        public int Quantity { get; set; }
    }
}