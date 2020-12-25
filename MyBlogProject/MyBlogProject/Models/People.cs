using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogProject.Models
{
    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime YearOfBirth { get; set; }
        public Cinsiyet Cinsiyet { get; set; }
    }
    public enum Cinsiyet
    {
        Erkek = 1,
        Kadin = 2
    }
}
