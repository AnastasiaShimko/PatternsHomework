using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatternsHomework.Handlers
{
    class AdminHandler : BaseHandler
    {
        public override object Handle(object request)
        {
            if ((request as string) == "Admin")
            {
                return $"admin";
            }
            else
            {
                return base.Handle(request);
            }
        }
    }
}
