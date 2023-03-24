using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = 1, CategoryId = 1, Name = "Faber Castels", Price = 20, Stock = 1000, CreatedTime = DateTime.Now },
                new Product { Id = 2, CategoryId = 1, Name = "Inci", Price = 25, Stock = 1500, CreatedTime = DateTime.Now },
                new Product { Id = 3, CategoryId = 2, Name = "SpeakOut", Price = 30, Stock = 700, CreatedTime = DateTime.Now },
                new Product { Id = 4, CategoryId = 3, Name = "Oyal", Price = 15, Stock = 2500, CreatedTime = DateTime.Now });
        }
    }
}
