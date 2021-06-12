using Business.Abstract;
using Business.Messages;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BookImageManager : IBookImageService
    {
        IBookImageDal _bookImageDal;

        public BookImageManager(IBookImageDal bookImageDal)
        {
            _bookImageDal = bookImageDal;
        }

        public IResult Add(BookImage bookImage, IFormFile formFile)
        {
            bookImage.ImagePath = FileHelper.Add(formFile);

            _bookImageDal.Add(bookImage);

            return new SuccessResult(Message.AddedMessage);
        }

        public IResult Delete(BookImage bookImage)
        {
            FileHelper.Delete(bookImage.ImagePath);

            _bookImageDal.Delete(bookImage);
            return new SuccessResult(Message.DeletedMessage);
        }

        public IDataResult<List<BookImage>> GetAll()
        {
            return new SuccessDataResult<List<BookImage>>(_bookImageDal.GetAll());
        }

        public IDataResult<BookImage> GetImageByBookId(int bookId)
        {
            return new SuccessDataResult<BookImage>(_bookImageDal.Get(b => b.BookId == bookId));
        }

        public IResult Update(BookImage bookImage, IFormFile formFile)
        {
            bookImage.ImagePath = FileHelper.Update(bookImage.ImagePath, formFile);

            _bookImageDal.Update(bookImage);

            return new SuccessResult(Message.UpdatedMessage);
        }
    }
}
