using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SocialApp.Domain.Common;

namespace SocialApp.Domain.Entities
{
    public class User : IdentityUser<Guid>, IEntityBase
    {
        public string FullName { get; set; }
        public string? RefreshToken { get; set; }
        public string? ProfileImage { get; set; }
        public DateTime? RefreshTokenExpireTime { get; set; }
        public string? Bio { get; set; }

        // IEntityBase arayüzünden gelen özellikleri ekleyin
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? Gender { get; set; }
        // IEntityBase arayüzündeki diğer özellikleri veya metotları ekleyin
    }
}