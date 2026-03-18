import java.util.*;
import java.time.LocalDate;
import java.io.*;

// Model Class
class StudyLog
{
    private LocalDate date;
    private String subject;
    private double duration;
    private String description;

    public StudyLog(LocalDate date, String subject, double duration, String description)
    {
        this.date = date;
        this.subject = subject;
        this.duration = duration;
        this.description = description;
    }

    public LocalDate getDate()
    {
        return date;
    }

    public String getSubject()
    {
        return subject;
    }

    public double getDuration()
    {
        return duration;
    }

    public String getDescription()
    {
        return description;
    }

    @Override
    public String toString()
    {
        return date + " | " + subject + " | " + duration + " hrs | " + description;
    }
}

// Service Class
class StudyTrackerService
{
    private ArrayList<StudyLog> database = new ArrayList<>();

    public void insertLog(Scanner sc)
    {
        System.out.println("\n--- Enter Study Details ---");

        LocalDate date = LocalDate.now();

        System.out.print("Enter subject: ");
        String subject = sc.nextLine().trim();

        if(subject.isEmpty())
        {
            System.out.println("❌ Subject cannot be empty!");
            return;
        }

        System.out.print("Enter duration (hours): ");
        if(!sc.hasNextDouble())
        {
            System.out.println("❌ Invalid input!");
            sc.nextLine();
            return;
        }

        double duration = sc.nextDouble();
        sc.nextLine();

        if(duration <= 0)
        {
            System.out.println("❌ Duration must be greater than 0!");
            return;
        }

        System.out.print("Enter description: ");
        String desc = sc.nextLine();

        StudyLog log = new StudyLog(date, subject, duration, desc);
        database.add(log);

        System.out.println("✅ Study log added successfully!");
    }

    public void displayLogs()
    {
        System.out.println("\n--- Study Logs ---");

        if(database.isEmpty())
        {
            System.out.println("❌ No data available.");
            return;
        }

        for(StudyLog s : database)
        {
            System.out.println(s);
        }
    }

    public void exportCSV()
    {
        if(database.isEmpty())
        {
            System.out.println("❌ No data to export.");
            return;
        }

        try(FileWriter fw = new FileWriter("StudyTracker.csv"))
        {
            fw.write("Date,Subject,Duration,Description\n");

            for(StudyLog s : database)
            {
                fw.write(s.getDate() + "," +
                         s.getSubject().replace(",", " ") + "," +
                         s.getDuration() + "," +
                         s.getDescription().replace(",", " ") + "\n");
            }

            System.out.println("✅ CSV exported successfully! File: StudyTracker.csv");
        }
        catch(IOException e)
        {
            System.out.println("❌ Error while exporting CSV file.");
        }
    }

    public void summaryByDate()
    {
        if(database.isEmpty())
        {
            System.out.println("❌ No data available.");
            return;
        }

        TreeMap<LocalDate, Double> map = new TreeMap<>();

        for(StudyLog s : database)
        {
            map.put(s.getDate(),
                    map.getOrDefault(s.getDate(), 0.0) + s.getDuration());
        }

        System.out.println("\n--- Summary By Date ---");
        for(LocalDate d : map.keySet())
        {
            System.out.println("Date: " + d + " | Total Hours: " + map.get(d));
        }
    }

    public void summaryBySubject()
    {
        if(database.isEmpty())
        {
            System.out.println("❌ No data available.");
            return;
        }

        TreeMap<String, Double> map = new TreeMap<>();

        for(StudyLog s : database)
        {
            map.put(s.getSubject(),
                    map.getOrDefault(s.getSubject(), 0.0) + s.getDuration());
        }

        System.out.println("\n--- Summary By Subject ---");
        for(String sub : map.keySet())
        {
            System.out.println("Subject: " + sub + " | Total Hours: " + map.get(sub));
        }
    }
}

// Main Class
public class StudyTracker
{
    public static void main(String[] args)
    {
        Scanner sc = new Scanner(System.in);
        StudyTrackerService tracker = new StudyTrackerService();

        int choice = 0;

        do
        {
            System.out.println("\n===== Study Tracker =====");
            System.out.println("1. Add Study Log");
            System.out.println("2. View Logs");
            System.out.println("3. Export CSV");
            System.out.println("4. Summary by Date");
            System.out.println("5. Summary by Subject");
            System.out.println("6. Exit");
            System.out.print("Enter choice: ");

            if(!sc.hasNextInt())
            {
                System.out.println("❌ Please enter valid number!");
                sc.nextLine();
                continue;
            }

            choice = sc.nextInt();
            sc.nextLine();

            switch(choice)
            {
                case 1:
                    tracker.insertLog(sc);
                    break;
                case 2:
                    tracker.displayLogs();
                    break;
                case 3:
                    tracker.exportCSV();
                    break;
                case 4:
                    tracker.summaryByDate();
                    break;
                case 5:
                    tracker.summaryBySubject();
                    break;
                case 6:
                    System.out.println("🙏 Thank you for using Study Tracker!");
                    break;
                default:
                    System.out.println("❌ Invalid choice!");
            }

        } while(choice != 6);

        sc.close();
    }
}