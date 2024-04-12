#include <iostream>
#include <stdlib.h>
#include <cstdlib>
#include <vector>

using namespace std;

struct BinaryTree
{
    int Data;          // поле данных
    BinaryTree *Left;  // указатель на левый потомок
    BinaryTree *Right; // указатель на правый потомок
};

//создание бинарного дерева
void create(BinaryTree **Node, int n)
{
    BinaryTree **ptr; //вспомогательный указатель
    srand(time(NULL) * 1000);
    while (n > 0)
    {
        ptr = Node;
        while (*ptr != NULL)
        {
            if ((double)rand() / RAND_MAX < 0.5)
                ptr = &((*ptr)->Left);
            else
                ptr = &((*ptr)->Right);
        }
        (*ptr) = new BinaryTree();
        cout << "0. Input data: ";
        cin >> (*ptr)->Data;
        n--;
    }
}

//печать бинарного дерева
void print(BinaryTree *Node, int l)
{
    int i;
    if (Node != NULL)
    {
        print(Node->Right, l + 1);
        for (i = 0; i < l; i++)
            cout << " ";
        printf("%4ld", Node->Data);
        print(Node->Left, l + 1);
    }
    else
        cout << endl;
}

//прямой обход бинарного дерева
void pre_order(BinaryTree *Node)
{
    if (Node != NULL)
    {
        printf("%3ld", Node->Data);
        pre_order(Node->Left);
        pre_order(Node->Right);
    }
}

//обратный обход бинарного дерева
void post_order(BinaryTree *Node)
{
    if (Node != NULL)
    {
        post_order(Node->Left);
        post_order(Node->Right);
        printf("%3ld", Node->Data);
    }
}

//симметричный обход бинарного дерева
void symmetric_order(BinaryTree *Node)
{
    if (Node != NULL)
    {
        post_order(Node->Left);
        printf("%3ld", Node->Data);
        post_order(Node->Right);
    }
}

vector<int> array;

void task_data(BinaryTree *Node)
{
    if (Node != NULL)
    {
        task_data(Node->Left);
        task_data(Node->Right);
        array.push_back(Node->Data);
    }
}

bool task(BinaryTree *Node)
{
    task_data(Node);

    for (int i = 0; i < array.size() - 1; i++)
    {
        for (int j = i + 1; j < array.size(); j++)
        {
            if (array[i] == array[j])
                return 1;
        }
    }
    return 0;
}

//вставка вершины в бинарное дерево
void insert(BinaryTree **Node, int Data)
{
    BinaryTree *New_Node = new BinaryTree;
    New_Node->Data = Data;
    New_Node->Left = NULL;
    New_Node->Right = NULL;
    BinaryTree **ptr = Node; //вспомогательный указатель
    srand(time(NULL) * 1000);
    while (*ptr != NULL)
    {
        double q = (double)rand() / RAND_MAX;
        if (q < 1 / 3.0)
            ptr = &((*ptr)->Left);
        else if (q > 2 / 3.0)
            ptr = &((*ptr)->Right);
        else
            break;
    }
    if (*ptr != NULL)
    {
        if ((double)rand() / RAND_MAX < 0.5)
            New_Node->Left = *ptr;
        else
            New_Node->Right = *ptr;
        *ptr = New_Node;
    }
    else
    {
        *ptr = New_Node;
    }
}

//удаление вершины из бинарного дерева
void delete_node(BinaryTree **Node, int Data)
{
    if ((*Node) != NULL)
    {
        if ((*Node)->Data == Data)
        {
            BinaryTree *ptr = (*Node);
            if ((*Node)->Left == NULL && (*Node)->Right == NULL)
                (*Node) = NULL;
            else if ((*Node)->Left == NULL)
                (*Node) = ptr->Right;
            else if ((*Node)->Right == NULL)
                (*Node) = ptr->Left;
            else
            {
                (*Node) = ptr->Right;
                BinaryTree **ptr1;
                ptr1 = Node;
                while (*ptr1 != NULL)
                    ptr1 = &((*ptr1)->Left);
                (*ptr1) = ptr->Left;
            }
            delete (ptr);
            delete_node(Node, Data);
        }
        else
        {
            delete_node(&((*Node)->Left), Data);
            delete_node(&((*Node)->Right), Data);
        }
    }
}

//проверка пустоты бинарного дерева
bool is_tree_empty(BinaryTree *Node)
{
    return (Node == NULL ? true : false);
}
//освобождение памяти, выделенной под бинарное дерево
void delete_tree(BinaryTree *Node)
{
    if (Node != NULL)
    {
        delete_tree(Node->Left);
        delete_tree(Node->Right);
        delete (Node);
    }
}

int main()
{
    BinaryTree *bt = NULL;

    system("CLS");
    system("Color 09");

    int n = -1, amount, data;

    while (n != 0)
    {
        cout << "~-~ Main menu ~-~\n";
        cout << "1. Insert node\n";
        cout << "2. Delete node\n";
        cout << "3. Print tree\n";
        cout << "4. Is empty\n";
        cout << "5. Order\n";
        cout << "6. Task\n";
        cout << "0. Exit\n";

        cin >> n;

        switch (n)
        {
        case 1: // создание дерева или вставка элемента
            system("CLS");
            cout << "Amount of nodes: ";
            cin >> amount;

            if (amount <= 0) // проверка на якушева
            {
                system("CLS");
                cout << "!* Non correct input\n";
                break;
            }

            if (bt == NULL) // проверка на наличие дерева
            {
                create(&bt, 1);
                for (int i = 1; i < amount; i++)
                {
                    cout << i << ". Input node: ";
                    cin >> data;
                    insert(&bt, data);
                }
            }
            else
            {
                for (int i = 1; i < amount + 1; i++)
                {
                    cout << i << ". Input node: ";
                    cin >> data;
                    insert(&bt, data);
                }
            }

            system("CLS");
            cout << "Tree was modyfied\n";
            break;

        case 2:
            if (bt != NULL)
            {
                system("CLS");
                cout << "Input data: ";
                cin >> data;
                delete_node(&bt, data);
                system("CLS");
                cout << "Tree was modyfied\n";
            }
            else
            {
                system("CLS");
                cout << "!* Binary tree is empty\n";
            }
            break;

        case 3:
            if (bt != NULL)
            {
                system("CLS");
                print(bt, 1);
            }
            else
            {
                system("CLS");
                cout << "!* Binary tree is empty\n";
            }
            break;

        case 4:
            system("CLS");
            if (is_tree_empty(bt))
                cout << "Tree is empty\n";
            else
                cout << "Tree is not empty\n";
            break;

        case 5:
            system("CLS");
            if (is_tree_empty(bt))
            {
                cout << "!* Binary tree is empty\n";
            }
            else
            {
                cout << "Symmetric order:";
                symmetric_order(bt);
                cout << endl
                     << "Post order: \t";
                post_order(bt);
                cout << endl
                     << "Pre order: \t";
                pre_order(bt);
                cout << endl;
            }
            break;

        case 6:
            system("CLS");
            if (bt != NULL)
            {
                if (task(bt))
                    cout << "There are equal elements\n";
                else
                    cout << "There are no equal elements\n";
            }
            else
            {
                cout << "!* Binary tree is empty\n";
            }
            break;

        case 0:
            system("Color 07");
            system("CLS");
            delete_tree(bt);
            return 0;
            break;

        default:
            system("CLS");
            cout << "!* Check your input\n";
            break;
        }
    }

    return 0;
}