using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api.Test.Application.Services.Agency;
using System.Collections;
using AgencyEntity = Api.Test.Domain.Entities.Agency;

namespace Api.Test.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Agency")]
    public class AgencyController : Controller
    {
        readonly IAgencyService agencyService;

        public AgencyController(IAgencyService agencyService)
        {
            this.agencyService = agencyService;
        }

        [HttpGet]
        [Route("/api/Agency/test")]
        public string Test()
        {
            return agencyService.Test();
        }


        [HttpGet]
        [Route("/api/Agency/list")]
        public IEnumerable List()
        {
            return agencyService.List();
        }

        [HttpGet("{id}")]
        [Route("/api/Agency/list/by/city/{id}")]
        public AgencyEntity.City CityById(int id)
        {
            return agencyService.CityById(id);
        }

        [HttpGet]
        [Route("/api/Agency/list/of/city/agencies")]
        public IEnumerable ListOfCityAgencies()
        {
            return agencyService.ListOfCityAgencies();
        }

    }
}