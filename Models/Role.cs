using System;
using System.Collections.Generic;

namespace SuggestionApp.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool isActive { get; set; }
        public bool IsManager { get; set; }
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
