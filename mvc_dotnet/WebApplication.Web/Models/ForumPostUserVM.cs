﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models
{
    public class ForumPostUserVM
    {
        public ForumPost Post { get; set; }
        public User CurrentUser { get; set; }
    }
}
