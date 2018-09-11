using System;
using Eron.Core.AppEnums;
using Eron.Core.Infrastructure;

namespace Eron.Core.Entities.Financial.Base
{
    public class FinanceTransaction: Entity<Guid>
    {
        public FinanceTransaction(long invoiceId, string transactionNumber, string userId)
        {
            this.Id = Guid.NewGuid();
            this.InvoiceId = invoiceId;
            this.TransactionNumber = transactionNumber;
            this.UserId = userId;
            this.Successful = false;
        }

        public FinanceTransaction(long invoiceId, string transactionNumber, string userId, BankNameType bankName, string referenceId)
        {
            InvoiceId = invoiceId;
            TransactionNumber = transactionNumber;
            UserId = userId;
            ReferenceId = referenceId;
            BankName = bankName;
        }

        public FinanceTransaction()
        {
            this.Id = Guid.NewGuid();
        }

        public string TransactionNumber { get; set; }

        public long InvoiceId { get; set; }

        public BankNameType BankName { get; set; }

        public string UserId { get; set; }

        public string BankResponse { get; set; }

        public bool Successful { get; set; }

        public string ReferenceId { get; set; }

        public Invoice Invoice { get; set; }
    }
}
