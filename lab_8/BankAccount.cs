using System;
using System.Collections;
using System.IO;

public enum AccountType
{
    Savings,
    Checking,
    Business
}

namespace lab_8
{
    public class BankAccount : IDisposable
    {
        private static int nextAccountNumber = 0;
        private string accountNumber;
        private decimal balance;
        private AccountType accountType;
        private Queue transactionQueue; // для хранения объектов класса BankTransaction
        private bool disposed = false;

        // Упражнение 9.1 Конструкторы
        // Конструктор по умолчанию
        public BankAccount()
        {
            this.accountNumber = GenerateUniqueAccountNumber();
            this.balance = 0;
            this.accountType = AccountType.Savings;
            this.transactionQueue = new Queue();
        }

        // Конструктор для заполнения поля баланс
        public BankAccount(decimal initialBalance)
        {
            this.accountNumber = GenerateUniqueAccountNumber();
            this.balance = initialBalance;
            this.accountType = AccountType.Savings;
            this.transactionQueue = new Queue();
        }

        // Конструктор для заполнения поля тип банковского счета
        public BankAccount(AccountType accountType)
        {
            this.accountNumber = GenerateUniqueAccountNumber();
            this.balance = 0;
            this.accountType = accountType;
            this.transactionQueue = new Queue();
        }

        // Конструктор для заполнения баланса и типа банковского счета
        public BankAccount(AccountType accountType, decimal initialBalance)
        {
            this.accountNumber = GenerateUniqueAccountNumber();
            this.balance = initialBalance;
            this.accountType = accountType;
            this.transactionQueue = new Queue();
        }

        public static string GenerateUniqueAccountNumber()
        {
            nextAccountNumber++;
            return nextAccountNumber.ToString().PadLeft(20, '0');
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Номер счета: {accountNumber}, Тип счета: {accountType}, Баланс: {balance:C}");
        }

        public decimal GetBalance()
        {
            return balance;
        }

        // Метод для пополнения счета
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Сумма должна быть положительной.");

            balance += amount;
            transactionQueue.Enqueue(new BankTransaction(amount)); 
            Console.WriteLine($"На счет {accountNumber} пополнено: {amount:C}");
        }

        // Метод для снятия средств со счета
        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Сумма должна быть положительной.");

            if (balance < amount)
                throw new InvalidOperationException("Недостаточно средств.");

            balance -= amount;
            transactionQueue.Enqueue(new BankTransaction(-amount));
            Console.WriteLine($"С счета {accountNumber} снято: {amount:C}");
        }

        // Метод для отображения всех транзакций
        public void DisplayTransactions()
        {
            Console.WriteLine($"Транзакции для счета {accountNumber}:");
            foreach (BankTransaction transaction in transactionQueue)
            {
                string type = transaction.Amount > 0 ? "Пополнение" : "Снятие";
                Console.WriteLine($"{type}: {Math.Abs(transaction.Amount):C} на {transaction.Timestamp}");
            }
        }

        // Метод для перевода средств
        public void Transfer(BankAccount targetAccount, decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Сумма должна быть положительной.");
            }

            if (balance < amount)
            {
                throw new InvalidOperationException("Недостаточно средств.");
            }

            balance -= amount;
            targetAccount.balance += amount;

            transactionQueue.Enqueue(new BankTransaction(-amount));
            targetAccount.transactionQueue.Enqueue(new BankTransaction(amount));

            Console.WriteLine($"Переведено {amount:C} со счета {accountNumber} на счет {targetAccount.accountNumber}.");
        }

        // Упражнение 9.3
        // Метод для записи транзакций в файл
        private void WriteTransactionsToFile()
        {
            using (StreamWriter writer = new StreamWriter($"transactions_{accountNumber}.txt", true))
            {
                foreach (BankTransaction transaction in transactionQueue)
                {
                    string type = transaction.Amount > 0 ? "Пополнение" : "Снятие";
                    writer.WriteLine($"{type}: {Math.Abs(transaction.Amount):C} на {transaction.Timestamp}");
                }
            }
            Console.WriteLine($"Транзакции записаны в файл transactions_{accountNumber}.txt");
        }

        // Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                { 
                    WriteTransactionsToFile(); // Пишем данные о транзакциях в файл
                }

                disposed = true;
            }
        }
    }
}