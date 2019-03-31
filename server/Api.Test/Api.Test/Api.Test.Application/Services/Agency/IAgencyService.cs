using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AgencyEntity = Api.Test.Domain.Entities.Agency;

namespace Api.Test.Application.Services.Agency
{
    public interface IAgencyService
    {
        string Test();
        IEnumerable List();
        IEnumerable ListByCityId(int id);
        IEnumerable ListByCityName(string name);
        AgencyEntity.City CityById(int id);
        AgencyEntity.State StateById(int id);
        IEnumerable ListOfCityAgencies();
    }
}
