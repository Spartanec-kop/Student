using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StudentData.Domain.Core
{
    public class Student
    {
        public Int64 Id { get; set; }
        [Required]
        public bool Sex { get; set; }

        [Required]
        [MaxLength(40)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
        [MaxLength(60)]
        public string MiddleName { get; set; }
        [MinLength(6)]
        [MaxLength(16)]
        public string NickName { get; set; }
        public List<StudentGroup> StudentGroups { get; set; }
        public Student()
        {
            StudentGroups = new List<StudentGroup>();
        }

    }
}
