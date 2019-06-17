using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace APIWithToken.Controllers
{
    public class ChartController : Controller
    {
        [Route("api/Chart")]
        public IActionResult Index()
        {
            XmlToJson();
            return View();
        }

        private void XmlToJson()
        {
            string xml = "<Attendances><Attendance><CompanyId>32</CompanyId><DeviceEmployeeId>2</DeviceEmployeeId><PunchTime>2019-05-31T14:54:57</PunchTime><BiometricDeviceId>OIN7040597030900588</BiometricDeviceId></Attendance><Attendance><CompanyId>32</CompanyId><DeviceEmployeeId>2</DeviceEmployeeId><PunchTime>2019-06-04T10:38:06</PunchTime><BiometricDeviceId>OIN7040597030900588</BiometricDeviceId></Attendance><Attendance><CompanyId>32</CompanyId><DeviceEmployeeId>2</DeviceEmployeeId><PunchTime>2019-06-04T10:38:08</PunchTime><BiometricDeviceId>OIN7040597030900588</BiometricDeviceId></Attendance><Attendance><CompanyId>32</CompanyId><DeviceEmployeeId>2</DeviceEmployeeId><PunchTime>2019-06-04T10:38:10</PunchTime><BiometricDeviceId>OIN7040597030900588</BiometricDeviceId></Attendance><Attendance><CompanyId>32</CompanyId><DeviceEmployeeId>2</DeviceEmployeeId><PunchTime>2019-06-04T10:38:12</PunchTime><BiometricDeviceId>OIN7040597030900588</BiometricDeviceId></Attendance></Attendances>";
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            string jsonText = JsonConvert.SerializeXmlNode(doc);

        }
        private void JsonToXml()
        {
            string json = "{\"employee\":{\"name\":\"John\",\"age\":\"30\", \"city\":\"New York\"}}";
            // To convert JSON text contained in string json into an XML node
            XmlDocument docx = JsonConvert.DeserializeXmlNode(json);


        }
    }
}