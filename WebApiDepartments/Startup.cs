using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(WebApiDepartments.Startup))]

namespace WebApiDepartments
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
