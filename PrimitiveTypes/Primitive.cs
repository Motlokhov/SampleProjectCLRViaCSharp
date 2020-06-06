using System;

namespace Types
{
    public class Primitive
    {
        /// <summary>
        /// FCL-type: SByte, CLS совместимость: нет, 8-разрядное со знаком
        /// </summary>
        sbyte m_sByte;

        /// <summary>
        /// FCL-type Byte, CLS совместимость: да, 8 разрядное без знака
        /// </summary>
        byte m_byte;

        /// <summary>
        /// FCL-type Int16, CLS совместимость: да, 16 разрадное со знаком
        /// </summary>
        short m_short;

        /// <summary>
        /// FCL-type Uint16, CLS совместимость: нет, 16-разрядное без знака
        /// </summary>
        ushort m_uShort;

        /// <summary>
        /// FCL-type Int32, CLS совместимость: да, 32-разрядное со знаком
        /// </summary>
        int m_int;

        /// <summary>
        /// FCL-type Uint32, CLS совместимость: нет, 32-разрядное без знака
        /// </summary>
        uint m_uint;

        /// <summary>
        /// FCL-type Int64, CLS совместимость: да, 64-разрядное со знаком
        /// </summary>
        long m_long;

        /// <summary>
        /// FCL-type Uint64, CLS совместимость: нет, 64-разрядное без знака
        /// </summary>
        ulong m_uLong;

        /// <summary>
        /// FCL-type Char, CLS совместимость: да, 16 разрядный символ UNICODE
        /// </summary>
        char m_char;

        /// <summary>
        /// FCL-type Single, CLS совместимость: да, 32 разрадное значение с плавующей точкой
        /// </summary>
        float m_float;

        /// <summary>
        /// FCL-type Double, CLS совместимость: да, 64 разрядное значение с плавующей точкой
        /// </summary>
        double m_double;

        /// <summary>
        /// FCL-type Boolean, CLS совместимость: да, булево значение <see langword="true"/> или <see langword="false"/>
        /// </summary>
        bool m_bool;

        /// <summary>
        /// FCL-type Decimal, CLS совместимость: да, 128-разрядное значение с плавающей точкой повышенной точности.
        /// <para>Один разряд числа - знак, следущие 96 разрядов значение, следущие 8 разрядов степень числа 10, на которое делится 96 разрядное число</para>
        /// </summary>
        decimal m_decimal;

        /// <summary>
        /// FCL-type String, CLS совместимость: да, Массив символов
        /// </summary>
        string m_string;

        /// <summary>
        /// FCL-type Object, CLS совместимость: да, Базовый тип для всех типов
        /// </summary>
        object m_object;

        /// <summary>
        /// FCL-type Object, CLS совместимость: да, В C# позволяет делать упрощенное преобразование
        /// </summary>
        dynamic m_dynamic;

        /// <summary>
        /// Преобразование типа
        /// </summary>
        private void Conversion()
        {
            // Неявное преобразование
            int i = 5;
            long l = i;
            float f = i;

            // Явное преобразование
            byte b = (byte)i;
            short s =  (short)i;

            //Неявное преобразование типа разрешается только в случаях если оно безопасно (не приводит к потере данных)

            //при преобразовании числа с плавующей точкой в тип без точки дробная часть будет отбрасываться
            float f_value = 6.8f;
            int i_value = (int)f_value; //будет равнятся 6

            //При арифмитических операциях внутри скобок происходит неявное преобразование к типу в котором не произойдет потери данных
            decimal d = 15;
            var b2 = ((short)6.8 - d);

        }

        /// <summary>
        /// Переполнение численных типов
        /// </summary>
        private void NoticeOverflow()
        {
            //По умолчание проверка на переполнение не происходит
            byte b = 100;
            b = (byte)(b + 200); // равно 44

            //Для предотвращения переполнения численных типов необходимо использовать конструкцию checked
            checked
            {
                byte b2 = 100;
                b2 = (byte)(b + 200);//вызовет исключение OverflowException
            }

            //использование блоков checked и unchecked не влияет на работу метода
            checked
            {
                SomeMethod(0); // ошибка не возникнет
            }

            // Для типа decimal использование блока checed всегда по умолчанию включен вне зависимотси от настроек компилятора и использования блоков checked и unchecked
            // Для типа BigInteger никогда не вызовется ошибка OverflowException, но может быть вызвано исключение OutOfMemoryException, если значение переменной будет слишком большим.
        }

        private void SomeMethod(byte b)
        {
            b = 100;
            b = (byte)(b + 200);
        }
    }
}
