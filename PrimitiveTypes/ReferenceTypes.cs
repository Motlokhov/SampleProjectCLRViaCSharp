using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimitiveTypes
{
    /// <summary>
    /// Класс это ссылочный тип данных
    /// </summary>
    public class ReferenceTypes
    {
        private int m_int = 0;
        /*
         1) Память для ссылочных типов всегда выделяется из управляемой кучи
         2) Каждый экземпляр объекта размещяемый в куче содержит дополнительные члены(ссылка на тип, индекс блока синхронизации)
         3) Незанятые полезной информацией байты объекта обнуляются (поля) (инициализация по умолчанию)
         4) размещение экземпляра объекта в управляемой куче со временем инициирует сборку мусора
         */

        /// <summary>
        /// Присвоение значения
        /// </summary>
        private void ValueAssignmetn()
        {
            //При присвоении экземпляра объекта ссылочного типа другому экземпляру происходит присвоение ссылки объекта а не его значений
            var c1 = new ReferenceTypes();
            c1.m_int = 1;

            var c2 = c1;
            c2.m_int = 2;

            //значение m_int измениется в обоих объектах

        }

        public static void foo()
        {
            var list = new List<int>();
            list.Add(1);
            list.Add(2);
            var i = list[0];
        }
    }
}
