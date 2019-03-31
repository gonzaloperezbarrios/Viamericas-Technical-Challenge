using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AgencyEntity = Api.Test.Domain.Entities.Agency;

namespace Api.Test.Client.Services
{
    public interface IAgencyService
    {
        Task<IEnumerable> GetAsync();
        Task<IEnumerable> GetListByCityIdAsync(int id);
        Task<IEnumerable> GetListByCityNameAsync(string name);
        Task<IEnumerable> GetListOfCityAgenciesAsync();        
        Task<AgencyEntity.City> GetCityByIdAsync(int id);
        Task<AgencyEntity.State> GetStateByIdAsync(int id);        
    }
}
