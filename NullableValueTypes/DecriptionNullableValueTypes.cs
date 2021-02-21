using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullableValueTypes
{

    public struct DecriptionNullableValueTypes<T> where T: struct
    {
        /// <summary>
        /// <see langword="null"/> - совместимые значимые типы  совмещают в себе <see langword="null"/> и значение <see cref="T"/>.
        /// <see langword="null"/> - совместимые значимые типы могут быть только значимыми типами, так как ссылочные типы итак могут иметь <see langword="null"/> значения.
        /// <see langword="null"/> - совместимые значимые типы имеют размер <see cref="T"/> + <see cref="bool"/>.
        /// </summary>
        Nullable<T> NullableType;

        /// <summary>
        /// Укороченная запись <see cref="Nullable{T}"/>
        /// </summary>
        T? ShortVersionNullableType;

    }
}
