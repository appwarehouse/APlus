using System;
using System.Collections.Generic;

#nullable disable

namespace APlus.DataAccess.Models
{
    public partial class Ranking
    {
        public int Id { get; set; }
        public string RankingName { get; set; }
        public int Priority { get; set; }
        public string Description { get; set; }
    }
}