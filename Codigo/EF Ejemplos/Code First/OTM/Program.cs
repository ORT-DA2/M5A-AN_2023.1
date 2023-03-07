using OTM.Context;
using System;

namespace OTM
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new FactoryOTMContext();
            var context = factory.CreateDbContext(null);
            Manera1(context);
            Manera2(context);
            Console.WriteLine("Hello World!");
        }

        private static void Manera2(OTMContext context)
        {
            Entities.Document document = new Entities.Document
            {
                Name = "DA1.txt",
            };
            context.Documents.Add(document);
            Entities.User user = new Entities.User
            {
                UserName = "MARCEL",
            };
            user.Documents.Add(document);
            context.Users.Add(user);
            context.SaveChanges();
        }

        private static void Manera1(OTMContext context)
        {
            Entities.User user = new Entities.User
            {
                UserName = "JUAN",
            };
            context.Users.Add(user);
            Entities.Document document = new Entities.Document
            {
                Name = "DA2.txt",
                User = user,
            };
            context.Documents.Add(document);
            context.SaveChanges();
        }
    }
}
