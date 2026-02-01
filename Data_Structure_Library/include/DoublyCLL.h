#ifndef DOUBLYCLL_H
#define DOUBLYCLL_H

#include <iostream>
using namespace std;

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//      Doubly Circular Linked List using Generic Approach
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

// ---------------- NODE ----------------
template <class T>
struct dcnode
{
    T data;
    struct dcnode *next;
    struct dcnode *prev;
};

// ---------------- DOUBLY CIRCULAR LINKED LIST ----------------
template <class T>
class DoublyCLL
{
private:
    dcnode<T> *first;
    dcnode<T> *last;
    int iCount;

public:
    DoublyCLL();

    void InsertFirst(T);
    void InsertLast(T);
    void InsertAtPos(T, int);

    void DeleteFirst();
    void DeleteLast();
    void DeleteAtPos(int);

    void Display();
    int Count();

    bool Search(T);
    int FirstOcc(T);
    int LastOcc(T);
    int Frequency(T);
};

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Function Name :     DoublyCLL (Constructor)
//  Input :             None
//  Output :            None
//  Description :       Initializes doubly circular linked list
//  Author :            Prathamesh Rajendra Gavandi
//  Date :              06/01/2026
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
DoublyCLL<T>::DoublyCLL()
{
    first = NULL;
    last = NULL;
    iCount = 0;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Function Name :     InsertFirst
//  Input :             Data of node (Generic)
//  Output :            Nothing
//  Description :       Inserts new node at beginning of doubly circular linked list
//  Author :            Prathamesh Rajendra Gavandi
//  Date :              06/01/2026
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
void DoublyCLL<T>::InsertFirst(T no)
{
    dcnode<T> *newn = new dcnode<T>;
    newn->data = no;

    if (first == NULL)
    {
        first = last = newn;
        first->next = first;
        first->prev = first;
    }
    else
    {
        newn->next = first;
        newn->prev = last;
        first->prev = newn;
        last->next = newn;
        first = newn;
    }
    iCount++;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Function Name :     InsertLast
//  Input :             Data of node (Generic)
//  Output :            Nothing
//  Description :       Inserts new node at end of doubly circular linked list
//  Author :            Prathamesh Rajendra Gavandi
//  Date :              06/01/2026
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
void DoublyCLL<T>::InsertLast(T no)
{
    dcnode<T> *newn = new dcnode<T>;
    newn->data = no;

    if (first == NULL)
    {
        first = last = newn;
        first->next = first;
        first->prev = first;
    }
    else
    {
        newn->prev = last;
        newn->next = first;
        last->next = newn;
        first->prev = newn;
        last = newn;
    }
    iCount++;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Function Name :     InsertAtPos
//  Input :             Data (Generic), Position
//  Output :            Nothing
//  Description :       Inserts node at specified position in doubly circular linked list
//  Author :            Prathamesh Rajendra Gavandi
//  Date :              06/01/2026
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
void DoublyCLL<T>::InsertAtPos(T no, int pos)
{
    if (pos < 1 || pos > iCount + 1)
        return;

    if (pos == 1)
        InsertFirst(no);
    else if (pos == iCount + 1)
        InsertLast(no);
    else
    {
        dcnode<T> *newn = new dcnode<T>;
        newn->data = no;

        dcnode<T> *temp = first;
        for (int i = 1; i < pos - 1; i++)
            temp = temp->next;

        newn->next = temp->next;
        newn->prev = temp;
        temp->next->prev = newn;
        temp->next = newn;

        iCount++;
    }
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Function Name :     DeleteFirst
//  Input :             None
//  Output :            Nothing
//  Description :       Deletes first node from doubly circular linked list
//  Author :            Prathamesh Rajendra Gavandi
//  Date :              06/01/2026
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
void DoublyCLL<T>::DeleteFirst()
{
    if (first == NULL)
        return;

    if (first == last)
    {
        delete first;
        first = last = NULL;
    }
    else
    {
        dcnode<T> *temp = first;
        first = first->next;
        first->prev = last;
        last->next = first;
        delete temp;
    }
    iCount--;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Function Name :     DeleteLast
//  Input :             None
//  Output :            Nothing
//  Description :       Deletes last node from doubly circular linked list
//  Author :            Prathamesh Rajendra Gavandi
//  Date :              06/01/2026
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////
template <class T>
void DoublyCLL<T>::DeleteLast()
{
    if (first == NULL)
        return;

    if (first == last)
    {
        delete first;
        first = last = NULL;
    }
    else
    {
        dcnode<T> *temp = last;
        last = last->prev;
        last->next = first;
        first->prev = last;
        delete temp;
    }
    iCount--;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Function Name :     DeleteAtPos
//  Input :             Position
//  Output :            Nothing
//  Description :       Deletes node from specified position in doubly circular linked list
//  Author :            Prathamesh Rajendra Gavandi
//  Date :              06/01/2026
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
void DoublyCLL<T>::DeleteAtPos(int pos)
{
    if (pos < 1 || pos > iCount)
        return;

    if (pos == 1)
        DeleteFirst();
    else if (pos == iCount)
        DeleteLast();
    else
    {
        dcnode<T> *temp = first;
        for (int i = 1; i < pos; i++)
            temp = temp->next;

        temp->prev->next = temp->next;
        temp->next->prev = temp->prev;
        delete temp;
        iCount--;
    }
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Function Name :     Display
//  Input :             None
//  Output :            Displays list
//  Description :       Displays all elements of doubly circular linked list
//  Author :            Prathamesh Rajendra Gavandi
//  Date :              06/01/2026
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
void DoublyCLL<T>::Display()
{
    if (first == NULL)
        return;

    dcnode<T> *temp = first;
    do
    {
        cout << "|" << temp->data << "|<=>";
        temp = temp->next;
    } while (temp != first);

    cout << "\n";
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Function Name :     Count
//  Input :             None
//  Output :            Integer
//  Description :       Returns number of nodes in doubly circular linked list
//  Author :            Prathamesh Rajendra Gavandi
//  Date :              06/01/2026
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
int DoublyCLL<T>::Count()
{
    return iCount;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Function Name :     Search
//  Input :             Data (Generic)
//  Output :            Boolean
//  Description :       Searches element in doubly circular linked list
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
bool DoublyCLL<T>::Search(T no)
{
    if (first == NULL)
        return false;

    dcnode<T> *temp = first;
    do
    {
        if (temp->data == no)
            return true;
        temp = temp->next;
    } while (temp != first);

    return false;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Function Name :     FirstOcc
//  Input :             Data (Generic)
//  Output :            Integer
//  Description :       Returns first occurrence position
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
int DoublyCLL<T>::FirstOcc(T no)
{
    if (first == NULL)
        return -1;

    int pos = 1;
    dcnode<T> *temp = first;

    do
    {
        if (temp->data == no)
            return pos;
        pos++;
        temp = temp->next;
    } while (temp != first);

    return -1;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Function Name :     LastOcc
//  Input :             Data (Generic)
//  Output :            Integer
//  Description :       Returns last occurrence position
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
int DoublyCLL<T>::LastOcc(T no)
{
    if (first == NULL)
        return -1;

    int pos = 1, lastpos = -1;
    dcnode<T> *temp = first;

    do
    {
        if (temp->data == no)
            lastpos = pos;
        pos++;
        temp = temp->next;
    } while (temp != first);

    return lastpos;
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
int DoublyCLL<T>::Frequency(T no)
{
    if (first == NULL)
        return 0;

    int cnt = 0;
    dcnode<T> *temp = first;

    do
    {
        if (temp->data == no)
            cnt++;
        temp = temp->next;
    } while (temp != first);

    return cnt;
}

#endif
