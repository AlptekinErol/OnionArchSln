using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Configurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Brand> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(256);
            Brand brand1 = new()
            {
                Id = 1,
                Name = "Marka1",
                CreatedDate = DateTime.Now,
                IsDeleted = false,

            };
            Brand brand2 = new()
            {
                Id = 2,
                Name = "Marka2",
                CreatedDate = DateTime.Now,
                IsDeleted = false,

            };
            Brand brand3 = new()
            {
                Id = 3,
                Name = "Marka3",
                CreatedDate = DateTime.Now,
                IsDeleted = false,

            };
            builder.HasData(brand1,brand2, brand3);
        }
    }
}
