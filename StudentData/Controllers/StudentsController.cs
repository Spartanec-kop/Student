using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentData.Domain.Core;
using StudentData.Domain.Interfaces;
using StudentData.Infrastructure.Business.ViewModel;
using StudentData.Services.Interfaces;
using StudentData.Services.Interfaces.Models;
using StudentData.Services.Interfaces.ViewModel;

namespace StudentData.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        IStudentsServices studentsServices;
        public StudentsController( IStudentsServices services)
        {
            studentsServices = services;
        }
        // GET: api/<StudentsController>
        [HttpGet]
        public async Task<PagedViewModel<StudentView>> Get([FromQuery] StudentFilters filters, int pageNumber, int pageSize)
        {
            return await studentsServices.GetStudents(filters, pageNumber, pageSize);
        }

        // POST api/<StudentsController>
        [HttpPost]
        public void Post([FromBody] Student student)
        {
            studentsServices.Create(student);
        }

        // PUT api/<StudentsController>
        [HttpPut]
        public void Put([FromBody] Student student)
        {
            studentsServices.Update(student);
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            studentsServices.Delete(id);
        }
    }
}
