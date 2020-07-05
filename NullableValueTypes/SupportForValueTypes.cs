using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullableValueTypes
{
    public struct SupportForValueTypes
    {
        private void ConversionsAndCasting()
        {
            //Неявное пробразование из типа Int32 в Nullable<Int32>
            int? a = 5;

            //Неявное преобразование из null в Nullable<Int32>
            int? b = null;

            //Явное преобразование Nullable<Int32> в Int32
            int c = (int)a;

            //При попытке неяного привидения Nullable<Int32> в Int32 возникает ошибка компиляции CS0266  Не удается неявно преобразовать тип "int?" в "int".
            //Существует явное преобразование(возможно, пропущено приведение типов).
            //int y = b;

            //При попытке присвоений null не Nullable типу возникает ошибка System.InvalidOperationException: Нулевой объект должен иметь значение.
            int x = b.Value;

            double? d = 5;
            double? e = b;
        }

        /// <summary>
        /// Применение операторов к <see langword="null"/> - cовместимым значимым типам
        /// </summary>
        private void Operators()
        {
            int? a = 5;
            int? b = null;

            //Унарные операторы (+,++,-,--,!,~)
            a++;// a = 6
            b = -b; // b = null
            Console.WriteLine(a);
            Console.WriteLine(b);

            //Бинарные операторы (+,-,*,/,%,&,|,^,<<,>>)
            a = a + 3; // a = 9
            b = b * 3; // b = null;
            Console.WriteLine(a);
            Console.WriteLine(b);


            //Операторы равенства(==, !=)
            Console.WriteLine(a == null); //false
            Console.WriteLine(b == null); //true
            Console.WriteLine(a != b); // true

            //Операторы сравнения(<,>,<=,>=)
            Console.WriteLine(a < b);//false
        }

        /// <summary>
        /// Если операнд равен <see langword="null"/>, результат тоже равен <see langword="null"/>.
        /// Иначе выполнение действий унарного оператора
        /// </summary>
        /// <typeparam name="T">Значимый тип</typeparam>
        /// <param name="operand">Исходное значение типа</param>
        /// <param name="unaryOperator">Унарный оператор (+,++,-,--,!,~)</param>
        /// <returns></returns>
        private T? UnaryLogic<T>(T? operand,Func <T,T> unaryOperator) where T:struct
        {
            if (!operand.HasValue)
            {
                return null;
            }
            return unaryOperator.Invoke(operand.Value);
        }

        /// <summary>
        /// Если один из апперндов равен <see langword="null"/>, то результат равен <see langword="null"/>, иначе выполнение в стандартном режиме.
        /// Исключение для операторов & и |.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="firstOperand">Первый операнд</param>
        /// <param name="secondOperand">Второй операнд</param>
        /// <param name="binaryOperator">Бинарный оператор (+,-,*,/,%,^,<<,>>)</param>
        /// <returns></returns>
        private T? BinaryLogc<T>(T? firstOperand, T? secondOperand,Func<T,T,T> binaryOperator) where T:struct
        {
            if (!firstOperand.HasValue || !secondOperand.HasValue)
            {
                return null;
            }
            return binaryOperator.Invoke(firstOperand.Value, secondOperand.Value);
        }

        /// <summary>
        /// Исключение для выполения And оператора.
        /// Если любой из операндов имеет значение <see langword="false"/>, то возвращает <see langword="false"/>,
        /// иначе если один из операндов имеет значение <see langword="null"/>, то возвращает <see langword="null"/>,
        /// иначе возвращает <see langword="true"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="firstOperand">Первый операнд</param>
        /// <param name="secondOperand">Второй операнд</param>
        /// <returns>Результат оператора &</returns>
        private bool? ExceptionOfBinaryLogicFor_AndOperator(bool? firstOperand, bool? secondOperand)
        {
            if (firstOperand.Value == false || secondOperand.Value == false)
            {
                return false;
            }
            else if (!firstOperand.HasValue || !secondOperand.HasValue)
            {
                return null;
            }
            return true;
        }

        /// <summary>
        /// Исключение для выполнения Or оператора.
        /// Если любой из операндов имеет значение <see langword="true"/>, то возвращает <see langword="true"/>,
        /// иначе если любой из операндов равен <see langword="null"/>, то возвращает <see langword="null"/>,
        /// иначе возвращает <see langword="false"/>
        /// </summary>
        /// <param name="firstOperand">Первый операнд</param>
        /// <param name="secondOperand">Второй операнд</param>
        /// <returns>Результат оператора |</returns>
        private bool? ExceptionOfBinaryLogcFor_OrOperator(bool? firstOperand, bool? secondOperand)
        {
            if(firstOperand.Value == true || secondOperand.Value == true)
            {
                return true;
            }
            else if(!firstOperand.HasValue || !secondOperand.HasValue)
            {
                return null;
            }
            return false;
        }

        /// <summary>
        /// Логика сравнения и равенства.
        /// Если любой из операндов равен <see langword="null"/>, то оперенды не равны, иначе сравниваем значения как обычно.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="firstOperand">Первый операнд</param>
        /// <param name="secondOperand">Второй операнд</param>
        /// <param name="equationComparisonOperator">Функция сравнения или равенства</param>
        /// <returns>Результат сравнения или равенства</returns>
        private bool EquationComparisonLogic<T>(T? firstOperand,T? secondOperand,Func<T,T,bool> equationComparisonOperator) where T:struct
        {
            if (!firstOperand.HasValue || !secondOperand.HasValue)
            {
                return false;
            }
            return equationComparisonOperator.Invoke(firstOperand.Value, secondOperand.Value);
        }
    }
}
