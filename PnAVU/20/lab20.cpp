#include <iostream>

using namespace std;

const int MAXSIZE = 50;


template <class T>
class Set
{
private:
    T *arr;
    int size;

public:
    Set()
    {
        arr = new T[MAXSIZE];
        size = 0;
    }
    Set(T *_arr, int _size)
    {
        int n = 0;
        for (int i = 0; i < _size - 1; i++)
            for (int j = i + 1; j < _size - i - 1; j++)
                if (_arr[i] == _arr[j])
                {
                    for (int k = j; k < _size; k++)
                    {
                        _arr[k] = _arr[k + 1];
                    }
                    n++;
                }
        arr = _arr;
        size = _size - n;
    }
    Set(int _size)
    {
        arr = new T[_size];
        size = _size;
    }

    Set(Set &s1)
    { //копирование
        size = s1.getSize();
        T *arr1 = s1.getArray();
        for (int i = 0; i < size; i++)
        {
            arr[i] = arr1[i];
            // size++;
            // add(arr1[i]);
        }
    }

    ~Set()
    {
        delete[] arr;
    }

    void add(T c);
    T *getArray();
    int find(T c);
    void remove();
    bool check(T c);
    void print();
    int getSize();
    void sort();

    Set &operator+(T t);
    // Set &operator+(Set<T>);


    Set<T> operator+(const Set<T> &s2); // обьединение множеств

    bool operator == (Set<T> &other)
    {
        if(size != other.size) return false;
        for(int i = 0; i < size; i++)
            if(arr[i] != other.arr[i]) return false;
        return true;
    }

    // template <class T>
    // Set &operator *(Set<T> set1);

    // T operator +(Set &set)
    // {
    //     cout << "1";
    //     // cout << *this;
    // }


};

template <class T>
void Set<T>::sort()
{



}

template <class T>
void Set<T>::add(T c)
{
    if (check(c) == false)
    {
        arr[size] = c;
        size++;
        sort();
    }

    else
    {
        cout << "There is already such element in array" << endl;
    }
}

template <class T>
T *Set<T>::getArray()
{
    return arr;
}

template <class T>
int Set<T>::find(T c)
{
    for (int i = 0; i < size; i++)
    {
        if (c == arr[i])
        {
            cout << "Element '" << c << "' nahoditsa in array pod indexom: " << i + 1 << endl;
            return i + 1;
        }
    }
}

template <class T>
void Set<T>::remove()
{
    int num;
    print();
    cout << "Input index of element you want to delete:" << endl;
    cin >> num;
    num--;
    for (int i = num; i < size; i++)
    {
        arr[i] = arr[i + 1];
    }
    size--;
}

template <class T>
bool Set<T>::check(T c)
{
    for (int i = 0; i < size; i++)
        if (c == arr[i])
            return true;
    return false;
}

template <class T>
void Set<T>::print()
{
    cout << "Output of array:" << endl;
    for (int i = 0; i < size; i++)
        cout << i + 1 << ": " << arr[i] << endl;
}

template <class T>
int Set<T>::getSize()
{
    return size;
}

template <class T>
Set<T> &Set<T>::operator+(T t)
{ //удалить элемент из множества (типа set-item);
    /*int num = find(t);
    for (int i = num; i < size; i++) {
        arr[i] = arr[i + 1];
    }
    size--;
    return *this;*/
    add(t);
    return *this;
}

template <class T>
Set<T> Set<T>::operator+(const Set<T> &s2)
{
    // bool in;
    Set <T> s3;
    for(int i = 0; i < size; i++)
    {
        cout << arr[i] <<"arr ";
        s3.arr[s3.size] = arr[i];
        s3.size++;
        cout << s3.size << " ";
    }
    for (int i = 0; i < s2.size; i++)
    {
        
        cout << s2.arr[i] << " ";
        bool check = false;
        for (int j = 0; j < size; j++)
        {
            if(s2.arr[i] == arr[j])
            { 
                check = true;
            }    
            
        }
        
        if(check == false)
        {  
            s3.arr[s3.size] = s2.arr[i];
            cout << s3.arr[s3.size] <<"- arr -" << s3.size;
            s3.size++;
            cout <<  s3.size << "s";
        }      
    }
    
    // for(int i=0;i<s2.size;i++)
    // {
    //         in=s3.check_in(s2.a[i]);

    //         if(!in)
    //         {
    //                 s3.a[size]=s2.a[i];
    //                 s3.size+=1;
    //         }
    // }
    return s3;
}


// Set<T> &operator*(Set<T> set1)
// {


//     return *this;
// }


// template <class T>
// Set<T>::operator+(Set<T>, T t)
// { //удалить элемент из множества (типа set-item);
//     /*int num = find(t);
//     for (int i = num; i < size; i++) {
//         arr[i] = arr[i + 1];
//     }
//     size--;
//     return *this;*/
//     add(t);
//     return *this;
// }

int main()
{
    Set<int> i;
    i + 2;
    i + 4;
    // 2 + i;
    i.print();

    Set<int> i1;
    i1 + 4;
    // 1 + i1;
    i1.print();

    Set<int> i2;

    i1+i;
    i.print();

    if(i2 == i1) cout << "equal\n";
    else cout << "no equal\n";
    return 0;
}