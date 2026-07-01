using compra_console.Models;

namespace compra_console.Services;

public class SolicitacaoFormatter : compra_console.Interfaces.ISolicitacaoFormatter
{
    public List<string> FormatarPedidosConsolidados(List<PedidoCompra> pedidos)
    {
        var linhas = new List<string>
        {
            "Numero;Solicitante;Prioridade;Item;Quantidade",
            string.Empty
        };

        linhas.AddRange(pedidos
            .SelectMany(pedido => pedido.Itens.Select(item => new
            {
                pedido.Numero,
                pedido.NomeSolicitante,
                pedido.Prioridade,
                Item = item
            }))
            .OrderBy(registro => registro.NomeSolicitante)
            .ThenBy(registro => registro.Item.NomeItem)
            .Select(registro =>
                $"{registro.Numero};{registro.NomeSolicitante};{registro.Prioridade};{registro.Item.NomeItem};{registro.Item.Quantidade}"));

        return linhas;
    }

    public List<string> FormatarItensOrdenados(List<PedidoCompra> pedidos)
    {
        var linhas = new List<string>
        {
            "Numero;Solicitante;Prioridade;Item;Quantidade",
            string.Empty
        };

        linhas.AddRange(pedidos
            .SelectMany(pedido => pedido.Itens.Select(item => new
            {
                pedido.Numero,
                pedido.NomeSolicitante,
                pedido.Prioridade,
                Item = item
            }))
            .OrderBy(registro => registro.Item.NomeItem)
            .ThenBy(registro => registro.NomeSolicitante)
            .Select(registro =>
                $"{registro.Numero};{registro.NomeSolicitante};{registro.Prioridade};{registro.Item.NomeItem};{registro.Item.Quantidade}"));

        return linhas;
    }

    public List<string> FormatarItensConsole(List<PedidoCompra> pedidos)
    {
        return pedidos
            .SelectMany(pedido => pedido.Itens.Select(item => new
            {
                pedido.Numero,
                pedido.NomeSolicitante,
                pedido.Prioridade,
                Item = item
            }))
            .OrderBy(registro => registro.Item.NomeItem)
            .ThenBy(registro => registro.NomeSolicitante)
            .Select(registro =>
                $"{registro.Numero} | {registro.NomeSolicitante} | {registro.Prioridade} | Item: {registro.Item.NomeItem} | Quantidade: {registro.Item.Quantidade}")
            .ToList();
    }

    public List<string> FormatarPedidosConsole(List<PedidoCompra> pedidos)
    {
        return pedidos
            .SelectMany(pedido => pedido.Itens.Select(item => new
            {
                pedido.Numero,
                pedido.NomeSolicitante,
                pedido.Prioridade,
                Item = item
            }))
            .OrderBy(registro => registro.NomeSolicitante)
            .ThenBy(registro => registro.Item.NomeItem)
            .Select(registro =>
                $"{registro.Numero} | {registro.NomeSolicitante} | {registro.Prioridade} | Item: {registro.Item.NomeItem} | Quantidade: {registro.Item.Quantidade}")
            .ToList();
    }

    public string FormatarResumoConsole(PedidoCompra pedido)
    {
        var itens = string.Join(", ", pedido.Itens.Select(i => $"{i.NomeItem} ({i.Quantidade})"));
        return $"{pedido.Numero} | {pedido.NomeSolicitante} | {pedido.Prioridade} | Itens: {itens}";
    }
}
