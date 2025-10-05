using FCG.Core.Messages;


namespace FCG.Business.Events;

public sealed class AlteraSenhaUsuarioEvent : Event
{
    public string Email { get; set; }
    public string Descricao { get; set; }
    public bool Sucesso { get; set; }

    public AlteraSenhaUsuarioEvent(string email, string descricao, bool sucesso)
    {
        Email = email;
        Descricao = descricao;
        Sucesso = sucesso;
        Timestamp = DateTime.UtcNow; 
    }
}
