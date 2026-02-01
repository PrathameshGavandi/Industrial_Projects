#include <iostream>
using namespace std;

#include "../include/SinglyLL.h"
#include "../include/Stack.h"
#include "../include/Queue.h"

int main()
{
    SinglyLL<int> sll;
    sll.InsertFirst(10);
    sll.InsertLast(20);
    sll.InsertLast(30);
    sll.Display();

    Stack<int> st;
    st.Push(11);
    st.Push(22);
    st.Push(33);
    st.Display();

    Queue<int> q;
    q.Enqueue(100);
    q.Enqueue(200);
    q.Dequeue();
    q.Display();

    return 0;
}
