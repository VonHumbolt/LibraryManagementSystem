using Business.Abstract;
using Core.Entities.Concrete;
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
    public class BooksController : ControllerBase
    {
        IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _bookService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getById")]
        public IActionResult Get(int bookId)
        {
            var result = _bookService.Get(bookId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getByUserId")]
        public IActionResult GetByUserId(int userId)
        {
            var result = _bookService.GetBooksByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getByAuthorId")]
        public IActionResult GetByAuthorId(int authorId)
        {
            var result = _bookService.GetBookByAuthorId(authorId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getByCategoryId")]
        public IActionResult GetByCategoryId(int categoryId)
        {
            var result = _bookService.GetBookByCategoryId(categoryId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getByPublisherId")]
        public IActionResult GetByPublisherId(int publisherId)
        {
            var result = _bookService.GetBookByPublisherId(publisherId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Book book)
        {
            var result = _bookService.Add(book);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Book book)
        {
            var result = _bookService.Delete(book);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(Book book)
        {
            var result = _bookService.Update(book);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getBookDtos")]
        public IActionResult GetBookDtos()
        {
            var result = _bookService.GetBookDtos();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getBookDtosByBookId")]
        public IActionResult GetBookDtosByBookId(int bookId)
        {
            var result = _bookService.GetBookDtosByBookId(bookId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("addTimeExtension")]
        public IActionResult AddTimeExtension(int bookId, int day)
        {
            var result = _bookService.AddTimeExtension(bookId, day);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPost("borrowBook")]
        public IActionResult BorrowBook(int bookId, int userId)
        {
            var result = _bookService.BorrowBook(bookId, userId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("returnBook")]
        public IActionResult ReturnBook(int bookId)
        {
            var result = _bookService.ReturnBook(bookId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
