using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadyApp.Client.Console.Services.SharedServices.ISharedServices
{
    public interface IEntityBase<TEntity> where TEntity : class
    {
        TEntity GetEntity(TEntity entity);
    }
}
