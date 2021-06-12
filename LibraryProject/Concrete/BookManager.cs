using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Business;
using Core.CrossCuttingConcernes.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BookManager : IBookService
    {
        IBookDal _bookDal;
        IUserService _userService;
        IEmailService _emailService;
        public BookManager(IBookDal bookDal, IUserService userService, IEmailService emailService)
        {
            _bookDal = bookDal;
            _userService = userService;
            _emailService = emailService;
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(BookValidator))]
        [CacheRemoveAspect("IBookService.Get")]
        public IResult Add(Book book)
        {

            _bookDal.Add(book);

            return new SuccessResult(Message.AddedMessage);
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("IBookService.Get")]
        public IResult Delete(Book book)
        {
            _bookDal.Delete(book);

            return new SuccessResult(Message.DeletedMessage);
        }

        public IDataResult<Book> Get(int bookId)
        {
            return new SuccessDataResult<Book>(_bookDal.Get(b => b.Id == bookId));
        }

        [CacheAspect(10)]
        public IDataResult<List<Book>> GetAll()
        {
            return new SuccessDataResult<List<Book>>(_bookDal.GetAll());
        }

        public IDataResult<List<Book>> GetBookByAuthorId(int authorId)
        {
            return new SuccessDataResult<List<Book>>(_bookDal.GetAll(b => b.AuthorId == authorId));
        }

        public IDataResult<List<Book>> GetBookByCategoryId(int categoryId)
        {
            return new SuccessDataResult<List<Book>>(_bookDal.GetAll(b => b.CategoryId == categoryId));
        }

        public IDataResult<List<Book>> GetBookByPublisherId(int publisherId)
        {
            return new SuccessDataResult<List<Book>>(_bookDal.GetAll(b => b.PublisherId == publisherId));
        }

        public IDataResult<List<BookDto>> GetBookDtos()
        {
            return new SuccessDataResult<List<BookDto>>(_bookDal.GetBookDtos());
        }

        public IDataResult<BookDto> GetBookDtosByBookId(int bookId)
        {
            return new SuccessDataResult<BookDto>(_bookDal.GetByBookId(bookId));
        }

        public IDataResult<List<Book>> GetBooksByUserId(int userId)
        {
            return new SuccessDataResult<List<Book>>(_bookDal.GetAll(b => b.UserId == userId));
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(BookValidator))]
        [CacheRemoveAspect("IBookService.Get")]
        public IResult Update(Book book)
        {
            var result = BusinessRules.Run(CheckIfUserBooksIsFull(book.UserId.Value));

            if (result != null)
            {
                return result;
            }

            _bookDal.Update(book);

            return new SuccessResult(Message.UpdatedMessage);
        }

        public IResult AddTimeExtension(int bookId, int day)
        {
            _bookDal.AddTimeExtension(bookId, day);

            return new SuccessResult(Message.ExtensionSuccess);
        }

        [SecuredOperation("admin")]
        public IResult BorrowBook(int bookId, int userId)
        {
            _bookDal.BorrowBook(bookId, userId);

            var book = _bookDal.GetByBookId(bookId);
            var user = _userService.GetUserById(userId);

            var message = book.BookName + " adlı kitabı ödünç aldınız. Son Teslim Tarihi: " + book.ReturnDate.ToString();

            _emailService.SendMail("Library Management System", "library@library.com", user.Data.FirstName, user.Data.Email, "Ödünç İşlemi",
                message, "library@library.com", "xxxx");


            return new SuccessResult(Message.BorrowSuccess);
        }

        public IResult ReturnBook(int bookId)
        {
            _bookDal.ReturnBook(bookId);

            return new SuccessResult(Message.SuccessfullyReturnedBook);
        }

        public IResult CheckIfUserBooksIsFull(int userId)
        {
            if (_bookDal.GetAll(b => b.UserId == userId).Count >= 5)
            {
                return new ErrorResult(Message.UserBooksLimitIsFull);
            }
            return new SuccessResult();
        }
  
    }
}
