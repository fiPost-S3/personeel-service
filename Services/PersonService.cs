using personeel_service.Helpers;
using personeel_service.Models;
using System.Collections.Generic;
using System.Linq;

namespace personeel_service.Services
{
    public class PersonService : IPersonService
    {
        private static readonly IEnumerable<Person> persons = new List<Person>()
        {
            new Person("1", "Jaap van der Meer", "fipostspamn@hotmail.com"),
            new Person("2", "Sverre van Gompel", "fipostspamn@hotmail.com"),
            new Person("3", "Kevin Wieling", "fipostspamn@hotmail.com"),
            new Person("4", "Robin de Witte", "fipostspamn@hotmail.com"),
            new Person("5", "Sjors Scholten", "fipostspamn@hotmail.com"),
            new Person("6", "Aron Heesakkers", "fipostspamn@hotmail.com")
        };

        public List<Person> GetAll()
        {
            return persons.ToList();
        }

        public Person GetById(string id)
        {
            var person = persons.FirstOrDefault(p => p.Id == id);

            if (person == null)
            {
                throw new NotFoundException($"Person with id {id} not found.");
            }

            return person;
        }
    }
}
