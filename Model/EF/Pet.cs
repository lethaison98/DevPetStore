namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pet")]
    public partial class Pet
    {
        [Key]
        public int ID_Pet { get; set; }

        [StringLength(50)]
        public string Ten_Pet { get; set; }

        public int? ID_GiongPet { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        [StringLength(50)]
        public string MetaTitle { get; set; }

        [StringLength(250)]
        public string MoTa { get; set; }

        [Column(TypeName = "ntext")]
        public string ChiTiet { get; set; }

        [StringLength(20)]
        public string MauLong { get; set; }

        [StringLength(50)]
        public string NguonGoc { get; set; }

        public decimal? GiaTien { get; set; }

        public bool? Status { get; set; }

        public virtual GiongPet GiongPet { get; set; }
    }
}
