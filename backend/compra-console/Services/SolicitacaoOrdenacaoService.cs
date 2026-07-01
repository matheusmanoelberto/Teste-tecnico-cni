using compra_console.Enums;
using compra_console.Interfaces;
using compra_console.Models;

namespace compra_console.Services;

public class SolicitacaoOrdenacaoService : ISolicitacaoOrdenacaoService
{
    public List<PedidoCompra> Ordenar(List<PedidoCompra> pedidos, TipoOrdenacao tipoOrdenacao)
    {
        return tipoOrdenacao switch
        {
            TipoOrdenacao.Item => pedidos
                .OrderBy(p => p.Itens.FirstOrDefault()?.NomeItem ?? string.Empty)
                .ThenBy(p => p.NomeSolicitante)
                .ToList(),
            TipoOrdenacao.Solicitante => pedidos
                .OrderBy(p => p.NomeSolicitante)
                .ThenBy(p => p.Itens.FirstOrDefault()?.NomeItem ?? string.Empty)
                .ToList(),
            _ => pedidos
        };
    }
}
