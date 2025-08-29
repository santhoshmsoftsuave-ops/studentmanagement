using StudentManagement.Cqrs.Api.Models;
namespace StudentManagement.Cqrs.Api.Repository
{
    public interface IStudentRepository
    {
        Task<Student> AddAsync(Student student);
        Task<Student?> GetByIdAsync(string id);
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student> UpdateAsync(Student student);
        Task DeleteAsync(string id);
    }
}
