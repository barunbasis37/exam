using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity.Owin;
using StudentManagementSystem.Model;
using StudentManagementSystem.Repo;
using StudentManagementSystem.Service;
using StudentManagementSystem.ViewMod;

namespace StudentManagementSystem.WebApp.Controllers
{
    public class DropdownController : ApiController
    {
        public async Task<IHttpActionResult> Get(string name)
        {            
            DropdownDataService service = new DropdownDataService(Request.GetOwinContext().Get<BusinessDbContext>());
            return Ok(await service.GetList(name.ToLower()));
        }        
    }
}
