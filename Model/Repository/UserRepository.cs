using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
namespace Model.Repository
{
    public class UserRepository
    {
        PetStoreDbContext db = null;
        public UserRepository()
        {
            db = new PetStoreDbContext();
        }

        public int InsertOrUpdate(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID_User;

        }

        public bool Login(string username, string password)
        {
            var result = db.Users.Count(x => x.Username == username && x.Password == password);
            if (result >=0)
            {
                return true;
            }
            else {
                return false;        
            }
        }
    }
}
