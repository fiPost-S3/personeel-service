using personeel_service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace personeel_service.Services
{
    public interface IPersonService
    {
        List<Person> GetAll();
        Person GetById(string id);
    }
}
