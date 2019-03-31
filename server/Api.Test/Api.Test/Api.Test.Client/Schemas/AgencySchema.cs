using System;
using System.Collections.Generic;
using System.Text;
using GraphQL;
using GraphQL.Types;

namespace Api.Test.Client.Schemas
{
    public class AgencySchema : Schema
    {
        public AgencySchema(AgencyQuery query, IDependencyResolver resolver)
        {
            Query = query;
            DependencyResolver = resolver;
        }
    }
}
