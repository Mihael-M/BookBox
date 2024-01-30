using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBox.Model;
using Microsoft.EntityFrameworkCore;

namespace BookBox.Controller
{
    public class BookControllers
    {
        private BookContext bookContext;
        private BookContext usercontext;

        public BookControllers(BookContext bookContext )
        {
            this.bookContext = bookContext;
           
        }
        public BookControllers()
        {
            bookContext = new BookContext();

        }

        public List<Book> GetAllbooks() //returns all books
        {
            using (bookContext = new BookContext())
            {
                return bookContext.book.ToList();
            }
        }
        public void Add(Book book) //adds books
        {
            using (bookContext = new BookContext())
            {
                bookContext.book.Add(book);
                bookContext.SaveChanges();
            }
        }
        public void Delete(int id) //deletes a book by Id
        {
            using (bookContext = new BookContext())
            {
                var book = bookContext.book.Where(x => x.Id == id).First();
                if (book != null)
                {
                    bookContext.book.Remove(book);
                    bookContext.SaveChanges();
                }
            }
        }
        public Book Get(int Id)
        {
            using (bookContext = new BookContext())
            {
                return bookContext.book.Find(Id);
            }
        }
        public Book GetAuthor(string Author)
        {
            using (bookContext = new BookContext())
            {
                return bookContext.book.FirstOrDefault(book => book.Author == Author);
            }
        }
        public Book GetName(string Name)
        {
            using (bookContext = new BookContext())
            {
                return bookContext.book.SingleOrDefault(book => book.Name == Name);
            }
        }
        public void AddUser(User user) //adds user
        {
            using (usercontext = new BookContext())
            {
                usercontext.user.Add(user);
                usercontext.SaveChanges();
            }
        }
        public User GetUsername(string Username)
        {
            using (usercontext = new BookContext())
            {
                return usercontext.user.SingleOrDefault(user => user.Username == Username);
            }
        }
        public User GetPassword(string Password)
        {
            using (usercontext = new BookContext())
            {
                return usercontext.user.SingleOrDefault(user => user.Password == Password);
            }
        }
        public User GetMail(string E_mail)
        {
            using (usercontext = new BookContext())
            {
                return usercontext.user.SingleOrDefault(user => user.E_mail == E_mail);
            }
        }
    }
}
