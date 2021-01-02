using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSonHal.Models
{
    public class Yorum
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Email { get; set; }
        public string YorumIcerik { get; set; }




        public int YaziId { get; set; }

        public Yazi Yazi { get; set; }
    }
}
