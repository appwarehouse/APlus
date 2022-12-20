using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APlus.DataAccess.Database
{
    public interface IDatabase
    {
        public void DoMigration();
    }
}