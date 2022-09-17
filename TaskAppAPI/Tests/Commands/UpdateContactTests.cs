using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tests.Common;
using Xunit;

namespace Tests.Commands
{
    public class UpdateContactTests :TestCommandBase
    {
        [Fact]
        public async Task ChangeContactTest_Success()
        {

            //Arrange
            var id = Guid.Parse("9ccdbef9-7d17-4f3f-a312-7b6c1f564e70");
            var name = "Mark";
            var birthDay = "12.10.2002";
            var phone = "+375232145781"; //change phone number
            var job = "programmer";

            //Act
            Contact contact = new()
            {
                Id = id,
                Name = name,
                BirthDate = birthDay,
                MobilePhone = phone,
                JobTitle = job
            };

            
            repository.Update(contact);
            await repository.SaveChangesAsync();


            //Assert

            Assert.NotNull(
                 await dataContext.Contacts.SingleOrDefaultAsync(c =>
                                                             c.Id == id &&
                                                             c.JobTitle == job &&
                                                             c.BirthDate == birthDay &&
                                                             c.MobilePhone == phone &&
                                                             c.Name == name
                                                             ));
        }

        [Fact]
        public async Task ChangeContactTest_FailWithOldPhone()
        {

            //Arrange
            var id = Guid.Parse("19513c2f-c412-4bb8-8d98-73d6cc3598cb");
            var name = "Lena";
            var birthDay = "09.01.2004";
            var phone = "+375235265389"; //change phone number
            var newPhone = "+375981265780";
            var job = "QA";

            //Act
            Contact contact = new()
            {
                Id = id,
                Name = name,
                BirthDate = birthDay,
                MobilePhone = newPhone,
                JobTitle = job
            };


            repository.Update(contact);
            await repository.SaveChangesAsync();

            //Assert

            Assert.Null(
                 await dataContext.Contacts.SingleOrDefaultAsync(c =>
                                                             c.Id == id &&
                                                             c.JobTitle == job &&
                                                             c.BirthDate == birthDay &&
                                                             c.MobilePhone == phone &&
                                                             c.Name == name
                                                             ));
        }
    }
}
