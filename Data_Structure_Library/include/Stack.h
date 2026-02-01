#ifndef STACK_H
#define STACK_H

#include <iostream>
using namespace std;

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//      Stack using Generic Approach (Linked List Implementation)
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

// ---------------- NODE ----------------
template <class T>
struct snode
{
    T data;
    struct snode *next;
};

// ---------------- STACK ----------------
template <class T>
class Stack
{
private:
    snode<T> *first;
    int iCount;

public:
    Stack();

    void Push(T);
    void Pop();

    void Display();
    int Count();

    bool Search(T);
    T Peek();
    int Frequency(T);
};

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Function Name :     Stack (Constructor)
//  Description :       Initializes stack
//  Author :            Prathamesh Rajendra Gavandi
//  Date :              06/01/2026
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
Stack<T>::Stack()
{
    first = NULL;
    iCount = 0;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Function Name :     Push
//  Input :             Data (Generic)
//  Output :            Nothing
//  Description :       Inserts element on top of stack
//  Author :            Prathamesh Rajendra Gavandi
//  Date :              06/01/2026
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
void Stack<T>::Push(T no)
{
    snode<T> *newn = new snode<T>;
    newn->data = no;
    newn->next = NULL;

    if (first == NULL)
    {
        first = newn;
    }
    else
    {
        newn->next = first;
        first = newn;
    }
    iCount++;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Function Name :     Pop
//  Input :             None
//  Output :            Nothing
//  Description :       Removes element from top of stack
//  Author :            Prathamesh Rajendra Gavandi
//  Date :              06/01/2026
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
void Stack<T>::Pop()
{
    if (first == NULL)
        return;

    snode<T> *temp = first;
    first = first->next;
    delete temp;
    iCount--;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Function Name :     Display
//  Input :             None
//  Output :            Displays stack elements
//  Description :       Displays all elements of stack
//  Author :            Prathamesh Rajendra Gavandi
//  Date :              06/01/2026
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
void Stack<T>::Display()
{
    snode<T> *temp = first;
    while (temp != NULL)
    {
        cout << "| " << temp->data << " |\n";
        temp = temp->next;
    }
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Function Name :     Count
//  Input :             None
//  Output :            Integer
//  Description :       Returns number of elements in stack
//  Author :            Prathamesh Rajendra Gavandi
//  Date :              06/01/2026
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
int Stack<T>::Count()
{
    return iCount;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Function Name :     Search
//  Input :             Data (Generic)
//  Output :            Boolean
//  Description :       Searches element in stack
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
bool Stack<T>::Search(T no)
{
    snode<T> *temp = first;
    while (temp != NULL)
    {
        if (temp->data == no)
            return true;
        temp = temp->next;
    }
    return false;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Function Name :     Peek
//  Input :             None
//  Output :            Data (Generic)
//  Description :       Returns top element of stack
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
T Stack<T>::Peek()
{
    if (first == NULL)
        return T();

    return first->data;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Function Name :     Frequency
//  Input :             Data (Generic)
//  Output :            Integer
//  Description :       Returns frequency of given element in stack
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
int Stack<T>::Frequency(T no)
{
    int cnt = 0;
    snode<T> *temp = first;

    while (temp != NULL)
    {
        if (temp->data == no)
            cnt++;
        temp = temp->next;
    }
    return cnt;
}

#endif
