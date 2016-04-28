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
using StudentManagementSystem.Model;
using StudentManagementSystem.Repo;
using StudentManagementSystem.Service;
using StudentManagementSystem.Request;
using StudentManagementSystem.ViewMod;
using PService = StudentManagementSystem.Service.PaymentService;
using Repository = StudentManagementSystem.Repo.PaymentRepository;
using Rm = StudentManagementSystem.Request.PaymentRequestModel;
using M = StudentManagementSystem.Model.Payment;


namespace StudentManagementSystem.WebApp.Controllers.QueryController
{
    public class PaymentQueryController : BaseQueryController<M>
    {
        private readonly PService service;

        public PaymentQueryController()
        {
            service = new PService(new Repository(Db));
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
