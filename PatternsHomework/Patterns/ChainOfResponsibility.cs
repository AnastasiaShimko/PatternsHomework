using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatternsHomework.Patterns
{
    public class ChainOfResponsibility
    {
        public interface IHandler
        {
            IHandler SetNext(IHandler handler);

            object Handle(object request);
        }
    }
}
