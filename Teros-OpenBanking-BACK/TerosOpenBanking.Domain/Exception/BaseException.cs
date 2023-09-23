using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerosOpenBanking.Domain.Exception
{
    public class BaseException : ArgumentException
    {
        public BaseException(string message) : base(message)
        {
        }
    }
}
