using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TerosOpenBanking.Application.Dto
{
    public class AuthorisationServersDto
    {
        public string AuthorisationServerId { get; set; }
        public string CustomerFriendlyLogoUri { get; set; }
        public string CustomerFriendlyName { get; set; }
        public string PayloadSigningCertLocationUri { get; set; }
        public List<ApiResourcesDto> ApiResources { get; set; }
    }
}
