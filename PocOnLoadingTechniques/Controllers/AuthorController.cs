using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PocOnLoadingTechniques.Models;
using PocOnLoadingTechniques.Repositories;

namespace PocOnLoadingTechniques.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IRepository _repository;
        public AuthorController(IRepository authorRepository)
        {
            _repository = authorRepository;
        }

        /* This is an example of Eager Loading : Fetching the Authors With Books
           Information Related with Author Which Helps to Reduce Database call stack */
        [HttpGet("EagerLoading")]
        public ActionResult GetAuthorsByEagerLoading()
        {
           // Here I am Just Implementing Include() But in Eager Loading We Can use ThenInclude()
           // But in This Example I need not to use ThenInclude()

           var authors =  _repository.GetAll().Include(author => author.Books).ToList();
           return Ok(authors);
        }

        /* This is an Example of Lazy Loading : Fetching only Authors Records and then For each Author
           The Related Books are being Fetched Later Which Leads to the Multiple Database Calls. */

        [HttpGet("LazyLoading")]
        public ActionResult GetAuthorsByLazyLoading()
        {
            // Here Books Will Not Load and We have to Accessed The Books Whenever We need Book Information.
            var authors = _repository.GetAll().ToList();

            //We Want to Load Books as Well So Now Here I am Implementing This When I need Book Information
            //As Well This is an Lazy Loading of Books Later for Each Author Leads to ===> Multiple Database Calls()
            authors.ForEach(author =>
            {
                author.Books = _repository.GetBooksByAuthorId(author.AuthorId);
            });
            return Ok(authors);
        }
    }
}
