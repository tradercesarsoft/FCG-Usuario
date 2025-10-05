using FCG.Business.Interfaces;
using FCG.Business.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FCG.Infra.Data.Repositories;

public sealed class EventoRepository : IEventoRepository
{

    protected readonly ApplicationDbContext _db;
    public EventoRepository(ApplicationDbContext context)
    {
        _db = context;
    }

    public async Task<Evento> Adicionar(Evento evento)
    {
        try
        {
            _db.Evento.Add(evento);
            int qtde = await _db.SaveChangesAsync();
            return evento;
        }
        catch (Exception ex)
        {
            // Log do erro
            throw;
        }
    }

    public async Task<IEnumerable<Evento>> ListarTodos()
    {
        return _db.Evento;
    }
}
