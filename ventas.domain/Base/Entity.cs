using System;
using System.Collections.Generic;
using System.Text;

namespace ventas.domain.Base
{
    public abstract class Entity<T> : BaseEntity,IEntity<T>
    {
        public virtual T Id { get; }
    }
}
