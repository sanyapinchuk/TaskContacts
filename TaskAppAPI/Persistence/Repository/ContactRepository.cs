using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class ContactRepository : RepositoryBase<Contact>, IContactRepository
    {
        public ContactRepository(DataContext dataContext):base(dataContext)
        {

        }

        public async Task<Contact?> GetContactByIdAsync(Guid contactId)
        {
            return await _dataContext.Contacts.Where(c=>c.Id == contactId)
                                              .AsNoTracking()
                                              .FirstOrDefaultAsync();
        }
    }
    
}
