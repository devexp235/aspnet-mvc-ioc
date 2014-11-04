﻿using Moq;
using NUnit.Framework;
using SimpleLogin.Authentications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogin.Test.Authentications
{
    [TestFixture]
    public class AuthenticationTest
    {
        [Test]
        public void When_Authenticate_With_Fake_Service_Should_Return_Success()
        {
            var expected = new Models.LoginModel()
            {
                Email = "fake@email.com",
                Password = "1234",
                Source = "Fake Service"
            };

            var mock = new Mock<IAuthentication>();
            mock.Setup(p => p.Authenticate(It.IsAny<string>(), It.IsAny<string>())).Returns(expected);

            var service = mock.Object;
            var actual = service.Authenticate("fake@email.com", "1234");
            Assert.AreEqual(expected.Email, actual.Email);
            Assert.AreEqual(expected.Password, actual.Password);
            Assert.AreEqual(expected.Source, actual.Source);
        }
    }
}