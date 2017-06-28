using Microsoft.VisualStudio.TestTools.UnitTesting;
using RaspberryBackend;
using System;

namespace RaspberryBackendTests
{
    [TestClass]
    public class MultiplexerTests
    {

        private Multiplexer mux;
        
        [TestInitialize]
        public void setUp()
        {
            mux = new Multiplexer();
        }

        //Tests if unknown requests creates the corresponding exception
        [TestMethod]
        public void TestSetDefaultMultiplexerConfig()
        {
            mux.setMultiplexerConfiguration();

            Assert.AreEqual(mux.get_Value_conntected_to_X(0), "");
            Assert.AreEqual(mux.get_Value_conntected_to_X(1), "RockerSW");
            Assert.AreEqual(mux.get_Value_conntected_to_X(2), "Ground");
            Assert.AreEqual(mux.get_Value_conntected_to_X(3), "Ground");
            Assert.AreEqual(mux.get_Value_conntected_to_X(4), "");
            Assert.AreEqual(mux.get_Value_conntected_to_X(5), "");
            Assert.AreEqual(mux.get_Value_conntected_to_X(6), "");
            Assert.AreEqual(mux.get_Value_conntected_to_X(7), "");
            Assert.AreEqual(mux.get_Value_conntected_to_X(8), "Ground");
            Assert.AreEqual(mux.get_Value_conntected_to_X(9), "PB");

            Assert.AreEqual(mux.get_Y_conntected_to_X(0), -1);
            Assert.AreEqual(mux.get_Y_conntected_to_X(1), YPinConfig._gpio_to_Y_map["RockerSW"]);
            Assert.AreEqual(mux.get_Y_conntected_to_X(2), YPinConfig._gpio_to_Y_map["Ground"]);
            Assert.AreEqual(mux.get_Y_conntected_to_X(3), YPinConfig._gpio_to_Y_map["Ground"]);
            Assert.AreEqual(mux.get_Y_conntected_to_X(4), -1);
            Assert.AreEqual(mux.get_Y_conntected_to_X(5), -1);
            Assert.AreEqual(mux.get_Y_conntected_to_X(6), -1);
            Assert.AreEqual(mux.get_Y_conntected_to_X(7), -1);
            Assert.AreEqual(mux.get_Y_conntected_to_X(8), YPinConfig._gpio_to_Y_map["Ground"]);
            Assert.AreEqual(mux.get_Y_conntected_to_X(9), YPinConfig._gpio_to_Y_map["PB"]);
        }

        [TestMethod]
        public void TestSetMultiplexerConfig()
        {
            mux.setMultiplexerConfiguration("D9_RIC13", "702 S (DN)");

            Assert.AreEqual(mux.get_Value_conntected_to_X(0), "Ground");
            Assert.AreEqual(mux.get_Value_conntected_to_X(1), "Ground");
            Assert.AreEqual(mux.get_Value_conntected_to_X(2), "");
            Assert.AreEqual(mux.get_Value_conntected_to_X(3), "");
            Assert.AreEqual(mux.get_Value_conntected_to_X(4), "REC_DET");
            Assert.AreEqual(mux.get_Value_conntected_to_X(5), "Ground");
            Assert.AreEqual(mux.get_Value_conntected_to_X(6), "");
            Assert.AreEqual(mux.get_Value_conntected_to_X(7), "Ground");
            Assert.AreEqual(mux.get_Value_conntected_to_X(8), "");
            Assert.AreEqual(mux.get_Value_conntected_to_X(9), "RockerSW");

            Assert.AreEqual(mux.get_Y_conntected_to_X(0), YPinConfig._gpio_to_Y_map["Ground"]);
            Assert.AreEqual(mux.get_Y_conntected_to_X(1), YPinConfig._gpio_to_Y_map["Ground"]);
            Assert.AreEqual(mux.get_Y_conntected_to_X(2), -1);
            Assert.AreEqual(mux.get_Y_conntected_to_X(3), -1);
            Assert.AreEqual(mux.get_Y_conntected_to_X(4), YPinConfig._gpio_to_Y_map["REC_DET"]);
            Assert.AreEqual(mux.get_Y_conntected_to_X(5), YPinConfig._gpio_to_Y_map["Ground"]);
            Assert.AreEqual(mux.get_Y_conntected_to_X(6), -1);
            Assert.AreEqual(mux.get_Y_conntected_to_X(7), YPinConfig._gpio_to_Y_map["Ground"]);
            Assert.AreEqual(mux.get_Y_conntected_to_X(8), -1);
            Assert.AreEqual(mux.get_Y_conntected_to_X(9), YPinConfig._gpio_to_Y_map["RockerSW"]);
        }


        [TestCleanup]
        public void tearDown()
        {
           
        }
    }
}
