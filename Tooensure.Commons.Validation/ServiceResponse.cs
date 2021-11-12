using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tooensure.ErrorHandling
{

    public delegate void RequestHandler<T>(bool confiem,T item);

    public abstract class ServiceResponse<T>
    {
        
    }
}
