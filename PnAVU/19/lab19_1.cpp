#include <iostream>
#include <string.h>

using namespace std;

class Integer;

class String
{
private:
    int length;
    char *str;

public:
    String() : str(NULL), length(0)
    {
        str = new char;
        strcpy(str, "");
    }
    String(const char *s) : str(NULL)
    {
        length = strlen(s);
        str = new char[length + 1];
        strcpy(str, s);
    }
    void display() const
    {
        cout << str;
        cout << endl;
    }
    String &operator=(const String &obj)
    {
        length = strlen(obj.str);
        if (str != NULL)
            delete[] str;
        str = new char[length + 1];
        strcpy(str, obj.str);
        return *this;
    }
    operator char *() const
    {
        return str;
    }
    operator Integer() const;
};

class Integer
{
private:
    int Val;

public:
    Integer() : Val(0)
    {
    }
    Integer(int d) : Val(d)
    {
    }
    void display() const
    {
        cout << Val;
        cout << endl;
    }
    operator int() const
    {
        return Val;
    }
    operator String() const
    {
        char buff[100];
        sprintf(buff, "%d", Val);

        return String(buff);
    }
};

String::operator Integer() const
{
    return Integer(atof(this->str));
}

int main()
{
    String s1("!dlroW olleH");
    String s2 = "5";

    cout << "s1=";
    s1.display();
    cout << "s2=" << s2;
    cout << "\n\n";

    Integer d1(1);
    Integer d2 = s2;
    cout << "d1=";
    d1.display();
    cout << "d2=";
    d2.display();
    cout << endl;
    
    s1 = d1;
    cout << "sl=" << s1;
    return 0;
}