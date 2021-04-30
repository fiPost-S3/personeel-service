using personeel_service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace personeel_service.Services
{
    public class PersonService : IPersonService
    {
        private static IEnumerable<Person> persons = new List<Person>()
        {
            new Person("1", "Jaap van der Meer", "jaap@jaap.nl"),
            new Person("2", "Aron Heesakkers", "aron@aron.nl")
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
                throw new Exception($"Person with id {id} not found.");
            }

            return person;
        }
    }
}
