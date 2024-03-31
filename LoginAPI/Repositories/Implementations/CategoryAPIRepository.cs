using LoginAPI.Data;
using LoginAPI.Models;
using LoginAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoginAPI.Repositories.Implementations
{
    public class CategoryAPIRepository : ICategoryAPI
    {
        private readonly MyDBContext _context;

        public CategoryAPIRepository(MyDBContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<string>> CreateCategory(Category category)
        {
            await _context.Category.AddAsync(category);
            await _context.SaveChangesAsync();
            return "Category Added Successfully!";
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<ActionResult<List<Category>>> GetCategory()
        {
            var data = await _context.Category.ToListAsync();
            return data;
        }
    }
}
