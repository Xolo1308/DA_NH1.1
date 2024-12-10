using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace DA_NH.Models
{
    public class User
    {
        
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? FullName { get; set; }
        public string? Phone { get; set; }
        public DateTime? DateCreate { get; set; }
        public string? Address { get; set; }
		public bool? IsActive { get; set; }

    }
}
