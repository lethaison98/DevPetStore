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
        public int ID_Item { get; set; }

        [StringLength(50)]
        [Display (Name ="Tên Pet")]
        public string Ten_Pet { get; set; }

        public int? ID_GiongPet { get; set; }

        [StringLength(250)]
        [Display (Name ="Hình Ảnh")]
        public string Image { get; set; }

        [StringLength(50)]
        public string MetaTitle { get; set; }

        [Display(Name ="Mô tả")]
        public string MoTa { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name ="Chi tiết")]
        public string ChiTiet { get; set; }

        [StringLength(20)]
        [Display (Name="Màu Lông")]
        public string MauLong { get; set; }

        [StringLength(50)]
        [Display (Name ="Nguồn gốc")]
        public string NguonGoc { get; set; }

        [Display(Name ="Giá tiền")]
        public decimal? GiaTien { get; set; }

        public bool? Status { get; set; }

        [Display (Name ="Giới tính (Đực)")]
        public bool? GioiTinh { get; set; }
        public virtual GiongPet GiongPet { get; set; }

    }
}
