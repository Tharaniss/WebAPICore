using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICore.Model.DBContext;
using WebAPICore.Repository.Repository.Abstract;

namespace WebAPICore.Repository.Repository.Concrete
{
    public class UnitOfWork: IUnitOfWork
    {
        private IUserRepository userRepository;

        private APIDBContext context = new APIDBContext();

        public IUserRepository UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new UserRepository(context);
                }
                return userRepository;
            }
        }
    }
}
