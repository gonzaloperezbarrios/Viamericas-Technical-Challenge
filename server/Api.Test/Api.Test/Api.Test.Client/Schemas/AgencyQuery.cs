using System;
using System.Collections.Generic;
using System.Text;
using Api.Test.Client.Services;
using GraphQL.Types;

namespace Api.Test.Client.Schemas
{
    public class AgencyQuery : ObjectGraphType<object>
    {
        readonly IAgencyService agencyService;

        public AgencyQuery(IAgencyService agencyService)
        {
            this.agencyService = agencyService;
            Name = "Query";
            Field<ListGraphType<AgencyType>>(
                 "angencies",
                  arguments: new QueryArguments(
                      new QueryArgument<IntGraphType> { Name = "filterIdCity" },
                      new QueryArgument<StringGraphType> { Name = "filterNameCity" }
                  ),
                  resolve: context =>
                  {
                      int filterIdCity = context.GetArgument<int>("filterIdCity");
                      string filterNameCity = context.GetArgument<string>("filterNameCity");
                      if (filterIdCity > 0)
                      {
                          return agencyService.GetListByCityIdAsync(filterIdCity);
                      }
                      else if (filterNameCity!=null)
                      {
                          return agencyService.GetListByCityNameAsync(filterNameCity);
                      }
                      else
                      {
                          return agencyService.GetAsync();
                      }
                  }
            );
            Field<CityType>(
                  "city",
                  arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                  resolve: context =>
                  {
                      var id = context.GetArgument<int>("id");
                      return agencyService.GetCityByIdAsync(id);
                  }
           );
           Field<StateType>(
                 "state",
                 arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                 resolve: context =>
                 {
                     var id = context.GetArgument<int>("id");
                     return agencyService.GetStateByIdAsync(id);
                 }
          );
          Field<ListGraphType<CityType>>(
                   "citiesOfAgencies",             
                   resolve: context =>
                   {
                       return agencyService.GetListOfCityAgenciesAsync();
                   }
            );


        }
    }
}
