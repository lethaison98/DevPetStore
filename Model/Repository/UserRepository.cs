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
        public User GetByID(String userName)
        {
            return (db.Users.SingleOrDefault(x => x.Username == userName));
        }

        public int Login(string username, string password)
        {
            var result = db.Users.SingleOrDefault(x => x.Username == username);
            if (result == null)
            {
                return 0;
            }
            else{
                if(result.Status != true)
                {
                    return 2;
                }
                else
                {
                    if(password == result.Password)
                    {
                        return 1;
                    }
                    else
                    {
                        return 3;
                    }
                }

                
            }
        }
    }
}
