﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;
using my_books.Data.ViewModels;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {

        private AuthorsService _authorService;

        public AuthorsController(AuthorsService authorsService)
        {
            _authorService = authorsService;
        }



        [HttpPost("add-author")]
        public IActionResult AddAuthor([FromBody] AuthorVM author)
        {

            _authorService.AddAuthor(author);

            return Ok("succesful");
        }

    }
}
