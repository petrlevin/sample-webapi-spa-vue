using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Common;
using Web;


namespace WebApiDepartments.Controllers
{

    public class DepartmentsController : ApiController<Department>
    {
        public DepartmentsController(IRepository<Department> repository):base(repository)
        {
            
        }
 
    }
}
