using System;
using CompleteMedicalSolutions.Utils;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Repository.Models;

namespace CompleteMedicalSolutions.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        
        
        // LogIn POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody]UserCredentials credentials)
        {
            try
            {
                var key = TokenHandler.CreateToken();
                return new ObjectResult(new { token = key });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500);
            }
        }

        // ChangePass PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}