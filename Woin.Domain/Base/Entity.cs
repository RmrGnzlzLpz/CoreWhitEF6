using System;
using System.Collections.Generic;
using System.Text;
using Woin.Domain.Interfaces;

namespace Woin.Domain.Base
{
    public class Entity<T> : BaseEntity, IEntity<T>
    {
        public T Id { get; set; }
    }
}
