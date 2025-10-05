using FCG.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FCG.Business.Interfaces;

public interface IEventoRepository
{
    Task<Evento> Adicionar(Evento evento);
    Task<IEnumerable<Evento>> ListarTodos();
}
