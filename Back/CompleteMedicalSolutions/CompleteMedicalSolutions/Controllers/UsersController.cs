using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.DTOs;
using Repository.Interfaces;

namespace CompleteMedicalSolutions.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {

        private readonly IRepository<UserDTO> _repository;

        public UsersController(IRepository<UserDTO> repository)
        {
            _repository = repository;
        }


        // GET: api/<controller>
        [HttpGet]
        public ActionResult<List<UserDTO>> Get()
        {
            try
            {
                var users = _repository.GetAllAsync();

                if (users == null)
                {
                    return NotFound(new { message = "ERROR" });
                }
                
                return Ok(users);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> Get(int id)
        {
            try
            {
                var user = await _repository.GetAsync(id);

                if (user == null)
                {
                    return NotFound(new { message = "NOT_FOUND" });
                }

                return Ok(user);

            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
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