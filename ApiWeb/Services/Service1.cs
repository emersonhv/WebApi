using ApiWeb.Entities;
using ApiWeb.Repositories.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ApiWeb.Services
{
    public class Service1 : BaseService
    {
        private readonly IPersonRepository _personRepository;
        public Service1(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public override bool isApplicable(int filter)
        {
            if (filter == 1) return true;
            return false;
        }


        public override IEnumerable<Person> GetPeople()
        {
            return _personRepository.PersonRetrieve();
            //using (IDbConnection db =
            //    new SqlConnection(ConfigurationManager.ConnectionStrings["ApiCRUDDb"].ConnectionString))
            //{
            //    return db.Query<Person>("Select * From dbo.Person").ToList();
            //}
        }
    }
}