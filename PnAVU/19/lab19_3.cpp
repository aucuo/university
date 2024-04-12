#include <iostream>
using namespace std;

template <class vectorType>
class Vector
{

    vectorType *arr;
    int capacity;
    int current;

public:
    typedef vectorType *iterator;
    typedef vectorType *reverse_iterator;

    Vector()
    {
        arr = new vectorType[1];
        capacity = 1;
        current = 0;
    }

    Vector(const Vector<vectorType> &v)
    {
        capacity = v.capacity;
        current = v.current;
        arr = new vectorType[current];
        for (int i = 0; i < size(); i++)
        {
            arr[i] = v.arr[i];
        }
    }

    // limited size of vector
    Vector(unsigned int size)
    {
        capacity = size;
        current = size;
        arr = new vectorType[size];
    }

    Vector(unsigned int size, const vectorType &initial)
    {
        current = size;
        capacity = size;
        arr = new vectorType[size];
        for (int i = 0; i < size; i++)
        {
            arr[i] = initial;
        }
    }
    // Function to add an element at the last
    void push(vectorType data)
    {

        if (current == capacity)
        {
            vectorType *temp = new vectorType[2 * capacity];

            for (int i = 0; i < capacity; i++)
            {
                temp[i] = arr[i];
            }

            delete[] arr;
            capacity *= 2;
            arr = temp;
        }

        arr[current] = data;
        current++;
    }

    void push(vectorType data, int index)
    {

        if (index == capacity)
            push(data);
        else
            arr[index] = data;
    }

    vectorType get(int index)
    {

        if (index < current)
            return arr[index]; // return array's type
    }

    // function to delete last element
    void pop()
    {
        current--;
    }

    // function to get size of the vector
    int size()
    {
        return current;
    }

    // function to get capacity of the vector
    int getCapacity()
    {
        return capacity;
    }

    vectorType &front()
    {
        return arr[0];
    }

    vectorType &back()
    {
        return arr[current - 1];
    }

    Vector<vectorType>::iterator begin()
    {
        return arr;
    }

    Vector<vectorType>::iterator end()
    {
        return arr + size(); // address beyond the last element
    }

    Vector<vectorType>::iterator rbegin()
    {
        return arr + size() - 1;
    }

    Vector<vectorType>::iterator rend()
    {
        return arr - 1;
    }

    void clear()
    {
        current = 0;
        capacity = 0;
        arr = NULL;
        delete[] arr;
    }

    vectorType &operator[](int index)
    {
        if (index < 0 || index > capacity)
        {
            cout << "Index is out of range" << endl;
            exit(1);
        }

        return arr[index];
    }

    Vector *operator->()
    {
        return this;
    }

    Vector<vectorType> &operator=(const Vector<vectorType> &v)
    {
        delete[] arr;
        current = v.current;
        capacity = v.capacity;
        arr = new vectorType[current];
        for (int i = 0; i < size(); i++)
        {
            arr[i] = v.arr[i];
        }

        return *this;
    }

    void reserve(int cap)
    {
        if (arr == NULL)
        {
            current = 0;
            capacity = 0;
        }

        vectorType *newBuffer = new vectorType[cap];
        // assert(newBuffer)
        unsigned int l_size = cap < current ? cap : current;
        // copy(buffer, buffer+l_size,newBuffer)

        for (unsigned int i = 0; i < l_size; i++)
        {
            newBuffer[i] = arr[i];
        }

        capacity = cap;
        delete[] arr;
        arr = newBuffer;
    }

    void resize(unsigned int size)
    {
        reserve(size);
        current = size;
    }
    Vector<vectorType> &operator++()
    {
        resize(current+1);
        arr[size()-1] = 0;
        return *this;
    }
    Vector<vectorType> &operator++(int)
    {
        resize(current+1);
        arr[size()-1] = 0;
        return *this;
    }
    Vector<vectorType> &operator--()
    {
        pop();
        return *this;
    }
    Vector<vectorType> &operator--(int)
    {
        pop();
        return *this;
    }
};

template <class vectorType>
void printVector(Vector<vectorType> vec)
{
    cout << "\n~-~-~-~-~ Output of vector ~-~-~-~-~\n";
    for (int i = 0; i < vec.size(); i++)
    {
        cout << vec[i] << " ";
    }    
    cout << endl;
}


