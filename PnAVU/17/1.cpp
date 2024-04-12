#include <iostream>
#include <stack>
#include <deque>
#include <algorithm>
#include <vector>

using namespace std;

void setRandom(stack<double> &s, int n)
{
    srand(time(NULL));
    for (int i = 0; i < n; i++)
    {
        double x = (rand() % 101 - 10)/10.0;
        s.push(x);
    }
}
void printStack(stack<double> s)
{
    while (!s.empty())
    {
        cout << s.top() << " ";
        s.pop();
    }
    cout << endl;
}

stack<double> sortt(stack<double> s)
{
    stack<double> result;
    vector <double> vec;
    while (!s.empty())
    {
        vec.push_back(s.top());
        s.pop();
    }  
    sort(vec.begin(), vec.end());
    for (int i = 0; i < vec.size(); i++)
    {
        result.push(vec[i]);
    }
    


    return result;
}

stack<double> someDelete(stack<double> s, double find_c, int n, int size)
{
    stack<double> result;
    stack<double> r = s;
    vector <double> vec;
    // double vec[]
    int nnn = 0, found = 0;
    while (!s.empty())
    {
        // vec.push_back(s.top());
        if(s.top() == find_c) found = 1, vec.push_back(s.top());
        else
        {
            if(!found || found >= n+1)
            { 
                vec.push_back(s.top());
            }   
            found++;         
        }        
        s.pop();
        nnn++;
    }  
    reverse(vec.begin(), vec.end());
    
    for (int i = 0; i < vec.size(); i++)
    {
        result.push(vec[i]);
    }

    return result;
}

double findMin(stack<double> s)
{
    double min = s.top();
    while (!s.empty())
    {
        if(s.top() < min) min = s.top();
        s.pop();
    }
    return min;
}

bool find(stack<double> s, double find_c)
{
    bool found = false;
    while (!s.empty())
    {
        if(s.top() == find_c)
        {
            found = true;
            break;
        }
        s.pop();
    }
    return found;
}

int findCount(stack<double> s, double find_c)
{
    int found = 0;
    while (!s.empty())
    {
        if(s.top() == find_c) found++;
        s.pop();
    }
    return found;
}


int main()
{
    stack<double> s1;
    int size = 10;
    setRandom(s1, size);
    printStack(s1);
    cout << "Minimalni element: " << findMin(s1) << endl;
    double find_c;
    cout << endl;
    cout << "Number you want to find ";
    while (!(cin >> find_c))
    {
        cout << "Number you want to find (drobnoe): ";
        cin.clear();
        fflush(stdin);
    }

    if(find(s1,find_c)) cout << "Takoy element est\n";
    else cout << "Takogo elementa net\n";

    cout << endl;
    find_c = 0.0;
    cout << "Number kotoroe poshcitat v steke: ";
    while (!(cin >> find_c))
    {
        cout << "Number kotoroe poshcitat v steke (drobnoe): ";
        cin.clear();
        fflush(stdin);
    }
    int result = findCount(s1,find_c);
    if(result) cout << "Nashlos" << result << " elementov\n";
    else cout << "Ne nashlos\n";

    cout << endl;
    cout << "Sorting...\n";
    s1 = sortt(s1);
    printStack(s1);

    cout << endl;
    cout << "Element s kotorogo nachat ydalenie: \n";
    find_c = 0.0;
    while (!(cin >> find_c))
    {
        cout << "Element s kotorogo nachat ydalenie (Drobnoe): ";
        cin.clear();
        fflush(stdin);
    }

    int n = 0;
    cout << "Kol-vo chisel, kotoroe ydalit: \n";
    while (!(cin >> n))
    {
        cout << "Kol-vo chisel, kotoroe ydalit(celoe chislo): ";
        cin.clear();
        fflush(stdin);
    }

    if(n > size-1)
    {
        cout << "kol-vo ydalaemix != stack\n";
        return 1;
    }
    stack<double> s2 = someDelete(s1, find_c, n, size);

    printStack(s2);
    return 0;
}