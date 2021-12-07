using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LibraryApp.Business.Abstract;
using LibraryApp.Business.Abstract.Dtos;
using LibraryApp.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;
        public BookController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _bookService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<BookDto>>(books));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var book = await _bookService.GetByIdAsync(id);
            return Ok(_mapper.Map<BookDto>(book));
        }

        [HttpGet("{id}/authors")]
        public async Task<IActionResult> GetWithAuthorById(int id)
        {
            var book = await _bookService.GetWithAuthorByIdAsync(id);
            // The book object has been converted(cast) to dto's with the author. 
            return Ok(_mapper.Map<BookWithAuthorDto>(book));
        }


        [HttpPost]
        public async Task<IActionResult> Save(BookDto bookDto)
        {
            var book = await _bookService.AddAsync(_mapper.Map<Book>(bookDto));
            return Created(string.Empty, _mapper.Map<BookDto>(book)); // Created=201 response status
        }

        [HttpPut]
        public IActionResult Update(BookDto bookDto)
        {

            var book = _bookService.Update(_mapper.Map<Book>(bookDto));
            return NoContent(); // for best practise we return 204
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var book = _bookService.GetByIdAsync(id).Result;
            _bookService.Remove(book);
            return NoContent();
        }
    }
}