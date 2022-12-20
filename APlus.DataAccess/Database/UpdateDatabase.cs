using APlus.DataAccess.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APlus.DataAccess.Database
{
    public class UpdateDatabase : IDatabase
    {
        private readonly PatientContext _context;

        public UpdateDatabase(PatientContext context)
        {
            _context = context;
        }

        public void DoMigration()
        {
            _context.Database.Migrate();
        }
    }
}