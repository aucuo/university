#include <iostream>
#include <vector>
#include <cmath>
#include <bits/stdc++.h>

using namespace std;

void floatdectobin(double dec)
{
    vector<int> array;

    int i = 0;

    int temp = (int)dec;

    while (temp >= 2)
    {
        array.push_back(temp % 2);
        temp /= 2;
    }

    array.push_back(1);

    for (int i = array.size() - 1; i >= 0; i--)
    {
        cout << array[i];
    }

    dec = dec - (int)dec;
    cout << ".";

    while (dec - (int)dec != 0)
    {
        dec *= 2;
        if (dec < 1)
            cout << 0;
        else
        {
            cout << 1;
            dec = dec - (int)dec;
        }
    }
    cout << endl;
}

void dectobin(int dec)
{
    if (dec == 0)
    {
        cout << 0;
        return;
    }

    int temp;
    vector<int> bin;

    temp = dec;

    while (temp != 0)
    {
        bin.push_back(temp % 2);
        temp /= 2;
    }

    for (int i = bin.size() - 1; i >= 0; i--)
    {
        cout << bin[i]; // выводим в обратном порядке
    }

    cout << endl;
}

void dectooc(int dec)
{
    int octalNum[100];

    int i = 0;
    while (dec != 0)
    {
        octalNum[i] = dec % 8;
        dec = dec / 8;
        i++;
    }

    for (int j = i - 1; j >= 0; j--)
        cout << octalNum[j];
    cout << endl;
}

void dectohex(int dec)
{
    int temp, i = 0;
    char hex[50];

    while (dec != 0)
    {
        temp = dec % 16;

        if (temp < 10)
            temp = temp + 48;
        else
            temp = temp + 55;

        hex[i] = temp;
        i++;
        dec = dec / 16;
    }

    for (i = i - 1; i >= 0; i--)
        cout << hex[i];

    cout << endl;

    return;
}

int bintodec(int bin)
{
    int dec = 0, i = 1, temp;

    while (bin != 0)
    {
        temp = bin % 10;
        dec = dec + (temp * i);
        i = i * 2;
        bin = bin / 10;
    }

    return dec;
}
void bintodec_f(long double bin)
{
    double sa = 0;
    int temp;
    cout << setprecision(14);

    temp = bintodec((long int)bin);

    bin = bin - (int)bin;

    for (int i = 0; i < 3; i++)
    {
        bin *= 10;
        sa += (int)bin * pow(2, 0 - 1 - i);
    }

    cout << temp + sa;
}

int binsum(int a, int b)
{
    int i = 0, r = 0, sum[20];

    while (a != 0 || b != 0)
    {
        sum[i++] = (a % 10 + b % 10 + r) % 2;
        r = (a % 10 + b % 10 + r) / 2;
        a = a / 10;
        b = b / 10;
    }

    if (r != 0)
        sum[i++] = r;

    --i;

    while (i >= 0)
        cout << sum[i--];

    cout << endl;

    return 0;
}

void floatdectooct(double dec)
{
    vector<int> array;

    int i = 0;

    int temp = (int)dec;

    while (temp >= 8)
    {
        array.push_back(temp % 8);
        temp /= 8;
    }

    array.push_back(1);

    for (int i = array.size() - 1; i >= 0; i--)
    {
        cout << array[i];
    }

    dec = dec - (int)dec;
    cout << ".";

    while (dec - (int)dec != 0)
    {
        dec *= 8;
        if (dec > 8)
            cout << 0;
        else
        {
            cout << dec;
            dec = dec - (int)dec;
        }
    }
    cout << endl;
}

void floatdectohex(double dec)
{
    vector<int> array;

    int i = 0;

    int temp = (int)dec;

    while (temp >= 16)
    {
        array.push_back(temp % 16);
        temp /= 16;
    }

    array.push_back(2);

    for (int i = array.size() - 1; i >= 0; i--)
    {
        if (array[i] == 10)
            cout << 'A';
        else if (array[i] == 11)
            cout << 'B';
        else if (array[i] == 12)
            cout << 'C';
        else if (array[i] == 13)
            cout << 'D';
        else if (array[i] == 14)
            cout << 'E';
        else if (array[i] == 15)
            cout << 'F';
        else
            cout << array[i];
    }

    dec = dec - (int)dec;
    cout << ".";

    while (dec - (int)dec != 0)
    {
        dec *= 16;
        if (dec > 16)
            cout << 0;
        else
        {
            cout << dec;
            dec = dec - (int)dec;
        }
    }
    cout << endl;
}

