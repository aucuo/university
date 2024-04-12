#include <iostream>
#include <cstring>
#include <cstdlib>
#include <vector>
#include <math.h>
#include <stdlib.h>

using namespace std;

int main()
{
    char str[50];
    vector <double> arr;
    vector <int> a;

    gets(str);

    int isMinus = 0;

    for (int i = 0; i < strlen(str); i++) {
        if (str[i] == '-') isMinus = 1;
        if (str[i] != ' ') {
            if (str[i] != '-') {
                arr.push_back(str[i] - 48);
            }
        } else {
            if (str[i+1] != ' ') {
                if (isMinus == 1) {
                    arr.push_back(0.7);
                } else {
                    arr.push_back(0.5);
                }
            }
            if (i != strlen(str) - 1) {
                isMinus = 0;
            }
        }
    }

    if (isMinus) {
        arr.push_back(0.7);
    } else {
        arr.push_back(0.5);
    }

    for (int i = 0; i < arr.size(); i++) {
        int num = arr[i], j = i+1;

        while (arr[j] != 0.5 && arr[j] != 0.7 && j < arr.size()) {
            num *= 10;
            num += arr[j];
            j++;
        }
        if (arr[j] == 0.7) {
            a.push_back(-num);
        } else if (arr[j] == 0.5) {
            a.push_back(num);
        }
        i = j;
    }

    int sum = 0;

    for (int i = 0; i < arr.size(); i++) {
        sum += arr[i];
    }

    cout << sum;

    return 0;
}