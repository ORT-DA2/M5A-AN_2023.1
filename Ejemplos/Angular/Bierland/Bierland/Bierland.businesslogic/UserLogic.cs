using Bierland.businesslogicInterface;
using Bierland.dataaccessInterface;
using Bierland.domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bierland.businesslogic
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserRepository userRepository;
        private readonly IRepository<UserSession> repository;
        public UserLogic(IUserRepository userRepository, IRepository<UserSession> repository)
        {
            this.userRepository = userRepository;
            this.repository = repository;
        }

        public IEnumerable<User> GetAll()
        {
            return userRepository.GetAll();
        }

        public bool IsLogued(string token)
        {
            UserSession userSession = repository.GetAll().Where(x => x.Token == token).FirstOrDefault();
            return userSession != null;
        }

        public string LogIn(string nickname, string password)
        {
            User user = userRepository.GetUserByNicknameAndPassword(nickname, password);
            if (user == null) throw new Exception("User or password incorrect");
            UserSession userSession = repository.GetAll().Where(x => x.User.Id == user.Id).FirstOrDefault();
            if (userSession == null)
            {
                Guid token = Guid.NewGuid();
                userSession = new UserSession()
                {
                    User = user,
                    Token = token.ToString()
                };
                repository.Create(userSession);
                repository.Save();
            }
            return userSession.Token;
        }

        public void LogOut(string token)
        {
            UserSession userSession = repository.GetAll().Where(x => x.Token == token).FirstOrDefault();
            if (userSession == null) throw new Exception("Token doesn't exist");
            repository.Delete(userSession);
            repository.Save();
        }
    }
}
