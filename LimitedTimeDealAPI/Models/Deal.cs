using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimitedTimeDealAPI.Models
{
    public class Deal
    {
        public int Id { get; set; }
        public DateTime ExpirationDate { get; set; }

        public double Price { get; set; }

        public int Items { get; set; }

        public bool IsActive { get; set; }
    }
}
