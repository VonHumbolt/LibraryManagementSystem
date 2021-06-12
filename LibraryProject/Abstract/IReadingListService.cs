using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IReadingListService
    {
        IResult Add(ReadingList readingListItem);
        IResult Delete(ReadingList readingListItem);
        IDataResult<ReadingList> Get(int bookId, int userId);
        IDataResult<List<ReadingList>> GetByUserId(int userId);
    }
}
