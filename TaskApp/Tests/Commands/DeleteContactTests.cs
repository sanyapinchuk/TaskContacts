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
    public class DeleteContactTests : TestCommandBase
    {
      

        [Fact]
        public async Task DeleteContactTest_Success()
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
            dataContext.Contacts.Add(contact);

            repository.Delete(contact);
            await repository.SaveChangesAsync();

            //Assert

            Assert.Null(
                await dataContext.Contacts.SingleOrDefaultAsync(c =>c.Id == id));
        }
    }
}
