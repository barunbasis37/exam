using System.Threading.Tasks;
using System.Web.Http;
using CDService = StudentManagementSystem.Service.CollectionDetailService;
using Repository = StudentManagementSystem.Repo.CollectionDetailRepository;
using Rm = StudentManagementSystem.Request.CollectionDetailRequestModel;
using M = StudentManagementSystem.Model.CollectionDetail;

namespace StudentManagementSystem.WebApp.Controllers.QueryController
{
    public class CollectionDetailQueryController : BaseQueryController<M>
    {
        private readonly CDService service;

        public CollectionDetailQueryController()
        {
            service = new CDService(new Repository(Db));
        }

        public IHttpActionResult Get(string id)
        {
            return Ok(service.GetDetail(id));
        }
        
        public async Task<IHttpActionResult> Post(Rm request)
        {
            return Ok(await service.SearchAsync(request));
        }
    }
}
