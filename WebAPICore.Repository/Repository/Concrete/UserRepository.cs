using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICore.Model.DBContext;
using WebAPICore.Model.Model;
using WebAPICore.Repository.Repository.Abstract;

namespace WebAPICore.Repository.Repository.Concrete
{
    public class UserRepository : IUserRepository
    {
        internal APIDBContext context;

        public UserRepository(APIDBContext context)
        {
            this.context = context;
        }
        public void Add(User user)
        {
            throw new NotImplementedException();
        }

        public void Delete(User user)
        {
            throw new NotImplementedException();
        }

        public void Edit(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable Get()
        {
            var data = this.context.User.Count();
            
            return this.context.User.AsEnumerable();
            //return new string[] { "value1", "value2" };
            //throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
