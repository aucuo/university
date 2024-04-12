#pragma once
#include <iostream>
using namespace std;
class Device
{
private:
    char title[20];
    char mainHead[20];
    int power;

public:
    Device();

    void Enter()
    {
        cout << "Nazvanie: ";
        cin >> title;
        cout << "Nachalnik: ";
        cin >> mainHead;
        cout << "Kol-vo rabotnikov: ";
        cin >> power;
    }
    ~Device()
    {
    }
    void setTitle(const char* title1)
    {
        strcpy_s(title, title1);
    }
    void setHeader(const char* mainHead1)
    {
        strcpy_s(mainHead, mainHead1);
    }
    void setPower(int power1)
    {
        power = power1;
    }
    const char* getTitle()
    {
        return title;
    }
    const char* getHeader()
    {
        return mainHead;
    }
    int getPower()
    {
        return power;
    }
    void print(int choose)
    {
        if (choose == 1)
        {
            cout << "Nazvanie: " << getTitle() << endl;
            cout << "Nachalnik: " << getHeader() << endl;
            cout << "Kol-vo rabotnikov: " << getPower() << endl;
        }
        else if (choose == 2)
        {
            cout << title << "\t\t" << mainHead << "\t\t" << power << endl;
        }
    }
};
