using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogProject.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string YorumBaslik { get; set; }
        public string YorumIcerik { get; set; }

        public int ArticleId { get; set; }
        public int PeopleId { get; set; }

        public Article Article { get; set; }
    }
}
