namespace KisiselBerkeKurnaz.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_BILGI
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string SITEADI { get; set; }

        [StringLength(250)]
        public string SITEACIKLAMA { get; set; }
    }
}
