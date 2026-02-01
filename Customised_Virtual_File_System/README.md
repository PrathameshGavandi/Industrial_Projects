# 📁 Customised Virtual File System (CVFS)

---

## 📌 Project Overview
The **Customised Virtual File System (CVFS)** is a system-level project developed in **C** 🧑‍💻 that emulates the core functionalities of a UNIX-like file system 🐧.  
It provides an in-depth understanding of how operating systems internally manage files using data structures such as **Inodes, SuperBlock, UFDT, and File Tables** 🧠.

All file records are maintained in **primary memory (RAM)**, making it a **Virtual File System** ⚙️.

---

## 🛠 Technology Used
- **Programming Language:** C  
- **Domain:** System Programming  
- **Concepts Used:**  
  - File System Internals 📂  
  - Inode Management 🧩  
  - File Descriptor Table (UFDT) 🔗  
  - Memory Management 🧠  
  - Linked List 🔄  

---

## 💻 User Interface
- **Command Line Interface (CLI)** ⌨️

---

## 🖥 Platform Required
- Windows NT 🪟  
- Linux Distributions 🐧  

---

## ⚙ Hardware Requirements
- Intel 32-bit or higher processor  
- Minimum 2 GB RAM  

---

## 📖 Description of the Project
This project simulates the internal working of a UNIX File System 🗂 by implementing all required data structures manually.  
It provides implementations for file-related system calls such as **create, read, write, delete, and list** 🔧 using custom logic instead of built-in OS functions.

The project helps in understanding:
- How files are stored and accessed 📄  
- How file descriptors work 🔍  
- How permissions and offsets are managed internally 🔐  

---

## 🧱 Data Structures Used
- **Boot Block** – Stores booting related information 🚀  
- **Super Block** – Maintains total and free inode information 📊  
- **Inode** – Stores metadata of files 🧾  
- **File Table** – Maintains file offsets and access mode 🧮  
- **UFDT (User File Descriptor Table)** – Maps file descriptors to files 🔗  
- **Linked List (DILB)** – Manages inode list 🔄  

---

## 🧩 Data Structure Diagrams
Refer to the `diagrams/` folder 📁 for:
- Inode Structure Diagram  
- UFDT Flow Diagram  
- Read / Write Operation Flow  

---

## 🔄 Flow of the Project
1. Initialize BootBlock, SuperBlock, UAREA, and DILB ⚙️  
2. Accept commands from the user ⌨️  
3. Validate command parameters ✅  
4. Perform requested file operation 🔧  
5. Update inode, file table, and UFDT 🔄  
6. Display output or error message 📤  

---

## 📂 Supported Commands

| Command | Description |
|------|------------|
| `creat <filename> <permission>` | Create a new file 📄 |
| `write <fd>` | Write data into a file ✍️ |
| `read <fd> <size>` | Read data from a file 📖 |
| `ls` | List all files 📃 |
| `unlink <filename>` | Delete a file ❌ |
| `man <command>` | Display command manual 📘 |
| `help` | Display help menu 🆘 |
| `clear` | Clear terminal 🧹 |
| `exit` | Exit CVFS 🚪 |

---

## 📸 Output Screenshots
Screenshots demonstrating all features are available in the `screenshots/` folder 📷:
- File creation  
- Writing data  
- Reading data  
- Listing files  
- File deletion  
- Error handling ⚠️  

---

## ⚠ Limitations
- No persistent storage (RAM-based)  
- Single-user simulation  

---

## 🚀 Future Enhancements
- Persistent storage using disk files 💾  
- Directory and sub-directory support 📁  
- File permission bits (rwx) 🔐  
- Multi-process simulation 🧵  
- File seek (lseek) implementation ⏩  

---

## 🎯 Learning Outcomes
- Deep understanding of UNIX File System internals 🐧  
- Hands-on experience with system-level programming 🧑‍💻  
- Practical knowledge of memory and pointer management 🧠  
- Designing scalable data structures 📐  

---

## 👨‍💻 Author
**Prathamesh Rajendra Gavandi**  
📅 January 2026  

---

## ⭐ Conclusion
This project strengthened my understanding of how operating systems manage files internally 🖥.  
Instead of using built-in system calls, I implemented the complete logic manually, which provided strong fundamentals in **System Programming and OS concepts** 💡.
