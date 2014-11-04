using Autofac.Extras.Multitenant;
using SimpleLogin.Authentications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleLogin.Controllers
{
    public class TwitterController : Controller
    {
        private IAuthentication service;
        private ITenantIdentificationStrategy tenantIdentificationStrategy;

        public TwitterController(IAuthentication service, ITenantIdentificationStrategy tenantIdStrategy)
        {
            this.service = service;
            this.tenantIdentificationStrategy = tenantIdStrategy;
        }

        // GET: Twitter
        public ActionResult Index()
        {
            return View(this.service.Authenticate("foo@bar.com", "1234"));
        }
    }
}