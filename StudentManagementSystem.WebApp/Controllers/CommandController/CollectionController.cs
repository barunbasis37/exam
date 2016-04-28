using StudentManagementSystem.Model;
using StudentManagementSystem.Repo;
using StudentManagementSystem.Service;

namespace StudentManagementSystem.WebApp.Controllers.CommandController
{
    public class CollectionController : BaseCommandController<Collection>
    {
        public CollectionController() : base(new CollectionService(new CollectionRepository(new BusinessDbContext())))
        {

        }
    }
}