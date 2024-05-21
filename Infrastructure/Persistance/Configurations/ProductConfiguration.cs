using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            Product product1 = new()
            {
                Id = 1,
                Title = "Title1",
                Description = "Description1",
                BrandId = 1,
                Discount = 0.5m,
                Price = 500,
                CreatedDate = DateTime.Now,
                IsDeleted = false,
            };
            Product product2 = new()
            {
                Id = 2,
                Title = "Title2",
                Description = "Description2",
                BrandId = 1,
                Discount = 0.3m,
                Price = 200,
                CreatedDate = DateTime.Now,
                IsDeleted = false,
            };

            builder.HasData(product1, product2);
        }
    }
}
