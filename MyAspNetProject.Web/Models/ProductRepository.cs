using System;
using Microsoft.EntityFrameworkCore;

namespace MyAspNetProject.Web.Models
{
    public class ProductRepository
    {
        private AppDbContext _context;
        


        public List<Product> GetAll() => _context.Set<Product>().ToList();// => ,return anlamında
        public void Add(Product newProduct)
        {
            var addedEntity = _context.Entry(newProduct);
            addedEntity.State = EntityState.Added;
            _context.SaveChanges();
        }
        public void Remove(int id)
        {
            
            _context.SaveChanges();
        }
        public void Update(Product entity)
        {
            var uptatedEntity = _context.Entry(entity);
            uptatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
