namespace Werter.ProjetoCassandra.Shared.Handlers
{
    public interface ICommandResult
    {
        bool Sucesso { get; set; }
        string Mensagem { get; set; }
    }
}
