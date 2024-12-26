using CleanArch.Domain.Entities;
using CleanArch.Infra.Data.Context;
using CleanArch.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProducts() 
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetById(int? id)
        {
            return await _context.Products.FindAsync(id);
        }
        public void Add(Product product) 
        {
            _context.Add(product);
            _context.SaveChanges();
        }
        public void Update(Product product) 
        {
            _context.Update(product);
            _context.SaveChanges();
        }
        public void Remove(int? id) 
        {
            _context.Remove(id);
            _context.SaveChanges();
        }
    }

}
