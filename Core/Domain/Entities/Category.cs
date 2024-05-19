using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Category : EntityBase, IEntityBase
    {
        public Category()
        {

        }
        public Category(int parentId, string name, int priority)
        {
            ParentId = parentId;
            Name = name;
            Priority = priority;
        }
        public required int ParentId { get; set; }
        public required string Name { get; set; }
        public required int Priority { get; set; }

        // Detail realtion with collection
        public ICollection<Detail> Details { get; set; }

        // n-n relation with Product                      example => Home Stuff (id 1) , Electronical (id 2) => user have to see Bulb Product in both Category
        public ICollection<Product> Products { get; set; }
    }
}


