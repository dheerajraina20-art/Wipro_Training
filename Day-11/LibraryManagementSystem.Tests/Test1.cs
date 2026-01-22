using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryManagementSystem;
using System.Linq;

namespace LibraryManagementSystem.Tests
{
    [TestClass]
    public class LibraryTests
    {
        private Library library;

        [TestInitialize]
        public void Setup()
        {
            library = new Library();
        }

        [TestMethod]
        public void AddBook_BookIsAddedToLibrary()
        {
            var book = new Book("C# Basics", "John", "ISBN001");

            library.AddBook(book);

            Assert.AreEqual(1, library.Books.Count);
            Assert.AreEqual("ISBN001", library.Books[0].ISBN);
        }

        [TestMethod]
        public void RegisterBorrower_BorrowerIsRegistered()
        {
            var borrower = new Borrower("Dheeraj", "CARD001");

            library.RegisterBorrower(borrower);

            Assert.AreEqual(1, library.Borrowers.Count);
            Assert.AreEqual("CARD001", library.Borrowers[0].LibraryCardNumber);
        }

        [TestMethod]
        public void BorrowBook_BookIsMarkedBorrowed_AndAddedToBorrower()
        {
            var book = new Book("C# Basics", "John", "ISBN001");
            var borrower = new Borrower("Dheeraj", "CARD001");

            library.AddBook(book);
            library.RegisterBorrower(borrower);

            bool result = library.BorrowBook("ISBN001", "CARD001");

            Assert.IsTrue(result);
            Assert.IsTrue(book.IsBorrowed);
            Assert.AreEqual(1, borrower.BorrowedBooks.Count);
            Assert.AreEqual("ISBN001", borrower.BorrowedBooks[0].ISBN);
        }

        [TestMethod]
        public void ReturnBook_BookIsMarkedAvailable_AndRemovedFromBorrower()
        {
            var book = new Book("C# Basics", "John", "ISBN001");
            var borrower = new Borrower("Dheeraj", "CARD001");

            library.AddBook(book);
            library.RegisterBorrower(borrower);

            library.BorrowBook("ISBN001", "CARD001");
            bool result = library.ReturnBook("ISBN001", "CARD001");

            Assert.IsTrue(result);
            Assert.IsFalse(book.IsBorrowed);
            Assert.AreEqual(0, borrower.BorrowedBooks.Count);
        }

        [TestMethod]
        public void ViewBooks_ReturnsAllBooks()
        {
            library.AddBook(new Book("Book1", "A", "B001"));
            library.AddBook(new Book("Book2", "B", "B002"));

            var books = library.ViewBooks();

            Assert.AreEqual(2, books.Count);
        }

        [TestMethod]
        public void ViewBorrowers_ReturnsAllBorrowers()
        {
            library.RegisterBorrower(new Borrower("User1", "C001"));
            library.RegisterBorrower(new Borrower("User2", "C002"));

            var borrowers = library.ViewBorrowers();

            Assert.AreEqual(2, borrowers.Count);
        }
    }
}
