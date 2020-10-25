using System;
using System.Collections.Generic;
using System.Text;

namespace StudentData.Services.Interfaces.ViewModel
{
    public class GroupView
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public int StudentCount { get; set; }
    }
}
