using System;
using System.Collections.Generic;
using System.Text;

namespace ventas.domain.Base
{
    public interface IEntity<out T>
    {
        T Id { get; }
    }
}
