using personeel_service.Helpers;
using personeel_service.Models;
using System.Collections.Generic;
using System.Linq;
using personeel_service.Database.Contexts;
using personeel_service.Database.Converters;
using personeel_service.Database.DTO_s;
using personeel_service.Models.DTO_s;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace personeel_service.Services
{
    public class PersonService : IPersonService
    {
        private readonly PersonServiceContext _context;
        private readonly IDtoConverter<Person, PersonRequest, PersonResponse> _converter;

        public PersonService(PersonServiceContext context, IDtoConverter<Person, PersonRequest, PersonResponse> converter)
        {
            _context = context;
            _converter = converter;
        }

        public async Task<List<PersonResponse>> GetAllAsync()
        {
            List<PersonResponse> persons = _converter.ModelToDto(await _context.Person.ToListAsync());
            return persons;
        }

        public async Task<PersonResponse> GetByIdAsync(string id)
        {
                PersonResponse person = _converter.ModelToDto(await _context.Person.FirstOrDefaultAsync(e => e.Id.ToString() == id));

                if (person == null)
                {
                    throw new NotFoundException($"Person with id {id} not found.");
                }
                return person;
        }

        public async Task<PersonResponse> GetSingleByFontysId(string fontysId)
        {
            PersonResponse person = _converter.ModelToDto(await _context.Person.FirstOrDefaultAsync(e => e.FontysId == fontysId));
            return person;
        }
    }
}
