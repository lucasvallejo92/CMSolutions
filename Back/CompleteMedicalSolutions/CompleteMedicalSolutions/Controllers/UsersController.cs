using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CompleteMedicalSolutions.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.DTOs;
using Repository.Interfaces;
using Repository.Models;

namespace CompleteMedicalSolutions.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {

        private readonly IRepository<UserDTO> _repository;
        private readonly IAuthRepository<UserDTO> _authRepository;

        public UsersController(IRepository<UserDTO> repository, IAuthRepository<UserDTO> authRepository)
        {
            _repository = repository;
            _authRepository = authRepository;
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
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<bool>> Post([FromBody]UserDTO user)
        {
            try
            {
                if (user.Id != 0)
                {
                    return StatusCode(400, new {message = "BAD_REQUEST"});
                }
                var created = await _repository.AddAsync(user);
                var response = created ?
                    StatusCode(201, new {message = "CREATED"}):
                    StatusCode(400, new {message = "ALREADY_EXISTS"});
                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> Put(int id, [FromBody]UserDTO user)
        {
            try
            {
                var updated = await _repository.UpdateAsync(id, user);
                var response = updated ?
                    StatusCode(201, new {message = "UPDATED"}):
                    StatusCode(400, new {message = "CANNOT_UPDATE"});
                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500);
            }
        }
        
        // POST api/<controller>
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult> LogIn([FromBody]UserCredentials credentials)
        {
            try
            {
                var user = await _authRepository.AuthorizeAsync(credentials);
                
                if (user == null)
                {
                    return NotFound();
                }
                
                var key = TokenHandler.CreateToken(user);
                return new ObjectResult(new { token = key });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500);
            }
        }
    }
}