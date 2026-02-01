#ifndef QUEUE_H
#define QUEUE_H

#include <iostream>
using namespace std;

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//      Queue using Generic Approach (Linked List Implementation)
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

// ---------------- NODE ----------------
template <class T>
struct qnode
{
    T data;
    struct qnode *next;
};

// ---------------- QUEUE ----------------
template <class T>
class Queue
{
private:
    qnode<T> *first;
    qnode<T> *last;
    int iCount;

public:
    Queue();

    void Enqueue(T);
    void Dequeue();

    void Display();
    int Count();

    bool Search(T);
    T Front();
    T Rear();
    int Frequency(T);
};

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Function Name :     Queue (Constructor)
//  Description :       Initializes queue
//  Author :            Prathamesh Rajendra Gavandi
//  Date :              06/01/2026
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
Queue<T>::Queue()
{
    first = NULL;
    last = NULL;
    iCount = 0;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Function Name :     Enqueue
//  Input :             Data (Generic)
//  Output :            Nothing
//  Description :       Inserts element at end of queue
//  Author :            Prathamesh Rajendra Gavandi
//  Date :              06/01/2026
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
void Queue<T>::Enqueue(T no)
{
    qnode<T> *newn = new qnode<T>;
    newn->data = no;
    newn->next = NULL;

    if (first == NULL)
    {
        first = last = newn;
    }
    else
    {
        last->next = newn;
        last = newn;
    }
    iCount++;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Function Name :     Dequeue
//  Input :             None
//  Output :            Nothing
//  Description :       Removes element from front of queue
//  Author :            Prathamesh Rajendra Gavandi
//  Date :              06/01/2026
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
void Queue<T>::Dequeue()
{
    if (first == NULL)
        return;

    qnode<T> *temp = first;
    first = first->next;
    delete temp;
    iCount--;

    if (first == NULL)
        last = NULL;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Function Name :     Display
//  Input :             None
//  Output :            Displays queue elements
//  Description :       Displays all elements of queue
//  Author :            Prathamesh Rajendra Gavandi
//  Date :              06/01/2026
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
void Queue<T>::Display()
{
    qnode<T> *temp = first;
    while (temp != NULL)
    {
        cout << "| " << temp->data << " | -> ";
        temp = temp->next;
    }
    cout << "NULL\n";
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Function Name :     Count
//  Input :             None
//  Output :            Integer
//  Description :       Returns number of elements in queue
//  Author :            Prathamesh Rajendra Gavandi
//  Date :              06/01/2026
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
int Queue<T>::Count()
{
    return iCount;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Function Name :     Search
//  Input :             Data (Generic)
//  Output :            Boolean
//  Description :       Searches element in queue
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
bool Queue<T>::Search(T no)
{
    qnode<T> *temp = first;
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
//  Function Name :     Front
//  Input :             None
//  Output :            Data (Generic)
//  Description :       Returns front element of queue
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
T Queue<T>::Front()
{
    if (first == NULL)
        return T();

    return first->data;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Function Name :     Rear
//  Input :             None
//  Output :            Data (Generic)
//  Description :       Returns last element of queue
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
T Queue<T>::Rear()
{
    if (last == NULL)
        return T();

    return last->data;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Function Name :     Frequency
//  Input :             Data (Generic)
//  Output :            Integer
//  Description :       Returns frequency of given element
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
int Queue<T>::Frequency(T no)
{
    int cnt = 0;
    qnode<T> *temp = first;

    while (temp != NULL)
    {
        if (temp->data == no)
            cnt++;
        temp = temp->next;
    }
    return cnt;
}

#endif
