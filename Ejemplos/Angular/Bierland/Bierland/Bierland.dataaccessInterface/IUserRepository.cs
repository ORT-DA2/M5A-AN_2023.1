using System;
using System.Collections.Generic;
using Bierland.domain;

namespace Bierland.dataaccessInterface
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByNicknameAndPassword(string nickname, string password);
    }
}
