using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialApp.Application.Bases;


namespace SocialApp.Application.Features.Users.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException() : base("Kullanıcı Bulunamadı")
        {
        }
    }
}