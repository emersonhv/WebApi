using ApiWeb.Entities;
using Common.Logging;
using System.Collections.Generic;

namespace ApiWeb.Services
{
    public abstract class BaseService : IService
    {
        private readonly ILog _logger = LogManager.GetLogger<BaseService>();

        public abstract bool isApplicable(int filter);

        public IEnumerable<Person> Process()
        {
            SaveLog();
            return GetPeople();
        }
        public virtual void SaveLog()
        {
            _logger.Info("Obteniendo Registrosss");
        }
        public abstract IEnumerable<Person> GetPeople();
    }
}