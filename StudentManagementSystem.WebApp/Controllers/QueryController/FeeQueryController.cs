using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;
using FService = StudentManagementSystem.Service.FeeService;
using Repository = StudentManagementSystem.Repo.FeeRepository;
using Rm = StudentManagementSystem.Request.FeeRequestModel;
using M= StudentManagementSystem.Model.Fee;

namespace StudentManagementSystem.WebApp.Controllers.QueryController
{
    public class FeeQueryController : BaseQueryController<M>
    {
        private readonly FService service;

        public FeeQueryController()
        {
            service = new FService(new Repository(Db));
        }

        public IHttpActionResult Get(string id)
        {
            return Ok(service.GetDetail(id));
        }
        

        [ActionName("Data")]
        [HttpPost]
        public async Task<IHttpActionResult> Data(Rm request)
        {
            return Ok(await service.SearchAsync(request));
        }

        [ActionName("Count")]
        [HttpPost]
        public async Task<IHttpActionResult> Count(Rm request)
        {
            return Ok(await service.CountAsync(request));
        }

       
       
    }
}
