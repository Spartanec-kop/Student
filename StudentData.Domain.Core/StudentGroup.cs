using System;
using System.Collections.Generic;
using System.Text;

namespace StudentData.Domain.Core
{
    public class StudentGroup
    {
        public Int64 StudentId { get; set; }
        public Student Student { get; set; }

        public Int64 GroupId { get; set; }
        public Group Group { get; set; }
    }
}
