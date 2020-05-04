using Model.EF;
using PagedList;
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
