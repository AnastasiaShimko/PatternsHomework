using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatternsHomework.Handlers
{
    class VisitorHandler : BaseHandler
    {
        public override object Handle(object request)
        {
            if ((request as string) == "Visitor")
            {
                return $"visitor";
            }
            else
            {
                return base.Handle(request);
            }
        }
    }
}
