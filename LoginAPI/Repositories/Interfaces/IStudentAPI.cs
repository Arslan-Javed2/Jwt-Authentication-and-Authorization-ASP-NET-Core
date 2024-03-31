using LoginAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LoginAPI.Repositories.Interfaces
{
    public interface IStudentAPI:IDisposable
    {
        Task<ActionResult<List<Students>>> GetStudents();
        Task<ActionResult<Students>> GetStudentsById(Guid id);
        Task<ActionResult<string>> CreateStudent(Students data);
        Task<ActionResult<String>> UpdateData(Guid id, Students data);
        Task<ActionResult<String>> DeleteData(Guid id);
    }
}
