using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatternsHomework.Handlers
{
    class UserHandler : BaseHandler
    {
        public override object Handle(object request)
        {
            if ((request as string) == "User")
            {
                return $"user";
            }
            else
            {
                return base.Handle(request);
            }
        }
    }
}
