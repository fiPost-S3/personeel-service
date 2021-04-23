using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace personeel_service.Models
{
    public class Person
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Person(string id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

    }
}
