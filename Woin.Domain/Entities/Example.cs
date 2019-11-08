using System;
using System.Collections.Generic;
using System.Text;
using Woin.Domain.Base;

namespace Woin.Domain.Entities
{
    public class Example : Entity<int>
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}