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
    public class PublisherManager : IPublisherService
    {
        IPublisherDal _publisherDal;

        public PublisherManager(IPublisherDal publisherDal)
        {
            _publisherDal = publisherDal;
        }
        [ValidationAspect(typeof(PublisherValidator))]
        public IResult Add(Publisher publisher)
        {
            _publisherDal.Add(publisher);

            return new SuccessResult(Message.AddedMessage);
        }

        public IResult Delete(Publisher publisher)
        {
            _publisherDal.Delete(publisher);
            return new SuccessResult(Message.DeletedMessage);
        }

        public IDataResult<Publisher> Get(int publisherId)
        {
            return new SuccessDataResult<Publisher>(_publisherDal.Get(p => p.Id == publisherId));

        }

        public IDataResult<List<Publisher>> GetAll()
        {
            return new SuccessDataResult<List<Publisher>>(_publisherDal.GetAll());
        }
        
        [ValidationAspect(typeof(PublisherValidator))]
        public IResult Update(Publisher publisher)
        {
            _publisherDal.Update(publisher);

            return new SuccessResult(Message.UpdatedMessage);
        }

    }
}
