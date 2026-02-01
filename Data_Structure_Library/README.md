# 📚 Data Structure Library 🚀

**Data Structure Library** is a generic, **header-only C++ template library** that provides clean, reusable, and interview-ready implementations of fundamental data structures.

This project is designed for **learning, academic use, competitive programming, and real-world C++ applications**, with a strong focus on clarity, reusability, and performance.

---

## 🎯 Project Overview

The Data Structure Library focuses on:

- Generic implementations using **C++ Templates**
- Clean and modular **header-only design**
- Core data structures commonly asked in **interviews**
- Easy integration into any **C++ project**
- Well-structured and readable codebase

---

## 🧩 Data Structures Implemented

### 🔗 Linked Lists
- Singly Linear Linked List  
- Singly Circular Linked List  
- Doubly Linear Linked List  
- Doubly Circular Linked List  

### 📚 Stack
- Stack implementation using Singly Linked List  
- Supported operations:
  - Push
  - Pop
  - Display
  - Count  

### 📥 Queue
- Queue implementation using Singly Linked List  
- Supported operations:
  - Enqueue
  - Dequeue
  - Display
  - Count  

---

## 📂 Project Structure

Data_Structure_Library/
│
├── include/
│ ├── SinglyLL.h # Singly Linear Linked List
│ ├── SinglyCLL.h # Singly Circular Linked List
│ ├── DoublyLL.h # Doubly Linear Linked List
│ ├── DoublyCLL.h # Doubly Circular Linked List
│ ├── Stack.h # Stack using Linked List
│ └── Queue.h # Queue using Linked List
│
|── src/
| ├── main.cpp
|
└── README.md


---

## 🚀 How to Use

### 1️⃣ Include Required Header Files

#include "SinglyLL.h"
#include "Stack.h"
#include "Queue.h"

2️⃣ Create Objects Using Templates
SinglyLL<int> sll;
Stack<int> st;
Queue<int> q;

3️⃣ Perform Operations
sll.InsertFirst(10);
sll.InsertLast(20);
sll.Display();

st.Push(100);
st.Pop();

q.Enqueue(50);
q.Dequeue();


🛠️ Technologies Used :
💻 Language

C++

🧠 Concepts :

Templates

Pointers

Object-Oriented Programming (OOP)

🧰 Tools :

GCC (g++)

Visual Studio Code

Git & GitHub

🎓 Learning Outcomes :

Strong understanding of Data Structures

Practical hands-on experience with C++ Templates

Writing clean and reusable header-only libraries

Interview-ready implementations

Improved problem-solving skills

🔮 Future Enhancements :

Binary Search Tree (BST)

Heap (Min Heap & Max Heap)

Graph Data Structures

Exception handling and validations

Unit testing support

👨‍💻 Developer Information :

Name: Prathamesh Gavandi
Role: Software / Full-Stack Developer
Education: M.Sc. Computer Science (Second Year – 2025)
Experience: 1 Year Industry Experience

📍 Pune, Maharashtra
🔗 GitHub: https://github.com/PrathameshGavandi
