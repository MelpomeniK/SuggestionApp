using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SuggestionApp.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        [Required]
        public string? DepartmentName { get; set; }
        public bool isActive { get; set; }
        public string? Description { get; set; }
        public string? ManagerName { get; set; }

        public ICollection<User> Users { get; set; } = new List<User>();
        public ICollection<Suggestion> Suggestions { get; set; } = new List<Suggestion>();
    }
}
