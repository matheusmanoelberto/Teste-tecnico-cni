using compra_console.Enums;
using compra_console.Models;

namespace compra_console.Interfaces;

public interface ISolicitacaoOrdenacaoService
{
    List<PedidoCompra> Ordenar(List<PedidoCompra> pedidos, TipoOrdenacao tipoOrdenacao);
}
