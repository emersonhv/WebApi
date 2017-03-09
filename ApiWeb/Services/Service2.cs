using ApiWeb.Entities;
using Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiWeb.Services
{
    public class Service2 : BaseService
    {
        private readonly ILog _logger = LogManager.GetLogger<BaseService>();

        public override bool isApplicable(int filter)
        {
            if (filter == 2) return true;
            return false;
        }

        public override IEnumerable<Person> GetPeople()
        {
            return new List<Person>{
                    new Person { PersonId = 1, LastName ="jjhj",Names="sdfsf",PhoneNumber="lklk"}
            };
           
        }
        public override void SaveLog()
        {
            _logger.Info("Obteniendo Registrosss : Para el 2");
        }
    }
}