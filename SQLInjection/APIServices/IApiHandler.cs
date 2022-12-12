using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQLInjection.APIServices
{
    public interface IApiHandler
    {
         T GetAPI<T>(string url);
    }
}
