using compra_console.Models;

namespace compra_console.Interfaces;

public interface ILeitorSolicitacaoService
{
    List<PedidoCompra> LerPedidos(string caminhoArquivo, IProtocoloService protocoloService);
}
