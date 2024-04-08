using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialApp.Domain.Common;

namespace SocialApp.Domain.Entities
{
    public class PostCategory : IEntityBase
    {
        public int PostCategoryId { get; set; }
        public string PostCategoryName { get; set; }

    }
}