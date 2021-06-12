using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBookService
    {
        IResult Add(Book book);
        IResult Delete(Book book);
        IResult Update(Book book);
        IDataResult<Book> Get(int bookId);

        IDataResult<List<Book>> GetAll();

        IDataResult<List<Book>> GetBookByCategoryId(int categoryId);
        IDataResult<List<Book>> GetBookByAuthorId(int authorId);
        IDataResult<List<Book>> GetBookByPublisherId(int publisherId);

        IDataResult<List<Book>> GetBooksByUserId(int userId);

        IDataResult<List<BookDto>> GetBookDtos();

        IDataResult<BookDto> GetBookDtosByBookId(int bookId);

        IResult AddTimeExtension(int bookId, int day);

        IResult BorrowBook(int bookId, int userId);
        IResult ReturnBook(int bookId);
    }
}
