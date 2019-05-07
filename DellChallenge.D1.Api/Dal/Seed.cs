using DellChallenge.D1.Api.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DellChallenge.D1.Api.Dal
{
    public class Seed
    {
        private readonly DataContext _context;
        public Seed(DataContext context)
        {
            _context = context;
        }

        public void SeedProducts()
        {
            if (!_context.Products.Any())
            {
                for (int i = 0; i < 9; i++)
                {
                    var product = new Product()
                    {
                        Name = $"Samsung Galaxy S{i + 1}",
                        Category = "SmartPhones"
                    };

                    _context.Products.Add(product);
                }

                _context.SaveChanges();
            }
        }
    }
}
