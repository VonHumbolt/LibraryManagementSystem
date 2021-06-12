using Business.Abstract;
using Business.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AuthorManager : IAuthorService
    {
        IAuthorDal _authorDal;
        public AuthorManager(IAuthorDal authorDal)
        {
            _authorDal = authorDal;
        }

        [ValidationAspect(typeof(AuthorValidator))]
        public IResult Add(Author author)
        {
            _authorDal.Add(author);

            return new SuccessResult(Message.AddedMessage);
        }

        public IResult Delete(Author author)
        {
            _authorDal.Delete(author);

            return new SuccessResult(Message.DeletedMessage);
        }

        public IDataResult<Author> Get(int authorId)
        {
            return new SuccessDataResult<Author>(_authorDal.Get(a => a.Id == authorId));
        }

        public IDataResult<List<Author>> GetAll()
        {
            return new SuccessDataResult<List<Author>>(_authorDal.GetAll());
        }

        [ValidationAspect(typeof(AuthorValidator))]
        public IResult Update(Author author)
        {
            _authorDal.Update(author);

            return new SuccessResult(Message.UpdatedMessage);
        }
    }
}
