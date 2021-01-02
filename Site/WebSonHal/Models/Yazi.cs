using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSonHal.Models
{
    public class Yazi
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public string Fotograf { get; set; }
        public DateTime OlusturulmaTarihi { get; set; }

        public int KategoriId { get; set; }



        public Kategori Kategori { get; set; }
    }
}
