using ReadyApp.Client.Console.Services.SharedServices.ISharedServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadyApp.Client.Console.Services.SharedServices
{
    public class EntityBase<TEntity> : IEntityBase<TEntity> where TEntity : class
    {
        public virtual TEntity GetEntity(TEntity entity)
        {
            return entity;
        }
    }
}
