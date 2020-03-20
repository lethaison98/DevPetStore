using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repository
{
    public class DanhMucRepository
    {
        PetStoreDbContext db = null;
        public DanhMucRepository()
        {
            db = new PetStoreDbContext();
        }
        public List<DanhMuc> ListAll()
        {
            return db.DanhMucs.ToList();
        }

    }
}
