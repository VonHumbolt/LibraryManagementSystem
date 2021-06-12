using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBookDal : EfEntityRepositoryBase<Book, LibraryDatabaseContext>, IBookDal
    {
        public void AddTimeExtension(int bookId, int day)
        {
            using (LibraryDatabaseContext context = new LibraryDatabaseContext())
            {
                var result = context.Books.SingleOrDefault(b => b.Id == bookId);
                if (result != null)
                {
                    result.IsTimeExtended = true;
                    result.ReturnDate = result.ReturnDate?.AddDays(day);
                    context.SaveChanges();
                }
            }
        }

        public void BorrowBook(int bookId, int userId)
        {
            using (LibraryDatabaseContext context = new LibraryDatabaseContext())
            {
                var result = context.Books.SingleOrDefault(b => b.Id == bookId);

                if (result != null)
                {
                    result.UserId = userId;
                    result.RentDate = DateTime.Today;
                    result.ReturnDate = DateTime.Today.AddDays(20);
                    context.SaveChanges();
                }
            }
        }

        public void ReturnBook(int bookId)
        {
            using (LibraryDatabaseContext context = new LibraryDatabaseContext())
            {
                var result = context.Books.SingleOrDefault(b => b.Id == bookId);

                if (result != null)
                {
                    result.UserId = null;
                    result.RentDate = null;
                    result.ReturnDate = null;
                    result.IsTimeExtended = false;
                    context.SaveChanges();
                }
            }
        }

        public List<BookDto> GetBookDtos()
        {
            using (LibraryDatabaseContext context = new LibraryDatabaseContext())
            {
                var result = from book in context.Books
                             join category in context.Categories
                             on book.CategoryId equals category.Id
                             join author in context.Authors
                             on book.AuthorId equals author.Id
                             join publisher in context.Publishers
                             on book.PublisherId equals publisher.Id
                             select new BookDto
                             {
                                 Id = book.Id,
                                 BookName = book.BookName,
                                 Author = author.AuthorName,
                                 Category = category.CategoryName,
                                 Publisher = publisher.PublisherName,
                                 BookPage = book.BookPage,
                                 BookLocation = book.BookLocation,
                                 Year = book.Year,
                                 RentDate = book.RentDate,
                                 ReturnDate = book.ReturnDate
                             };

                return result.ToList();
            }
        }

        public BookDto GetByBookId(int bookId)
        {
            using (LibraryDatabaseContext context = new LibraryDatabaseContext())
            {
                var result = from book in context.Books
                             where book.Id==bookId
                             join category in context.Categories
                             on book.CategoryId equals category.Id
                             join author in context.Authors
                             on book.AuthorId equals author.Id
                             join publisher in context.Publishers
                             on book.PublisherId equals publisher.Id
                             select new BookDto
                             {
                                 Id = bookId,
                                 BookName = book.BookName,
                                 Author = author.AuthorName,
                                 Category = category.CategoryName,
                                 Publisher = publisher.PublisherName,
                                 BookPage = book.BookPage,
                                 BookLocation = book.BookLocation,
                                 Year = book.Year,
                                 RentDate = book.RentDate,
                                 ReturnDate = book.ReturnDate
                             };
                return result.Single();
            }
        }

    }
}
