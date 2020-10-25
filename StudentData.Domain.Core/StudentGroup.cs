using System;
using System.Collections.Generic;
using System.Text;

namespace StudentData.Domain.Core
{
    public class StudentGroup
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
