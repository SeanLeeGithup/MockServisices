using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MLTWebAPIService.Models;

namespace MLTWebAPIService.Controllers
{
    public class MLTEventV2Controller : ApiController
    {
        static List<MLTEventV2Models> mevents = new List<MLTEventV2Models>()
        {
            new MLTEventV2Models() {Id=1, EventName="행복 찾기", EventType = 1},
            new MLTEventV2Models() {Id=2, EventName="친구 만들기", EventType = 4},
            new MLTEventV2Models() {Id=3, EventName="애인 만들기 찾기", EventType = 5}
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
                return NotFound();
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
