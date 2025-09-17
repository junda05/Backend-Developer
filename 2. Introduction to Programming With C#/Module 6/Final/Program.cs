using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagementSystem
{
    // Book class to represent each book in the library
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsCheckedOut { get; set; }
        public string? BorrowedBy { get; set; }

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
            IsCheckedOut = false;
            BorrowedBy = null;
        }

        public override string ToString()
        {
            string status = IsCheckedOut ? $" (Checked out by {BorrowedBy})" : " (Available)";
            return $"{Title} by {Author}{status}";
        }
    }

    // User class to track borrowing information
    public class User
    {
        public string Name { get; set; }
        public List<Book> BorrowedBooks { get; set; }
        public int MaxBorrowLimit { get; } = 3;

        public User(string name)
        {
            Name = name;
            BorrowedBooks = new List<Book>();
        }

        public bool CanBorrowMore()
        {
            return BorrowedBooks.Count < MaxBorrowLimit;
        }

        public int RemainingBorrowSlots()
        {
            return MaxBorrowLimit - BorrowedBooks.Count;
        }
    }

    // Library class to manage the collection and operations
    public class Library
    {
        private List<Book> books;
        private List<User> users;

        public Library()
        {
            books = new List<Book>();
            users = new List<User>();
            InitializeLibrary();
        }

        private void InitializeLibrary()
        {
            // Add some sample books
            books.Add(new Book("The Great Gatsby", "F. Scott Fitzgerald"));
            books.Add(new Book("To Kill a Mockingbird", "Harper Lee"));
            books.Add(new Book("1984", "George Orwell"));
            books.Add(new Book("Pride and Prejudice", "Jane Austen"));
            books.Add(new Book("The Catcher in the Rye", "J.D. Salinger"));
            books.Add(new Book("Lord of the Flies", "William Golding"));
            books.Add(new Book("Animal Farm", "George Orwell"));
            books.Add(new Book("Brave New World", "Aldous Huxley"));

            // Add some sample users
            users.Add(new User("Alice Johnson"));
            users.Add(new User("Bob Smith"));
            users.Add(new User("Charlie Brown"));
        }

        // Search feature - requirement 1 (5pts)
        public void SearchBook()
        {
            Console.Write("Enter the title of the book to search for: ");
            string? searchTitle = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(searchTitle))
            {
                Console.WriteLine("Please enter a valid book title.");
                return;
            }

            Book? foundBook = books.FirstOrDefault(b => 
                b.Title.Equals(searchTitle.Trim(), StringComparison.OrdinalIgnoreCase));

            if (foundBook != null)
            {
                if (foundBook.IsCheckedOut)
                {
                    Console.WriteLine($"The book '{foundBook.Title}' is in our collection but is currently checked out by {foundBook.BorrowedBy}.");
                }
                else
                {
                    Console.WriteLine($"The book '{foundBook.Title}' is available in our collection!");
                }
            }
            else
            {
                Console.WriteLine($"Sorry, the book '{searchTitle}' is not in our collection.");
            }
        }

        // Borrowing limit feature - requirement 2 (5pts)
        public void BorrowBook()
        {
            Console.WriteLine("Available users:");
            for (int i = 0; i < users.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {users[i].Name} (Books borrowed: {users[i].BorrowedBooks.Count}/{users[i].MaxBorrowLimit})");
            }

            Console.Write("Select a user (enter number): ");
            if (!int.TryParse(Console.ReadLine(), out int userChoice) || 
                userChoice < 1 || userChoice > users.Count)
            {
                Console.WriteLine("Invalid user selection.");
                return;
            }

            User selectedUser = users[userChoice - 1];

            if (!selectedUser.CanBorrowMore())
            {
                Console.WriteLine($"{selectedUser.Name} has reached the borrowing limit of {selectedUser.MaxBorrowLimit} books.");
                Console.WriteLine("Please return some books before borrowing more.");
                return;
            }

            Console.WriteLine("Available books:");
            var availableBooks = books.Where(b => !b.IsCheckedOut).ToList();
            
            if (availableBooks.Count == 0)
            {
                Console.WriteLine("No books are currently available for borrowing.");
                return;
            }

            for (int i = 0; i < availableBooks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {availableBooks[i].Title} by {availableBooks[i].Author}");
            }

            Console.Write("Select a book to borrow (enter number): ");
            if (!int.TryParse(Console.ReadLine(), out int bookChoice) || 
                bookChoice < 1 || bookChoice > availableBooks.Count)
            {
                Console.WriteLine("Invalid book selection.");
                return;
            }

            Book selectedBook = availableBooks[bookChoice - 1];
            
            // Check out the book
            selectedBook.IsCheckedOut = true;
            selectedBook.BorrowedBy = selectedUser.Name;
            selectedUser.BorrowedBooks.Add(selectedBook);

            Console.WriteLine($"Successfully borrowed '{selectedBook.Title}' for {selectedUser.Name}.");
            Console.WriteLine($"{selectedUser.Name} can borrow {selectedUser.RemainingBorrowSlots()} more book(s).");
        }

        // Checkout/Checkin feature - requirement 3 (5pts)
        public void ReturnBook()
        {
            Console.WriteLine("Users with borrowed books:");
            var usersWithBooks = users.Where(u => u.BorrowedBooks.Count > 0).ToList();
            
            if (usersWithBooks.Count == 0)
            {
                Console.WriteLine("No users currently have borrowed books.");
                return;
            }

            for (int i = 0; i < usersWithBooks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {usersWithBooks[i].Name} ({usersWithBooks[i].BorrowedBooks.Count} books)");
            }

            Console.Write("Select a user (enter number): ");
            if (!int.TryParse(Console.ReadLine(), out int userChoice) || 
                userChoice < 1 || userChoice > usersWithBooks.Count)
            {
                Console.WriteLine("Invalid user selection.");
                return;
            }

            User selectedUser = usersWithBooks[userChoice - 1];

            Console.WriteLine($"Books borrowed by {selectedUser.Name}:");
            for (int i = 0; i < selectedUser.BorrowedBooks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {selectedUser.BorrowedBooks[i].Title} by {selectedUser.BorrowedBooks[i].Author}");
            }

            Console.Write("Select a book to return (enter number): ");
            if (!int.TryParse(Console.ReadLine(), out int bookChoice) || 
                bookChoice < 1 || bookChoice > selectedUser.BorrowedBooks.Count)
            {
                Console.WriteLine("Invalid book selection.");
                return;
            }

            Book bookToReturn = selectedUser.BorrowedBooks[bookChoice - 1];
            
            // Check the book back in - remove the checked-out flag
            bookToReturn.IsCheckedOut = false;
            bookToReturn.BorrowedBy = null;
            selectedUser.BorrowedBooks.Remove(bookToReturn);

            Console.WriteLine($"Successfully returned '{bookToReturn.Title}' from {selectedUser.Name}.");
            Console.WriteLine($"{selectedUser.Name} can now borrow {selectedUser.RemainingBorrowSlots()} more book(s).");
        }

        public void DisplayAllBooks()
        {
            Console.WriteLine("\nAll books in the library:");
            Console.WriteLine("========================");
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }

        public void DisplayBorrowingSummary()
        {
            Console.WriteLine("\nBorrowing Summary:");
            Console.WriteLine("==================");
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Name}: {user.BorrowedBooks.Count}/{user.MaxBorrowLimit} books borrowed");
                if (user.BorrowedBooks.Count > 0)
                {
                    foreach (var book in user.BorrowedBooks)
                    {
                        Console.WriteLine($"  - {book.Title}");
                    }
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            bool running = true;

            Console.WriteLine("Welcome to the Library Management System!");
            Console.WriteLine("========================================");

            while (running)
            {
                Console.WriteLine("\nPlease select an option:");
                Console.WriteLine("1. Search for a book");
                Console.WriteLine("2. Borrow a book");
                Console.WriteLine("3. Return a book");
                Console.WriteLine("4. Display all books");
                Console.WriteLine("5. Display borrowing summary");
                Console.WriteLine("6. Exit");
                Console.Write("\nEnter your choice (1-6): ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        library.SearchBook();
                        break;
                    case "2":
                        library.BorrowBook();
                        break;
                    case "3":
                        library.ReturnBook();
                        break;
                    case "4":
                        library.DisplayAllBooks();
                        break;
                    case "5":
                        library.DisplayBorrowingSummary();
                        break;
                    case "6":
                        running = false;
                        Console.WriteLine("Thank you for using the Library Management System. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                        break;
                }

                if (running)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine("Library Management System");
                    Console.WriteLine("========================");
                }
            }
        }
    }
}
