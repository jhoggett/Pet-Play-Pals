using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models
{
    public class ForumPost
    {
        [Required]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "username must be atleast 1 character and cant exceed 20 characters.")]
        public string User { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 2)]
        public string Subject { get; set; }

        [Required]
        public string Message { get; set; }

        public DateTime Post_Date { get; set; }

        public int Id { get; set; }
    }
}
