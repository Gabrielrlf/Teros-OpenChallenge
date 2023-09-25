using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerosOpenBanking.Infra.BaseApi.Interface
{
    public interface IClientApi
    {
        Task<string> SendPostAsync(string url);
    }
}
