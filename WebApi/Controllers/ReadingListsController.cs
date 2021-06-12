using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadingListsController : ControllerBase
    {
        IReadingListService _readingListService;

        public ReadingListsController(IReadingListService readingListService)
        {
            _readingListService = readingListService;
        }

        [HttpGet("getByUserId")]
        public IActionResult GetByUserId(int userId)
        {
            var result = _readingListService.GetByUserId(userId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("get")]
        public IActionResult Get(int bookId, int userId)
        {
            var result = _readingListService.Get(bookId, userId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(ReadingList readingList)
        {

            var result = _readingListService.Add(readingList);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(ReadingList readingList)
        {

            var result = _readingListService.Delete(readingList);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

    }
}
