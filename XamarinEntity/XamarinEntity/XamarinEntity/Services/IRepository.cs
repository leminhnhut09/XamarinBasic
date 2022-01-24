using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinEntity.Models;

namespace XamarinEntity.Services
{
    public interface IRepository<T> where T : class
    {
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetAsync();
        Task<IEnumerable<Student>> GetListStudentAsync(int idGrade);

    }
}
