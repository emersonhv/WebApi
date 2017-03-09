using ApiWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiWeb.Services
{
    public interface IService
    {
        bool isApplicable(int filter);
        IEnumerable<Person> Process();
    }
}