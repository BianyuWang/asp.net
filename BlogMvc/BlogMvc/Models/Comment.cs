using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogMvc.Models
{
    public class Comment

    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(MAX)")]
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public String Content { get; set; }


        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

       
        public ApplicationUser User { get; set; }
        [Required]
        
        public String UseFullName { get; set; }

        public Post Post { get; set; }

        [Required]
        public int PostId { get; set; }

        [Required ]
        [DefaultValue("false")]
        public bool IsPublished { get; set; }


    }
}