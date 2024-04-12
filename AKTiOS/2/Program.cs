using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static string DecToBinaryDec(string dec)
        {
            for (int i = 0; i < dec.Length; i++) // Проходим по всем символам в строке
            {
                if ((dec[i] < '0' || dec[i] > '9') & dec[i] != ',' & dec[i] != '-') // Проверка на правильность ввода
                    return "Неправильный формат";
            }
            string binDec = dec;

            binDec = binDec.Replace("0", "0000 "); // Если число равно 0, заменяем на 0000 и так далее
            binDec = binDec.Replace("1", "0001 ");
            binDec = binDec.Replace("2", "0010 ");
            binDec = binDec.Replace("3", "0011 ");
            binDec = binDec.Replace("4", "0100 ");
            binDec = binDec.Replace("5", "0101 ");
            binDec = binDec.Replace("6", "0110 ");
            binDec = binDec.Replace("7", "0111 ");
            binDec = binDec.Replace("8", "1000 ");
            binDec = binDec.Replace("9", "1001 ");

            if (binDec.Contains(','))
                binDec = binDec.Replace(" ,", ", "); // Если строка вывода содержит запятую, убираем перед ней пробел и добавляем после нее через замену

            return binDec; // Возвращаем число в двоично-десятичной форме
        }

        static string BinaryDecToDec(string binaryDec)
        {
            for (int i = 0; i < binaryDec.Length; i++) // Проходим по всем символам в строке
            {
                if (binaryDec[i] != '1' & binaryDec[i] != '0' & binaryDec[i] != ' ' & binaryDec[i] != '-') // Проверка на правильность ввода
                    return "Неправильный формат";
            }
            string dec = binaryDec;

            dec = dec.Replace("0000", "0"); // Если число = 0000, заменяем на 0 и так далее
            dec = dec.Replace("0001", "1");
            dec = dec.Replace("0010", "2");
            dec = dec.Replace("0011", "3");
            dec = dec.Replace("0100", "4");
            dec = dec.Replace("0101", "5");
            dec = dec.Replace("0110", "6");
            dec = dec.Replace("0111", "7");
            dec = dec.Replace("1000", "8");
            dec = dec.Replace("1001", "9"); // Проверка на ввод

            if (dec.Contains(' '))
                dec = dec.Remove(dec.IndexOf(' '), 1); // Если строка вывода содержит пробел - удаляем его

            return dec;
        }

        static string DecToHex(int dec)
        {
            if (dec == 0) // Если десятичное число = 0, то сразу же возвращаем 0
                return "0";

            int temp, i = 0;
            string hex = "";

            while (dec != 0)
            {
                temp = dec % 16; // В temp записываем остаток от деления на 16

                if (temp < 10) // Если остаток от деления находится в промежутке от 0 до 9
                    temp = temp + 48; // Добавляем 48 (начинаем счет с 0)
                else // Если остаток от деления больше 9
                    temp = temp + 55; // Добавляем 55 (начинаем счет с A)

                hex += (char)temp; // В строку вывода записываем значение temp
                i++;
                dec /= 16; // Делим dec на 16
            }

            char[] arr = hex.ToCharArray(); // Переворачиваем строку через массив (особенности языка C#)
            Array.Reverse(arr);
            return new string(arr);
        }

        static string CryptText(string text)
        {
            string cryptedText = "";
            int symbol;

            for (int i = 0; i < text.Length; i++)
            {
                symbol = (int)text[i]; // Узнаем ASCII код
                cryptedText += DecToHex(symbol) + " "; // Переводим ASCII код в hex и вставляем в строку вывода
            }

            return cryptedText;
        }

        static string HexToDec(string hex)
        {
            int hexLength;

            if (!hex.Contains('.')) // Высчитываем длину целой части числа
                hexLength = hex.Length;
            else
                hexLength = hex.IndexOf('.');

            int symbol;
            double temp = 0;
            string dec;
            for (int i = 0; i < hexLength; i++) // Цикл для перевода целой части чесла
            {
                if (hex[i] >= '0' & hex[i] <= '9') // Если число находится в промежутке от 0 до 9
                    symbol = (int)hex[i] - 48; // Вычитаем 48 (по таблице ASCII)
                else
                    symbol = (int)hex[i] - 55; // Вычитаем 55 (по таблице ASCII)

                temp += symbol * Math.Pow(16, hexLength - 1 - i); // Полученный символ числа умножаем на 16 в степени i-1
            }

            if (hex.Contains('.')) // Цикл для перевода дробной части числа
            {
                hexLength = hex.Length - hex.IndexOf('.') - 1; // Считаем длину дробной части числа
                hex = hex.Substring(hex.IndexOf('.') + 1); // Удаляем целую часть числа и точку (остается только дробная)

                for (int i = 0; i < hexLength; i++) // Проходимся по полученному числу
                {
                    if (hex[i] >= '0' & hex[i] <= '9') // Если число находится в промежутке от 0 до 9
                        symbol = (int)hex[i] - 48; // Вычитаем 48 (по таблице ASCII)
                    else
                        symbol = (int)hex[i] - 55; // Вычитаем 55 (по таблице ASCII)

                    temp += symbol * Math.Pow(16, -1 - i); // Умножаем символ на 16 в степени -1 - i (-1, -2, -3, ... и т.д. по циклу)
                }
            }

            dec = Convert.ToString(temp); // Присваем строке вывода значение temp

            return dec;
        }

        static string DecryptText(string cryptedText)
        {
            string decryptedText = "";

            string[] subs = cryptedText.Split(' '); // Разделяем строку по пробелу

            foreach (var sub in subs) // Цикл для каждого разделенного числа
            {
                decryptedText += (char)Convert.ToInt16(HexToDec(sub)); // Конвертируем hex в dec и конвертируем в символ по таблице ASCII
            }

            return decryptedText;
        }

        static string ToDirectCode(string dec)
        {
            string directCode = "";

            if (!dec.Contains('-')) // Если число отрицательное, добавляем в начало 1`, если положительное 0`
                directCode += "0`";
            else
                directCode += "1`";

            directCode += DecToBinaryDec(dec); // После знакового разряда (0` или 1`) добавляем двоично-десятичное число

            if (directCode.Contains('-'))
                directCode = directCode.Remove(directCode.IndexOf('-'), 1); // Избавляемся от минуса 

            return directCode;
        }

        static string ToReverseCode(string dec)
        {
            string reverseCode = "";

            reverseCode = ToDirectCode(dec); // Сначала получаем число в прямом коде

            if (!dec.Contains('-')) // Обратный код для положительных чисел совпадает с прямым кодом
                return reverseCode;

            char[] arr = reverseCode.ToCharArray(); // Создаем массив (особенности c#)

            for (int i = 2; i < reverseCode.Length; i++) // проходим по числу (знаковый разряд не включен в цикл)
            {
                if (arr[i] == '1') // 1 меняем на 0, а 0 на 1
                    arr[i] = '0';
                else
                    arr[i] = '1';
            }

            return reverseCode;
        }

        static string ToAdditionalCode(string dec)
        {
            string reverseCode = "";

            if (!dec.Contains('-')) // Обратный код для положительных чисел совпадает с прямым кодом
                return ToDirectCode(dec);
            else
                reverseCode = ToReverseCode(dec);

            char[] arr = reverseCode.ToCharArray(); // Создаем массив (особенности c#)

            // Прибавление единицы
            if (arr[arr.Length - 1] == '1') // Если последняя цифра числа = 1
            {
                for (int i = arr.Length - 1; i >= 0; --i) // проходимся по числу с конца
                {
                    if (arr[i] == '1') // Если цифра = 1 то заменяем на 0
                        arr[i] = '0';
                    else
                    {
                        arr[i] = '1'; // Если цифра = 0 то прибавляем 1 и выводим число
                        return new string(arr);
                    }
                }
            }
            else
                arr[reverseCode.Length - 1] = '1'; // Если последняя цифра числа = 0 то заменяем ее на 1 и выводим число

            return new string(arr);
        }

        static string ReverseSum(string decA, string decB)
        {
            string reverseA = "", reverseB = "";

            reverseA += ToReverseCode(decA); // Переводим числа a и b в обратный код
            reverseB += ToReverseCode(decB);

            reverseA = reverseA.Remove(0, 2); // Избавляемся от апострофа
            reverseB = reverseB.Remove(0, 2);

            char[] arrA = reverseA.ToCharArray(); // Создаем массивы символов для двух чисел (особенности c#)
            char[] arrB = reverseB.ToCharArray();

            int numA, numB;

            string result = "";
            bool next = false;

            for (int i = reverseA.Length - 1; i >= 0; --i) // с конца проходимся по числам
            {
                numA = (int)arrA[i] - 48; // Узнаем цифры в числах
                numB = (int)arrB[i] - 48;

                if (next) // Если есть единица переноса то прибавляем ее и удаляем ее (next = false)
                {
                    numA++;
                    next = false;
                }

                if (numA + numB == 0) // Если 0 + 0
                    result += '0';
                else if (numA + numB == 1) // Если 0 + 1
                    result += '1';
                else if (numA + numB == 2) // Если 1 + 1
                {
                    result += '0';
                    next = true; // добавляем единицу переноса
                }
                else if (numA + numB == 3) // Если 1 + 1 и еще есть единица переноса
                {
                    result += '1';
                    next = true; // добавляем единицу переноса
                }
            }

            return result;
        }

        static string AdditionalSum(string decA, string decB)
        {
            string reverseA = "", reverseB = "";

            reverseA += ToAdditionalCode(decA); // Переводим числа a и b в дополнительный
            reverseB += ToAdditionalCode(decB);

            reverseA = reverseA.Remove(0, 2); // Избавляемся от апострофа
            reverseB = reverseB.Remove(0, 2);

            char[] arrA = reverseA.ToCharArray(); // Создаем массивы символов для двух чисел (особенности c#)
            char[] arrB = reverseB.ToCharArray();

            int numA, numB;

            string result = "";
            bool next = false;
            for (int i = reverseA.Length - 1; i >= 0; --i) // с конца проходимся по числам
            {
                numA = (int)arrA[i] - 48; // Узнаем цифры в числах
                numB = (int)arrB[i] - 48;

                if (next) // Если есть единица переноса то прибавляем ее и удаляем ее (next = false)
                {
                    numA++;
                    next = false;
                }

                if (numA + numB == 0) // Если 0 + 0
                    result += '0';
                else if (numA + numB == 1) // Если 0 + 1
                    result += '1';
                else if (numA + numB == 2) // Если 1 + 1
                {
                    result += '0';
                    next = true; // добавляем единицу переноса
                }
                else if (numA + numB == 3) // Если 1 + 1 и еще есть единица переноса
                {
                    result += '1';
                    next = true; // добавляем единицу переноса
                }
            }

            return result;
        }

        static string ToNormalizedNumber(string num)
        {
            double intNum = Convert.ToDouble(num);
            int numLength = 0;
            string normalizedNum = "";

            if (intNum > 0) // сразу добавляем в стркоку вывода 0, или -0, по формату нормальзованного вида числа
                normalizedNum = "0,";
            else
            {
                normalizedNum = "-0,";
                num = num.Remove(num.IndexOf('-'), 1); // удаляем - так как уже написали его выше
            }

            if (num.Contains(','))  // длинна числа для степени в будущем
            {
                numLength = num.IndexOf(',');
                normalizedNum += num.Remove(num.IndexOf(','), 1); // удаляем запятую так как мы уже написали ее
            }
            else
            {
                numLength = num.Length;
                normalizedNum += num; // вставляем в строку вывода форматированное число
            }
            normalizedNum += "*10^" + numLength; // добавляем степень


            return normalizedNum;
        }

        static double NormalizedToDec(string normalized)
        {
            string temp = normalized;
            double number;

            temp = temp.Remove(temp.IndexOf('^') - 3, temp.Length - temp.IndexOf('^') + 3); // удаляем *10^x

            number = Convert.ToDouble(temp); // присваиваем и переводим в double

            temp = normalized; // снова приравниваем в нормализованное число

            temp = normalized.Remove(0, normalized.IndexOf('^') + 1); // находим степень и ложим ее в temp

            number *= Math.Pow(10, Convert.ToInt32(temp)); // умножаем на 10 в степени temo

            return number;
        }

        static string NormalizedSum(string a, string b)
        {
            return Convert.ToString(NormalizedToDec(a) + NormalizedToDec(b)); // Сумма
        }

        static string NormalizedSub(string a, string b)
        {
            return Convert.ToString(NormalizedToDec(a) - NormalizedToDec(b)); // Разность
        }

        static string NormalizedMult(string a, string b)
        {
            return Convert.ToString(NormalizedToDec(a) * NormalizedToDec(b)); // Умножение
        }

        static string NormalizedDiv(string a, string b)
        {
            return Convert.ToString(NormalizedToDec(a) / NormalizedToDec(b)); // Деление
        }

        static void Main(string[] args)
        {
            System.Console.WriteLine("1. Задание: " + DecToBinaryDec("712,375"));
            System.Console.WriteLine("2. Задание: " + BinaryDecToDec("0011 0011"));
            System.Console.WriteLine("3. Задание: " + CryptText("abcdef0123!@#$%^&*()"));
            System.Console.WriteLine("4. Задание: " + DecryptText("61 62 63 64 65 66 30 31 32 33 21 40 23 24 25 5E 26 2A 28 29"));
            System.Console.WriteLine("5. Задание: " + "\nПрямой код - " + ToDirectCode("-5") + "\nОбратный код - " + ToReverseCode("-8") + "\nДополнительный код - " + ToAdditionalCode("-8"));
            System.Console.WriteLine("6. Задание: " + "\nСложение в обратном коде - " + ReverseSum("-34", "15") + "\nСложение в дополнительном коде - " + AdditionalSum("1", "2"));
            System.Console.WriteLine("7. Задание: " + ToNormalizedNumber("-54,7"));

            string a = "0,3*10^2", b = "0,2*10^1"; // значения для операций над числами в нормализованном виде
            System.Console.WriteLine("8. Задание: введите 2 числа в формате (0.1*10^2):\n");
            System.Console.WriteLine("8.1. Normalized sum: " + NormalizedSum(a, b) + "\n");
            System.Console.WriteLine("8.2. Normalized sum: " + NormalizedSub(a, b) + "\n");
            System.Console.WriteLine("8.3. Normalized sum: " + NormalizedMult(a, b) + "\n");
            System.Console.WriteLine("8.4. Normalized sum: " + NormalizedDiv(a, b) + "\n");
        }
    }
}
