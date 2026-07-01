namespace compra_console.Services;

public class ProtocoloService : compra_console.Interfaces.IProtocoloService
{
    private int _contador;

    public string GerarProtocolo()
    {
        _contador++;
        var ano = DateTime.Now.Year;
        return $"COMP-{_contador:0000}/{ano}";
    }
}
