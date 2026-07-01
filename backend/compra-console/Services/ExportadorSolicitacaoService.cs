using compra_console.Interfaces;

namespace compra_console.Services;

public class ExportadorSolicitacaoService : IExportadorSolicitacaoService
{
    public void Exportar(string caminhoArquivoSaida, List<string> linhas)
    {
        File.WriteAllLines(caminhoArquivoSaida, linhas);
    }

    public static string GerarNomeArquivoPedido(string protocolo)
    {
        return protocolo.Replace('/', '-') + ".txt";
    }
}
