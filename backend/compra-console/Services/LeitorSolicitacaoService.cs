using compra_console.Interfaces;
using compra_console.Models;

namespace compra_console.Services;

public class LeitorSolicitacaoService : ILeitorSolicitacaoService
{
    public List<PedidoCompra> LerPedidos(string caminhoArquivo, IProtocoloService protocoloService)
    {
        var linhas = File.ReadAllLines(caminhoArquivo);
        var registros = new List<(string Solicitante, string Item, int Quantidade, string Prioridade)>();

        foreach (var linha in linhas)
        {
            if (string.IsNullOrWhiteSpace(linha))
            {
                continue;
            }

            var campos = linha.Split(';');
            if (campos.Length != 4)
            {
                continue;
            }

            var solicitante = campos[0].Trim();
            var item = campos[1].Trim();
            var quantidadeTexto = campos[2].Trim();
            var prioridade = campos[3].Trim();

            if (!int.TryParse(quantidadeTexto, out var quantidade))
            {
                continue;
            }

            registros.Add((solicitante, item, quantidade, prioridade));
        }

        var pedidos = new List<PedidoCompra>();

        foreach (var grupo in registros.GroupBy(r => new { r.Solicitante, r.Prioridade }))
        {
            var pedido = new PedidoCompra
            {
                Numero = protocoloService.GerarProtocolo(),
                NomeSolicitante = grupo.Key.Solicitante,
                Prioridade = grupo.Key.Prioridade,
                Itens = grupo
                    .Select(g => new ItemPedidoCompra
                    {
                        NomeItem = g.Item,
                        Quantidade = g.Quantidade
                    })
                    .ToList()
            };

            pedidos.Add(pedido);
        }

        return pedidos;
    }
}
