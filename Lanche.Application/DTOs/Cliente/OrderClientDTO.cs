using Lanche.Application.DTOs.Cliente;

public class PedidoAdminDTO
{
    public int Id { get; set; }
    public string ClientName { get; set; }
    public DateTime DateHour { get; set; }
    public string Status { get; set; }
    public decimal TotalValue { get; set; }
    public List<ItemOrderDto> Itens { get; set; }
}
