#ifndef SINGLYLL_H
#define SINGLYLL_H

#include <iostream>
using namespace std;

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//      Singly Linear Linked List using Generic Approach
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

// ---------------- NODE ----------------
template <class T>
struct node
{
    T data;
    struct node *next;
};

// ---------------- SINGLY LINEAR LINKED LIST ----------------
template <class T>
class SinglyLL
{
private:
    node<T> *first;
    int iCount;

public:
    SinglyLL();

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
//  Function Name :     SinglyLL (Constructor)
//  Input :             None
//  Output :            None
//  Description :       Initializes singly linear linked list
//  Author :            Prathamesh Rajendra Gavandi
//  Date :              06/01/2026
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
SinglyLL<T>::SinglyLL()
{
    first = NULL;
    iCount = 0;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Function Name :     InsertFirst
//  Input :             Data of node (Generic)
//  Output :            Nothing
//  Description :       Inserts new node at the beginning of singly linear linked list
//  Author :            Prathamesh Rajendra Gavandi
//  Date :              06/01/2026
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
void SinglyLL<T>::InsertFirst(T no)
{
    node<T> *newn = new node<T>;
    newn->data = no;
    newn->next = first;
    first = newn;
    iCount++;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Function Name :     InsertLast
//  Input :             Data of node (Generic)
//  Output :            Nothing
//  Description :       Inserts new node at the end of singly linear linked list
//  Author :            Prathamesh Rajendra Gavandi
//  Date :              06/01/2026
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
void SinglyLL<T>::InsertLast(T no)
{
    node<T> *newn = new node<T>;
    newn->data = no;
    newn->next = NULL;

    if (first == NULL)
    {
        first = newn;
    }
    else
    {
        node<T> *temp = first;
        while (temp->next != NULL)
        {
            temp = temp->next;
        }
        temp->next = newn;
    }
    iCount++;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Function Name :     InsertAtPos
//  Input :             Data of node (Generic), Position
//  Output :            Nothing
//  Description :       Inserts new node at specified position in singly linear linked list
//  Author :            Prathamesh Rajendra Gavandi
//  Date :              06/01/2026
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
void SinglyLL<T>::InsertAtPos(T no, int pos)
{
    if (pos < 1 || pos > iCount + 1)
        return;

    if (pos == 1)
        InsertFirst(no);
    else if (pos == iCount + 1)
        InsertLast(no);
    else
    {
        node<T> *newn = new node<T>;
        newn->data = no;

        node<T> *temp = first;
        for (int i = 1; i < pos - 1; i++)
            temp = temp->next;

        newn->next = temp->next;
        temp->next = newn;
        iCount++;
    }
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Function Name :     DeleteFirst
//  Input :             None
//  Output :            Nothing
//  Description :       Deletes first node from singly linear linked list
//  Author :            Prathamesh Rajendra Gavandi
//  Date :              06/01/2026
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
void SinglyLL<T>::DeleteFirst()
{
    if (first == NULL)
        return;

    node<T> *temp = first;
    first = first->next;
    delete temp;
    iCount--;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Function Name :     DeleteLast
//  Input :             None
//  Output :            Nothing
//  Description :       Deletes last node from singly linear linked list
//  Author :            Prathamesh Rajendra Gavandi
//  Date :              06/01/2026
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
void SinglyLL<T>::DeleteLast()
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
        node<T> *temp = first;
        while (temp->next->next != NULL)
            temp = temp->next;

        delete temp->next;
        temp->next = NULL;
    }
    iCount--;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Function Name :     DeleteAtPos
//  Input :             Position
//  Output :            Nothing
//  Description :       Deletes node from specified position in singly linear linked list
//  Author :            Prathamesh Rajendra Gavandi
//  Date :              06/01/2026
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
void SinglyLL<T>::DeleteAtPos(int pos)
{
    if (pos < 1 || pos > iCount)
        return;

    if (pos == 1)
        DeleteFirst();
    else if (pos == iCount)
        DeleteLast();
    else
    {
        node<T> *temp = first;
        for (int i = 1; i < pos - 1; i++)
            temp = temp->next;

        node<T> *target = temp->next;
        temp->next = target->next;
        delete target;
        iCount--;
    }
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Function Name :     Display
//  Input :             None
//  Output :            Displays linked list
//  Description :       Displays all elements of singly linear linked list
//  Author :            Prathamesh Rajendra Gavandi
//  Date :              06/01/2026
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
void SinglyLL<T>::Display()
{
    node<T> *temp = first;
    while (temp != NULL)
    {
        cout << "|" << temp->data << "|->";
        temp = temp->next;
    }
    cout << "NULL\n";
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Function Name :     Count
//  Input :             None
//  Output :            Integer
//  Description :       Returns total number of nodes in singly linear linked list
//  Author :            Prathamesh Rajendra Gavandi
//  Date :              06/01/2026
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
int SinglyLL<T>::Count()
{
    return iCount;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Function Name :     Search
//  Input :             Data to search (Generic)
//  Output :            Boolean
//  Description :       Searches element in singly linear linked list
//  Author :            Prathamesh Rajendra Gavandi
//  Date :              06/01/2026
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
bool SinglyLL<T>::Search(T no)
{
    node<T> *temp = first;
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
//  Output :            Integer (Position)
//  Description :       Returns first occurrence position of element
//  Author :            Prathamesh Rajendra Gavandi
//  Date :              06/01/2026
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
int SinglyLL<T>::FirstOcc(T no)
{
    int pos = 1;
    node<T> *temp = first;

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
//  Output :            Integer (Position)
//  Description :       Returns last occurrence position of element
//  Author :            Prathamesh Rajendra Gavandi
//  Date :              06/01/2026
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
int SinglyLL<T>::LastOcc(T no)
{
    int pos = 1, last = -1;
    node<T> *temp = first;

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
//  Author :            Prathamesh Rajendra Gavandi
//  Date :              06/01/2026
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
int SinglyLL<T>::Frequency(T no)
{
    int cnt = 0;
    node<T> *temp = first;

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
//  Description :       Reverses singly linear linked list
//  Author :            Prathamesh Rajendra Gavandi
//  Date :              06/01/2026
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
void SinglyLL<T>::Reverse()
{
    node<T> *prev = NULL;
    node<T> *curr = first;
    node<T> *next = NULL;

    while (curr != NULL)
    {
        next = curr->next;
        curr->next = prev;
        prev = curr;
        curr = next;
    }
    first = prev;
}

#endif
