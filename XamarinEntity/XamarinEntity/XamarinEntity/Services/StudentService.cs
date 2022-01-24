using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XamarinEntity.DataAccess;
using XamarinEntity.Models;
namespace XamarinEntity.Services
{
    public interface IStudentService : IRepository<Student>
    {
        Task<IEnumerable<Student>> GetListStudentAsync(int idGrade);
    }
    public class StudentService : Repository<Student>, IStudentService
    {
        private DatabaseContext _dbContext;
        public StudentService()
        {
            _dbContext = new DatabaseContext();
        }

        public async Task<IEnumerable<Student>> GetListStudentAsync(int idGrade)
        {
            return await Task.FromResult(_dbContext.Students.Where(t => t.GradeId == idGrade).ToList());
        }
    }
}
