using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IBookDal : IEntityRepository<Book>
    {
        List<BookDto> GetBookDtos();
        BookDto GetByBookId(int bookId);
        void BorrowBook(int bookId, int userId);
        void ReturnBook(int bookId);
        void AddTimeExtension(int bookId, int day);
    }
}
