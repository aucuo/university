#include "menu.h"
#include "main.h"
#include "input.h"
#include "file.h"
#include "output.h"

void menu(struct B_inf* babies)
{
    int n = -1, pos = 0;
    string path = "DB.txt";

    while (n != 0)
    {
        // cout << "-- Main menu --\n";
        cout << "Input 1:\n";
        cout << "Output 2:\n";
        cout << "Table 3:\n";
        cout << "New DB 4:\n";
        cout << "Load DB 5:\n";
        cout << "Save DB 6:\n";
        cout << "Remove DB 7:\n";
        cout << "Clear structure 8:\n";
        cout << "To exit enter 0:\n";
        cin >> n;

        switch (n)
        {
        case 1:
        {
            system("CLS");
            babies = add_baby(babies, pos);
            pos++;
            break;
        }
        case 2:
        {
            system("CLS");
            output(babies, pos);
            break;
        }
        case 3:
        {
            system("CLS");
            table(babies, pos);
            break;
        }
        case 4:
        {
            system("CLS");
            new_DB(babies, pos, path);
            break;
        }
        case 5:
        {
            system("CLS");
            babies = clear(babies, pos);
            pos = DB_length(path);
            babies = load_DB(babies, path, pos);
            break;
        }
        case 6:
        {
            system("CLS");
            save_DB(babies, pos, path);
            break;
        }
        case 7:
        {
            system("CLS");
            remove_DB(babies, pos, path);
            break;
        }
        case 8:
        {
            system("CLS");
            babies = clear(babies, pos);
            pos = 0;
            break;
        }
        default:
        {
            cout << "Check your input";
        }
        }
    }
}