namespace KisiselBerkeKurnaz.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_ILETISIM
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string ADSOYAD { get; set; }

        [StringLength(100)]
        public string MAIL { get; set; }

        [StringLength(50)]
        public string TELEFON { get; set; }

        public string MESAJ { get; set; }
    }
}
