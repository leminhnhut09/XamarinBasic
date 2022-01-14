using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinEntity.Models;
using System.Linq;
namespace XamarinEntity.Services
{
    public class StudentService : IStudentService
    {
        private DatabaseContext _dbContext;
        public StudentService()
        {
            _dbContext = new DatabaseContext();
        }
        public async Task<bool> AddStudentAsync(Student student)
        {
            try
            {
                await _dbContext.Students.AddAsync(student).ConfigureAwait(false);
                await _dbContext.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            var studentResult = _dbContext.Students.Where(t => t.Id.Equals(id)).FirstOrDefault();
            if (studentResult != null)
            {
                _dbContext.Students.Remove(studentResult);
                await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
            return true;
        }

        public async Task<Student> GetStudentAsync(int id)
        {
            return await Task.FromResult(_dbContext.Students.Where(t => t.Id.Equals(id)).FirstOrDefault());
        }

        public async Task<IEnumerable<Student>> GetStudentAsync()
        {
            return await Task.FromResult(_dbContext.Students.ToList());
        }

        public async Task<bool> UpdateStudentAsync(Student student)
        {
            try
            {
                _dbContext.Students.Update(student);
                await _dbContext.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
