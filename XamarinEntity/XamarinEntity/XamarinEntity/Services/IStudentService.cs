using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinEntity.Models;

namespace XamarinEntity.Services
{
    public interface IStudentService
    {
        Task<bool> AddStudentAsync(Student student);
        Task<bool> UpdateStudentAsync(Student student);
        Task<bool> DeleteStudentAsync(int id);
        Task<Student> GetStudentAsync(int id);
        Task<IEnumerable<Student>> GetStudentAsync();
    }
}
