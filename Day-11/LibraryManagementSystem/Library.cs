using System.Collections.Generic;
using System.Linq;

namespace LibraryManagementSystem
{
    public class Library
    {
        public List<Book> Books { get; }
        public List<Borrower> Borrowers { get; }

        public Library()
        {
            Books = new List<Book>();
            Borrowers = new List<Borrower>();
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public void RegisterBorrower(Borrower borrower)
        {
            Borrowers.Add(borrower);
        }

        public bool BorrowBook(string isbn, string libraryCardNumber)
        {
            Book book = Books.FirstOrDefault(b => b.ISBN == isbn);
            Borrower borrower = Borrowers.FirstOrDefault(br => br.LibraryCardNumber == libraryCardNumber);

            if (book == null || borrower == null || book.IsBorrowed)
                return false;

            book.Borrow();
            borrower.BorrowBook(book);
            return true;
        }

        public bool ReturnBook(string isbn, string libraryCardNumber)
        {
            Book book = Books.FirstOrDefault(b => b.ISBN == isbn);
            Borrower borrower = Borrowers.FirstOrDefault(br => br.LibraryCardNumber == libraryCardNumber);

            if (book == null || borrower == null || !book.IsBorrowed)
                return false;

            book.Return();
            borrower.ReturnBook(book);
            return true;
        }

        public List<Book> ViewBooks()
        {
            return Books;
        }

        public List<Borrower> ViewBorrowers()
        {
            return Borrowers;
        }
    }
}
