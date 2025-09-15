using System;

class Program
{
    // Dictionaries to store student data
    private static Dictionary<string, string> studentNames = new Dictionary<string, string>();
    private static Dictionary<string, Dictionary<string, double>> studentGrades = new Dictionary<string, Dictionary<string, double>>();

    static void Main(string[] args)
    {
        Console.WriteLine("🎓 Welcome to Student Grade Management System 🎓");
        Console.WriteLine("==============================================");
        
        // Main application loop
        bool running = true;
        while (running)
        {
            DisplayMainMenu();
            string choice = Console.ReadLine();

            // Switch statement for menu navigation
            switch (choice)
            {
                case "1":
                    AddStudent();
                    break;
                case "2":
                    AssignGrade();
                    break;
                case "3":
                    DisplayStudents();
                    break;
                case "4":
                    running = false;
                    Console.WriteLine("👋 Thank you for using Student Grade Management System!");
                    break;
                default:
                    Console.WriteLine("❌ Invalid option. Please select 1-4.");
                    break;
            }

            if (running)
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    // Method to display the main menu
    static void DisplayMainMenu()
    {
        Console.WriteLine("\n📋 MAIN MENU");
        Console.WriteLine("=============");
        Console.WriteLine("1. 👤 Add New Student");
        Console.WriteLine("2. 📊 Assign Grade");
        Console.WriteLine("3. 📈 View All Records");
        Console.WriteLine("4. 🔚 Exit Application");
        Console.Write("\nSelect an option (1-4): ");
    }

    // Method to add a new student
    static void AddStudent()
    {
        Console.Clear();
        Console.WriteLine("👤 ADD NEW STUDENT");
        Console.WriteLine("==================");

        // Get student name
        Console.Write("Enter student name: ");
        string name = Console.ReadLine();

        // Validate name input
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("❌ Invalid name. Name cannot be empty.");
            return;
        }

        // Get student ID with validation loop
        string studentId;
        while (true)
        {
            Console.Write("Enter unique student ID: ");
            studentId = Console.ReadLine();

            // Validate ID input
            if (string.IsNullOrWhiteSpace(studentId))
            {
                Console.WriteLine("❌ Invalid ID. ID cannot be empty.");
                continue;
            }

            // Check if ID already exists
            if (studentNames.ContainsKey(studentId))
            {
                Console.WriteLine("⚠️ ID already exists. Please enter a different ID.");
                continue;
            }

            break; // Valid unique ID
        }

        // Create and save new student
        studentNames[studentId] = name;
        studentGrades[studentId] = new Dictionary<string, double>();

        Console.WriteLine($"✅ Student '{name}' with ID '{studentId}' added successfully!");
    }

    // Method to assign a grade to a student
    static void AssignGrade()
    {
        Console.Clear();
        Console.WriteLine("📊 ASSIGN GRADE");
        Console.WriteLine("===============");

        // Check if there are any students
        if (studentNames.Count == 0)
        {
            Console.WriteLine("⚠️ No students found. Please add students first.");
            return;
        }

        // Display available students
        Console.WriteLine("Available Students:");
        foreach (var kvp in studentNames)
        {
            Console.WriteLine($"- ID: {kvp.Key}, Name: {kvp.Value}");
        }

        // Get student ID
        Console.Write("\nEnter student ID: ");
        string studentId = Console.ReadLine();

        // Validate if student exists
        if (!studentNames.ContainsKey(studentId))
        {
            Console.WriteLine("❌ Student not found. Please check the ID and try again.");
            return;
        }

        // Get subject name
        Console.Write("Enter subject name: ");
        string subject = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(subject))
        {
            Console.WriteLine("❌ Invalid subject. Subject cannot be empty.");
            return;
        }

        // Get grade with validation
        double grade;
        while (true)
        {
            Console.Write("Enter grade (0-100): ");
            string gradeInput = Console.ReadLine();

            // Validate grade input
            if (!double.TryParse(gradeInput, out grade))
            {
                Console.WriteLine("❌ Invalid grade format. Please enter a numeric value.");
                continue;
            }

            // Check grade range
            if (grade < 0 || grade > 100)
            {
                Console.WriteLine("❌ Invalid grade range. Grade must be between 0 and 100.");
                continue;
            }

            break; // Valid grade
        }

        // Assign grade to student
        studentGrades[studentId][subject] = grade;

        Console.WriteLine($"✅ Grade {grade} assigned to {studentNames[studentId]} for {subject}!");
    }

    // Method to display all students with their records
    static void DisplayStudents()
    {
        Console.Clear();
        Console.WriteLine("📈 STUDENT RECORDS");
        Console.WriteLine("==================");

        // Check if there are any students
        if (studentNames.Count == 0)
        {
            Console.WriteLine("⚠️ No students found. Please add students first.");
            return;
        }

        // Display each student's information
        foreach (var kvp in studentNames)
        {
            string studentId = kvp.Key;
            string studentName = kvp.Value;
            Console.WriteLine($"\n👤 Student: {studentName} (ID: {studentId})");
            Console.WriteLine("   " + new string('-', 40));

            // Display grades for each subject
            if (studentGrades[studentId].Count == 0)
            {
                Console.WriteLine("   📊 No grades assigned yet.");
            }
            else
            {
                Console.WriteLine("   📊 Grades:");
                foreach (var gradeKvp in studentGrades[studentId])
                {
                    Console.WriteLine($"      • {gradeKvp.Key}: {gradeKvp.Value:F1}");
                }

                // Calculate and display average
                double average = CalculateAverage(studentId);
                Console.WriteLine($"   🧮 Average Grade: {average:F2}");
                
                // Display grade classification
                string classification = GetGradeClassification(average);
                Console.WriteLine($"   🏆 Classification: {classification}");
            }
        }

        // Display summary statistics
        DisplaySummaryStatistics();
    }

    // Method to calculate average grade for a student
    static double CalculateAverage(string studentId)
    {
        if (studentGrades[studentId].Count == 0)
            return 0.0;

        return studentGrades[studentId].Values.Average();
    }

    // Method to get grade classification
    static string GetGradeClassification(double average)
    {
        // Control structure: if-else statements for grade classification
        if (average >= 90)
            return "Excellent (A)";
        else if (average >= 80)
            return "Good (B)";
        else if (average >= 70)
            return "Satisfactory (C)";
        else if (average >= 60)
            return "Needs Improvement (D)";
        else
            return "Failing (F)";
    }

    // Method to display summary statistics
    static void DisplaySummaryStatistics()
    {
        Console.WriteLine("\n📊 SUMMARY STATISTICS");
        Console.WriteLine("=====================");

        // Calculate statistics using loops
        int totalStudents = studentNames.Count;
        int studentsWithGrades = 0;
        double totalAverageSum = 0;

        // For loop to iterate through students and calculate statistics
        foreach (var studentId in studentNames.Keys)
        {
            if (studentGrades[studentId].Count > 0)
            {
                studentsWithGrades++;
                totalAverageSum += CalculateAverage(studentId);
            }
        }

        Console.WriteLine($"Total Students: {totalStudents}");
        Console.WriteLine($"Students with Grades: {studentsWithGrades}");

        if (studentsWithGrades > 0)
        {
            double classAverage = totalAverageSum / studentsWithGrades;
            Console.WriteLine($"Class Average: {classAverage:F2}");
        }
        else
        {
            Console.WriteLine("Class Average: N/A (No grades assigned)");
        }
    }
}