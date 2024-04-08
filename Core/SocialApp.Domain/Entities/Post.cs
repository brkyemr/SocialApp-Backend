using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialApp.Domain.Common;

namespace SocialApp.Domain.Entities
{
    public class Post : EntityBase
    {
        public Post()
        {
            
        }
        public Post(string title, string description, int userId)
        {
            Title = title;
            Description = description;
            UserId = userId;
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<PostCategory> PostCategories { get; set;}
    }
}