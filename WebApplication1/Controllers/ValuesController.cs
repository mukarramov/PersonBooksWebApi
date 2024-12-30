using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonBooks : ControllerBase
    {
        public static List<Person> persons = new List<Person>();
        public static List<Book> books = new List<Book>();
        public static List<ListPerson> personsList = new List<ListPerson>();

        [HttpPost]
        public IActionResult PostPerson(Person person)
        {
            persons.Add(person);
            return Ok(person);
        }

        [HttpPost]
        public IActionResult PostBook(Book book)
        {
            books.Add(book);
            return Ok(book);
        }

        [HttpGet]
        public IActionResult GetPerson()
        {
            return Ok(persons);
        }

        [HttpGet]
        public IActionResult GetBook()
        {
            return Ok(books);
        }

        [HttpPost]//create new person with books
        public IActionResult GetPersonBooks(int PersonId, int BookId)
        {
            // List<Book> book1;
            if (PersonId > 0 && BookId > 0)
            {
                var person = persons.FirstOrDefault(d => d.Id == PersonId);
                var book = books.FirstOrDefault(i => i.Id == BookId);

                if (person != null && book != null)
                {
                    //string name1 = "";
                    //int psize = 0;
                    //var name=books.Where(n=>n.Name == name1).ToList();
                    //var name2=books.Where(p=>p.PageSize == psize).ToList();

                    //var PersonListId = personsList.Select(p => p.Id).ToList();
                    var personList = personsList.FirstOrDefault(i => i.Id == PersonId);
                    //var personBook = books.FirstOrDefault(b => b.Id == BookId);

                    if (personList == null || book == null)
                    {
                        personsList.Add(new ListPerson
                        {
                            Id = PersonId,
                            Age = person.Age,
                            Name = person.Name,
                            Books = new List<Book>
                        {
                            new Book
                            {
                               Id = BookId,
                               Name = book.Name,
                               PageSize = book.PageSize,
                               Quantity = book.Quantity,
                            }
                        }
                        });
                    }
                    else
                    {
                        personList.Books.Add(new Book
                        {
                            Id = BookId,
                            Name = book.Name,
                            PageSize = book.PageSize,
                            Quantity = book.Quantity,
                        });
                    }
                }
            }
            return Ok(personsList);
        }

        [HttpGet]
        public IActionResult GetPersonBook()
        {
            return Ok(personsList);
        }
    }
}
