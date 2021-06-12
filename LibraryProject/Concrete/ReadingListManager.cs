using Business.Abstract;
using Business.Messages;
using Core.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ReadingListManager : IReadingListService
    {
        IReadingListDal _readingListDal;

        public ReadingListManager(IReadingListDal readingListDal)
        {
            _readingListDal = readingListDal;
        }


        public IResult Add(ReadingList readingListItem)
        {
            var result = BusinessRules.Run(IsBookAlreadyAddedInUserList(readingListItem));

            if (result != null)
            {
                return result;
            }

            _readingListDal.Add(readingListItem);

            return new SuccessResult(Message.BookAddedIntoReadingList);
        }

        public IResult Delete(ReadingList readingListItem)
        {
            _readingListDal.Delete(readingListItem);

            return new SuccessResult(Message.BookDeletedInReadingList);
        }

        public IDataResult<ReadingList> Get(int bookId, int userId)
        {
            return new SuccessDataResult<ReadingList>(_readingListDal.Get(r => r.BookId == bookId && r.UserId == userId));
        }

        public IDataResult<List<ReadingList>> GetByUserId(int userId)
        {
            return new SuccessDataResult<List<ReadingList>>(_readingListDal.GetAll(r => r.UserId == userId));
        }


        public IResult IsBookAlreadyAddedInUserList(ReadingList readingList)
        {
            if (_readingListDal.Get(r => r.BookId == readingList.BookId && r.UserId == readingList.UserId) != null)
            {
                return new ErrorResult(Message.BookIsAlreadyAddedInList);
            }
            return new SuccessResult();
        }
    }
}
