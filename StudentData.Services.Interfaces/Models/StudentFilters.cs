using System;
using System.Collections.Generic;
using System.Text;

namespace StudentData.Services.Interfaces.Models
{
    public class StudentFilters
    {
        public bool? Sex { get; set; }
        public string Fio { get; set; }
        public string NickName { get; set; }
        public string GroupName { get; set; }
    }
}
