﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }
        public bool IsSuccessful { get; set; } = true;
        public string? Message { get; set; } = string.Empty;
    }
}
