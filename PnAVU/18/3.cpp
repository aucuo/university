#include <iostream>
#include <vector>

using namespace std;
 
struct Node {
    int number; //РґР°РЅРЅС‹Рµ
    Node *next; //СѓРєР°Р·Р°С‚РµР»СЊ РЅР° СЃР»РµРґСѓСЋС‰РёР№ СѓР·РµР»
    Node *prev; //СѓРєР°Р·Р°С‚РµР»СЊ РЅР° РїСЂРµРґС‹РґСѓС‰РёР№
};
 
class doubleList {
    Node *head;
    Node *tail;
public:
    doubleList();
    doubleList(doubleList *list);
    void addFirst(int number);
    void addLast(int number);
    void delTail();
    void delHead();
    void sortingList();
    void swap(int &a, int &b);
    void showList(string name) const;


    bool operator == (doubleList list1)
    {
        if(head != list1.head || tail != list1.tail) return false;
        return true;
    }

    doubleList operator + (doubleList list)
    {
        doubleList res;
        if (this->head)
        {
            Node *buf = this->head;
            while (buf) {
                cout << buf->number << " ";
                res.addLast(buf->number);
                buf = buf -> next;
            }
        }
        if (list.head)
        {
            Node *buf = list.head;
            while (buf) {
                cout << buf->number << " ";
                res.addLast(buf->number);
                buf = buf -> next;
            }
        }
        return res;
    }

    doubleList operator += (int numb)
    {
        addLast(numb);
        return *this;
    }

    // doubleList operator - (doubleList list)
    // {   
    //     doubleList res;
    //     vector<int> vec;

    //     if (list.head) {  // РґРѕР±Р°РІР»СЏРµРј С‚Рѕ, С‡С‚Рѕ РІ 1 СЃРїРёСЃРєРµ
    //         Node *buf = list.head;
    //         while (buf) {
    //             cout << buf->number << " ";
    //             vec.push_back(buf->number);
    //             buf = buf -> next;
    //         }
    //     }

    //     if (this->head) {
    //         Node *buf1 = this->head;
    //         while (buf1) {
    //             cout << buf1->number << " ";
    //             bool result = false;
    //             for (int i = 0; i < vec.size(); i++)
    //             {
    //                 // cout << ".-" << vec[i] << "-.\n";
    //                 if(vec[i] == buf1->number) result = true;
    //             }
    //             // cout << buf->number << " " << result;
    //             // if(!result) vec.push_back(buf->number);
    //             res.addFirst(buf1->number);
    //             if(!result)
    //             { 
    //                 // cout << buf->number << " ";
    //                 res.addFirst(buf1->number);
    //             }
    //             buf1 = buf1 -> next;
    //         }
    //     }

    //     return res;
    // }   

    doubleList operator = (doubleList *list)
    {
        doubleList res = list;
        return res;
    }

    void operator [] (doubleList *list);
};
 
doubleList :: doubleList() {
    head = tail = NULL;
}

doubleList :: doubleList(doubleList *list) {
    head = list->head;
    tail = list->tail;
}
 
//Р”РѕР±Р°РІР»РµРЅРёРµ СѓР·Р»Р° РІ РЅР°С‡Р°Р»Рѕ
void doubleList :: addFirst(int number) {
    Node *buf  = new Node;
    buf -> number = number;
    if (!head) {
        buf -> next = tail;
        tail = buf;
    }
    else {
        buf -> next = head;
        head -> prev = buf;
    }
    head = buf;
    head -> prev = NULL;
 
}
 
//Р”РѕР±Р°РІР»РµРЅРёРµ СѓР·Р»Р° РІ РЅР°С‡Р°Р»Рѕ
void doubleList :: addLast(int number) {
    Node *buf = new Node;
    buf -> number = number;
    if (!head) {
        buf -> next = tail;
        head = buf;
        buf -> prev = NULL;
    }
    else {
        buf -> next = tail -> next;
        buf -> prev = tail;
        tail -> next = buf;
    }
    tail = buf;
}
 
//РџСЂРѕР№С‚Рё РїРѕ СЃРїРёСЃРєСѓ Рё РІС‹РІРµСЃС‚Рё РІСЃРµ СЌР»РµРјРµРЅС‚С‹
void doubleList :: showList(string name) const {
    if (head) {
        cout << "\n~-~-~-~- Р’С‹РІРѕРґ " << name << " ~-~-~-~-\n";
        Node *buf = head;
        while (buf) {
            cout << buf ->number << " ";
            buf = buf -> next;
        }
        cout << endl;
    }
    else cout << "List is empty " << endl;
}
 
//РЈРґР°Р»РµРЅРёРµ РіРѕР»РѕРІС‹
void doubleList :: delHead() {
    if (head) {
        Node *buf = head;
        head = head -> next;
        head -> prev = NULL;
        delete buf;
    }
    else cout << "List is empty" << endl;
}
 
//РЈРґР°Р»РµРЅРёРµ С…РІРѕСЃС‚Р°
void doubleList :: delTail() {
    if (tail) {
        Node *buf = tail;
        tail = tail -> prev;
        tail -> next = NULL;
        delete buf;
    }
    else cout << "List is empty" << endl;
}
 
//РћР±РјРµРЅ РґР°РЅРЅС‹С… СЃРїРёСЃРєР°
void doubleList :: swap(int &a, int &b) {
    int buf = a;
    a = b;
    b = buf;
}
 
//РЎРѕСЂС‚РёСЂРѕРІРєР°
void doubleList :: sortingList() {
    Node *buf = head;
    for (Node *i = buf; i; i = i -> next) {
        for (Node *j = i -> next; j; j = j -> next) {
            if (i -> number < j -> number) {
                swap(i -> number, j -> number);
            }
        }
    }
 
}
 
 
int main()
{
    doubleList ob;

    int n;
    cout << "Р’РІРµРґРёС‚Рµ РєРѕР»-РІРѕ СЌР»РµРјРµРЅС‚РѕРІ: " << endl;
    cin >> n;

    int numb = 0;
    for (int i = 0; i < n; i++)
    {
        cin >> numb;
        ob.addFirst(numb);
    }
    
    // while (1) {
    //     cin >> a_i;
    //     if (a_i) {
    //         ob.addFirst(a_i);
    //     }
    //     else break;
    // }
    // ob.sortingList();
    ob.showList("ob");

    doubleList ob1;
    if(ob1 == ob) cout << "equal\n";
    else cout << "no equal\n";

    ob1 = ob;
    ob1.showList("ob1");
    ob1 += 5;
    ob1.showList("ob1");

    doubleList ob2;

    ob2 = ob1+ob;
    ob2.showList("ob2");
    return 0;
}