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

        public string Post([FromBody]Dummy dm)
        {
            return "FirstName: "+ dm.Firstname+",LastName: "+dm.LastName+ ",Response format Coming from API";
        }


        // POST api/values
        //public HttpResponseMessage Post(string param)
        //{
        //    HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
        //    result.Content = new ByteArrayContent(CreateZip(param));
        //    result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/zip, application/octet-stream");
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


        //private byte[] CreateZip(string data)
        //{
        //    using (var ms = new MemoryStream())
        //    {
        //        using (var ar = new ZipArchive(ms, ZipArchiveMode.Create, true))
        //        {
        //            var file = ar.CreateEntry("file.html");

        //            using (var entryStream = file.Open())
        //            using (var sw = new StreamWriter(entryStream))
        //            {
        //                sw.Write(data);
        //            }
        //        }
        //        return ms.ToArray();
        //    }
        //}





    }

    public class Dummy
    {
        public string Firstname { get; set; }
        public string LastName { get; set; }
    }



}
