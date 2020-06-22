using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace AppPersons.Services
{
    public interface IDataStorePerson<T>
    {
        Task<bool> AddPersonAsync(T person);
        Task<bool> UpdatePersonAsync(T person);
        Task<bool> DeletePersonAsync(string TcNo);
        Task<T> GetPersonAsync(string TcNo);
        Task<IEnumerable<T>> GetPersonsAsync(bool forceRefresh = false);
    }
}
