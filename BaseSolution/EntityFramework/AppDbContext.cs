using Microsoft.EntityFrameworkCore;
using System;

namespace EntityFramework
{
    public class AppDbContext : DbContext
    {
        internal static AppDbContext context;
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected AppDbContext()
        {
        }

        public static void Register(AppDbContext dbContext)
        {
            if(dbContext == null)
            {
                throw new ArgumentNullException("No Context");
            }

            context = dbContext;
        }
    }
}
