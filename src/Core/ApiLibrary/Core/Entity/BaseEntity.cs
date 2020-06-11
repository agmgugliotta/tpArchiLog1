using ApiLibrary.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogAPI.Core.Entity
{
    public abstract class BaseEntity
    {
        [NoModified]
        public DateTime CreatedAt { get; set; }

        [NoModified]
        public DateTime? UpdateAt { get; set; }

        [NoModified]
        public DateTime? DeleteAt { get; set; }
    }
}
