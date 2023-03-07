using OTO.Library.Entities;
using System;

namespace OTO.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new FactoryOTOContext();
            var context = factory.CreateDbContext(null);
            User user = new User
            {
                UserName = "JUAN",
            };
            context.Users.Add(user);
            Document document = new Document
            {
                Name = "DA2.txt",
                User = user,
            };
            context.Documents.Add(document);
            context.SaveChanges();
            Console.WriteLine("Hello World!");
        }
    }
}
