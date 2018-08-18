namespace KisiselBerkeKurnaz.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_EKIPARKADASI
    {
        public int ID { get; set; }

        [StringLength(80)]
        public string ADSOYAD { get; set; }

        [StringLength(50)]
        public string TELEFON { get; set; }

        [StringLength(50)]
        public string MAIL { get; set; }

        [StringLength(150)]
        public string ALAN { get; set; }

        [StringLength(500)]
        public string YETENEKLER { get; set; }

        public string HAKKINIZDA { get; set; }
    }
}
