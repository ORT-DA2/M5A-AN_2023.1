using Microsoft.EntityFrameworkCore;
using MTM.Context;
using System;

namespace MTM
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new FactoryMTMContext();
            var user = Create(factory, "JUAN");
            var context = factory.CreateDbContext(null);
            Entities.Document document = new Entities.Document
            {
                Name = "DA2-AAAAA.txt"
            };
            context.Documents.Add(document);
            context.UserDocuments.Add(new Entities.UserDocument
            {
                Document = document,
                User = user,
            });
            context.SaveChanges();

            Console.WriteLine("Hello World!");
        }

        private static Entities.User Create(FactoryMTMContext factory, string userName)
        {
            using var context = factory.CreateDbContext(null);
            Entities.User user = new Entities.User
            {
                UserName = userName,
            };
            context.Users.Add(user);
            Entities.Document document = new Entities.Document
            {
                Name = "DA2.txt"
            };
            context.Documents.Add(document);
            context.UserDocuments.Add(new Entities.UserDocument
            {
                Document = document,
                User = user,
            });
            context.SaveChanges();
            return user;
        }
    }
}
