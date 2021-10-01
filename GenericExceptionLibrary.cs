using System;
using System.Collections.Generic;
using System.Linq;
//write a program to issue a book from library, to enter the library you need to be a student of the class (need to verify using some roll no etc.)
//but you can only issue one book at a time. give the details of student after the book is issued.
//*Use exception handling to show the error message  use generic class

namespace GenericExceptionLibrary
{
    public class Book
    {
        public string BookName { get; private set; }
        public Book(string name)
        {
            BookName = name;
        }
    }
    public class Student
    {
        public string Name { get; private set; }
        private IList<Book> _bookIssued;
        public IList<Book> BookIssued
        {
            get
            {
                if (_bookIssued == null)
                    _bookIssued = new List<Book>();
                return _bookIssued;
            }
            private set
            {
                _bookIssued = value;
            }
        }
        public Student(string name)
        {
            Name = name;
        }
    }
    public class Collection<Tstudents>
    {
        private IList<Tstudents> _collection;
        public IList<Tstudents> CollectionObj
        {
            get
            {
                if (_collection == null)
                    _collection = new List<Tstudents>();
                return _collection;
            }
            private set
            {
                _collection = value;
            }
        }
        public void addCollection(Tstudents item)
        {
            CollectionObj.Add(item);
        }
        public void removeCollection(Tstudents item)
        {
            CollectionObj.Remove(item);
        }
        public Tstudents this[int index]
        {
            get { return CollectionObj[index]; }
            set { CollectionObj[index] = value; }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Collection<Student> listStudents = new Collection<Student>();
            Collection<Book> listBooks = new Collection<Book>();

            bool loop = true;
            while (loop)
            {
                Console.WriteLine("--Generic Exception Library--");
                Console.WriteLine("1. Issue book");
                Console.WriteLine("2. Add student");
                Console.WriteLine("3. Add book");
                Console.WriteLine("4. List all students");
                Console.WriteLine("5. List all available books");
                Console.WriteLine("6. Exit");
                int input = Int32.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        {
                            Console.WriteLine("Enter your name:");
                            string yourName = Console.ReadLine();
                            Student studentObj = null;
                            foreach (Student std in listStudents.CollectionObj)
                            {
                                if (string.Equals(yourName, std.Name))
                                {
                                    studentObj = std;
                                }
                            }
                            if (studentObj != null)
                            {
                                Console.WriteLine("Select book to borrow:");
                                foreach (Book bk in listBooks.CollectionObj)
                                {
                                    Console.WriteLine(listBooks.CollectionObj.IndexOf(bk) + 1 + ". " + bk.BookName);
                                }
                                int bookSelect = Int32.Parse(Console.ReadLine());
                                studentObj.BookIssued.Add(listBooks[bookSelect - 1]);
                                listBooks.removeCollection(listBooks[bookSelect - 1]);
                            }
                            else
                            {
                                Console.WriteLine(yourName + " does not exist.");
                            }
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Enter student name:");
                            string studentName = Console.ReadLine();
                            listStudents.addCollection(new Student(studentName));
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Enter book name:");
                            string bookName = Console.ReadLine();
                            listBooks.addCollection(new Book(bookName));
                            break;
                        }
                    case 4:
                        {
                            foreach (var std in listStudents.CollectionObj)
                            {
                                Console.WriteLine(std.Name);
                                foreach (Book bk in std.BookIssued)
                                {
                                    Console.WriteLine("Books Issued: " + bk.BookName + "\n");
                                }

                            }
                            break;
                        }
                    case 5:
                        {
                            foreach (var book in listBooks.CollectionObj)
                            {
                                Console.WriteLine(book.BookName);
                            }
                            break;
                        }
                }
            }
        }
    }
}

