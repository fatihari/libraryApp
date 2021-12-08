using LibraryApp.Business.Abstract;
using LibraryApp.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.WebAPI.Controllers
{
    // THIS CONTROLLER IS SAMPLE CONTROLLER THAT WITHOUT SPECIAL SERVICE AND DTO! :)

    [ApiController]
    [Route("api/[controller]s")]
    public class PublisherController : ControllerBase
    {
        private readonly IService<Publisher> _publisherService;
        public PublisherController(IService<Publisher> service)
        {
            _publisherService = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var publishers = await _publisherService.GetAllAsync();
            return Ok(publishers);
        }
        [HttpPost]
        public async Task<IActionResult> Save(Publisher publisher)
        {
            var newPublisher = await _publisherService.AddAsync(publisher);
            return Ok(newPublisher);
        }
    }
}