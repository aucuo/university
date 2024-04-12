#include <iostream>
using namespace std;
typedef struct node
{
    int data;

    int priority;
    struct node *next;
} Node;

Node *newNode(int d, int p) // создание корня
{
    Node *temp = (Node *)malloc(sizeof(Node));
    temp->data = d;
    temp->priority = p;
    temp->next = NULL;

    return temp;
}

int peek(Node **head) // вывод
{
    return (*head)->data;
}

void pop(Node **head) // удаление
{
    Node *temp = *head;
    (*head) = (*head)->next;
    free(temp);
}

void push(Node **head, int d, int p) // добавление
{
    Node *start = (*head);

    Node *temp = newNode(d, p);

    if ((*head)->priority > p)
    {
        temp->next = *head;
        (*head) = temp;
    }
    else
    {

        while (start->next != NULL &&
               start->next->priority < p)
        {
            start = start->next;
        }

        temp->next = start->next;
        start->next = temp;
    }
}

int isEmpty(Node **head)
{
    return (*head) == NULL;
}

int main()
{
    int n, num, pr;
    cout << "Node and priority: ";
    cin >> num;
    cin >> pr;
    Node *pq = newNode(num, pr);
    cout << "N: ";
    cin >> n;

    for (int i = 0; i < n; i++)
    {
        cout << i + 1 << "st element and priority: \n";
        cin >> num;
        cin >> pr;
        push(&pq, num, pr);
    }

    cout << endl;

    pop(&pq); // удаление элемента с наибольшим приоритетом

    while (!isEmpty(&pq)) // вывод и удаление оставшейся очереди
    {
        cout << peek(&pq) << " ";
        pop(&pq);
    }
    return 0;
}