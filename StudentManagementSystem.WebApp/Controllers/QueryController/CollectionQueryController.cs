using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using CService = StudentManagementSystem.Service.CollectionService;
using Repository = StudentManagementSystem.Repo.CollectionRepository;
using Rm = StudentManagementSystem.Request.CollectionRequestModel;
using M = StudentManagementSystem.Model.Collection;

namespace StudentManagementSystem.WebApp.Controllers.QueryController
{
    public class CollectionQueryController : BaseQueryController<M>
    {
        private readonly CService service;

        public CollectionQueryController()
        {
            service = new CService(new Repository(Db));
        }

        public IHttpActionResult Get(string id)
        {
            return Ok(service.GetDetail(id));
        }

        public async Task<IHttpActionResult> Get(string keyword, string orderBy, string isAsc)
        {
            var request = new Rm(keyword, orderBy, isAsc);
            var products = await service.SearchAsync(request);
            return Ok(products);
        }


        public async Task<IHttpActionResult> Post(Rm request)
        {
            return Ok(await service.SearchAsync(request));
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
