using AOAHub.Db.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AOAHub.Db
{
    public class AOAContext : DbContext, IAOAContext
    {
        protected AOAContext()
        {
        }
    }
}