void octsum(double a, double b)
{
    vector<int> arr;
    int i1 = 0, i2 = 0, j1 = 0, j2 = 0;

    while (a - (int)a != 0) // избавляемся от запятых и запоминаем кол-во символов после запятой
    {
        a *= 10;
        i1++;
    }

    while (b - (int)b != 0)
    {
        b *= 10;
        i2++;
    }

    if (i2 > i1)
    {
        i1 = i2;
    }

    while (a / pow(10, j1) > 1)
    {
        j1++;
    }
    while (b / pow(10, j2) > 1)
    {
        j2++;
    }

    if (j1 > j2)
    {
        b = b * pow(10, j1 - j2);

        int t = 1, i = 0, an, bn, next = 0;

        while (i < j1)
        {
            t *= 10;
            an = fmod((int)(a / pow(10, i)), 10);
            bn = fmod((int)(b / pow(10, i)), 10);

            if (next == 1)
            {
                an++;
                next = 0;
            }

            if (an + bn > 7)
            {
                arr.push_back(fmod(an + bn, 8));
                next = 1;
            }
            else
            {
                arr.push_back(an + bn);
            }

            i++;
        }
    }
    else
    {
        a = a * pow(10, j2 - j1 - 1);

        int t = 1, i = 0, an, bn, next = 0;

        while (i < j2)
        {
            t *= 10;
            an = fmod((int)(a / pow(10, i)), 10);
            bn = fmod((int)(b / pow(10, i)), 10);

            if (next == 1)
            {
                an++;
                next = 0;
            }

            if (an + bn > 7)
            {
                arr.push_back(fmod(an + bn, 8));
                next = 1;
            }
            else
            {
                arr.push_back(an + bn);
            }

            i++;
        }
    }

    for (int i = arr.size() - 1; i >= 0; i--)
    {
        if (i == i1)
            cout << '.';
        cout << arr[i];
    }
}

void binsub(int a, int b)
{
    a = bintodec(a);
    b = bintodec(b);

    dectobin(a - b);
}

float octtodec(float oct)
{
    int s = 0, sa = 0, t = 1;
    float dec = 0;

    while (oct - (int)oct != 0) // избавляемся от запятых и запоминаем кол-во символов после запятой
    {
        oct *= 10;
        sa++;
    }

    while (oct / pow(10, s) > 1) // считаем кол-во символов
    {
        s++;
    }

    for (int i = s - 1; i >= 0; i--)
    {
        t *= 10;
        dec += pow(8, i - sa) * fmod((int)(oct / pow(10, i)), 10);
    }

    return dec;
}

void octsub(float a, float b)
{
    a = octtodec(a);
    b = octtodec(b);

    int octalNum[100];

    int i = 0;
    int dec = a - b;
    while (dec != 0)
    {
        octalNum[i] = dec % 8;
        dec = dec / 8;
        i++;
    }

    for (int j = i - 1; j >= 0; j--)
        cout << octalNum[j];

    cout << '.';

    dec = a - b;
    float t = a - b - dec;

    while (t - (int)t != 0) // избавляемся от запятых
    {
        t *= 10;
    }

    dec = t;

    dectooc(dec);
}

void binmult(int a, int b)
{
    a = bintodec(a);
    b = bintodec(b);

    int mult = a * b;

    dectobin(mult);
}

void octmult(float a, float b)
{
    a = octtodec(a);
    b = octtodec(b);

    int octalNum[100];

    int i = 0;
    int dec = a * b;
    while (dec != 0)
    {
        octalNum[i] = dec % 8;
        dec = dec / 8;
        i++;
    }

    for (int j = i - 1; j >= 0; j--)
        cout << octalNum[j];

    cout << '.';

    dec = a - b;
    float t = a - b - dec;

    while (t - (int)t != 0) // избавляемся от запятых
    {
        t *= 10;
    }

    dec = t;

    dectooc(dec);
}

int main()
{
    cout << "Primer 1: ";
    dectobin(37);

    cout << "Primer 2: ";
    dectohex(123);

    cout << "Primer 3: ";
    cout << bintodec(10011);

    cout << "\n\n";

    cout << "Task 1:\n";
    dectobin(220);
    dectooc(220);
    dectohex(220);
    floatdectobin(652.625);
    floatdectooct(652.625);
    floatdectohex(652.625);

    cout << "\n\nTask 2:\n";
    cout << bintodec(1101100);
    cout << endl;
    bintodec_f(1110010100.001);

    cout << "\n\nTask 3:\n";
    binsum(1000110, 1001101111);
    octsum(275.2, 724.2);

    cout << "\n\nTask 4:\n";
    binsub(1110001110, 100001011);
    octsub(1330.2, 1112.2);

    cout << "\nTask 5:\n";
    binmult(110000, 1101100);
    octmult(1560.2, 101.2);

    return 0;
}