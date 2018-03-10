using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWorld.Models;

namespace HelloWorld.Interfaces
{
    public interface IPerson
    {
        Task<IQueryable<Person>> GetPersonList();
        Task<Person> GetPerson(int personID);
        Task<bool> DeletePerson(int personID);
        Task<string> AddPerson(Person model);
    }
}
