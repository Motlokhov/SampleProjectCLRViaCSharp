using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PrimitiveTypes
{
    /// <summary>
    /// 1)Компилятор автоматически создает код для упаковки значимых типов.
    /// </summary>
    class BoxingAndUnboxing
    {

        /// <summary>
        /// 1) В управляемой куче выделяется память. Ее объем определяется длиной значимого типа + (ссылка на тип и индекс блока синхронизации)
        /// 2) Поля значимого типа копируются в память выделеную в куче.
        /// 3) Возвращается адрес объекта.
        /// </summary>
        private void BoxingPoint()
        {
            ArrayList array = new ArrayList();
            var p = new Point(); // выделение памяти для point в стеке
            for (var i = 0; i < 10; i++)
            {
                p.X = p.Y = i; //инициализация членов в значимом типе
                array.Add(p); // упаковка значимого типа идобавление ссылки в ArrayList
            }
        }
    }
}
