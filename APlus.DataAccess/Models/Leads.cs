using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APlus.DataAccess.Models
{
    public class Leads
    {
        public Guid Id { get; set; }

        public DateTime Date
        {
            get
            {
                return DateTime.Now;
            }
            set { }
        }

        public string Payload { get; set; }
    }
}