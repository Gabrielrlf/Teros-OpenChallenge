using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerosOpenBanking.Domain.Entity
{
    public class RequestDataModel : EntityBase
    {
        public string Name { get; set; }
        public string Discovery { get; set; }
        public string Image { get; set; }
    }
}
