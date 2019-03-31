using Api.Test.Application.Services.Agency;
using Api.Test.Domain.Entities.Agency;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Test.Client.Schemas
{
    public class AgencyType : ObjectGraphType<Agency>
    {
        public AgencyType(IAgencyService agencyService)
        {
            Field(f => f.Id).Description("Id de la agencia");
            Field(f => f.Name).Description("Nombre de la agencia");     
            Field<CityType>(
                "city",
                resolve: context => agencyService.CityById(context.Source.CityId)
            );
            Field<StateType>(
                "state",
                resolve: context => agencyService.StateById(context.Source.StateId)
            );            
        }
    }
}
