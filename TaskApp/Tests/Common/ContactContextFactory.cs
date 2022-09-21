using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Common
{
    public class ContactContextFactory
    {
        public static DataContext Create()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString(), c=>c.EnableNullChecks())
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .Options;
            var context = new DataContext(options);
            context.Database.EnsureCreated();

            var c1 = new Contact
            {
                Id = Guid.Parse("9ccdbef9-7d17-4f3f-a312-7b6c1f564e70"),
                Name = "Mark",
                BirthDate = "12.10.2002",
                MobilePhone = "+375232145789",
                JobTitle = "programmer"
            };
            var c2 = new Contact
            {
                Id = Guid.Parse("19513c2f-c412-4bb8-8d98-73d6cc3598cb"),
                Name = "Lena",
                BirthDate = "09.01.2004",
                MobilePhone = "+375235265389",
                JobTitle = "QA"
            };
            var c3 = new Contact
            {
                Id = Guid.Parse("f5d7756f-9c67-4115-82fa-88818be71059"),
                Name = "Carl",
                BirthDate = "12.06.1997",
                MobilePhone = "+375297895126",
                JobTitle = "actor"
            };

            context.AddRange(c1, c2, c3);

           
            context.Entry<Contact>(c1).State = EntityState.Added;
            context.Entry<Contact>(c2).State = EntityState.Added;
            context.Entry<Contact>(c3).State = EntityState.Added;
            context.SaveChanges();
            context.Entry<Contact>(c1).State = EntityState.Detached;
            context.Entry<Contact>(c2).State = EntityState.Detached;
            context.Entry<Contact>(c3).State = EntityState.Detached;
            context.SaveChanges();
            return context;
        }
        public static void Destroy(DataContext datacontext)
        {
            datacontext.Database.EnsureDeleted();
            datacontext.Dispose();
        }   
    }
}
