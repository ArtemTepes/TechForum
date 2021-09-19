
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TechForum.Models.Items
{
    public class Topic
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Created")]
        public DateTime? PostDate { get; set; }

        [Display(Name = "Topic description")]
        public string Text { get; set; }

        [Display(Name = "Topic title")]
        public string Title { get; set; }

        [Display(Name = "Name of creator")]
        public string UserName { get; set; }
        public virtual ICollection<Post> Posts { get; set; }

        public Topic()
        {
            Posts = new List<Post>();
        }
    }
}