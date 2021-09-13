using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL_WebApi.Controllers
{
    public class EmpleadoController : ApiController
    {
        // GET api/empleado

        [Route("api/empleado")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.Empleado.GetAll();

            if (result.Correct)
            {
                return Ok(result);

            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }


        }

        // GET api/empleado/5

        [Route("api/empleado/{IdEmpleado}")]
        [HttpGet]
        public IHttpActionResult GetById(int IdEmpleado)
        {
            ML.Result result = BL.Empleado.GetById(IdEmpleado);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }

        }

        // POST api/empleado

        [Route("api/empleado")]
        [HttpPost]
        public IHttpActionResult Add([FromBody]ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.Add(empleado);

            if (result.Correct)
            {
                return Ok(result);

            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);

            }
        }

        // PUT api/empleado/5
        [Route("api/empleado/{IdEmpleado}")]
        [HttpPut]
        public IHttpActionResult Update(int IdEmpleado, [FromBody]ML.Empleado empleado)
        {
            
            empleado.Id = IdEmpleado;
            ML.Result result = BL.Empleado.Update(empleado);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        // DELETE api/empleado/5
        [Route("api/empleado/{IdEmpleado}")]
        [HttpDelete]
        public IHttpActionResult Delete(int IdEmpleado)
        {
            ML.Result result = BL.Empleado.Delete(IdEmpleado);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }

        }
    }
}
