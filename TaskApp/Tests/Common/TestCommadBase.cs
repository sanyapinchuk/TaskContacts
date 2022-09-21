using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Common
{
    public abstract class TestCommandBase: IDisposable
    {
        protected readonly DataContext dataContext;
        protected readonly ContactRepository repository;

        public TestCommandBase()
        {
            dataContext = ContactContextFactory.Create();
            repository = new ContactRepository(dataContext);
        }
        public void Dispose()
        {
            ContactContextFactory.Destroy(dataContext);
        }
    }
}
