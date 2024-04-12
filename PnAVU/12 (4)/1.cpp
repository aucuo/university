#include <iostream>
#include <string>
#include <cstring>
#include <Windows.h>

using namespace std;

class Audio
{
public:
    char *name;
    char *model;
    int year;

    Audio()
    {
        this->name = new char[20];
        this->model = new char[20];

        cout << "Vvedite infy ob ustroistve:" << endl;
        cout << "Naming: ";
        char title[20];
        while (!(cin >> title))
        {
            cout << "Input string!\n";

            cin.clear();
            fflush(stdin);
        }
        this->setName(title);

        cout << "Model: ";
        char model[20];
        while (!(cin >> model))
        {
            cout << "Vvedite string!\n";
            cin.clear();
            fflush(stdin);
        }
        this->setModel(model);

        cout << "God vipuska: ";
        int year;
        while (!(cin >> this->year))
        {
            cout << "Input number!\n";
            cin.clear();
            fflush(stdin);
        }
    }
    ~Audio()
    {
        delete[] this->name;
        delete[] this->model;
    }

    void setName(char *title)
    {
        strcpy(this->name, title);
    }
    void setModel(char *title)
    {
        strcpy(this->model, title);
    }
    virtual void print()
    {
        cout << "- - - - - - - - - - - - - - - \n";
        cout << "Name: " << name << "\tModel: " << model << "\tYear: " << year << endl;
    }
    virtual void input()
    {
        cout << "Input information:" << endl;
        cout << "Naming: ";
        char title[20];
        while (!(cin >> title))
        {
            cout << "Input string!\n";

            cin.clear();
            fflush(stdin);
        }
        this->setName(title);

        cout << "Model: ";
        char model[20];
        while (!(cin >> model))
        {
            cout << "Input string!\n";
            cin.clear();
            fflush(stdin);
        }
        this->setModel(model);

        cout << "God vipuska: ";
        int year;
        while (!(cin >> this->year))
        {
            cout << "Vvedite chislo!\n";

            cin.clear();
            fflush(stdin);
        }
    }
    virtual void print_all() const = 0;
};

class Player : public Audio
{
public:
    bool dict;
    bool fm_tuner;
    int gbs;

    Player()
    {
        cout << "Nalichie diktofona(0-1): ";
        while (!(cin >> this->dict))
        {
            cout << "Vvedite chislo!\n";
            cin.clear();
            fflush(stdin);
        }

        cout << "nALICHIE FM TUNERA(0-1): ";
        while (!(cin >> this->fm_tuner))
        {
            cout << "Vvedite libo 0(net) libo 1 (est)\n";

            cin.clear();
            fflush(stdin);
        }

        cout << "Ob`em vstroennoi pamyati: ";
        while (!(cin >> this->gbs))
        {
            cout << "Vvedite libo 0(net) libo 1 (est)\n";
        }
    }

    virtual void input()
    {
        cout << "Nalichie diktofona(0-1): ";
        while (!(cin >> this->dict))
        {
            cout << "Input number!\n";
            cin.clear();
            fflush(stdin);
        }

        cout << "Nalichie fm tunera (0-1): ";
        while (!(cin >> this->fm_tuner))
        {
            cout << "Vvedite libo 0(net) libo 1 (est)\n";
            cin.clear();
            fflush(stdin);
        }

        cout << "Ob`em vstroennoy pamyati: ";
        while (!(cin >> this->gbs))
        {
            cout << "Vvedite libo 0(net) libo 1 (est)\n";
        }
    }
    virtual void print()
    {
        cout << "- - - - - - - - - - - - - - - \n";
        cout << "Dict: " << dict << "\tFM-tuner: " << fm_tuner << "\tGbs: " << gbs << endl;
    }
    virtual void print_all() const
    {
        cout << "------------------------------\n";
        cout << "Name: " << name << "\tModel: " << model << "\tYear: " << year << endl;
        cout << "Dict: " << dict << "\tFM-tuner: " << fm_tuner << "\tGbs: " << gbs << endl;
    }
};

class MusicCentre : public Player
{
public:
    int decs;
    int power_Wt;

    MusicCentre()
    {
        cout << "Input number of kassetnie deki: ";
        while (!(cin >> decs))
        {
            cout << "Input number\n";
            cin.clear();
            fflush(stdin);
        }

        cout << "Input moshnost: ";
        while (!(cin >> power_Wt))
        {
            cout << "Input number\n";
            cin.clear();
            fflush(stdin);
        }
    }
    virtual void input()
    {
        cout << "Input numbers of kassetnie diski: ";
        while (!(cin >> decs))
        {
            cout << "Input number\n";
            cin.clear();
            fflush(stdin);
        }

        cout << "Input moshnost: ";
        while (!(cin >> power_Wt))
        {
            cout << "Input number\n";
            cin.clear();
            fflush(stdin);
        }
    }
    virtual void print()
    {
        cout << "- - - - - - - - - - - - - - - \n";
        cout << "Number of dequeues: " << decs << "\tMoshnost: " << power_Wt << "Vt\n";
    }
    virtual void print_all() const
    {
        cout << "------------------------------\n";
        cout << "Name: " << name << "\tModel: " << model << "\tYear: " << year << endl;
        cout << "Dict: " << dict << "\tFM-tuner: " << fm_tuner << "\tGbs: " << gbs << endl;
        cout << "Number of dequeues: " << decs << "\t Moshnost: " << power_Wt << "Vt\n";
    }
};

int main()
{
    system("CLS");
    Audio *array[2];

    cout << "~~~~~~ 1 ~~~~~~\n";
    array[0] = new Player();
    array[0]->print();
    cout << endl;
    cout << "~~~~~~ 2 ~~~~~~\n";
    array[1] = new MusicCentre();
    array[1]->print_all();
    return 0;
}