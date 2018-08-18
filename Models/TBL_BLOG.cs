namespace KisiselBerkeKurnaz.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    public partial class TBL_BLOG
    {
        public int ID { get; set; }

        [StringLength(250)]
        public string BASLIK { get; set; }

        [StringLength(50)]
        public string TARIH { get; set; }

        [UIHint("tinymce_full_compressed"), AllowHtml]
        public string ICERIK { get; set; }
    }
}
