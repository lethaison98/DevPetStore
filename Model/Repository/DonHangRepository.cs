using Model.EF;
using PagedList;
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
        public IEnumerable<DonHang> ListAllPaging(String searchString, int page, int pageSize)
        {
            IQueryable<DonHang> model = db.DonHangs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.ShipName.Contains(searchString) || x.ShipMobile.Contains(searchString) || x.ShipAddress.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }
    }
}
