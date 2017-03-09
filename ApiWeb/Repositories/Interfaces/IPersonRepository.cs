using ApiWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiWeb.Repositories.Interfaces
{
    public interface IPersonRepository
    {
        List<Person> PersonRetrieve();
        void PersonSave(Person person);
        void PersonDelete(int PersonId);
    }
}