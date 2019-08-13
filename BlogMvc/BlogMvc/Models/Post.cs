using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlogMvc.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(MAX)")]
        public String Title { get; set; }

        [Required]
        [Column(TypeName = "varchar(MAX)")]
        [DataType(DataType.MultilineText)]
        public String Content { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public DateTime? PostedOn { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        public String UserFullName { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}