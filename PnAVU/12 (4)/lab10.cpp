 #include <iostream>
#include <string>
using namespace std;

class Teacher
{
private:
    char name[20];
    char kom[20];
    float time;

public:
    // Teacher();
    // Teacher()

    void Enter()
    {
        cout << "Фамилия: ";
        cin >> name;
        cout << "Цикловая комиссия: ";
        cin >> kom;
        cout << "Педагогический стаж: ";
        cin >> time;
    }
    // ~Teacher()
    // {
    // }
    void setname(const char *name1)
    {
        strcpy(name, name1);
    }
    void setkom(const char *kom1)
    {
        strcpy(kom, kom1);
    }
    void settime(float time1)
    {
        time = time1;
    }
    const char *getname()
    {
        return name;
    }
    const char *getkom()
    {
        return kom;
    }
    float gettime()
    {
        return time;
    }
    void print(int choose)
    {
        if(choose == 1){
            cout << "Фамилия: " << getname() << endl;
            cout << "Цикловая комиссия: " << getkom() << endl;
            cout << "Педагогический стаж: " << gettime() << endl;
        }
        else if(choose == 2)
        {
            cout << name << "\t\t" << kom << "\t\t" << time << endl;
        }
    }
};

int main()
{
    const int N = 2;

    Teacher arr[N];

    char name[20];
    char kom[20];
    float time;
    for (int i = 0; i < N; i++)
    {
        cout << "РџСЂРµРїРѕРґР°РІР°С‚РµР»СЊ РЅРѕРјРµСЂ " << i + 1 << endl;
        arr[i].Enter();
    }
    cout << endl;
    for (int i = 0; i < N; i++) arr[i].print(1);
    cout << "Р¤Р°РјРёР»РёСЏ\tР¦РёРєР»РѕРІР°СЏ РєРѕРјРёСЃСЃРёСЏ\tРџРµРґР°РіРѕРіРёС‡РµСЃРєРёР№ СЃС‚Р°Р¶" << endl;

    for (int i = 0; i < N; i++) arr[i].print(2);

    return 0;
}