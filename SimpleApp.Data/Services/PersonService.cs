using Microsoft.EntityFrameworkCore;
using SimpleApp.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApp.Data.Services
{
    public class PersonService
    {
        private readonly IRepository<Person> _personRepository = null;

        public PersonService(IRepository<Person> personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<Person> GetByIdAsync(params object[] ids)
        {
            return await _personRepository.GetByIdAsync(ids);
        }
        public async Task<Person> GetByIdAsNoTrackingAsync(params object[] ids)
        {
            return await _personRepository.GetByIdAsNoTrackingAsync(ids);
        }
        public async Task InsertAsync(Person person)
        {
            await _personRepository.InsertAsync(person);
        }
        public async Task UpdateAsync(Person person)
        {
            var model = await GetByIdAsync(person.ID);

            model.FirstName = person.FirstName;
            model.LastName = person.LastName;
            model.Gender = person.Gender;
            model.Mobile = person.Mobile;
            model.Address = person.Address;
            model.Birthday = person.Birthday;

            await _personRepository.UpdateAsync(model);
        }
        public async Task DeleteAsync(params object[] ids)
        {
            var model = await GetByIdAsync(ids);
            await _personRepository.DeleteAsync(model);
        }
        public async Task<List<Person>> SearchAsync()
        {
            return await _personRepository.TableNoTracking.ToListAsync();
        }
    }
}
