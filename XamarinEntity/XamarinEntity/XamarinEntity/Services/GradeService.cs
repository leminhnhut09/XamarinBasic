using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinEntity.Models;

namespace XamarinEntity.Services
{
    public interface IGradeService : IRepository<Grade>
    {
    }
    public class GradeService : Repository<Grade>, IGradeService
    {
    }
}
