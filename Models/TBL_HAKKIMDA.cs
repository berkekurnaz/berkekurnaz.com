namespace KisiselBerkeKurnaz.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    public partial class TBL_HAKKIMDA
    {
        public int ID { get; set; }

        [UIHint("tinymce_full_compressed"), AllowHtml]
        public string HAKKIMDA { get; set; }

        public string BKOYUN { get; set; }
    }
}
