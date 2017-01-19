using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Xml;
using System.Xml.Linq;
using log4net;
using log4net.Config;
using Newtonsoft.Json;

namespace Evaluation
{
    /// <summary>
    /// Summary description for MyService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ScriptService]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MyService : System.Web.Services.WebService
    {
        protected readonly ILog _log = LogManager.GetLogger(typeof(MyService));

        public MyService() 
        {

            XmlConfigurator.Configure();
            _log = LogManager.GetLogger(typeof(MyService));
            _log.Info("Service is Initialized ");
       
        }




        [WebMethod]
        public int Fibonacci(int number)
        {
            try
            {
                _log.Info("Fibonacci method start ");

                if (number == 0)
                    return 0;

                if (number < 1 || number > 100)
                    return -1;

                if (number == 1)
                    return 1;

                _log.Info("Fibonacci method finished ");

                return Fibonacci(number - 1) + Fibonacci(number - 2);
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                throw;
            }
        }

        
        //[WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)] // To get Json in response
        public string XmlToJson(string xml)
        {
            try
            {
                _log.Info("XmlToJson method start ");

                //var json = new JavaScriptSerializer().Serialize(ParseXml(XElement.Parse(xml)));
                var json = JsonConvert.SerializeObject(ParseXml(XElement.Parse(xml)));

                _log.Info("XmlToJson method finished ");

                return json;
            }

            catch (XmlException ex)
            {
                _log.Info("Bad XML Format ");
                return "Bad XML Format";
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                throw;
            }

        }

         private Dictionary<string, object> ParseXml(XElement xml)
         {
             var dict = new Dictionary<string, object>();

             if (xml != null  && xml.HasElements)
                 dict.Add(xml.Name.LocalName, xml.Elements()
                                                    .SelectMany(e => ParseXml(e))
                                                    .ToDictionary(x => x.Key, y => y.Value));
             else if (!xml.IsEmpty)
                 dict.Add(xml.Name.LocalName, xml.Value);

             return dict; 
         }




       


    }
}
