using Api.Test.Application.Services.Agency;
using Api.Test.Domain.Entities.Agency;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Test.Client.Schemas
{
    public class CityType : ObjectGraphType<City>
    {
        public CityType(IAgencyService agencyService)
        {
            Field(f => f.Id).Description("Id de la ciudad");
            Field(f => f.Name).Description("Nombre de la ciudad");            
        }
    }
}
