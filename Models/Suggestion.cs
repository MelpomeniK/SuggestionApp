using System;
using System.Collections.Generic;

namespace SuggestionApp.Models
{
    public class Suggestion
    {
        public int SuggestionId { get; set; }
        public string? Description { get; set; }
        public string? ApprovedBy { get; set;  } //αυτό κανονικά σαν τύπος είναι string αλλά τα ονόματα δεν θα τα παίρνουμε από Λίστα int από το user ID? Έχει κάποια σημασία;
        public bool isApproved { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ApprovalDate { get; set; }
        public int Likes { get; set; }
        public int Disliked { get; set; }

        public int CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }
        public ICollection<Department> Departments { get; set; }


    }
}
