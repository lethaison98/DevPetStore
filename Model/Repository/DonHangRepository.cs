using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repository
{
    public class DonHangRepository
    {
        PetStoreDbContext db = null;
        public DonHangRepository()
        {
            db = new PetStoreDbContext();
        }
        public int Insert(DonHang donHang)
        { 
            db.DonHangs.Add(donHang);
            db.SaveChanges();         
            return donHang.ID_DonHang;  
        }
    }
}
