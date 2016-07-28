using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HypermediaApiTests.Util;
using System.Net.Http;
using System.Net;

namespace HypermediaApiTests.Tests
{
    [TestClass]
    public class Test
    {

        [TestMethod]
        public void GoogleTest()
        {
            var response = Helper.CreateRequest("?p=test", HttpMethod.Get);

            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
        }
    }
}
