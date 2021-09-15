using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ASF.Data;
using ASF.Entities;

namespace ASF.Test
{
    [TestClass]
    public class ClientDACTests
    {
        [TestMethod]
        public void Test_FindClientById()
        {
            var dac = new ClientDAC();

            var result = dac.FindById<Client>(1);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, new Client().GetType());
        }
    }
}
