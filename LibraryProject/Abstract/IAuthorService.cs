using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAuthorService
    {
        IResult Add(Author author);
        IResult Delete(Author author);
        IResult Update(Author author);
        IDataResult<Author> Get(int authorId);
        IDataResult<List<Author>> GetAll();
    }
}
