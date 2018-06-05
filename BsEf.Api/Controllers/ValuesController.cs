using System.Collections.Generic;
using System.Web.Http;

namespace BsEf.Api.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        // POST api/values
        [HttpPost]
        public void Post([FromBody]object value)
        {

        }

        // PUT api/values
        [HttpPut]
        public void Put([FromBody]object value)
        {

        }

        // PUT api/values
        [HttpPut]
        public void Put()
        {

        }

        // DELETE api/values/{id}
        [HttpDelete]
        public void Delete(int id)
        {

        }

        // GET api/values
        [HttpGet]
        public IEnumerable<object> Get()
        {
            return new[]{ "value1", "value2" };
        }

        // GET api/values/{id}
        [HttpGet]
        public object Get(int id)
        {
            return "value";
        }
    }
}