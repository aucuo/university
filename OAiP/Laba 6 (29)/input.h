#ifndef INPUT_H 
#define INPUT_H

#include <iostream> 
#include <iomanip>
#include <string.h>
#include <string>

using namespace std;

struct T_inf *add_tenant(struct T_inf *tenants, int pos);
T_inf *clear(struct T_inf *tenants, int pos);

#endif
