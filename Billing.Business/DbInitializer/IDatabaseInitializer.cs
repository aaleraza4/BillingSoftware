using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Business.DbInitializer
{
    public interface IDatabaseInitializer
    {

        /// <summary>
        /// Applies any pending migrations for the context to the database.
        /// Will create the database if it does not already exist.
        /// </summary>
        Task MigrateDbsAsync();


        /// <summary>
        /// Adds some default values to the Db
        /// </summary>
        Task SeedDataAsync();
    }
}
