using System;
using System.Collections.Generic;
using System.Text;

namespace Woin.Domain.Interfaces
{
    public interface IEntity<T>
    {
        public T Id { get; set; }
    }
}
