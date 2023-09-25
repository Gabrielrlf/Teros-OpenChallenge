using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TerosOpenBanking.Application.Dto
{
    public class RequestDto
    {
        public string OrganisationId { get; set; }
        public List<AuthorisationServersDto> AuthorisationServers { get; set; }
    }
}
