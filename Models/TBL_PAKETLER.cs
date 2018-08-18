namespace KisiselBerkeKurnaz.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    public partial class TBL_PAKETLER
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string PAKETAD { get; set; }

        [StringLength(150)]
        public string PAKETTANITIM { get; set; }

        [UIHint("tinymce_full_compressed"), AllowHtml]
        public string PAKETACIKLAMA { get; set; }

        [StringLength(350)]
        public string PAKETFOTOGRAF { get; set; }

        [StringLength(10)]
        public string PAKETFIYAT { get; set; }
    }
}
