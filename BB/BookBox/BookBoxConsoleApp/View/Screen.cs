using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBox.Controller;
using BookBox.Model;
using Microsoft.EntityFrameworkCore;

namespace BookBoxConsoleApp.View
{
    public class Screen
    {
        private int closeOperationId = 7;
        private BookControllers bookControllers;
        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "BOOK MENU" + new string(' ', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all books");
            Console.WriteLine("2. Add new book");
            Console.WriteLine("3. Fetch book by Id");
            Console.WriteLine("4. Delete book by Id");
            Console.WriteLine("5. Search book by Author");
            Console.WriteLine("6. Search book by Name");
            Console.WriteLine("7. Exit");
        }
        private void Input()
        {
            var operation = -1;
            do
            {
                ShowMenu();
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1:
                        GetAll();
                        break;
                    case 2:
                        Add();
                        break;
                    case 3:
                        Search();
                        break;
                    case 4:
                        Delete();
                        break;
                    case 5:
                        SearchByAuthor();
                        break;
                    case 6:
                        SearchByName();
                        break;
                    case 7:
                        System.Environment.Exit(1);
                        break;
                    default:
                         break;
                      
                    
                } 
            }
            while (operation != closeOperationId);
        }
        public Screen()
        {
            bookControllers = new BookControllers();
            Input();
        }
        private void GetAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "Books" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var books = bookControllers.GetAllbooks();
            foreach (var book in books)
            {


                if (book.Name == null)
                {
                    Console.WriteLine($"{book.Id} - Taken");
                }
                else Console.WriteLine($"{book.Id} - {book.Name}, {book.Author}");
            }
            Console.WriteLine(new string('-', 40));
        }
        private void Add() //recieves information and add a book to the database
        {

            //Name
            Book book = new Book();
            Console.WriteLine("Enter name: ");
            book.Name = Console.ReadLine();
            Console.WriteLine("Enter author: ");
            book.Author = Console.ReadLine();
            bookControllers.Add(book);
        }
        private void Search() //Gets the id of the book
        {
            Console.WriteLine("Enter Id to search: ");
            int id = int.Parse(Console.ReadLine());
            var book = bookControllers.Get(id);
            if (book != null)
            {

                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + book.Id);
                Console.WriteLine("Name: " + book.Name);
                Console.WriteLine("Author: " + book.Author);
                Console.WriteLine(new string('-', 40));

            }
            else
            {
                Console.WriteLine("Book not found!");
            }
        }
        private void SearchByAuthor() //Gets the author of the book
        {
            Console.WriteLine("Enter Author to search: ");
            string author = Console.ReadLine();
            var book = bookControllers.GetAuthor(author);
            if (book != null)
            {

                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + book.Id);
                Console.WriteLine("Name: " + book.Name);
                Console.WriteLine("Author: " + book.Author);
                Console.WriteLine(new string('-', 40));

            }
            else
            {
                Console.WriteLine("Author not found!");
            }
        }
        private void SearchByName() //Gets the author of the book
        {
            Console.WriteLine("Enter Name to search: ");
            string name = Console.ReadLine();
            var book = bookControllers.GetName(name);
            if (book != null)
            {

                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + book.Id);
                Console.WriteLine("Name: " + book.Name);
                Console.WriteLine("Author: " + book.Author);
                Console.WriteLine(new string('-', 40));

            }
            else
            {
                Console.WriteLine("Name not found!");
            }
        }
        private void Delete() //deletes the information for the book
        {
            Console.WriteLine("Enter Id to take: ");
            int id = int.Parse(Console.ReadLine());
            bookControllers.Delete(id);
            Console.WriteLine("Done.");
        }
    }
}
