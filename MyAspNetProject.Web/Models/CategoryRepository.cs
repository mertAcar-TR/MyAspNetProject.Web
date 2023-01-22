using System;
using Microsoft.EntityFrameworkCore;

namespace MyAspNetProject.Web.Models
{
	public class CategoryRepository
	{
        private AppDbContext _context;



        public List<Category> GetAll() => _context.Set<Category>().ToList();// => ,return anlamında
        public void Add(Category newCategory)
        {
            var addedEntity = _context.Entry(newCategory);
            addedEntity.State = EntityState.Added;
            _context.SaveChanges();
        }
        public void Remove(int id)
        {

            _context.SaveChanges();
        }
        public void Update(Category entity)
        {
            var uptatedEntity = _context.Entry(entity);
            uptatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}

