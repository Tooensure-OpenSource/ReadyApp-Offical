﻿using Ecommerce.Data.Repositories.IRepositories.IBusinessRepositories;
using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data.Repositories.BusinessRepositories
{
    public class BusinessRepository : IBusinessRepository
    {
        private readonly DataContext _dataContext;

        public BusinessRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public bool ExistByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<Guid> Register(Owner owner, Guid guid)
        {
            throw new NotImplementedException();
        }
    }
}