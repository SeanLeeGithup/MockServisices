using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace MLTWebAPIService.Custom
{
    public class CustomControllerSelector : DefaultHttpControllerSelector
    {
        HttpConfiguration _config;
        public CustomControllerSelector(HttpConfiguration config) : base(config)
        {
            _config = config;
        }

        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            var controllers = GetControllerMapping();
            var routeData = request.GetRouteData();

            var controllerName = routeData.Values["controller"].ToString();

            string versionNumber = "1";

            //using query string
            var versionQueryString = HttpUtility.ParseQueryString(request.RequestUri.Query);
            if (versionQueryString["v"] != null)
            {
                versionNumber = versionQueryString["v"];
            }

            //using custom header
            //string customHeader = "X-MLTEventService-Version";
            //if (request.Headers.Contains(customHeader))
            //{
            //    versionNumber = request.Headers.GetValues(customHeader).FirstOrDefault();
            //    if (versionNumber.Contains(","))
            //    {
            //        versionNumber = versionNumber.Substring(0, versionNumber.IndexOf(","));
            //    }
            //}

            //accept header withversion
            //var acceptHeader = request.Headers.Accept.Where(a => a.Parameters.Count(p => p.Name.ToLower() == "version") > 0);

            //if(acceptHeader.Any())
            //{
            //    versionNumber = acceptHeader.First().Parameters.First(p => p.Name.ToLower() == "version").Value;
            //}

            if (versionNumber == "1")
            {
                controllerName = controllerName + "V1";
            }
            else
                controllerName = controllerName + "V2";

            HttpControllerDescriptor controllerDescriptor;
            if (controllers.TryGetValue(controllerName, out controllerDescriptor))
                return controllerDescriptor;

            return null;

        }
    }
}