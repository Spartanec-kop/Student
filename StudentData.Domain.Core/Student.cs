using System;
using System.Collections.Generic;
using System.Text;

namespace StudentData.Domain.Core
{
    public class Student
    {
        public int Id { get; set; }
        public bool Sex { get; set; }
        public string LastNam { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public List<StudentGroup> StudentGroups { get; set; }
        public Student()
        {
            StudentGroups = new List<StudentGroup>();
        }

    }
}
