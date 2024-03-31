using LoginAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LoginAPI.Repositories.Interfaces
{
    public interface ICategoryAPI:IDisposable
    {
        Task<ActionResult<string>> CreateCategory(Category category);
        Task<ActionResult<List<Category>>> GetCategory();
    }
}
