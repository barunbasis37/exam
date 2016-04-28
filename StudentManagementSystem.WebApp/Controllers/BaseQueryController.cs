using System.Web.Http;
using StudentManagementSystem.Model;

namespace StudentManagementSystem.WebApp.Controllers
{
    public class BaseQueryController<T> : ApiController
    {
        protected BusinessDbContext Db;
        public BaseQueryController()
        {
            Db = new BusinessDbContext();
        }
    }
}