using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BlogMvc.Models
{
    public class PostViewModel
    {
        public static Expression<Func<Posts, PostViewModel>> FromPost
        {
            get
            {
                return post => new PostViewModel
                {
                    Id = post.Id,
                    Title = post.Title,
                    Content = post.Content,
                    UserFullName = post.UserFullName,
                    CreatedOn = post.CreatedOn
                };
            }
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string UserFullName { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}