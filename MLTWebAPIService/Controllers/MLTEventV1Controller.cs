using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MLTWebAPIService.Models;

namespace MLTWebAPIService.Controllers
{
    [RoutePrefix("api/MLTEvent")]
    public class MLTEventV1Controller : ApiController
    {
        static List<MLTEventV1Models> mevents = new List<MLTEventV1Models>()
        {
            new MLTEventV1Models() {Id=1, EventName="행복 찾기"},
            new MLTEventV1Models() {Id=2, EventName="친구 만들기"},
            new MLTEventV1Models() {Id=3, EventName="애인 만들기 찾기"}
        };


        public IHttpActionResult Get ()
        {
            return Ok(mevents);
        }

        public IHttpActionResult Get(int id)
        {
            var mevent = mevents.FirstOrDefault(e => e.Id == id);
            if (mevent != null)
                return Ok(mevent);
            else
                return NotFound(); //return Content(HttpStatusCode.NotFound, "Event not found");
        }
        //[Route("{name:string}")]
        //public MLTEvent Get(string name)
        //{
        //    return mevents.FirstOrDefault(e => e.EventName.ToLower() == name.ToLower());
        //}
        //[Route("{id}/members")]
        //public IEnumerable<string> GetEventMember(int id)
        //{
        //    if(id==1)
        //        return new List<string>() {"김명자", "이한수", "임현식" };
        //    else if (id == 2)
        //        return new List<string>() { "김명자", "이한수", "임현식" };
        //    else
        //        return new List<string>() { "김명자", "이한수", "임현식" };
        //}

        //public HttpResponseMessage Post(MLTEvent mevent)
        //{
        //    mevents.Add(mevent);
        //    var response = Request.CreateResponse(HttpStatusCode.Created);
        //    response.Headers.Location = new Uri(Url.Link("GetEventById", new { id = mevent.Id }));
        //    return response;
        //}
    }
}
