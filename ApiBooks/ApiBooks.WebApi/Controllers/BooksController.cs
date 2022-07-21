using ApiBooks.Models;
using ApiBooks.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiBooks.WebApi.Controllers
{
    [Route("api/Books")]

    public class BooksController : Controller
    {
        private readonly IUnitOfWork uow;
        public BooksController(IUnitOfWork unitOfWork)
        {
            uow = unitOfWork;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var entity = uow.Books.GetById(id);

            return Ok(entity);
        }
        [HttpGet]
        public IActionResult GetList()
        {
            var list = uow.Books.GetList();

            return Ok(list);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Books book)
        {
            if (!ModelState.IsValid) return BadRequest();
            
            if (uow.Books.Insert(book)>0)
            {
                return Ok(new { Message="El libro fue creado correctamente" });
            }
            return BadRequest();
        }
        [HttpPut("{Id}")]
        public IActionResult Put([FromBody] Books book)
        {
            //var book1 = uow.Books.GetById(Id);
            if (!ModelState.IsValid) return BadRequest();

            if(uow.Books.Update(book))
            {
                return Ok(new { Message="El libro fue actualizado correctamente" });
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = uow.Books.GetById(id);

            if (book != null && uow.Books.Delete(book))
                return Ok(new { Message = "El libro fue eliminado correctamente" });

            return BadRequest();
        }
    }
}
