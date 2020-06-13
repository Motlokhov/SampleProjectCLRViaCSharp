using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Types
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

        /// <summary>
        /// 1) Если переменная содержит ссылку на упакованный значимый тип, равна <see langword="null"/>, генерируется NullReferenceException
        /// 2) Если ссылка указывает на объект, не являющийся упакованным значение требуемого значимого типа генерируется исключение InvalidCastException
        /// </summary>
        /// <param name="array"></param>
        private void UnboxingPoint(ArrayList array)
        {
            var a = array[0]; //Получение ссылки на объект в куче
            var p = (Point)a; //Распаковка значимого типа (копирование полей структуры)
        }

        /// <summary>
        /// Пример InvalidCastExcepton при распаковке объекта из кучи
        /// </summary>
        private void SampleInvalidCastException()
        {
            int x = 5;
            object o = x;
            short q = (short)(int)o; //Ошибки не будет

            // для правильной распаковки необходимо привести тип к int, а после преобразовывать к short
            short y = (short)o; //Ошибка InvalidCastException
        }


        private void SampleUnboxingAppropriation()
        {
            var i = 5;
            object o = i;
            var q = (int)o;
            Console.WriteLine($"q={q} o={o}"); //q=5 o=5 упакованный и не упакованный тип равны
            q = 6;                             //изменение значения не упакованого типа. Упакованный тип не знает об изменениях
            Console.WriteLine($"q={q} o={o}"); //q=6 o=5 
            o = q;                             // повторная упаковка упакованный тип получил изменения.
            Console.WriteLine($"q={q} o={o}"); //q=6 o=6 
        }




    }
}
