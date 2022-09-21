

using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IDataContext
    {
        DbSet<Contact> Contacts { get; set; }
    }
}
