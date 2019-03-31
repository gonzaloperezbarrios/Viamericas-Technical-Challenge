using Api.Test.Domain.Entities.Agency.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Test.Domain.Entities.Agency
{
    public class Agency
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public StatusEnum Status { get; set; }
        public City City { get; set; }
        public int CityId { get; set; }
        public State State { get; set; }
        public int StateId { get; set; }
    }
}
