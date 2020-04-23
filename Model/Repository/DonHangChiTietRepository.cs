using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repository
{
    public class DonHangChiTietRepository
    {
        PetStoreDbContext db = null;
        public DonHangChiTietRepository()
        {
            db = new PetStoreDbContext();
        }
        public int Insert(DonHangDetail donHangChiTiet)
        {
         
                db.DonHangDetails.Add(donHangChiTiet);
                db.SaveChanges();
                return donHangChiTiet.ID_DonHangChiTiet;
           
        }
    }
}
