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

        [StringLength(20)]
        [Display(Name = "Tên giống Pet")]
        public string TenGiongPet { get; set; }

        [Display(Name = "Danh mục")]
        public int? ID_DanhMuc { get; set; }

  
        [Display(Name ="Nguồn gốc")]
        public string NguonGoc{ get; set; }

        [StringLength(250)]
        [Display(Name ="Ảnh nguồn gốc")]
        public string ImgNguonGoc { get; set; }

        [Display(Name = "Đặc điểm")]
        public string DacDiem { get; set; }

        [StringLength(250)]
        [Display(Name = "Ảnh đặc điểm")]
        public string ImgDacDiem { get; set; }
        [Display(Name = "Lý do nuôi")]
        public string LyDoNuoi { get; set; }

        [StringLength(250)]
        [Display(Name = "Ảnh lý do nuôi")]
        public string ImgLyDoNuoi { get; set; }

        [StringLength(50)]
        [Display(Name ="Meta Title")]
        public string MetaTitle { get; set; }

        public virtual DanhMuc DanhMuc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pet> Pets { get; set; }
    }
}