// шаблонный класс Матрица
template <typename T>
class MATRIX
{
private:
    T **M; // матрица
    int m; // количество строк rows
    int n; // количество столбцов colums

public:
    // конструкторы
    MATRIX()
    {
        n = m = 0;
        M = nullptr;
    }

    MATRIX(int _m, int _n)
    {
        m = _m;
        n = _n;

        M = (T **)new T *[m]; // количество строк, количество указателей

        for (int i = 0; i < m; i++)
            M[i] = (T *)new T[n];

        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
                M[i][j] = 0;
    }

    MATRIX(const MATRIX &_M)
    {
        m = _M.m;
        n = _M.n;

        M = (T **)new T *[m]; // количество строк, количество указателей

        for (int i = 0; i < m; i++)
            M[i] = (T *)new T[n];

        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
                M[i][j] = _M.M[i][j];
    }

    T GetMij(int i, int j)
    {
        if ((m > 0) && (n > 0))
            return M[i][j];
        else
            return 0;
    }

    int GetRows()
    {
        return m;
    }
    int GetColums()
    {
        return n;
    }

    void SetMij(int i, int j, T value)
    {
        if ((i < 0) || (i >= m))
            return;
        if ((j < 0) || (j >= n))
            return;
        M[i][j] = value;
    }

    void printMatrix()
    {
        cout << "\n~~~~~~~~~ Output of matrix ~~~~~~~~~\n";
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
                cout << M[i][j] << "\t";
            cout << endl;
        }
        cout << "---------------------\n\n";
    }

    // Деструктор - освобождает память, выделенную для матрицы
    ~MATRIX()
    {
        if (n > 0)
        {
            // освободить выделенную память для каждой строки
            for (int i = 0; i < m; i++)
                delete[] M[i];
        }

        if (m > 0)
            delete[] M;
    }

    // оператор копирования - обязательный
    MATRIX operator=(const MATRIX &_M)
    {
        if (n > 0)
        {
            // освободить память, выделенную ранее для объекта *this
            for (int i = 0; i < m; i++)
                delete[] M[i];
        }

        if (m > 0)
        {
            delete[] M;
        }

        // Копирование данных M <= _M
        m = _M.m;
        n = _M.n;

        // Выделить память для M опять
        M = (T **)new T *[m]; // количество строк, количество указателей
        for (int i = 0; i < m; i++)
            M[i] = (T *)new T[n];

        // заполнить значениями
        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
                M[i][j] = _M.M[i][j];
        return *this;
    }
    template <class vectorType>
    friend MATRIX<T> operator*(Vector<vectorType> vec);

};

// template <typename T>
// template <class vectorType>
// void func(const MATRIX &_M, Vector<vectorType> vec)
// {

// }

template <typename T, class vectorType>
MATRIX<T> operator*(MATRIX<T> &m1, Vector<vectorType> vec)
{
    MATRIX<T> res(m1.GetRows(), m1.GetColums());
    // if(m1.GetRows() != vec.size())
    // {
    //     return res;
    // }
    for (int j = 0; j < m1.GetColums(); j++)
    {
        for (int i = 0; i < m1.GetRows(); i++)
        {
            res.SetMij(i, j, m1.GetMij(i, j) * vec[j]);
        }
    }

    return res;
}

int main()
{
    int m = 2;
    int n = 3;
    MATRIX<double> M(m, n);
    M.printMatrix();

    for (int i = 0; i < 2; i++)
        for (int j = 0; j < 3; j++)
            M.SetMij(i, j, i + j);

    M.printMatrix();

    MATRIX<double> M2 = M; // вызов конструктора копирования
    M2.printMatrix();

    MATRIX<double> M3; // вызов оператора копирования - проверка
    M3 = M;
    M3.printMatrix();

    MATRIX<double> M4;
    M4 = M3 = M2 = M; // вызов оператора копирования в виде "цепочки"
    M4.printMatrix();


    Vector<double> vec;
    vec.push(0.5);
    printVector(vec);

    vec++;
    printVector(vec); 

    vec--;
    for (int i = 0; i < 6; i++)
    {
        vec.push(i+1);
    }
    printVector(vec); 

    MATRIX<double> M5;
    M5 = M4*vec;
    M5.printMatrix();
    return 0;
}