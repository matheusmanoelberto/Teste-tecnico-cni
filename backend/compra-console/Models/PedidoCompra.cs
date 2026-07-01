namespace compra_console.Models;

public class PedidoCompra
{
    public string Numero { get; set; } = string.Empty;
    public string NomeSolicitante { get; set; } = string.Empty;
    public string Prioridade { get; set; } = string.Empty;
    public List<ItemPedidoCompra> Itens { get; set; } = new();
}
