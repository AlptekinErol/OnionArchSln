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
    public class DetailConfiguration : IEntityTypeConfiguration<Detail>
    {
        public void Configure(EntityTypeBuilder<Detail> builder)
        {
            Detail detail1 = new()
            {
                Id = 1,
                Title = "test1",
                Description = "test1",
                CategoryId = 1,
                CreatedDate = DateTime.Now,
                IsDeleted = false,
            };
            Detail detail2 = new()
            {
                Id = 2,
                Title = "test2",
                Description = "test2",
                CategoryId = 3,
                CreatedDate = DateTime.Now,
                IsDeleted = true,
            };
            Detail detail3 = new()
            {
                Id = 3,
                Title = "test3",
                Description = "test3",
                CategoryId = 4,
                CreatedDate = DateTime.Now,
                IsDeleted = false,
            };

            builder.HasData(detail1, detail2, detail3);
        }
    }
}
