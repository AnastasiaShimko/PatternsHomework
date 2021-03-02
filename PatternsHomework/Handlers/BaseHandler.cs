using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PatternsHomework.Patterns;

namespace PatternsHomework.Handlers
{
    abstract class BaseHandler : ChainOfResponsibility.IHandler
    {
        private ChainOfResponsibility.IHandler _nextHandler;

        public ChainOfResponsibility.IHandler SetNext(ChainOfResponsibility.IHandler handler)
        {
            this._nextHandler = handler;
            return handler;
        }

        public virtual object Handle(object request)
        {
            if (this._nextHandler != null)
            {
                return this._nextHandler.Handle(request);
            }
            else
            {
                return null;
            }
        }
    }
}
