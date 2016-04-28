using StudentManagementSystem.Model;
using StudentManagementSystem.Repo;
using StudentManagementSystem.Service;

namespace StudentManagementSystem.WebApp.Controllers.CommandController
{
    public class StudentController : BaseCommandController<Student>
    {
        public StudentController() : base(new StudentService(new StudentRepository(new BusinessDbContext())))
        {

        }
    }
}