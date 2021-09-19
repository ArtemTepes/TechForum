using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TechForum.Models.Items
{
    public class Post
    {
        public int PostId { get; set; }

        [Required]
        [Display(Name = "Post Title")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Post body")]
        public string Text { get; set; }
        [Display(Name = "Created")]
        public DateTime? PostDate { get; set; }

        [Display(Name = "Name of creator")]
        public string UserName { get; set; }

        public virtual Topic Topic { get; set; }  
        public int TopicId { get; set; }
    }
}