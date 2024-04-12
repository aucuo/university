#ifndef MAIN_H
#define MAIN_H

#include <iostream>
#include <iomanip>
#include <string.h>
#include <string>

using namespace std;

struct B_inf // babies info
{
    char* mname; // имя матери
    char* dname; // имя врача
    char* date;
    char* time;
    char* gender;
    int weight;
    int round;
    char* expdate;
};

#endif