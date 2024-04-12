#ifndef FILE_H 
#define FILE_H

#include <iostream>
#include <fstream>
#include <string.h>
#include <string>

using namespace std;

void new_DB(struct B_inf *babies, int pos, string path);
void save_DB(struct B_inf *babies, int pos, string path);
void remove_DB(struct B_inf *babies, int pos, string path);
int DB_length(string path);
struct B_inf* load_DB(struct B_inf *babies, string path, int pos);

#endif
