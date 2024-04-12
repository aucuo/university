#include <stdio.h>
#include <cstring>
#include <iostream>

using namespace std;

string input()
{
    string s;
    cout << "Input string:\n";
    cin >> s;
    return s;
}

void encryption(string s)
{
    for (int i = 0; i < s.size(); i++)
    {
        if (s[i] >= 65 && s[i] <= 89 || s[i] >= 97 && s[i] <= 121)
        {
            s[i] = s[i] + 1;
        }
        if (s[i] == 90 || s[i] == 122)
        {
            s[i] = s[i] - 25;
        }
    }
    
    cout << "\nEncrypted string:\n";
    cout << s;
}

int main()
{
    string s;

    system("CLS");

    s = input();

    encryption(s);
    
    return 0;
}