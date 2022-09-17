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

namespace Tests.Queries
{
    public class GetContactTests:TestCommandBase
    {
        [Fact]
        public async Task GetContactTest_Success()
        {

            //Arrange

            //Act

            //Assert

            Assert.NotNull(await repository.GetContactByIdAsync(
                Guid.Parse("f5d7756f-9c67-4115-82fa-88818be71059")
                ));
               
        }
        [Fact]
        public async Task GetContactTest_FailExistID()
        {

            //Arrange

            //Act

            //Assert

            Assert.Null(await repository.GetContactByIdAsync(Guid.NewGuid()));
        }
    }
}
