using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using personeel_service.Models;

namespace personeel_service.Controllers
{
    [Route("api/persons")]
    [ApiController]
    public class PersonController : Controller
    {
        private static List<Person> persons = new List<Person>()
        {
            new Person("1", "Jaap van der Meer", "jaap@jaap.nl"),
            new Person("2", "Aron Heesakkers", "aron@aron.nl")
        };

        // GET: api/Persons
        [HttpGet]
        public ActionResult<IEnumerable<Person>> GetPerson()
        {
            return persons;
        }

        // GET: api/Persons/5
        [HttpGet("{id}")]
        public ActionResult<Person> GetPerson(string id)
        {
            var person = persons.Find(p => p.Id == id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }
    }
}
