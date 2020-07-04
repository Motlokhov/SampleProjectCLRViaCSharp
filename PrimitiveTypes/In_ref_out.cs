using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Types
{
    class In_ref_out
    {
        private void SampleParameterWithValueTypes()
        {
            int ri = 0;
            RefFunction(ref ri);
            Console.WriteLine(ri);

            int oi;
            List<int> oList;
            OutFunction(out oi,out oList);
            Console.WriteLine(oi);


        }

        /// <summary>
        /// Использование модификатора in используется для передачи по ссылки больших значимых типов по ссылке без изменения их внутри функции
        /// Использование модификатора in для ссылочных типов необходимо для гарантии, что адрес внутри функции не изменится
        /// </summary>
        /// <param name="inPoint"></param>
        /// <param name="inList"></param>
        private void InFuntion(in Point inPoint, in List<int> inList)
        {
            //inPoint.X = 1; //cs8332 CompileError переменная только для чтения
            inList.Add(1); // ошибки нет ссылка объекта не меняется
            //inList = new List<int>(); //cs8331 CompileError переменная только для чтения
        }

        /// <summary>
        /// При передачи значимого типа с модификатором ref упаковка объекта не производится!!!
        /// Использование модификатора ref необходимо для передачи значимого типа по ссылке с возможным, но не обязательным изменением внутри функции
        /// </summary>
        /// <param name="refI"></param>
        private void RefFunction(ref int refI)
        {
            Console.WriteLine(refI);
            refI = 5;
            Console.WriteLine(refI);
        }

        /// <summary>
        /// При передачи значимого типа с модификатором out упаковка объекта не производится.
        /// Модификатор out требует обязательного изменения значения переменной внутри функции
        /// Входной параметр с модификатором out может быть не инициализирован
        /// </summary>
        /// <param name="outI"></param>
        private void OutFunction(out int outI,out List<int> outList)
        {
            outI = 6;
            outList = new List<int>();
            Console.WriteLine(outI);
        }


    }
}
