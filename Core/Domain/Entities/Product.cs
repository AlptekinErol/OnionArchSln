using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product : EntityBase
    {
        //public Product()
        //{

        //}
        //public Product(string title, string description, int BrandId, decimal price, decimal discount)
        //{
        //    Title = title;
        //    Description = description;
        //    this.BrandId = BrandId;
        //    Price = price;
        //    Discount = discount;
        //}

        public string Title { get; set; }
        public string Description { get; set; }
        public int BrandId { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }


        // relation with Brand Table 
        Brand Brand { get; set; }

        // n-n relation with Category Table                  example => Home Stuff (id 1) , Electronical (id 2) => user have to see Bulb Product in both Category

        public ICollection<Category> Categories { get; set; }

    }
}
