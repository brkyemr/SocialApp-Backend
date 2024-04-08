using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialApp.Domain.Common;

namespace SocialApp.Domain.Entities
{
    public class PostComment : IEntityBase
    {
        public int PostId { get; set; }
        public ReactionType ReactionType { get; set; }
        public User UserFrom { get; set; }
        public User UserTo { get; set; }

    }
}