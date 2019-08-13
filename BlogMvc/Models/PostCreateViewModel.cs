using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogMvc.Models
{
    public class PostCreateViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
    }
}