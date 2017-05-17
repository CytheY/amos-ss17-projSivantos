using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestmachineFrontend;

namespace TestmachineFrontendTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void setUp()
        {
            
        }

        [TestMethod]
        public void TestXMLSerializer()
        {
            Request req1 = new Request("read", 1);
            Request req2 = new Request("read", 1);
            Request req3 = new Request("write", 2);

            string req1XML = Serializer.Serialize(req1);
            string req2XML = Serializer.Serialize(req2);
            string req3XML = Serializer.Serialize(req3);


            Assert.AreEqual(req1XML, req2XML);
            Assert.AreNotEqual(req1XML, req3XML);
            
        }

        [TestCleanup]
        public void tearDown()
        {

        }
    }
}
