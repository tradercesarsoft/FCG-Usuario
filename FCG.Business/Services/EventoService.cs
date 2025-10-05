using FCG.Business.Interfaces;
using FCG.Business.Models;
using FCG.Business.Services.Interfaces;

namespace FCG.Business.Services;

public class EventoService : IEventoService
{
    public readonly IEventoRepository _eventoRepository;
    public EventoService(IEventoRepository eventoRepository)
    {
        _eventoRepository = eventoRepository;
    }

    Task<IEnumerable<Evento>> IEventoService.ListarTodos()
    {
        return _eventoRepository.ListarTodos();
    }
}
