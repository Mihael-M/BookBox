using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookBox.Model;
using BookBox.Controller;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace BookTest.Test
{
    public class UnitTest1
    {
        [TestCase]
        public void Gives_All_Books()
        {
            var data = new List<Book>
            {
                new Book { Name="First" },
                new Book { Name="Second" },
                new Book { Name="Third" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Book>>();
            mockSet.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<BookContext>();
            mockContext.Setup(c => c.book).Returns(mockSet.Object);
            var controllers = new BookControllers(mockContext.Object);
            var Books = controllers.GetAllbooks();

            Assert.AreEqual(3, Books.Count);
            Assert.AreEqual("First", Books[0].Name);
            Assert.AreEqual("Second",Books[1].Name);
            Assert.AreEqual("Third", Books[2].Name);
        }
        [TestCase]
        public void Add_Book()
        {
            var mockSet = new Mock<DbSet<Book>>();
            var book = new Book();
            var mockContext = new Mock<BookContext>();
            mockContext.Setup(m => m.book).Returns(mockSet.Object);

            var controller = new BookControllers(mockContext.Object);
            controller.Add(book);

            mockSet.Verify(m => m.Add(It.IsAny<Book>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
        [TestCase]
        public void Remove_Book()
        {
            var data = new List<Book>()
            {
                new Book{Id=1, Name="Book1"},
                new Book{Id=2, Name="Book2" },
                new Book{Id=3, Name="Book3"},
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Book>>();
            mockSet.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<BookContext>();
            mockContext.Setup(x => x.book).Returns(mockSet.Object);

            var controller = new BookControllers(mockContext.Object);
            var books = controller.GetAllbooks();

            int deletedCactusId = 1; controller.Delete(books[0].Id);

            Assert.IsNull(controller.GetAllbooks().FirstOrDefault(x => x.Id == deletedCactusId));
        }
        [TestCase]
        public void Gives_Book_By_Name()
        {
            var data = new List<Book>()
            {
                new Book{Id=1, Name="Book1"},
                new Book{Id=2, Name="Book2" },
                new Book{Id=3, Name="Book3"},
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Book>>();
            mockSet.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<BookContext>();
            mockContext.Setup(c => c.book).Returns(mockSet.Object);

            var controller = new BookControllers(mockContext.Object);

            var book = controller.GetName("Book1");
            Assert.AreEqual("Book1", book.Name);
        }
        [TestCase]
        public void Gives_Book_By_Author()
        {
            var data = new List<Book>()
            {
                new Book{Id=1, Author="Author1"},
                new Book{Id=2, Author="Author2" },
                new Book{Id=3, Author="Author3"},
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Book>>();
            mockSet.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<BookContext>();
            mockContext.Setup(c => c.book).Returns(mockSet.Object);
            var controller = new BookControllers(mockContext.Object);
            var author = controller.GetAuthor("Author1");
            Assert.AreEqual("Author1", author.Author);
        }
    }
}
