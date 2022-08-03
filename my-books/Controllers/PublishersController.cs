using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;
using my_books.Data.ViewModels;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {

        private PublishersService _publisherService;

        public PublishersController(PublishersService publishersService)
        {
            _publisherService = publishersService;
        }


        [HttpPost("add-publisher")]
        public IActionResult AddAuthor([FromBody] PublisherVM publisher)
        {

            _publisherService.AddPublisher(publisher);

            return Ok("succesful");
        }


        [HttpGet("get-publisher-data-with-authors/{id}")]

        public IActionResult GetPublisherData(int id) { 
        
        var response = _publisherService.GetPublisherData(id);

            return Ok(response);
        
        }



        [HttpDelete("delete-publisher-by-id/{id}")]

        public IActionResult DeletePublisherById(int id) {

            _publisherService.DeletePublisherById(id);

            return Ok();
        
        }
    }
}
