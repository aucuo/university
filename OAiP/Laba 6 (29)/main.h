#ifndef MAIN_H
#define MAIN_H

#include <iostream>
#include <iomanip>
#include <string.h>
#include <string>

using namespace std;

struct T_inf // tenant info
{
    // ������ �������
    char* street;
    char* house_num;
    char* apart_num;
    char* area;
    char* rooms;

    // ������ �������
    char* name;
    char* birth_date;
    char* reg_date;   // ���� ��������
    char* disch_date; // ���� �������
    char* rel;        // ��������� � ��������� ��������
};


#endif