using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialApp.Domain.Common;

namespace SocialApp.Domain.Entities
{
    public class Brand : EntityBase
    {

        public Brand()
        {

        }
        public Brand(string name)
        {
            
        }
        public string Name { get; set; }
    }
}