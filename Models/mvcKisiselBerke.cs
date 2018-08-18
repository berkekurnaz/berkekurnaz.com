namespace KisiselBerkeKurnaz.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class mvcKisiselBerke : DbContext
    {
        public mvcKisiselBerke()
            : base("name=mvcKisiselBerke")
        {
        }

        public virtual DbSet<TBL_BILGI> TBL_BILGI { get; set; }
        public virtual DbSet<TBL_BLOG> TBL_BLOG { get; set; }
        public virtual DbSet<TBL_EKIPARKADASI> TBL_EKIPARKADASI { get; set; }
        public virtual DbSet<TBL_HAKKIMDA> TBL_HAKKIMDA { get; set; }
        public virtual DbSet<TBL_HAZIRLADIKLARIM> TBL_HAZIRLADIKLARIM { get; set; }
        public virtual DbSet<TBL_ILETISIM> TBL_ILETISIM { get; set; }
        public virtual DbSet<TBL_KULLANICI> TBL_KULLANICI { get; set; }
        public virtual DbSet<TBL_ORTAKOL> TBL_ORTAKOL { get; set; }
        public virtual DbSet<TBL_PAKETLER> TBL_PAKETLER { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
