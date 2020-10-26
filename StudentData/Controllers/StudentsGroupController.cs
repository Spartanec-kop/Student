using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentData.Services.Interfaces;

namespace StudentData.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class StudentsGroupController : ControllerBase
    {
        IStudentGroupServices StudentGroupServices;
        public StudentsGroupController(IStudentGroupServices studentGroup)
        {
            StudentGroupServices = studentGroup;
        }

        // POST api/<StudentsGroupController>
        [HttpPost]
        public void Post(long studentId, long groupId)
        {
            StudentGroupServices.AddStudentToGroup(studentId, groupId);
        }

        // DELETE api/<StudentsGroupController>/5
        [HttpDelete]
        public void Delete(long studentId, long groupId)
        {
            StudentGroupServices.RemoveStudentfromGroup(studentId, groupId);
        }
    }
}
