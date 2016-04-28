using StudentManagementSystem.Model;
using StudentManagementSystem.Repo;
using StudentManagementSystem.Service;

namespace StudentManagementSystem.WebApp.Controllers.CommandController
{
    public class FeeController : BaseCommandController<Fee>
    {
        public FeeController() : base(new FeeService(new FeeRepository(new BusinessDbContext())))
        {
            
        }
    }
}