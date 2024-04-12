#include <iostream>
#include <stdlib.h>
#include <vector>
#include <cmath>
#include <regex>
#include <string>

using namespace std;

bool replace(string &str, const string &from, const string &to) // Функция для замены строк
{
    size_t start_pos = str.find(from); // Находим нужную строку
    if (start_pos == string::npos)     // Проверка на существование
        return false;
    str.replace(start_pos, from.length(), to); // Заменяем
    return true;
}

string DecToBinaryDec(string dec)
{
    string binDec = dec;

    replace(binDec, "0", "0000 "); // Заменяем строки в десятичном числе по таблице соответсвия
    replace(binDec, "1", "0001 ");
    replace(binDec, "2", "0010 ");
    replace(binDec, "3", "0011 ");
    replace(binDec, "4", "0100 ");
    replace(binDec, "5", "0101 ");
    replace(binDec, "6", "0110 ");
    replace(binDec, "7", "0111 ");
    replace(binDec, "8", "1000 ");
    replace(binDec, "9", "1001 ");

    return binDec;
}

string BinaryDecToDec(string binDec)
{
    string dec = binDec;

    replace(dec, "0000", "0"); // Заменяем строки в десятичном числе по таблице соответсвия
    replace(dec, "0001", "1");
    replace(dec, "0010", "2");
    replace(dec, "0011", "3");
    replace(dec, "0100", "4");
    replace(dec, "0101", "5");
    replace(dec, "0110", "6");
    replace(dec, "0111", "7");
    replace(dec, "1000", "8");
    replace(dec, "1001", "9");

    return dec;
}

string DecToHex(int number)
{
    string hexa;

    while (number)
    {
        int rem = number % 16; // Узнаем остаток от деления на 16

        if (rem < 10)                  // Для нумерации 0 1 2 ... 9 A B C...
            hexa.push_back(rem + '0'); // Добавляем закодированный символ
        else
            hexa.push_back(rem - 10 + 'A'); // Добавляем закодированный символ

        number = number / 16; // Делим число на 16
    }

    reverse(hexa.begin(), hexa.end()); // Переворачиваем строку для правильного ответа (т.к. пушили в конец а не в начало)

    return hexa;
}

int HexToDec(string hex)
{
    int result = 0;
    for (int i = 0; i < hex.length(); i++)
    {
        if (hex[i] >= 48 && hex[i] <= 57) // Условие на допустимость символов (0-9 и A-F)
        {
            result += (hex[i] - 48) * pow(16, hex.length() - i - 1); // Добавляем к результату число в степени i-1
        }
        else if (hex[i] >= 65 && hex[i] <= 70)
        {
            result += (hex[i] - 55) * pow(16, hex.length() - i - 1); // Добавляем к результату число в степени i-1
        }
        else if (hex[i] >= 97 && hex[i] <= 102)
        {
            result += (hex[i] - 87) * pow(16, hex.length() - i - 1); // Добавляем к результату число в степени i-1
        }
    }
    return result;
}

string CryptText(string text)
{
    string cryptedText = "";
    int symbol;

    for (int i = 0; i < text.size(); i++)
    {
        symbol = (int)text[i];                 // Узнаем ASCII код
        cryptedText += DecToHex(symbol) + " "; // Переводим ASCII код в hex и вставляем
    }

    return cryptedText;
}

string DecryptText(string cryptedText)
{

    string s = cryptedText, decryptedText;
    string delimiter = " "; // Разделитель = пробел

    size_t pos = 0;
    string token;
    while ((pos = s.find(delimiter)) != string::npos) // Берем значения между пробелами в строке
    {
        token = s.substr(0, pos); // Узнаем число между разделителями
        decryptedText += (char)HexToDec(token);

        s.erase(0, pos + delimiter.length()); // удаляем узнанное число
    }

    return decryptedText;
}

string ToDirectCode(string dec)
{
    string directCode = "";

    if (dec[0] == '-') // Если > 0 добавляем 1`, если нет, то добавляем 0`
        directCode += "1`";
    else
        directCode += "0`";

    directCode += DecToBinaryDec(dec); // Переводим в двоично-десятичную систему счисления

    if (directCode[2] == '-') // Избавляемся от побочного минуса если он есть
        directCode.erase(2, 1);

    return directCode;
}

