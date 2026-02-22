using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentPlatform.Domain.Entities
{
    public class Investment
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public int Quantity {  get; set; }
        
        public string Type { get; set; }
        public DateTime PurchaseDate { get; set; }
        public Guid UserId { get; set; }

    }
}
