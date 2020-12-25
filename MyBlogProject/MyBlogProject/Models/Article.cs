using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogProject.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public int? OlusturulmaTarihi { get; set; }
        public int? TahminiOkumaSuresi { get; set; }

        public int CategoryId { get; set; }
        public int PersonId { get; set; }



        public Category Category { get; set; }
        public People People { get; set; }
    }
}
