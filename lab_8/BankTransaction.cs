using System;

namespace lab_8
{
    // Упражнение 9.2
    public class BankTransaction
    {
        public decimal Amount { get; }
        public DateTime Timestamp { get; }

        public BankTransaction(decimal amount)
        {
            Amount = amount;
            Timestamp = DateTime.Now;
        }
    }
}