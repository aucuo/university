#include <iostream>
#include <fstream>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>
#include <string>
#include <iomanip>

using namespace std;

string mas[1000][2];
int num = 0;
int isKeyword(char buffer[])
{
    char keywords[22][12] = {"constructor", "const", "array", "var", "Begin", "inherited", "for", "do", "new", "ad", "of", "char", "Integer", "PView", "TRect", "Assign", "or", "to", "do", "and", "not", "End"};
    int i, flag = 0;
    for (i = 0; i < 22; i++)
    {
        if (strcmp(keywords[i], buffer) == 0)
        {
            flag = 1;
            break;
        }
    }
    return flag;
}

int main()
{
    char ch, buffer[50] = "\0", buffer2[3] = "\0";
    ifstream fin("programLD1.txt");
    int i = 0, j = 0, k = 0;
    char delimiter[] = "<>[],:=()^;:#.'";
    bool isdelim, isliteral = false;
    char DoubleD = 0;
    char DD = 0;
    if (!fin.is_open())
    {
        cout << "error while opening the file\n";
        exit(0);
    }
    while (!fin.eof())
    {
        ch = fin.get();
        isdelim = false;
        if (!ch == '=' || !ch == '>')
            DoubleD = 0;
        if (!isdigit(ch))
            DD = 0;
        if (ch == '\'')
        {
            if (isliteral)
            {
                buffer[j] = '\0';
                j = 0;
                mas[num][0] = "Literal";
                mas[num][1] = buffer;
                num++;
            }
            isliteral = !isliteral;
            isdelim = true;
        }
        if (!isalnum(ch) && !(ch == ' ' || ch == '\n') && !isliteral)
        {
            isdelim = true;
        }
        if (isdigit(DD) && isdigit(ch))
        {
            buffer2[k] = '\0';
            k = 0;
            num--;
            mas[num][1].clear();
            buffer2[k++] = DD;
            buffer2[k++] = ch;
            mas[num][0] = "Number";
            mas[num][1] = buffer2;
            num++;
        }
        else if (isdigit(ch) && !(isdelim) && !isliteral)
        {
            DD = ch;
            mas[num][0] = " Number";
            mas[num][1] = ch;
            num++;
        }
        else if ((ch == ' ' || ch == '\n' || isdelim) && (j != 0) && !isliteral)
        {
            buffer[j] = '\0';
            j = 0;
            if (isKeyword(buffer) == 1)
            {
                mas[num][0] = "KeyWords";
                mas[num][1] = buffer;
                num++;
            }
            else
            {
                mas[num][0] = "ID";
                mas[num][1] = buffer;
                num++;
            }
        }
        if ((DoubleD == ':' && ch == '=') || (DoubleD == '<' & ch == '>'))
        {
            buffer2[k] = '\0';
            k = 0;
            num--;
            mas[num][1].clear();
            buffer2[k++] = DoubleD;
            buffer2[k++] = ch;
            mas[num][0] = "Delimiter";
            mas[num][1] = buffer2;
            num++;
        }
        else if (isdelim == true && ch != EOF)
        {
            if (ch == ':' || ch == '<')
                DoubleD = ch;
            isdelim = false;
            for (i = 0; i < 13; ++i)
            {
                if (ch == delimiter[i])
                {
                    mas[num][0] = "Delimiter";
                    mas[num][1] = ch;
                    num++;
                    isdelim = true;
                }
            }
            if (isdelim == false)
            {
                mas[num][0] = "Error";
                mas[num][1] = ch;
                num++;
            }
        }
        if ((isalpha(ch) && !isdelim) || (ch == ' ' && isliteral) || (ch == '-' && isliteral))
        {
            buffer[j++] = ch;
        }
    }
    fin.close();
    cout << '\n'
         << endl;
    for (int i = 0; i < num; i++)
    {
        cout << mas[i][0] << setw(20) << mas[i][1] << setw(25) << left << endl;
    }
    system("pause");
    return 0;
}