string ToReverseCode(string dec)
{
    string reverseCode = "";

    reverseCode = ToDirectCode(dec);

    if (dec[0] != '-') // Обратный код для положительных чисел совпадает с прямым кодом
        return reverseCode;

    for (int i = 2; i < reverseCode.size() - 1; i++) // Если число отрицательное срабатывает цикл
    {
        if (reverseCode[i] == '1') // Меняем 1 на 0 и 0 на 1
            reverseCode[i] = '0';
        else
            reverseCode[i] = '1';
    }

    return reverseCode;
}

string ToAdditionalCode(string dec)
{
    string additionalCode = "";

    if (dec[0] != '-') // Дополнительный код для положительных чисел совпадает с прямым кодом
        return ToDirectCode(dec);
    else
        additionalCode = ToReverseCode(dec);

    if (additionalCode[additionalCode.size() - 1] == '1') // Проверка на количество символов
    {
        for (int i = additionalCode.size() - 1; i >= 0; --i)
        {
            if (additionalCode[i] == '1') // Изменяем 1 на 0 и 0 на 1
                additionalCode[i] = '0';
            else
            {
                additionalCode[i] = '1';
                return additionalCode;
            }
        }
    }
    else
        additionalCode[additionalCode.size() - 2] = '1';

    return additionalCode;
}

void reverseStr(string &str) // Функция для переворота строки
{
    int n = str.length(); // узнаем длину строки

    for (int i = 0; i < n / 2; i++)
        swap(str[i], str[n - i - 1]); // Переворачиваем строку
}

string ReverseSum(string decA, string decB)
{
    string reverseA = "", reverseB = "", result = "";

    reverseA += ToReverseCode(decA); // Переводим числа a и b в обратный код
    reverseB += ToReverseCode(decB);

    reverseA.erase(0, 2); // Избавляемся от апострофа
    reverseB.erase(0, 2);

    cout << reverseA << " + " << reverseB << " = "; // выводим a + b = для удобства просмотра

    int numA, numB;

    bool next = false;
    for (int i = reverseA.size() - 1; i >= 0; --i)
    {
        numA = (int)reverseA[i] - 48; // числа a и b в int
        numB = (int)reverseB[i] - 48;

        if (next) // Проверка на дополнительный десяток
        {
            numA++;
            next = false;
        }

        if (numA + numB == 0) // Само сложение 2 чисел
            result += '0';
        else if (numA + numB == 1)
            result += '1';
        else if (numA + numB == 2)
        {
            result += '0';
            next = true;
        }
        else if (numA + numB == 3)
        {
            result += '1';
            next = true;
        }
    }

    if (result.size() % 4 != 0) // Если появилась единица переноса - прибавляем к младшему числовому разряду
    {
        next = false;
        result.erase(0, 1);

        for (int i = result.size() - 1; i >= 0; --i)
        {
            int num = (int)result[i] - 48;

            if (next) // Проверка на дополнительный десяток
            {
                num++;
                next = false;
            }

            if (num + 1 == 0) // Само сложение 2 чисел
                result[i] = '0';
            else if (num + 1 == 1)
                result[i] = '1';
            else if (num + 1 == 2)
            {
                result[i] = '0';
                next = true;
            }
            else if (num + 1 == 3)
            {
                result[i] = '1';
                next = true;
            }
        }
    }

    reverseStr(result);

    return result;
}

string AdditionalSum(string decA, string decB)
{
    string reverseA = "", reverseB = "", result = "";

    reverseA += ToAdditionalCode(decA); // Переводим числа a и b в дополнительный код
    reverseB += ToAdditionalCode(decB);

    reverseA.erase(0, 2); // Избавляемся от апострофа
    reverseB.erase(0, 2);

    cout << reverseA << " + " << reverseB << " = ";

    int numA, numB;

    bool next = false;
    for (int i = reverseA.size() - 1; i >= 0; --i)
    {
        numA = (int)reverseA[i] - 48;
        numB = (int)reverseB[i] - 48;

        if (next) // Проверка на дополнительный десяток
        {
            numA++;
            next = false;
        }

        if (numA + numB == 0) // Сложение чисел
            result += '0';
        else if (numA + numB == 1)
            result += '1';
        else if (numA + numB == 2)
        {
            result += '0';
            next = true;
        }
        else if (numA + numB == 3)
        {
            result += '1';
            next = true;
        }
    }

    if (result.size() % 4 != 0) // Если появилась единица переноса - прибавляем к младшему числовому разряду
    {
        next = false;
        result.erase(0, 1);

        for (int i = result.size() - 1; i >= 0; --i)
        {
            int num = (int)result[i] - 48;

            if (next) // Проверка на дополнительный десяток
            {
                num++;
                next = false;
            }

            if (num + 1 == 0) // Сложение чисел
                result[i] = '0';
            else if (num + 1 == 1)
                result[i] = '1';
            else if (num + 1 == 2)
            {
                result[i] = '0';
                next = true;
            }
            else if (num + 1 == 3)
            {
                result[i] = '1';
                next = true;
            }
        }
    }

    reverseStr(result);

    return result;
}

