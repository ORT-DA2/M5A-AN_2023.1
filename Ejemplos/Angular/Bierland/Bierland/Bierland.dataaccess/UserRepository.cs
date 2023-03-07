using Bierland.dataaccessInterface;
using Bierland.domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace Bierland.dataaccess
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly DbSet<User> DbSet;
        private readonly DbContext context;
        public UserRepository(DbContext context) : base(context)
        {
            this.DbSet = context.Set<User>();
            this.context = context;
        }

        public User GetUserByNicknameAndPassword(string nickname, string password)
        {
            return DbSet.Where(x => x.Nickname == nickname && x.Password == password).FirstOrDefault();
        }
    }
}
