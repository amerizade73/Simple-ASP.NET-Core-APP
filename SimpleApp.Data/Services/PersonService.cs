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
    }
}
