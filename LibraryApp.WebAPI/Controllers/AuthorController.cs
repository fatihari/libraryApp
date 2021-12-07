using AutoMapper;
using LibraryApp.Business.Abstract;
using LibraryApp.Business.Abstract.Dtos;
using LibraryApp.Entities;
using Microsoft.AspNetCore.Mvc;

//  shared = web api ile 
namespace LibraryApp.WebAPI.Controllers
{
    
    [ApiController]
    [Route("api/[controller]s")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;
        public AuthorController(IAuthorService authorService, IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var authors = await _authorService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<AuthorDto>>(authors));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var author = await _authorService.GetByIdAsync(id);
            return Ok(_mapper.Map<AuthorDto>(author));
        }

        [HttpGet("{id}/books")]
        public async Task<IActionResult> GetWithBooksById(int id)
        {
            var author = await _authorService.GetWithBooksByIdAsync(id);
            // The author object has been converted(cast) to dto's with the books. 
            return Ok(_mapper.Map<AuthorWithBookDto>(author));
        }

        [HttpPost]
        public async Task<IActionResult> Save(AuthorDto authorDto)
        {
            var author = await _authorService.AddAsync(_mapper.Map<Author>(authorDto));
            return Created(string.Empty, _mapper.Map<AuthorDto>(author)); // Created=201 response status
        }

        [HttpPut]
        public IActionResult Update(AuthorDto authorDto)
        {
            
            var author = _authorService.Update(_mapper.Map<Author>(authorDto));
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var author = _authorService.GetByIdAsync(id).Result;
            _authorService.Remove(author);
            return NoContent();
        }
       

    }
}