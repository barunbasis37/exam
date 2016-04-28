using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SService = StudentManagementSystem.Service.StudentService;
using Repository = StudentManagementSystem.Repo.StudentRepository;
using Rm = StudentManagementSystem.Request.StudentRequestModel;
using M = StudentManagementSystem.Model.Student;


namespace StudentManagementSystem.WebApp.Controllers.QueryController
{
    public class StudentHistoryQueryController : BaseQueryController<M>
    {
        private readonly SService service;

        public StudentHistoryQueryController()
        {
            service = new SService(new Repository(Db));
        }
         
        public async Task<IHttpActionResult> Post(Rm request)
        {
            return Ok(await service.GetHistoryAsync(request.Id));
        }
    }
}
