using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AplicationService=Api.Test.Application.Services.Agency;
using Api.Test.Domain.Entities.Agency;
using System.Collections;

namespace Api.Test.Client.Services
{
    public class AgencyService: IAgencyService
    {
        readonly AplicationService.IAgencyService agencyService;
        public AgencyService(AplicationService.IAgencyService agencyService)
        {
            this.agencyService = agencyService;
        }
        public Task<IEnumerable> GetAsync()
        {
            return Task.FromResult(agencyService.List());
        }

        public Task<City> GetCityByIdAsync(int id)
        {
            return Task.FromResult(agencyService.CityById(id));
        }        

        public Task<IEnumerable> GetListByCityIdAsync(int id)
        {
            return Task.FromResult(agencyService.ListByCityId(id));
        }

        public Task<IEnumerable> GetListByCityNameAsync(string name)
        {
            return Task.FromResult(agencyService.ListByCityName(name));
        }

        public Task<IEnumerable> GetListOfCityAgenciesAsync()
        {
            return Task.FromResult(agencyService.ListOfCityAgencies());
        }

        public Task<State> GetStateByIdAsync(int id)
        {
            return Task.FromResult(agencyService.StateById(id));
        }
    }
}
