#ifndef MAIN_H
#define MAIN_H

#include <iostream>
#include <iomanip>
#include <string.h>
#include <string>

using namespace std;

struct T_inf // tenant info
{
    // данные квартир
    char* street;
    char* house_num;
    char* apart_num;
    char* area;
    char* rooms;

    // данные жильцов
    char* name;
    char* birth_date;
    char* reg_date;   // дата прописки
    char* disch_date; // дата выписки
    char* rel;        // отношение к владельцу квартиры
};


#endif