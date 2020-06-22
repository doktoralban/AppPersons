using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppPersons.Models;

namespace AppPersons.Services
{
    public class PrsDataStrore : IDataStorePerson<Person>
    {
        readonly List<Person> Lstpersons;

        public PrsDataStrore()
        {
            Lstpersons = new List<Person>()
            {
                new Person { TcNo="11111111111",AdSoyad ="Ali bey"},
                new Person { TcNo="22222222222",AdSoyad ="Ayşe hanım"}
            };
        } 

        public async Task<bool> AddPersonAsync(Person person)
        {
            Lstpersons.Add(person);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdatePersonAsync(Person person)
        {
            var oldPerson = Lstpersons.Where((Person arg) => arg.TcNo == arg.TcNo).FirstOrDefault();
            Lstpersons.Remove(oldPerson);
            Lstpersons.Add(person);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeletePersonAsync(string TcNo)
        {
            var oldPerson = Lstpersons.Where((Person arg) => arg.TcNo == arg.TcNo).FirstOrDefault();
            Lstpersons.Remove(oldPerson);

            return await Task.FromResult(true);
        }

        public async Task<Person> GetPersonAsync(string TcNo)
        {
            return await Task.FromResult(Lstpersons.FirstOrDefault(s => s.TcNo == TcNo));
        }

        public async Task<IEnumerable<Person>> GetPersonsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Lstpersons);
        }


    




    }
}
