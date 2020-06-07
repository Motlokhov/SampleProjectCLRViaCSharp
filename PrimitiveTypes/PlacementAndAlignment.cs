using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PrimitiveTypes
{
    /// <summary>
    /// Размещений и выравнивание полей
    /// </summary>
    class PlacementAndAlignment
    {
        /// <summary>
        /// По умолчанию для классов значение LayoutKind.Auto
        /// </summary>
        [StructLayout(LayoutKind.Auto)]
        class T_Class
        {
            int m_int;
            byte m_byte;
        }

        /// <summary>
        /// По умолчанию для структур значение LayoutKind.Sequential
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        struct T_Struct
        {
            int m_int;
            byte m_byte;
        }

        /// <summary>
        /// Значение LayoutKind.Explicit позволяет явно задавать смещение полей с помощью FielsOffset
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        struct ExplicitStruct
        {
            [FieldOffset(0)]
            byte m_byte;
            [FieldOffset(1)]
            int m_int;
        }

    }
}
