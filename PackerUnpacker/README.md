📦 Customized File Packer–Unpacker (Java)

📌 Project Overview  
Customized File Packer–Unpacker is a Java-based system level application that packs multiple `.txt` files from a directory into a single packed file and later restores them to their original form using an unpacking process.

This project demonstrates low-level file handling, fixed-size header design, and basic encryption techniques without using built-in compression or archive libraries.

---

✨ Key Features  
• Packs multiple `.txt` files into a single file  
• Uses fixed-size (100 bytes) file header  
• Supports XOR-based encryption and decryption  
• Console User Interface (CUI) and GUI (Swing) versions  
• Platform independent application  

---

🛠 Technologies Used  
Programming Language: Java  

Core Concepts:  
• File Handling (FileInputStream, FileOutputStream)  
• Binary File Processing  
• Fixed Header File Design  
• XOR Encryption and Decryption  
• GUI Development using Java Swing  

---

🧠 Packing Logic  
1. User provides folder name and packed file name  
2. Application scans the folder for `.txt` files  
3. For each file:  
   • A 100-byte header is created containing:  
     - File Name  
     - File Size  
   • Header is written to the packed file  
   • File data is encrypted using XOR key (0x11)  
   • Encrypted data is written to the packed file  

📦 Packed File Format:  
[100 Bytes Header]  
[Encrypted File Data]  

---

🔓 Unpacking Logic  
1. User provides packed file name  
2. Application reads 100 bytes header  
3. Extracts file name and file size from header  
4. Reads encrypted data based on file size  
5. Decrypts data using the same XOR key  
6. Recreates the original file  

---

🔐 Encryption Logic  
The project uses XOR encryption for securing file data.

Encryption Formula:  
EncryptedByte = OriginalByte ^ Key  

Decryption Formula:  
OriginalByte = EncryptedByte ^ Key  

Since XOR is reversible:  
(A ^ B) ^ B = A  

The same key is used for both encryption and decryption.

---

▶️ How to Run (CUI)

Compile:  
javac Packer.java  
javac Unpacker.java  

Run:  
java Packer  
java Unpacker  

---

🖥 GUI Version  
The GUI version provides:  
• Folder selection using Browse button  
• One-click file packing  
• Real-time status logs  

Run GUI:  
javac PackerGUI.java  
java PackerGUI  

---

⚠ Limitations  
• Supports only `.txt` files  
• XOR encryption is basic (educational purpose)  
• No compression mechanism  
• Sub-directory packing is not supported  

---

🚀 Future Enhancements  
• Support for all file types  
• File compression support  
• Strong encryption algorithms (AES)  
• Unified GUI for packing and unpacking  
• Custom packed file extension  

---

🎯 Learning Outcomes  
• In-depth understanding of Java file handling  
• Binary file format design  
• Encryption and decryption fundamentals  
• System-level programming concepts  
• GUI application development  

---

👨‍💻 Author  
Prathamesh Rajendra Gavandi  
January 2026  

---

⭐ Conclusion  
This project demonstrates how multiple files can be packed into a single file using custom logic without relying on standard archiving tools. It is useful for understanding low-level file operations, encryption concepts, and system programming using Java.
