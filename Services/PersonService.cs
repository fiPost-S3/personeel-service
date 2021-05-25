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
            new Person("1", "Jaap van der Meer", "jaap@jaap.nl"),
            new Person("2", "Sverre van Gompel", "sverre@sverre.nl"),
            new Person("3", "Kevin Wieling", "kevin@kevin.nl"),
            new Person("4", "Robin de Witte", "robin@robin.nl"),
            new Person("5", "Sjors Scholten", "sjors@sjors.nl"),
            new Person("6", "Aron Heesakkers", "aron@aron.nl")
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
