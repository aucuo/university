#ifndef FILE_H 
#define FILE_H

#include <iostream>
#include <fstream>
#include <string.h>
#include <string>

using namespace std;

void new_DB(struct T_inf *tenants, int pos, string path);
void save_DB(struct T_inf *tenants, int pos, string path);
void remove_DB(struct T_inf *tenants, int pos, string path);
int DB_length(string path);
struct T_inf* load_DB(struct T_inf *tenants, string path, int pos);

#endif
