using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialApp.Domain.Common;

namespace SocialApp.Domain.Entities
{
    public class ReactionType : IEntityBase
    {
        public int ReactionTypeId { get; set; }
        public string ReactionTypeName { get; set; }
    }
}