#include <bits/stdc++.h>
using namespace std;
int main()
{
    char c;
    string s, s1;
    cin >> c >> s >> s1;
    int pos = s.find(c);
    while(pos + 1){
        s.insert(pos, s1);
        pos = s.find(c, pos + s1.size() + 1);
    }
    cout << s;
    return 0;
}