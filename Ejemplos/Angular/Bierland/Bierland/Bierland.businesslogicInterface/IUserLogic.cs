using System;
using System.Collections.Generic;
using Bierland.domain;

namespace Bierland.businesslogicInterface
{
    public interface IUserLogic
    {
        IEnumerable<User> GetAll();
        string LogIn(string nickname, string password);
        void LogOut(string token);
        bool IsLogued(string token);
    }
}
