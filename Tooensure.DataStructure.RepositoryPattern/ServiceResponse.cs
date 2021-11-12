using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tooensure.DataStructure.RepositoryPattern
{
    public class ServiceResponse<TEntity>
    {
        public TEntity? Data { get; set; }
        public bool Successful { get; set; } = true;
        public string Message { get; set; } = string.Empty;

        public ServiceResponse()
        {

        }
        public ServiceResponse(TEntity? data)
        {
            Data = data;
        }
        public ServiceResponse(bool successful)
        {
            Successful = successful;
        }
        public ServiceResponse(TEntity? data, bool successful)
        {
            Data = data;
            Successful = successful;
        }
        public ServiceResponse(bool successful, string message)
        {
            Successful = successful;
            Message = message;
        }
        public ServiceResponse(TEntity? data, bool successful, string message)
        {
            Data = data;
            Successful = successful;
            Message = message;
        }

    }
}
