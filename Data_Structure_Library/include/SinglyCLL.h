#ifndef SINGLYCLL_H
#define SINGLYCLL_H

#include <iostream>
using namespace std;

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//      Singly Circular Linked List using Generic Approach
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

// ---------------- NODE ----------------
template <class T>
struct snode
{
    T data;
    struct snode *next;
};

// ---------------- SINGLY CIRCULAR LINKED LIST ----------------
template <class T>
class SinglyCLL
{
private:
    snode<T> *first;
    snode<T> *last;
    int iCount;

public:
    SinglyCLL();

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
//  Function Name :     SinglyCLL (Constructor)
//  Input :             None
//  Output :            None
//  Description :       Initializes singly circular linked list
//  Author :            Prathamesh Rajendra Gavandi
//  Date :              06/01/2026
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
SinglyCLL<T>::SinglyCLL()
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
//  Description :       Inserts new node at beginning of singly circular linked list
//  Author :            Prathamesh Rajendra Gavandi
//  Date :              06/01/2026
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
void SinglyCLL<T>::InsertFirst(T no)
{
    snode<T> *newn = new snode<T>;
    newn->data = no;

    if ((first == NULL) && (last == NULL))
    {
        first = last = newn;
        last->next = first;
    }
    else
    {
        newn->next = first;
        first = newn;
        last->next = first;
    }
    iCount++;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Function Name :     InsertLast
//  Input :             Data of node (Generic)
//  Output :            Nothing
//  Description :       Inserts new node at end of singly circular linked list
//  Author :            Prathamesh Rajendra Gavandi
//  Date :              06/01/2026
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
void SinglyCLL<T>::InsertLast(T no)
{
    snode<T> *newn = new snode<T>;
    newn->data = no;

    if ((first == NULL) && (last == NULL))
    {
        first = last = newn;
        last->next = first;
    }
    else
    {
        last->next = newn;
        last = newn;
        last->next = first;
    }
    iCount++;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Function Name :     InsertAtPos
//  Input :             Data (Generic), Position
//  Output :            Nothing
//  Description :       Inserts node at specified position in singly circular linked list
//  Author :            Prathamesh Rajendra Gavandi
//  Date :              06/01/2026
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
void SinglyCLL<T>::InsertAtPos(T no, int pos)
{
    if (pos < 1 || pos > iCount + 1)
        return;

    if (pos == 1)
        InsertFirst(no);
    else if (pos == iCount + 1)
        InsertLast(no);
    else
    {
        snode<T> *newn = new snode<T>;
        newn->data = no;

        snode<T> *temp = first;
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
//  Description :       Deletes first node from singly circular linked list
//  Author :            Prathamesh Rajendra Gavandi
//  Date :              06/01/2026
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
void SinglyCLL<T>::DeleteFirst()
{
    if ((first == NULL) && (last == NULL))
        return;

    if (first == last)
    {
        delete first;
        first = last = NULL;
    }
    else
    {
        snode<T> *temp = first;
        first = first->next;
        delete temp;
        last->next = first;
    }
    iCount--;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Function Name :     DeleteLast
//  Input :             None
//  Output :            Nothing
//  Description :       Deletes last node from singly circular linked list
//  Author :            Prathamesh Rajendra Gavandi
//  Date :              06/01/2026
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
void SinglyCLL<T>::DeleteLast()
{
    if ((first == NULL) && (last == NULL))
        return;

    if (first == last)
    {
        delete first;
        first = last = NULL;
    }
    else
    {
        snode<T> *temp = first;
        while (temp->next != last)
            temp = temp->next;

        delete last;
        last = temp;
        last->next = first;
    }
    iCount--;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Function Name :     DeleteAtPos
//  Input :             Position
//  Output :            Nothing
//  Description :       Deletes node from specified position in singly circular linked list
//  Author :            Prathamesh Rajendra Gavandi
//  Date :              06/01/2026
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
void SinglyCLL<T>::DeleteAtPos(int pos)
{
    if (pos < 1 || pos > iCount)
        return;

    if (pos == 1)
        DeleteFirst();
    else if (pos == iCount)
        DeleteLast();
    else
    {
        snode<T> *temp = first;
        for (int i = 1; i < pos - 1; i++)
            temp = temp->next;

        snode<T> *target = temp->next;
        temp->next = target->next;
        delete target;
        iCount--;
    }
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Function Name :     Display
//  Input :             None
//  Output :            Displays list
//  Description :       Displays all elements of singly circular linked list
//  Author :            Prathamesh Rajendra Gavandi
//  Date :              06/01/2026
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
void SinglyCLL<T>::Display()
{
    if ((first == NULL) && (last == NULL))
        return;

    snode<T> *temp = first;
    do
    {
        cout << "|" << temp->data << "|->";
        temp = temp->next;
    } while (temp != first);

    cout << "\n";
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Function Name :     Count
//  Input :             None
//  Output :            Integer
//  Description :       Returns number of nodes in singly circular linked list
//  Author :            Prathamesh Rajendra Gavandi
//  Date :              06/01/2026
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
int SinglyCLL<T>::Count()
{
    return iCount;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Function Name :     Search
//  Input :             Data (Generic)
//  Output :            Boolean
//  Description :       Searches element in singly circular linked list
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

template <class T>
bool SinglyCLL<T>::Search(T no)
{
    if (first == NULL)
        return false;

    snode<T> *temp = first;
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
int SinglyCLL<T>::FirstOcc(T no)
{
    if (first == NULL)
        return -1;

    int pos = 1;
    snode<T> *temp = first;

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
int SinglyCLL<T>::LastOcc(T no)
{
    if (first == NULL)
        return -1;

    int pos = 1, lastpos = -1;
    snode<T> *temp = first;

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
int SinglyCLL<T>::Frequency(T no)
{
    if (first == NULL)
        return 0;

    int cnt = 0;
    snode<T> *temp = first;

    do
    {
        if (temp->data == no)
            cnt++;
        temp = temp->next;
    } while (temp != first);

    return cnt;
}

#endif
