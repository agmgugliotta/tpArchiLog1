using CatalogAPI.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLibrary.Core.Entity
{
    class BaseModel<T> : BaseEntity
    {
        public T ID { get; set; }
    }
}
