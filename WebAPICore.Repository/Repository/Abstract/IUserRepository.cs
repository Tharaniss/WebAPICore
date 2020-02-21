using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICore.Model.Model;

namespace WebAPICore.Repository.Repository.Abstract
{
    public interface IUserRepository
    {
        void Add(User user);
        void Edit(User user);
        void Delete(User user);
        IEnumerable Get();
        User GetById(int id);

    }
}
