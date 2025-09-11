using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentGradeManagement
{
    // Class to represent a student
    public class Student
    {
        public string Name { get; set; }
        public string StudentId { get; set; }
        public Dictionary<string, double> Grades { get; set; }

        public Student(string name, string studentId)
        {
            Name = name;
            StudentId = studentId;
            Grades = new Dictionary<string, double>();
        }

        public double CalculateAverage()
        {
            if (Grades.Count == 0)
                return 0.0;

            return Grades.Values.Average();
        }
    }

    class Program
    {
        // Dictionary to store all students (StudentId -> Student)
        private static Dictionary<string, Student> students = new Dictionary<string, Student>();

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
                if (students.ContainsKey(studentId))
                {
                    Console.WriteLine("⚠️ ID already exists. Please enter a different ID.");
                    continue;
                }

                break; // Valid unique ID
            }

            // Create and save new student
            Student newStudent = new Student(name, studentId);
            students[studentId] = newStudent;

            Console.WriteLine($"✅ Student '{name}' with ID '{studentId}' added successfully!");
        }

        // Method to assign a grade to a student
        static void AssignGrade()
        {
            Console.Clear();
            Console.WriteLine("📊 ASSIGN GRADE");
            Console.WriteLine("===============");

            // Check if there are any students
            if (students.Count == 0)
            {
                Console.WriteLine("⚠️ No students found. Please add students first.");
                return;
            }

            // Display available students
            Console.WriteLine("Available Students:");
            foreach (var kvp in students)
            {
                Console.WriteLine($"- ID: {kvp.Key}, Name: {kvp.Value.Name}");
            }

            // Get student ID
            Console.Write("\nEnter student ID: ");
            string studentId = Console.ReadLine();

            // Validate if student exists
            if (!students.ContainsKey(studentId))
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
            students[studentId].Grades[subject] = grade;

            Console.WriteLine($"✅ Grade {grade} assigned to {students[studentId].Name} for {subject}!");
        }

        // Method to display all students with their records
        static void DisplayStudents()
        {
            Console.Clear();
            Console.WriteLine("📈 STUDENT RECORDS");
            Console.WriteLine("==================");

            // Check if there are any students
            if (students.Count == 0)
            {
                Console.WriteLine("⚠️ No students found. Please add students first.");
                return;
            }

            // Display each student's information
            foreach (var kvp in students)
            {
                Student student = kvp.Value;
                Console.WriteLine($"\n👤 Student: {student.Name} (ID: {student.StudentId})");
                Console.WriteLine("   " + new string('-', 40));

                // Display grades for each subject
                if (student.Grades.Count == 0)
                {
                    Console.WriteLine("   📊 No grades assigned yet.");
                }
                else
                {
                    Console.WriteLine("   📊 Grades:");
                    foreach (var gradeKvp in student.Grades)
                    {
                        Console.WriteLine($"      • {gradeKvp.Key}: {gradeKvp.Value:F1}");
                    }

                    // Calculate and display average
                    double average = CalculateAverage(student);
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
        static double CalculateAverage(Student student)
        {
            return student.CalculateAverage();
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
            int totalStudents = students.Count;
            int studentsWithGrades = 0;
            double totalAverageSum = 0;

            // For loop to iterate through students and calculate statistics
            foreach (var student in students.Values)
            {
                if (student.Grades.Count > 0)
                {
                    studentsWithGrades++;
                    totalAverageSum += student.CalculateAverage();
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
}