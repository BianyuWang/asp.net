using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogMvc.Models
{
    public class AddCommentViewModel
    {
        [Required]
        public string Content { get; set; }
        [Required]
        public int PostId { get; set; }
    }
}