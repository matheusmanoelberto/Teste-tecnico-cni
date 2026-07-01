using compra_console.Enums;
using compra_console.Services;
using compra_console.Interfaces;

ILeitorSolicitacaoService leitorSolicitacaoService = new LeitorSolicitacaoService();
ISolicitacaoOrdenacaoService solicitacaoOrdenacaoService = new SolicitacaoOrdenacaoService();
ISolicitacaoFormatter formatter = new SolicitacaoFormatter();
IExportadorSolicitacaoService exportador = new ExportadorSolicitacaoService();

while (true)
{
    IProtocoloService protocoloService = new ProtocoloService();

    Console.Write("Informe o caminho do arquivo .txt (Enter para usar solicitacoes.txt local): ");
    var caminhoInformado = Console.ReadLine();
    var caminhoPadrao = Path.Combine(Directory.GetCurrentDirectory(), "solicitacoes.txt");
    var caminhoArquivo = string.IsNullOrWhiteSpace(caminhoInformado)
        ? caminhoPadrao
        : caminhoInformado.Trim().Trim('\uFEFF');

    if (!File.Exists(caminhoArquivo))
    {
        Console.WriteLine($"Arquivo nao encontrado: {caminhoArquivo}");
    }
    else
    {
        var pedidos = leitorSolicitacaoService.LerPedidos(caminhoArquivo, protocoloService);

        if (pedidos.Count == 0)
        {
            Console.WriteLine("Nenhum pedido valido foi encontrado.");
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Solicitacoes geradas:");
            Console.WriteLine("Ordenacao aplicada: ordem de entrada");
            foreach (var pedido in pedidos)
            {
                Console.WriteLine(formatter.FormatarResumoConsole(pedido));
            }

            Console.WriteLine();
            Console.WriteLine("Como deseja ordenar os pedidos?");
            Console.WriteLine("1 - Por item (primeiro item do pedido)");
            Console.WriteLine("2 - Por solicitante");
            Console.Write("Escolha: ");

            var opcao = Console.ReadLine();
            var tipoOrdenacao = opcao == "2" ? TipoOrdenacao.Solicitante : TipoOrdenacao.Item;

            if (opcao is not ("1" or "2"))
            {
                Console.WriteLine("Opcao invalida. Aplicando ordenacao por item.");
            }

            var pedidosOrdenados = solicitacaoOrdenacaoService.Ordenar(pedidos, tipoOrdenacao);

            var descricaoOrdenacao = tipoOrdenacao == TipoOrdenacao.Item
                ? "por item"
                : "por solicitante";

            Console.WriteLine();
            Console.WriteLine("Solicitacoes geradas:");
            Console.WriteLine($"Ordenacao aplicada: {descricaoOrdenacao}");

            if (tipoOrdenacao == TipoOrdenacao.Item)
            {
                foreach (var linha in formatter.FormatarItensConsole(pedidosOrdenados))
                {
                    Console.WriteLine(linha);
                }
            }
            else
            {
                foreach (var linha in formatter.FormatarPedidosConsole(pedidosOrdenados))
                {
                    Console.WriteLine(linha);
                }
            }

            Console.WriteLine();
            Console.Write("Deseja exportar o resultado consolidado? (s/n): ");
            var desejaExportar = Console.ReadLine();

            if (string.Equals(desejaExportar, "s", StringComparison.OrdinalIgnoreCase))
            {
                var diretorioBase = Path.GetDirectoryName(Path.GetFullPath(caminhoArquivo)) ?? AppContext.BaseDirectory;
                var diretorioSaida = Path.Combine(diretorioBase, "salva");
                Directory.CreateDirectory(diretorioSaida);

                var linhasConsolidadas = tipoOrdenacao == TipoOrdenacao.Item
                    ? formatter.FormatarItensOrdenados(pedidosOrdenados)
                    : formatter.FormatarPedidosConsolidados(pedidosOrdenados);
                var nomeArquivo = tipoOrdenacao == TipoOrdenacao.Item
                    ? "pedidos-ordenados-por-item.txt"
                    : "pedidos-ordenados-por-solicitante.txt";

                var caminhoSaida = Path.Combine(diretorioSaida, nomeArquivo);
                exportador.Exportar(caminhoSaida, linhasConsolidadas);
                Console.WriteLine($"Arquivo exportado: {caminhoSaida}");
            }
            else
            {
                Console.WriteLine("Exportacao nao realizada.");
            }
        }
    }

    Console.WriteLine();
    Console.Write("Deseja integrar um novo pedido? (s/n): ");
    var continuar = Console.ReadLine();

    if (!string.Equals(continuar, "s", StringComparison.OrdinalIgnoreCase))
    {
        Console.WriteLine("Encerrando aplicacao.");
        break;
    }

    Console.WriteLine();
}
