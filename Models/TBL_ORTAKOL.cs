namespace KisiselBerkeKurnaz.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    public partial class TBL_ORTAKOL
    {
        public int ID { get; set; }

        [UIHint("tinymce_full_compressed"), AllowHtml]
        public string TANITIM { get; set; }

        [UIHint("tinymce_full_compressed"), AllowHtml]
        public string YATIRIMCI { get; set; }

        [UIHint("tinymce_full_compressed"), AllowHtml]
        public string EKIPARKADAS { get; set; }

        [UIHint("tinymce_full_compressed"), AllowHtml]
        public string PROJEORTAK { get; set; }

        [UIHint("tinymce_full_compressed"), AllowHtml]
        public string REKLAMVEREN { get; set; }
    }
}
