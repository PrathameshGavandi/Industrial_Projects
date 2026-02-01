#ifndef DOUBLYLL_H
#define DOUBLYLL_H

#include <iostream>
using namespace std;

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//      Doubly Linear Linked List using Generic Approach
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

// ---------------- NODE ----------------
template <class T>
struct dnode
{
    T data;
    struct dnode *next;
    struct dnode *prev;
};

// ---------------- DOUBLY LINEAR LINKED LIST ----------------
template <class T>
class DoublyLL
{
private:
    dnode<T> *first;
    int iCount;

public:
    DoublyLL();

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
    void Reverse();
};

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Function Name :     DoublyLL (Constructor)
//  Input :             None
//  Output :            None
//  Description :       Initializes doubly linear linked list
//  Author :            Prathamesh Rajendra Gavandi
//  Date :              06/01/2026
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
DoublyLL<T>::DoublyLL()
{
    first = NULL;
    iCount = 0;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Function Name :     InsertFirst
//  Input :             Data of node (Generic)
//  Output :            Nothing
//  Description :       Inserts new node at the beginning of doubly linear linked list
//  Author :            Prathamesh Rajendra Gavandi
//  Date :              06/01/2026
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
void DoublyLL<T>::InsertFirst(T no)
{
    dnode<T> *newn = new dnode<T>;
    newn->data = no;
    newn->next = first;
    newn->prev = NULL;

    if (first != NULL)
        first->prev = newn;

    first = newn;
    iCount++;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Function Name :     InsertLast
//  Input :             Data of node (Generic)
//  Output :            Nothing
//  Description :       Inserts new node at the end of doubly linear linked list
//  Author :            Prathamesh Rajendra Gavandi
//  Date :              06/01/2026
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
void DoublyLL<T>::InsertLast(T no)
{
    dnode<T> *newn = new dnode<T>;
    newn->data = no;
    newn->next = NULL;
    newn->prev = NULL;

    if (first == NULL)
    {
        first = newn;
    }
    else
    {
        dnode<T> *temp = first;
        while (temp->next != NULL)
            temp = temp->next;

        temp->next = newn;
        newn->prev = temp;
    }
    iCount++;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Function Name :     InsertAtPos
//  Input :             Data (Generic), Position
//  Output :            Nothing
//  Description :       Inserts node at specified position in doubly linear linked list
//  Author :            Prathamesh Rajendra Gavandi
//  Date :              06/01/2026
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
void DoublyLL<T>::InsertAtPos(T no, int pos)
{
    if (pos < 1 || pos > iCount + 1)
        return;

    if (pos == 1)
        InsertFirst(no);
    else if (pos == iCount + 1)
        InsertLast(no);
    else
    {
        dnode<T> *newn = new dnode<T>;
        newn->data = no;

        dnode<T> *temp = first;
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
//  Description :       Deletes first node from doubly linear linked list
//  Author :            Prathamesh Rajendra Gavandi
//  Date :              06/01/2026
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
void DoublyLL<T>::DeleteFirst()
{
    if (first == NULL)
        return;

    if (first->next == NULL)
    {
        delete first;
        first = NULL;
    }
    else
    {
        first = first->next;
        delete first->prev;
        first->prev = NULL;
    }
    iCount--;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Function Name :     DeleteLast
//  Input :             None
//  Output :            Nothing
//  Description :       Deletes last node from doubly linear linked list
//  Author :            Prathamesh Rajendra Gavandi
//  Date :              06/01/2026
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
void DoublyLL<T>::DeleteLast()
{
    if (first == NULL)
        return;

    if (first->next == NULL)
    {
        delete first;
        first = NULL;
    }
    else
    {
        dnode<T> *temp = first;
        while (temp->next != NULL)
            temp = temp->next;

        temp->prev->next = NULL;
        delete temp;
    }
    iCount--;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Function Name :     DeleteAtPos
//  Input :             Position
//  Output :            Nothing
//  Description :       Deletes node from specified position in doubly linear linked list
//  Author :            Prathamesh Rajendra Gavandi
//  Date :              06/01/2026
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
void DoublyLL<T>::DeleteAtPos(int pos)
{
    if (pos < 1 || pos > iCount)
        return;

    if (pos == 1)
        DeleteFirst();
    else if (pos == iCount)
        DeleteLast();
    else
    {
        dnode<T> *temp = first;
        for (int i = 1; i < pos; i++)
            temp = temp->next;

        temp->prev->next = temp->next;
        temp->next->prev = temp->prev;
        delete temp;
        iCount--;
    }
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Function Name :     Display
//  Input :             None
//  Output :            Displays list
//  Description :       Displays all elements of doubly linear linked list
//  Author :            Prathamesh Rajendra Gavandi
//  Date :              06/01/2026
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
void DoublyLL<T>::Display()
{
    dnode<T> *temp = first;
    while (temp != NULL)
    {
        cout << "|" << temp->data << "|<=>";
        temp = temp->next;
    }
    cout << "NULL\n";
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Function Name :     Count
//  Input :             None
//  Output :            Integer
//  Description :       Returns number of nodes in doubly linear linked list
//  Author :            Prathamesh Rajendra Gavandi
//  Date :              06/01/2026
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
int DoublyLL<T>::Count()
{
    return iCount;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Function Name :     Search
//  Input :             Data (Generic)
//  Output :            Boolean
//  Description :       Searches element in doubly linear linked list
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
bool DoublyLL<T>::Search(T no)
{
    dnode<T> *temp = first;
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
//  Function Name :     FirstOcc
//  Input :             Data (Generic)
//  Output :            Integer
//  Description :       Returns first occurrence position
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
int DoublyLL<T>::FirstOcc(T no)
{
    int pos = 1;
    dnode<T> *temp = first;

    while (temp != NULL)
    {
        if (temp->data == no)
            return pos;
        pos++;
        temp = temp->next;
    }
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
int DoublyLL<T>::LastOcc(T no)
{
    int pos = 1, last = -1;
    dnode<T> *temp = first;

    while (temp != NULL)
    {
        if (temp->data == no)
            last = pos;
        pos++;
        temp = temp->next;
    }
    return last;
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
int DoublyLL<T>::Frequency(T no)
{
    int cnt = 0;
    dnode<T> *temp = first;

    while (temp != NULL)
    {
        if (temp->data == no)
            cnt++;
        temp = temp->next;
    }
    return cnt;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Function Name :     Reverse
//  Input :             None
//  Output :            Nothing
//  Description :       Reverses doubly linear linked list
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
void DoublyLL<T>::Reverse()
{
    dnode<T> *temp = NULL;
    dnode<T> *curr = first;

    while (curr != NULL)
    {
        temp = curr->prev;
        curr->prev = curr->next;
        curr->next = temp;
        curr = curr->prev;
    }

    if (temp != NULL)
        first = temp->prev;
}

#endif
