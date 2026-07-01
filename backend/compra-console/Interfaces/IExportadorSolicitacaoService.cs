namespace compra_console.Interfaces;

public interface IExportadorSolicitacaoService
{
    void Exportar(string caminhoArquivoSaida, List<string> linhas);
}
