using System;
using System.Collections.Generic;
using System.Text;

namespace StudentData.Infrastructure.Business.ViewModel
{
    public class StudentView
    {
        public Int64 Id { get; set; }
        public bool Sex { get; set; }
        public string Fio { get; set; }
        public string NickName { get; set; }
        public string Groups { get; set; }
    }
}
