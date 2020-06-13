using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Types
{
    /// <summary>
    /// Структура это значимый тип данных
    /// </summary>
    struct ValueTypes
    {
        private int m_int;
        private List<int> m_list;
        /*
          1) Память для значимых типов не входящих в состав классов выделяется в стеке потока
          2) При инициализации поля заполняются значением  по умолчанию
          3) По умолчанию запечатан(sealed)
          4) Структуры не могут иметь авто инициализаторы
         */

        /// <summary>
        /// Присвоение значения
        /// </summary>
        private void ValueAssignmetn()
        {
            //При присвоении экземпляра объекта значимого типа другому экземпляру происходит копирование значений полей
            var c1 = new ValueTypes();
            c1.m_int = 1;
            c1.m_list = new List<int>() { 1 };

            var c2 = c1;
            c2.m_int = 2;

            var equal = c2.m_int == c1.m_int; //false
            Console.WriteLine(equal);
            //значение m_int измениется в только в объекте c2;
        }

    }
}
