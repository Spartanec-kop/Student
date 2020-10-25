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
        IRepository<Student> repositoryStudent;
        IStudentsServices studentsServices;
        public StudentsController(IRepository<Student> repository, IStudentsServices services)
        {
            repositoryStudent = repository;
            studentsServices = services;
        }
        // GET: api/<StudentsController>
        [HttpGet]
        public async Task<PagedViewModel<StudentView>> Get([FromQuery] StudentFilters filters, int pageNumber, int pageSize)
        {
            return await studentsServices.GetStudents(filters, pageNumber, pageSize);
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public async Task<Student> Get(int id)
        {
            return await repositoryStudent.GetId(id);
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
