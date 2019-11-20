﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Common;
using Web;

namespace WebApiUsers.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsersController : ApiController<User>
    {

        public UsersController(IRepository<User> repository):base(repository)
        {
            
        }
    }
}
