using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialApp.Application.Bases
{
    public class BaseException : ApplicationException
    {
        public BaseException()
        {
            
        }
        public BaseException(string message) : base(message)
        {
            
        }
    }
}