using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentData.Domain.Interfaces;
using StudentData.Services.Interfaces;
using SG = StudentData.Domain.Core;

namespace StudentData.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        IRepository<SG.Group> repositoryGroup;
        IGroupsServices groupServices;

        public GroupsController(IRepository<SG.Group> repository, IGroupsServices services)
        {
            repositoryGroup = repository;
            groupServices = services;
        }
        // GET: api/<GroupsController>
        [HttpGet]
        public async Task<IEnumerable<SG.Group>> Get()
        {
            return await repositoryGroup.GetAll();
        }

        // GET api/<GroupsController>/5
        [HttpGet("{id}")]
        public async Task<SG.Group> Get(int id)
        {
            return await repositoryGroup.GetId(id);
        }

        // POST api/<GroupsController>
        [HttpPost]
        public void Post([FromBody] SG.Group group)
        {
            groupServices.Create(group);
        }

        // PUT api/<GroupsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] SG.Group group)
        {
            groupServices.Update(group);
        }

        // DELETE api/<GroupsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            groupServices.Delete(id);
        }
    }
}
