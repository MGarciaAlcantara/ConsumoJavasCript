using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL_WebApi.Controllers
{
    public class EntidadFederativaController : ApiController
    {
        // GET api/entidadfederativa
        [HttpGet]
        [Route("api/entidadfederativa")]
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.EntidadFederativa.GetAll();

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        // GET api/entidadfederativa/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/entidadfederativa
        public void Post([FromBody]string value)
        {
        }

        // PUT api/entidadfederativa/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/entidadfederativa/5
        public void Delete(int id)
        {
        }
    }
}
