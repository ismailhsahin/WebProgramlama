using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Models
{
    public class Yorum
    {
        public int Id { get; set; }
        public string Isim { get; set; }
        [EmailAddress]
        public string Mail { get; set; }
        public string YorumIcerik { get; set; }

        public int YaziId { get; set; }

        public Yazi Yazi { get; set; }
    }
}
