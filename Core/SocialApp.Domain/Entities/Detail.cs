using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialApp.Domain.Common;

namespace SocialApp.Domain.Entities
{
    public class Detail : EntityBase
    {
        public Detail()
        {

        }
        public Detail(string title, string description, int categoryId)
        {

        }

        public  string Title { get; set; }
        public  string Description { get; set; }
        public  int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}