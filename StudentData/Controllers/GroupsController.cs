using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentData.Domain.Interfaces;
using StudentData.Services.Interfaces;
using StudentData.Services.Interfaces.ViewModel;
using SG = StudentData.Domain.Core;

namespace StudentData.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        IGroupsServices groupServices;

        public GroupsController(IGroupsServices services)
        {
            groupServices = services;
        }
        // GET: api/<GroupsController>
        [HttpGet]
        public async Task<PagedViewModel<GroupView>> Get(string name, int pageNumber, int pageSize)
        {
            return await groupServices.GetGroups(name, pageNumber, pageSize);
        }

        // POST api/<GroupsController>
        [HttpPost]
        public void Post([FromBody] SG.Group group)
        {
            groupServices.Create(group);
        }

        // PUT api/<GroupsController>
        [HttpPut]
        public void Put([FromBody] SG.Group group)
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
