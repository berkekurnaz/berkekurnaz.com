namespace KisiselBerkeKurnaz.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_KULLANICI
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string KULLANICIADI { get; set; }

        [StringLength(50)]
        public string SIFRE { get; set; }

        public int? YETKI { get; set; }
    }
}
