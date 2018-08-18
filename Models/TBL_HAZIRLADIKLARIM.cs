namespace KisiselBerkeKurnaz.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    public partial class TBL_HAZIRLADIKLARIM
    {
        public int ID { get; set; }

        [StringLength(150)]
        public string AD { get; set; }

        [StringLength(150)]
        public string TANITIM { get; set; }

        [UIHint("tinymce_full_compressed"), AllowHtml]
        public string ACIKLAMA { get; set; }

        [StringLength(500)]
        public string FOTOGRAF { get; set; }
    }
}
