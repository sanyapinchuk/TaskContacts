using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Common;
using Xunit;

namespace Tests.Commands
{
    public class CreateContactTests:TestCommandBase
    {
        [Fact]
        public async Task CreateContactTest_Success()
        {

            //Arrange
            var id = Guid.NewGuid();
            var name = "Boris";
            var birthDay = "13.09.1999";
            var phone = "+37587456321";
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

            await Task.Run(() => repository.CreateAsync(contact));
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
    }
}
