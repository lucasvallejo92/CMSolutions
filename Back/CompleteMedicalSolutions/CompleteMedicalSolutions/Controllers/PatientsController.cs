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
    public class PatientsController : Controller
    {
        private readonly IRepository<PatientDTO> _repository;

        public PatientsController(IRepository<PatientDTO> repository)
        {
            _repository = repository;
        }


        // GET: api/<controller>
        [HttpGet]
        public ActionResult<List<PatientDTO>> Get()
        {
            try
            {
                var patients = _repository.GetAllAsync();

                if (patients == null)
                {
                    return NotFound(new { message = "ERROR" });
                }
                
                return Ok(patients);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientDTO>> Get(int id)
        {
            try
            {
                var patient = await _repository.GetAsync(id);

                if (patient == null)
                {
                    return NotFound(new { message = "NOT_FOUND" });
                }

                return Ok(patient);

            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // POST api/<controller>
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<bool>> Post([FromBody]PatientDTO patient)
        {
            try
            {
                if (patient.Id != 0)
                {
                    return StatusCode(400, new {message = "BAD_REQUEST"});
                }
                var created = await _repository.AddAsync(patient);
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
        public async Task<ActionResult<bool>> Put(int id, [FromBody]PatientDTO patient)
        {
            try
            {
                var updated = await _repository.UpdateAsync(id, patient);
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
    }
}