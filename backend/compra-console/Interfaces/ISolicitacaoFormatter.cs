using compra_console.Models;

namespace compra_console.Interfaces;

public interface ISolicitacaoFormatter
{
    List<string> FormatarPedidosConsolidados(List<PedidoCompra> pedidos);
    List<string> FormatarItensOrdenados(List<PedidoCompra> pedidos);
    List<string> FormatarItensConsole(List<PedidoCompra> pedidos);
    List<string> FormatarPedidosConsole(List<PedidoCompra> pedidos);
    string FormatarResumoConsole(PedidoCompra pedido);
}
