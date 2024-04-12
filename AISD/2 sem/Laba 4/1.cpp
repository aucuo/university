#include <iostream>
using namespace std;

struct tnode
{
    int data;
    struct tnode *left;  // левое поддерево
    struct tnode *right; // правое поддерево
};
// вывод в сортированном виде
void treeprint(tnode *tree)
{
    if (tree != NULL)
    {
        treeprint(tree->left);     // вывод левого поддерева
        cout << tree->data << " "; // вывод кореня дерева
        treeprint(tree->right);    // вывод правого поддерева
    }
}
// добавление узлов в дерево
struct tnode *addnode(int x, tnode *tree)
{
    if (tree == NULL) // создание корня
    {
        tree = new tnode;
        tree->data = x;
        tree->left = NULL;
        tree->right = NULL;
    }
    else                                           // если корень есть
        if (x < tree->data)                        // x меньше корневого - уходим влево
            tree->left = addnode(x, tree->left);   // добавление элемента рекурсией
        else                                       // во всех остальных случаях - уходим вправо
            tree->right = addnode(x, tree->right); // тоже добавление элемента рекурсией
    return (tree);
}
// освобождение памяти дерева
void cleartrea(tnode *tree)
{
    if (tree != NULL)
    {
        cleartrea(tree->left); // удаление левой и правой ветки с помощью рекурсии
        cleartrea(tree->right);
        delete tree; // удаление корня
    }
}

int main()
{
    struct tnode *root = 0;
    system("CLS");
    int node, n;
    cout << "Count of nodes: ";
    cin >> n;

    for (int i = 0; i < n; i++)
    {
        cout << "Input node " << i + 1 << ": ";
        cin >> node;
        root = addnode(node, root); // добавление узла в дерево
    }
    treeprint(root); // вывод элементов дерева в отсортированном виде
    cleartrea(root); // очистка памяти

    return 0;
}
