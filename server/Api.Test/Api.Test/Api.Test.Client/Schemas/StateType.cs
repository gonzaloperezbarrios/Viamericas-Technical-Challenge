using Api.Test.Application.Services.Agency;
using Api.Test.Domain.Entities.Agency;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Test.Client.Schemas
{
    public class StateType : ObjectGraphType<State>
    {
        public StateType(IAgencyService agencyService)
        {
            Field(f => f.Id).Description("Id del estado");
            Field(f => f.Name).Description("Nombre del estado");            
        }
    }
}
