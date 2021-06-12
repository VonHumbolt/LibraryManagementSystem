using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBookImageService
    {
        IResult Add(BookImage bookImage, IFormFile formFile);
        IResult Delete(BookImage bookImage);
        IResult Update(BookImage bookImage, IFormFile formFile);
        IDataResult<List<BookImage>> GetAll();
        IDataResult<BookImage> GetImageByBookId(int bookId);
    }
}
