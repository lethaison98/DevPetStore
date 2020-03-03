namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [Key]
        public int ID_User { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(10)]
        public string Password { get; set; }

        [StringLength(50)]
        public string Ten { get; set; }

        [StringLength(250)]
        public string DiaChi { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(30)]
        public string SoDienThoai { get; set; }

        public bool? Status { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifyDate { get; set; }

        public bool? isAdmin { get; set; }
    }
}
