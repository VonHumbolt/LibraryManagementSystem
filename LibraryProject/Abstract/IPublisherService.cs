using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IPublisherService
    {
        IResult Add(Publisher publisher);
        IResult Delete(Publisher publisher);
        IResult Update(Publisher publisher);
        IDataResult<Publisher> Get(int publisherId);
        IDataResult<List<Publisher>> GetAll();

    }
}
