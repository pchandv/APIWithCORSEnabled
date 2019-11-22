using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.IO.Compression;
//using System.IO.Compression.FileSystem;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using System.Text;

namespace SAT_API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }


        //public string Post([FromBody]string helloMesage)
        //{
        //    return helloMesage + "- Coming from API";

        //}

        //public string Post([FromBody]Dummy dm)
        //{
        //    return "FirstName: "+ dm.Firstname+",LastName: "+dm.LastName+ ",Response format Coming from API";
        //}
        //public IHttpActionResult Post([FromBody]Dummy dm)
        //{
        //    //return "FirstName: " + dm.Firstname + ",LastName: " + dm.LastName + ",Response format Coming from API";

        //    return 

        //}

        public HttpResponseMessage Post([FromBody]Dummy dm)
        {
            HttpResponseMessage result = new HttpResponseMessage();
            try
            {
                result.Content = new ByteArrayContent(CreateZip(dm));
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/zip");
                result.StatusCode = HttpStatusCode.OK;
                throw new Exception();
                return result;
            }
            catch (Exception ex)
            {
                var json = JsonConvert.SerializeObject(dm);
                result.Content = new StringContent("{'error':'" + json + "'}",Encoding.UTF8, "application/json");
                result.StatusCode = HttpStatusCode.InternalServerError;
                //result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                return result;
            }
        }   




        // POST api/values
        //public HttpResponseMessage Post(string param)
        //{
        //    HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
        //    result.Content = new ByteArrayContent(CreateZip(param));
        //    result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/zip");
        //    return result;
        //}

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }


        private byte[] CreateZip(Dummy data)
        {
            using (var ms = new MemoryStream())
            {
                using (var ar = new ZipArchive(ms, ZipArchiveMode.Create, true))
                {
                    var file = ar.CreateEntry("file.html");

                    using (var entryStream = file.Open())
                    using (var sw = new StreamWriter(entryStream))
                    {
                        sw.Write(data);
                    }
                }
                return ms.ToArray();
            }
        }





    }

    public class Dummy
    {
        public string Firstname { get; set; }
        public string LastName { get; set; }
    }



}
