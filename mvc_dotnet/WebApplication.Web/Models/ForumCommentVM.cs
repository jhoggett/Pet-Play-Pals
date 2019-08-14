using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models
{
    public class ForumCommentVM
    {
        public ForumPostComments Comment { get; set; }
        public User CurrentUser { get; set; }
        public int PostId { get; set; }
    }
}
