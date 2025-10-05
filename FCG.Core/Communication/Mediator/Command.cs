﻿using FCG.Core.Messages;
using MediatR;


namespace FCG.Core.Communication.Mediator
{
    public abstract class Command: Message, IRequest<bool>
    {
        public DateTime Timestamp { get; private set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public virtual bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}
