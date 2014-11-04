using Autofac.Extras.Multitenant;
using SimpleLogin.Authentications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleLogin.Controllers
{
    public class FacebookController : Controller
    {
        private IAuthentication service;
        private ITenantIdentificationStrategy tenantIdentificationStrategy;

        public FacebookController(IAuthentication service, ITenantIdentificationStrategy tenantIdStrategy)
        {
            this.service = service;
            this.tenantIdentificationStrategy = tenantIdStrategy;
        }

        // GET: Facebook
        public ActionResult Index()
        {
            return View(this.service.Authenticate("foo@bar.com", "1234"));
        }
    }
}