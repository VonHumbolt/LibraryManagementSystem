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
    public class BookImagesController : ControllerBase
    {
        IBookImageService _bookImageService;

        public BookImagesController(IBookImageService bookImageService)
        {
            _bookImageService = bookImageService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _bookImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getByBookId")]
        public IActionResult GetByBookId(int bookId)
        {
            var result = _bookImageService.GetImageByBookId(bookId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = "image")] IFormFile formFile, [FromForm] BookImage bookImage)
        {
            var result = _bookImageService.Add(bookImage, formFile);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(BookImage bookImage)
        {
            var result = _bookImageService.Delete(bookImage);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm(Name = "image")] IFormFile formFile, [FromForm] BookImage bookImage)
        {
            var result = _bookImageService.Update(bookImage, formFile);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
