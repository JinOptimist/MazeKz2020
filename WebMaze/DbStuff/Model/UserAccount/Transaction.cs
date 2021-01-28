using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.DbStuff.Model.UserAccount
{
    public class Transaction : BaseModel
    {
        public DateTime Date;

        public string Description { get; set; }

        public decimal Amount { get; set; }

        public TransactionCategory Category { get; set; }
        
        public TransactionType Type { get; set; }

        public virtual CitizenUser Sender { get; set; }

        public virtual CitizenUser Recipient { get; set; }
    }

    public enum TransactionCategory
    {
        Shopping,
        Income,
        Education,
        Health,
        Transport,
        Entertainment,
        Food,
        Travel,
        Fees,
        Taxes,
        Rent,
        Pension,
        Bills,
        Atm
    }

    public enum TransactionType
    {
        Purchase,
        Transfer,
        Payment,
        Refund
    }
}