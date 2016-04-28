using StudentManagementSystem.Model;
using StudentManagementSystem.Repo;
using StudentManagementSystem.Service;

namespace StudentManagementSystem.WebApp.Controllers.CommandController
{
    public class CollectionDetailController : BaseCommandController<CollectionDetail>
    {
        public CollectionDetailController() : base(new CollectionDetailService(new CollectionDetailRepository(new BusinessDbContext())))
        {

        }
    }
}