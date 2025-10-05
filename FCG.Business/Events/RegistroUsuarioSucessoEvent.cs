using FCG.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FCG.Business.Events;

public sealed class RegistroUsuarioEvent : Event
{
    public string Email { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public bool Sucesso { get; set; }

    public RegistroUsuarioEvent(string email, string nome, string descricao, bool sucesso)
    {
        Email = email;
        Nome = nome;
        Descricao = descricao;
        Sucesso = sucesso;
        Timestamp = DateTime.UtcNow; 
    }

}
