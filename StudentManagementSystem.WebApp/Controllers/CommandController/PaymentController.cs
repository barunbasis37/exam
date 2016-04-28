using StudentManagementSystem.Model;
using StudentManagementSystem.Repo;
using StudentManagementSystem.Service;

namespace StudentManagementSystem.WebApp.Controllers.CommandController
{
    public class PaymentController : BaseCommandController<Payment>
    {
        public PaymentController() : base(new PaymentService(new PaymentRepository(new BusinessDbContext())))
        {

        }
    }
}