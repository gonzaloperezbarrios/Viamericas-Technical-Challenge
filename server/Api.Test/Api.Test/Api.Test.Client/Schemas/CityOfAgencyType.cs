using Api.Test.Application.Services.Agency;
using Api.Test.Domain.Entities.Agency;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Test.Client.Schemas
{
    public class CityOfAgencyType : ObjectGraphType<Agency>
    {
        public CityOfAgencyType(IAgencyService agencyService)
        {
            Field(f => f.City.Id).Description("Id de la ciudad");
            Field(f => f.City.Name).Description("Nombre de la ciudad");            
        }
    }
}
