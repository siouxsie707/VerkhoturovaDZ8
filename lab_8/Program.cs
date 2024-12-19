using System;
using lab_8;


namespace lab_8
{
    class Program
    {
        static void Main(string[] args)
        {
            using (BankAccount account1 = new BankAccount())
            {
                Console.WriteLine("Упражнения 9");
                account1.DisplayInfo();

                // Пополнение аккаунта
                account1.Deposit(1000.00m);
                account1.DisplayInfo();
                account1.DisplayTransactions();

                // Снятие средств
                account1.Withdraw(200.00m);
                account1.DisplayInfo();
                account1.DisplayTransactions();

                // Перевод средств
                using (BankAccount account2 = new BankAccount(AccountType.Checking, 500.00m))
                {
                    account2.DisplayInfo();
                    account1.Transfer(account2, 300.00m);
                    account1.DisplayInfo();
                    account1.DisplayTransactions();
                    account2.DisplayInfo();
                    account2.DisplayTransactions();
                }
            }
            using (BankAccount account3 = new BankAccount(100.00m))
            {
                using (BankAccount account4 = new BankAccount(AccountType.Checking, 500.00m))
                {
                    account3.DisplayInfo();
                    account4.DisplayInfo();
                    try
                    {
                        // Если переводить больше
                        account3.Transfer(account4, 200.00m);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка: {ex.Message}");
                    }
                }
            }
            // Домашнее задание 9.1
            // Песни
            Console.WriteLine("Домашнее задание 9.1");
            Song song1 = new Song("Песня 1", "Автор А");
            Song song2 = new Song("Песня 2", "Автор B", song1);
            Song song3 = new Song("Песня 3", "Автор C");

            // Предыдущая песня
            song3.SetPrev(song2);

            // Вывод информации
            Console.WriteLine("Список песен:");
            Console.WriteLine(song1.Title());
            Console.WriteLine(song2.Title());
            Console.WriteLine(song3.Title());

            if (song2.Equals(song1))
            {
                Console.WriteLine("Song Two и Song One совпадают.");
            }
            else
            {
                Console.WriteLine("Song Two и Song One разные песни.");
            }

            // Проверка на наличие предыдущей песни
            Console.WriteLine($"{song3.Title()} предшествует песне {song3.Title()}");
        }
    }
}
