using FCG.Business.Interfaces;
using FCG.Business.Models;
using FCG.Core.Communication.Mediator;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FCG.Business.Events;

public sealed class AuthEventHandler :  INotificationHandler<RegistroUsuarioEvent>,
                                        INotificationHandler<LoginUsuarioEvent>,
                                        INotificationHandler<AlteraSenhaUsuarioEvent>
{
    private readonly IEventoRepository _eventoRepository;


    public AuthEventHandler(IEventoRepository eventoRepository)
    {
        _eventoRepository = eventoRepository;
    }



    public Task Handle(RegistroUsuarioEvent notification, CancellationToken cancellationToken)
    {
        _eventoRepository.Adicionar(new Evento
        {
            Nome = nameof(RegistroUsuarioEvent),
            Data = DateTime.Now,
            Descricao = $"Tentativa de Registar Usuário com Nome: {notification.Nome} e Email: {notification.Email} realizado com {(notification.Sucesso ? "Sucesso" : "Falha.")}. Descricao: {notification.Descricao}"
        });

        return Task.CompletedTask;
    }

    public Task Handle(LoginUsuarioEvent notification, CancellationToken cancellationToken)
    {
        _eventoRepository.Adicionar(new Evento
        {
            Nome = nameof(LoginUsuarioEvent),
            Data = DateTime.Now,
            Descricao = $"Tentativa de Login do Usuário com Email: {notification.Email} realizado com {(notification.Sucesso ? "Sucesso" : "Falha")}. Descricao: {notification.Descricao}"
        });

        return Task.CompletedTask;
    }

    public Task Handle(AlteraSenhaUsuarioEvent notification, CancellationToken cancellationToken)
    {
        _eventoRepository.Adicionar(new Evento
        {
            Nome = nameof(AlteraSenhaUsuarioEvent),
            Data = DateTime.Now,
            Descricao = $"Tentativa de Alterar senha do Usuário com Email: {notification.Email} realizado com {(notification.Sucesso ? "Sucesso" : "Falha")}. Descricao: {notification.Descricao}"
        });

        return Task.CompletedTask;
    }
}
