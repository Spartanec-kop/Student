using System;
using System.Collections.Generic;
using System.Text;

namespace StudentData.Domain.Core
{
    public class Group
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public List<StudentGroup> StudentGroups { get; set; }

        public Group()
        {
            StudentGroups = new List<StudentGroup>();
        }
    }
}
