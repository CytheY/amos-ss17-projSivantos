
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RaspberryBackend;

namespace RaspberryBackendTests
{
    [TestClass]
    public class RequestControllerTests
    {

        [TestMethod]
        public void TestXMLSerializerBackend()
        {
            Request req1 = new Request("read", 1);
            Request req2 = new Request("read", 1);
            Request req3 = new Request("write", 2);

            string req1XML = Serializer.Serialize(req1);
            string req2XML = Serializer.Serialize(req2);
            string req3XML = Serializer.Serialize(req3);

           // Assert.IsFalse(true);
           Assert.AreEqual(req1XML, req2XML);
           Assert.AreNotEqual(req1XML, req3XML);

        }


        // TODO implement test as soon as GPIOInterface is updated
        [TestMethod]
        public void TestSingleton()
        {
            //RequestController controller = RequestController.Instance;
            //RequestController controller2 = RequestController.Instance;
            //Assert.AreEqual(controller, controller2);
        }
    }
}
