using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCG.Business.Services.Interfaces;

public interface IEventoService
{
    Task<IEnumerable<Models.Evento>> ListarTodos();
}
