using Autofac.Extras.Multitenant.Web;
using Moq;
using NUnit.Framework;
using SimpleLogin.Authentications;
using SimpleLogin.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SimpleLogin.Test.Controllers
{
    [TestFixture]
    public class TwitterControllerTest
    {
        [Test]
        public void When_Call_Index_Action_Should_Return_Valid_Model()
        {
            var expected = new Models.LoginModel()
            {
                Email = "foo@bar.com",
                Password = "1234",
                Source = "Twitter"
            };
            var service = new TwitterAuthentication();
            var tenantIdStrategy = new RequestParameterTenantIdentificationStrategy("tenant");
            var controller = new TwitterController(service, tenantIdStrategy);
            var actionResult = controller.Index();
            var viewResult = actionResult as ViewResult;
            var actual = viewResult.ViewData.Model as Models.LoginModel;
            Assert.AreEqual(expected.Email, actual.Email);
            Assert.AreEqual(expected.Password, actual.Password);
            Assert.AreEqual(expected.Source, actual.Source);
        }
    }
}
