using OpsPortal.Attributes;
using OpsPortal.Entities;
using OpsPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace OpsPortal.Controllers
{
    //public class JenkinsJobEntity
    //{
    //    public string ServiceName { get; set; }
    //    /// <summary>
    //    /// 0 - defailt(Red), 1-Success(Green), 2-Exception(Yellow)
    //    /// </summary>
    //    public int Status { get; set; }

    //    public DateTime StartTime { get; set; }
    //    public DateTime EndTime { get; set; }

    //    public DateTime LatertTime { get; set; }

    //    public int BuildNumber { get; set; }

    //    //public string Weherate { get; set; }

    //    //public int Duration { get; set; }
    //}

    public class JenkinsJobApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        //// GET: api/JenkinsJob
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/JenkinsJob/5
        //public string Get(int id)
        //{
        //    return "value";
        //}


        //// POST: api/JenkinsJob
        //public void Post([FromBody]string value)
        //{

        //}

        // POST: 
        public async Task<HttpResponseMessage> Post([FromBody]JenkinsJobEntity job)
        {
            try
            {
                db.JenkinsJobEntities.Add(job);
                await db.SaveChangesAsync();

                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("Operation is success", System.Text.Encoding.UTF8, "text/plain")
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.ExpectationFailed)
                {
                    Content = new StringContent("Add jenkins job record data failed", System.Text.Encoding.UTF8, "text/plain")
                };
            }
        }


        //// DELETE: api/JenkinsJob/5
        //public void Delete(int id)
        //{
        //}
    }
}
