using APlus.DataAccess.Database;
using APlus.Patient.Booking.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APlus.Patient.Booking.Services
{
    public class DatabaseUpdaterService : IDatabaseUpdaterService
    {
        private readonly IDatabase _updateDatabase;

        public DatabaseUpdaterService(IDatabase updateDatabase)
        {
            _updateDatabase = updateDatabase;
        }

        public void RunDatabaseMigration()
        {
            _updateDatabase.DoMigration();
        }
    }
}