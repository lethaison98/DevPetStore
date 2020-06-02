using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repository
{
    public class DichVuRepository
    {
        PetStoreDbContext db = null;

        public DichVuRepository()
        {
            db = new PetStoreDbContext();
        }
        public List<DichVu> ListAll()
        {
            return db.DichVus.ToList();
        }
    }
}
