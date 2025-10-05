using FCG.Core.Messages;

namespace FCG.Core.Communication.Mediator
{
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;

    }
}
