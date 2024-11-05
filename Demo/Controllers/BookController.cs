using Demo.Data;
using Demo.Model;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [Route("apiDemo/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookDBContext _dbContext;

        public BooksController(BookDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("All", Name = "GetAllBooks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<BookDTO>> GetAllBooks()
        {
            var books = _dbContext.Books.Select(b => new BookDTO()
            {
                Id = b.Id,
                Name = b.Name,
                Author = b.Author,
                Year = b.Year
            });

            return Ok(books);
        }

        [HttpGet]
        [Route("{id}:int", Name = "GetBookById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<BookDTO> GetBookById(int id)
        {
            if (id <= 0)
                return BadRequest();

            Book book = _dbContext.Books.FirstOrDefault(b => b.Id == id);

            if (book == null)
                return NotFound($"Book id {id} is not found");

            BookDTO bookDTO = new BookDTO()
            {
                Id = book.Id,
                Name = book.Name,
                Author = book.Author,
                Year = book.Year
            };

            return Ok(bookDTO);
        }

        [HttpGet("{name}:alpha", Name = "GetBookByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<BookDTO> GetBookByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return BadRequest();

            Book book = _dbContext.Books.FirstOrDefault(b => b.Name.ToUpper().Contains(name.Trim().ToUpper()));

            if (book == null)
                return NotFound($"Book name {name} is not found");

            BookDTO bookDTO = new BookDTO()
            {
                Id = book.Id,
                Name = book.Name,
                Author = book.Author,
                Year = book.Year
            };

            return Ok(bookDTO);
        }

        [HttpDelete("{id}:int", Name = "DeleteBookById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<bool> DeleteBookById(int id)
        {
            if (id <= 0)
                return BadRequest();

            Book book = _dbContext.Books.FirstOrDefault(b => b.Id == id);

            if (book == null)
                return NotFound($"Book id {id} is not found");

            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpPost("Create", Name = "CreateBook")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<BookDTO> CreateBook([FromBody]BookDTO model)
        {
            if (model == null)
                return BadRequest();


            Book book = new Book()
            {
                Name = model.Name,
                Author = model.Author,
                Year = model.Year
            };

            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();

            return Ok(book);

        }
    }
}
