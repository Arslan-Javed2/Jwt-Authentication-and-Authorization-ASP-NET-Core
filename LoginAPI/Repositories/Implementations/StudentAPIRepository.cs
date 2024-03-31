using LoginAPI.Data;
using LoginAPI.Models;
using LoginAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoginAPI.Repositories.Implementations
{
    public class StudentAPIRepository : IStudentAPI
    {
        private readonly MyDBContext _context;

        public StudentAPIRepository(MyDBContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<string>> CreateStudent(Students data)
        {
            await _context.Students.AddAsync(data);
            await _context.SaveChangesAsync();
            return "Students Added Successfully!";
        }

        public async Task<ActionResult<string>> DeleteData(Guid id)
        {
            var userData = await _context.Students.FindAsync(id);
            if(userData != null)
            {
                _context.Students.Remove(userData);
                await _context.SaveChangesAsync();
                return "Student deleted successfully!";
            }
            return $"No Data against student id:{id}";
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<ActionResult<List<Students>>> GetStudents()
        {
            var studentData = await _context.Students.ToListAsync();
            return studentData;
        }

        public async Task<ActionResult<Students>> GetStudentsById(Guid id)
        {
            var studentData = await _context.Students.FindAsync(id);
            return studentData;
        }

        public Task<ActionResult<string>> UpdateData(Guid id, Students data)
        {
            throw new NotImplementedException();
        }
    }
}
