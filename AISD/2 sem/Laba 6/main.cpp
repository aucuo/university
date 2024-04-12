#include <iostream>

using namespace std;

// стркуктура узла
struct node
{
    int data;
    unsigned char height;
    node *left;
    node *right;
    node(int n_data)
    {
        data = n_data;
        left = right = 0;
        height = 1;
    }
};

// Возвращает height узла если он существует
unsigned char height(node *p_node)
{
    return p_node ? p_node->height : 0;
}

// Возвращает фактор баланса между левым и правым
int balanceFactor(node *p_node)
{
    return height(p_node->right) - height(p_node->left);
}

// Исправляет высоту
void fix_height(node *p_node)
{
    unsigned char height_left = height(p_node->left);
    unsigned char height_right = height(p_node->right);
    p_node->height = (height_left > height_right ? height_left : height_right) + 1;
}

// Меняе узлы местами -> малый поворот
node *rotateRight(node *p_node)
{
    node *temp_node = p_node->left;
    p_node->left = temp_node->right;
    temp_node->right = p_node;
    fix_height(p_node);
    fix_height(temp_node);
    return temp_node;
}

// Меняе узлы местами -> малый поворот
node *rotateLeft(node *p_node)
{
    node *temp_node = p_node->right;
    p_node->right = temp_node->left;
    temp_node->left = p_node;
    fix_height(p_node);
    fix_height(temp_node);
    return temp_node;
}

// Большие повороты
node *balance(node *p_node)
{
    fix_height(p_node);
    if (balanceFactor(p_node) == 2)
    {
        if (balanceFactor(p_node->right) < 0)
        {
            p_node->right = rotateRight(p_node->right);
        }
        return rotateLeft(p_node);
    }
    if (balanceFactor(p_node) == -2)
    {
        if (balanceFactor(p_node->left) > 0)
        {
            p_node->left = rotateLeft(p_node->left);
        }
        return rotateRight(p_node);
    }
    return p_node;
}

// Добавление узла
node *insert(node *p_node, int data)
{
    if (!p_node)
        return new node(data);
    if (data < p_node->data)
    {
        p_node->left = insert(p_node->left, data);
    }
    else
    {
        p_node->right = insert(p_node->right, data);
    }
    return balance(p_node);
}

//прямой обход бинарного дерева
void pre_order(node *Node)
{
    if (Node != NULL)
    {
        printf("%3ld", Node->data);
        pre_order(Node->left);
        pre_order(Node->right);
    }
}

//обратный обход бинарного дерева
void post_order(node *Node)
{
    if (Node != NULL)
    {
        post_order(Node->left);
        post_order(Node->right);
        printf("%3ld", Node->data);
    }
}

//симметричный обход бинарного дерева
void symmetric_order(node *Node)
{
    if (Node != NULL)
    {
        post_order(Node->left);
        printf("%3ld", Node->data);
        post_order(Node->right);
    }
}

node *findMin(node *p) // поиск узла с минимальным ключом в дереве p
{
    return p->left ? findMin(p->left) : p;
}

node *removeMin(node *p) // удаление узла с минимальным ключом из дерева p
{
    if (p->left == 0)
        return p->right;
    p->left = removeMin(p->left);
    return balance(p);
}

// Идем влево до упора что-бы найти минимальное
node *find_Min(node *p_node)
{
    if (!p_node)
    {
        cout << "No node";
        return (p_node);
    }
    else
    {
        while (p_node->left != NULL)
        {
            p_node = p_node->left;
        }
        return p_node;
    }
}

// Идем вправо до упора что-бы найти максимальное
node *findMax(node *p_node)
{
    if (!p_node)
    {
        cout << "No node";
        return (p_node);
    }
    else
    {
        while (p_node->right != NULL)
        {
            p_node = p_node->right;
        }
        return p_node;
    }
}

node *removeNode(node *p_node, int data)
{
    if (!p_node)
        return 0;
    if (data < p_node->data)
    {
        p_node->left = removeNode(p_node->left, data);
    }
    else if (data > p_node->data)
    {
        p_node->right = removeNode(p_node->right, data);
    }
    else
    {
        node *q = p_node->left;
        node *r = p_node->right;
        delete p_node;
        if (!r)
            return q;
        node *min = findMin(r);
        min->right = removeMin(r);
        min->left = q;
        return balance(min);
    }
    return balance(p_node);
}

int main()
{
    system("CLS");
    system("Color 09");
    int x = 0;
    cout << "Input first node: ";
    cin >> x;
    node *root = new node(x);

    int task = -1;
    while (task != 0)
    {
        cout << "\n~-~Menu~-~\n";
        cout << "1. Insert node\n";
        cout << "2. Delete node\n";
        cout << "3. Output\n";
        cout << "4. Min. and max.\n";
        cout << "5. Height.\n";
        cout << "0. Exit\n";
        cin >> task;
        switch (task)
        {
        case 1:
            system("CLS");
            cin >> x;
            insert(root, x);
            break;
        case 2:
            system("CLS");
            cin >> x;
            removeNode(root, x);
            break;
        case 3:
            system("CLS");
            cout << "\ninOrder ->\n";
            pre_order(root);

            cout << "\ninPostOrder ->\n";
            post_order(root);

            cout << "\ninPreOrder ->\n";
            symmetric_order(root);
            break;
        case 4:
            system("CLS");
            cout << "Min. -> " << find_Min(root)->data << "\n";
            cout << "Max. -> " << findMax(root)->data << "\n";
            break;
        
        case 5:
            system("CLS");
            fix_height(root);
            cout << height(root);
            break;

        case 0:
            system("CLS");
            system("Color 07");
            break;
        default:
            cout << "!* Check your input\n";
            break;
        }
    }
}