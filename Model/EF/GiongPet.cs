namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GiongPet")]
    public partial class GiongPet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GiongPet()
        {
            Pets = new HashSet<Pet>();
        }

        [Key]
        public int ID_GiongPet { get; set; }

        [StringLength(10)]
        public string TenGiongPet { get; set; }

        public int? ID_DanhMuc { get; set; }

        [StringLength(500)]
        public string MoTa { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        [StringLength(50)]
        public string MetaTitle { get; set; }

        public virtual DanhMuc DanhMuc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pet> Pets { get; set; }
    }
}
