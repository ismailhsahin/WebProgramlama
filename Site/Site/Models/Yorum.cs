using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Models
{
    public class Yorum
    {
        public int Id { get; set; }
        public string YorumBaslik { get; set; }
        public string YorumIcerik { get; set; }

        public int YaziId { get; set; }
        public int KisiId { get; set; }

        public Yazi Yazi { get; set; }
        public Kisi Kisi { get; set; }
    }
}
