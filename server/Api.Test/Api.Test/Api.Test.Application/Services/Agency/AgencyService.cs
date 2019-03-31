using Api.Test.Infrastructure.Framework.RepositoryPattern;
using AgencyEntity = Api.Test.Domain.Entities.Agency;
using System;
using System.Collections.Generic;
using System.Text;
using Api.Test.Domain.Entities.Agency;
using System.Collections;
using System.Linq;
using Api.Test.Domain.Entities.Agency.Enums;

namespace Api.Test.Application.Services.Agency
{
    public class AgencyService : IAgencyService
    {
        readonly IRepository<AgencyEntity.Agency> agencyRepository;
        readonly IRepository<AgencyEntity.City> cityRepository;
        readonly IRepository<AgencyEntity.State> stateRepository;

        public AgencyService(IRepository<AgencyEntity.Agency> agencyRepository, IRepository<City> cityRepository, IRepository<State> stateRepository)
        {
            this.agencyRepository = agencyRepository;
            this.cityRepository = cityRepository;
            this.stateRepository = stateRepository;
        }

        public IEnumerable List()
        {
            return agencyRepository.Get().Where(i => i.Status == StatusEnum.OPEN).ToList();
        }

        public IEnumerable ListByCityId(int id)
        {
            return agencyRepository.Get().Where(i =>i.CityId == id).ToList();
        }

        public City CityById(int id)
        {
            return cityRepository.Get(i => i.Id == id);
        }

        public string Test()
        {
            return agencyRepository.Test();
        }

        public State StateById(int id)
        {
            return stateRepository.Get(i => i.Id == id);
        }

        public IEnumerable ListByCityName(string name)
        {
            return agencyRepository.Get(i => i.City.Name == name && i.Status== StatusEnum.OPEN, null, "City");         
        }

        public IEnumerable ListOfCityAgencies()
        {
            return agencyRepository.Get(i => i.Status == StatusEnum.OPEN, null, "City").Select(i => i.City).Distinct().ToList();
        }
    }
}
