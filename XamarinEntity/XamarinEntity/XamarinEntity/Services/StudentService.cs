using XamarinEntity.Models;
namespace XamarinEntity.Services
{
    public interface IStudentService : IRepository<Student>
    {

    }
    public class StudentService : Repository<Student>, IStudentService
    {
    }
}
