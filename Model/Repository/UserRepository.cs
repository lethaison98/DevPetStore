using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

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
            var x = entity.ID_User;
      
            if (entity.ID_User <= 0)
            {
                entity.CreatedDate = DateTime.Now;
                db.Users.Add(entity);
                db.SaveChanges();
            }
            else
            {
                var user = db.Users.Find(entity.ID_User);
                user.Username = entity.Username;
                user.Password = entity.Password;
                user.Ten = entity.Ten;
                user.SoDienThoai = entity.SoDienThoai;
                user.Email = entity.Email;
                user.ModifyDate = DateTime.Now;
                user.Status = entity.Status;
                user.IsAdmin = entity.IsAdmin;
                user.DiaChi = entity.DiaChi;
                db.SaveChanges();
            }
            return entity.ID_User;

        }

        public void Delete(int id)
        {
            User user = db.Users.SingleOrDefault(x => x.ID_User == id);
            db.Users.Remove(user);
            db.SaveChanges();
        }

        public IEnumerable<User> ListAllPaging(String searchString, int page, int pageSize)
        {
            IQueryable<User> model = db.Users;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Username.Contains(searchString));
            }
            return model.OrderByDescending(x => x.Username).ToPagedList(page, pageSize);
        }
        public User GetByID(int id)
        {
            return (db.Users.SingleOrDefault(x => x.ID_User == id));
        }
        public User GetByUsername(String userName)
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
