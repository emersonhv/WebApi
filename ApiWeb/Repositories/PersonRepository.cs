using ApiWeb.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApiWeb.Entities;
using System.Data;
using System.Data.SqlClient;
using Insight.Database;

namespace ApiWeb.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IDbConnection _connection;
        private readonly IPersonRepository _repo;

        public PersonRepository()
        {
            _connection = new SqlConnection(DataBases.CrudDb.ConnectionString);
            _repo = _connection.As<IPersonRepository>();
        }
        public void PersonDelete(int PersonId)
        {
            _repo.PersonDelete(PersonId);
        }

        public List<Person> PersonRetrieve()
        {
            return _repo.PersonRetrieve();
        }

        public void PersonSave(Person person)
        {
            _repo.PersonSave(person);
        }
    }
}