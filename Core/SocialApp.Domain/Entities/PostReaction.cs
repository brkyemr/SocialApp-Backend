using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialApp.Domain.Common;

namespace SocialApp.Domain.Entities
{
    public class PostReaction : IEntityBase
    {
        public int PostId { get; set; }
        public User User { get; set; }
    }
}