# 📚 Study Tracker

Study Tracker is a Java-based console application that helps users track their daily study activities. It allows users to record study sessions, view logs, generate summaries, and export data into CSV format for better analysis and productivity tracking.

---

## 🎯 Project Overview

The system is designed to:

* Track daily study activities
* Maintain subject-wise study records
* Generate summaries based on date and subject
* Export study logs into CSV format
* Provide a simple and user-friendly console interface

---

## 📋 Features

* ➕ Add new study log
* 📄 View all study logs
* 📊 Summary by date
* 📚 Summary by subject
* 📁 Export data to CSV file
* ❌ Exit application

---

## 🧩 Functional Modules

### 🔹 Study Log Module

* Stores study details such as:

  * Date
  * Subject
  * Duration
  * Description

---

### 🔹 Study Tracker Module

* Manages study logs using Java Collections (`ArrayList`)
* Provides core functionalities like insert, display, export, and summary

---

### 🔹 Summary Module

* Generates grouped data using `TreeMap`
* Displays:

  * Total study hours per date
  * Total study hours per subject

---

### 🔹 File Handling Module

* Exports study data into CSV format
* Uses `FileWriter` for file operations

---

## 🛠️ Technologies Used

* Java
* Java Collections Framework (`ArrayList`, `TreeMap`)
* File Handling (`FileWriter`)
* Java Time API (`LocalDate`)

---

## ⚙️ How to Run

1. Compile the program:

```
javac StudyTracker.java
```

2. Run the program:

```
java StudyTracker
```

---

## 📌 Sample Menu

```
1. Add Study Log
2. View Logs
3. Export CSV
4. Summary by Date
5. Summary by Subject
6. Exit
```

---

## 📊 Output

* Displays study logs in structured format
* Generates CSV file: `StudyTracker.csv`
* Shows summary reports by date and subject

---

## 🚀 Future Enhancements

* GUI version using JavaFX or Swing
* Database integration (MySQL / MongoDB)
* User authentication system
* Weekly and monthly analytics

---

## 👨‍💻 Developer

**Name:** Prathamesh Rajendra Gavandi
**Role:** Full-Stack Developer

**Education:**
M.Sc. Computer Science (2nd year – 2026)

**Experience:**
1 Year Industry Experience

📍 Sangli, Maharashtra

---

⭐ If you like this project, don’t forget to star the repository!
