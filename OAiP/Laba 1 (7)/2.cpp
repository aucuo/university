#include <iostream>
#include <cstring>
#include <cstdlib>

using namespace std;

int main()
{
    char line[50][50];

    for (int i = 0; i < 50; i++) {
        gets(line[i]);

        if (line[i][0] == 0) break;
    }

    for (int i = 0; i < 50; i++) {
        if (line[i][0] == 0) break;
        cout << line[i] << " - length: " << strlen(line[i]) << "\n";
    }
    
    return 0;
}