string ToNormalizedNumber(string num)
{
    double intNum = std::stod(num);
    int numLength = 0;
    string normalizedNum = "0.";

    if (intNum > 0)
    {
        if (num.find('.')) // длина числа для степени в будущем
        {
            numLength = num.find(".", 0);
            normalizedNum += num.erase(numLength, 1);
        }
        else
        {
            numLength = num.size();
            normalizedNum += num;
        }
        normalizedNum += "*10^";         // Добавляем *10^ для корректного вывода
        normalizedNum += numLength + 48; // добавляем степень
    }

    return normalizedNum;
}

double NormalizedToDec(string normalized)
{
    string temp = normalized;
    double number;

    temp.erase(temp.find('*'), temp.size() - 1); // Парсим *

    number = stod(temp); // присваиваем и переводим в double

    temp = normalized; // снова приравниваем в нормализованное число

    temp = normalized.erase(0, normalized.find('^') + 1); // находим степень

    number *= pow(10, stoi(temp)); // умножаем на 10 в степени

    return number;
}

string NormalizedSum(string a, string b)
{
    return to_string(NormalizedToDec(a) + NormalizedToDec(b)); // Сумма
}

string NormalizedSub(string a, string b)
{
    return to_string(NormalizedToDec(a) - NormalizedToDec(b)); // Разность
}

string NormalizedMult(string a, string b)
{
    return to_string(NormalizedToDec(a) * NormalizedToDec(b)); // Умножение
}

string NormalizedDiv(string a, string b)
{
    return to_string(NormalizedToDec(a) / NormalizedToDec(b)); // Деление
}

int main()
{
    string input = "", input2 = "";
    cout << "Dec to Binary Dec\n";
    cin >> input;
    cout << "1. Dec to BinaryDec: " << DecToBinaryDec(input) << endl; // Десятичное число в Двоично-десятичное

    cout << "Binary Dec to Dec\n";
    cin >> input;
    cout << "2. BinaryDec to Dec: " << BinaryDecToDec(input) << endl; // Двоично-десятичное число в десятичное

    cout << "Crypt Text\n";
    cin >> input;
    cout << "3. ASCII Encrypt: " << CryptText(input) << endl; // Закодировать текст по ASCII

    cout << "4. ASCII Decrypt: " << DecryptText(CryptText(input)) << endl; // Декодировать текст по ASCII

    cout << "Dec number to diffrent codes\n";
    cin >> input;
    cout << "5.1. Direct code: " << ToDirectCode(input) << endl;          // Прямой код
    cout << "5.2. Reverse code: " << ToReverseCode(input) << endl;       // Обратный код
    cout << "5.3. Additional code: " << ToAdditionalCode(input) << endl; // Дополнительный код

    cout << "2 dec numbers for reverse and additional sum\n";
    cin >> input >> input2;
    cout << "6.1. Reverse Sum: " << ReverseSum(input, input2) << endl;   // Сложение чисел в обратных кодах
    cout << "6.2. Additional Sum: " << AdditionalSum(input, input2) << endl; // Сложение чисел в дополнительных кодах

    cout << "dec number to normalized format\n";
    cin >> input;
    cout << "7. Normalized format: " << ToNormalizedNumber(input) << endl; // Представить числа в нормализованном виде

    string a, b;
    cout << "(For 8 task) Input 2 numbers (f.e. 0.1*10^2): " << endl;
    cin >> a >> b;
    cout << "8.1. Normalized sum: " << NormalizedSum(a, b) << endl;   // Сумма
    cout << "8.2. Normalized sub: " << NormalizedSub(a, b) << endl;   // Вычитание
    cout << "8.3. Normalized mult: " << NormalizedMult(a, b) << endl; // Умножение
    cout << "8.4. Normalized div: " << NormalizedDiv(a, b) << endl;   // Деление

    return 0;
}