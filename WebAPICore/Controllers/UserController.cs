using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPICore.Model.DBContext;
using WebAPICore.Repository.Repository.Abstract;

namespace WebAPICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork UnitOfWork;
        public UserController(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }
        // GET: api/User
        [HttpGet]
        public IEnumerable Get()
        {
            return this.UnitOfWork.UserRepository.Get();            
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
