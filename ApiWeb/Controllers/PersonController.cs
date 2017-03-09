using ApiWeb.Entities;
using ApiWeb.Repositories.Interfaces;
using ApiWeb.Services;
using Common.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ApiWeb.Controllers
{
    public class PersonController : ApiController
    {
        private readonly ILog _logger = LogManager.GetLogger<PersonController>();
        private readonly IEnumerable<IService> _services;
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository, IEnumerable<IService> services)
        {
            _services = services;
            _personRepository = personRepository;
        }
        // GET api/<controller>
        public List<Person> Get()
        {
            _logger.Info("Getting list of people");
            return _personRepository.PersonRetrieve();
        }

        // GET api/<controller>/5
        public List<Person> Get(int id)
        {

            var service = _services.FirstOrDefault(x => x.isApplicable(id));
            return service.Process().ToList();
            //var ListaGeneral = new List<Person>();
            //foreach (var service in _services)
            //{
            //    var lista = service.Process();
            //    ListaGeneral.AddRange(lista);
            //}
            //return ListaGeneral;
        }

        // POST api/<controller>
        public void Post([FromBody]Person person)
        {
            _personRepository.PersonSave(person);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            _personRepository.PersonDelete(id);
        }
    }
}