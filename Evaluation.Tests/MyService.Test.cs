using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Evaluation;
using Newtonsoft.Json.Linq;

namespace Evaluation.Tests
{
    [TestClass]
    public class UnitTest1
    {
        #region Fibonacci Unit test
        [TestMethod]
        // Check if  Fibonacci(0) == 0
        public void Check_Fibonacci_0()
        {
            var service = new MyService();

            int number = service.Fibonacci(0);

            Assert.AreEqual( number, 0);
        }

        [TestMethod]
        // Check if  Fibonacci(101) == -1
        public void Check_Fibonacci_101()
        {
            var service = new MyService();

            int number = service.Fibonacci(101);

            Assert.AreEqual(number, -1);
        }

        [TestMethod]
        // Check if  Fibonacci(2) == 1
        public void Check_Fibonacci_2()
        {
            var service = new MyService();

            int number = service.Fibonacci(2);

            Assert.AreEqual(number, 1);
        }


        [TestMethod]
        // Check if  Fibonacci(5) == 5
        public void Check_Fibonacci_5()
        {
            var service = new MyService();

            int number = service.Fibonacci(5);

            Assert.AreEqual(number, 5);
        }

        [TestMethod]
        // Check if  Fibonacci(6) == 8
        public void Check_Fibonacci_6()
        {
            var service = new MyService();

            int number = service.Fibonacci(6);

            Assert.AreEqual(number, 8);
        }
        #endregion

        #region XmlToJson Unit Test
        

        [TestMethod]
        // Check if  Fibonacci(0) == 0
        public void Check_XmlToJson_XML_FORMAT_NOTWELL()
        {
            var service = new MyService();

            string myJson = service.XmlToJson("<foo>hello</ba>");

            Assert.AreEqual(myJson, "Bad XML Format");
        }

        [TestMethod]
        public void Check_XmlToJson_SIMPLE_XML()
        {
            var service = new MyService();

            string myJson = service.XmlToJson("<foo>bar</foo>");

            // convert JSON to object
            var resultJson = JObject.Parse(myJson);
            var actualJson = JObject.Parse("{ \"foo\" : \"bar\" }");


            Assert.IsTrue(JToken.DeepEquals(resultJson, actualJson));
        }

        [TestMethod]
        public void Check_XmlToJson_LONG_XML()
        {
            var service = new MyService();

            string myJson = service.XmlToJson("<TRANS><HPAY><lD>103</lD><STATUS>3</STATUS><EXTRA><lS3DS>0</lS3DS><AUTH>031183</AUTH></EXTRA><lNT_MSG /><MLABEL>501767XXXXXX6700</MLABEL><MTOKEN>projectOl</MTOKEN></HPAY></TRANS>");

            // convert JSON to object
            var resultJson = JObject.Parse(myJson);
            var actualJson = JObject.Parse("{\"TRANS\":{\"HPAY\":{\"lD\":\"103\",\"STATUS\":\"3\",\"EXTRA\":{\"lS3DS\":\"0\",\"AUTH\":\"03'1183\"},\"MLABEL\":\"501767XXXXXX6700\",\"MTOKEN\":\"projectOl\"}}}");


            Assert.IsTrue(JToken.DeepEquals(resultJson, actualJson));
        }

        #endregion
    } 


}
