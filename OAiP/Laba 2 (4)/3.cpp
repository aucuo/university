#include <iostream>
#include <cstdlib>
#include <cstring>

using namespace std;

void invertStr(char str[255], int k, int n) {
    if (k > strlen(str)) {
        cout << "\n";
    } else if (strlen(str) < k+n) {
        for (int i = strlen(str); i >= k; i--) {
            cout << str[i];
        }
    } else if (strlen(str) >= k+n) {
        for (int i = n+k-1; i >= k; i--) {
            cout << str[i];
        }
    }
}

int main() {
    char str[255];
    int k[3], n[3];

    cout << "String input: ";
    cin >> str;

    for (int i = 0; i < 3; i++) {
        cout << "K" << i+1 << ": ";
        cin >> k[i];

        cout << "N" << i+1 << ": ";
        cin >> n[i];
    }

    for (int i = 0; i < 3; i++) {
        cout << i+1 << ". ";
        invertStr(str, k[i], n[i]);
        cout << "\n";
    }
    
    return 0;
}