
using System;

class CreateAccount
{
    static void Main() 
    {
        BankAccount berts = NewBankAccount();
        Write(berts);
        TestDeposit(berts);
        Write(berts);
        TestWithdraw(berts);
        Write(berts);

        BankAccount freds = NewBankAccount();
        Write(freds);
        TestDeposit(freds);
        Write(freds);
        TestWithdraw(freds);
        Write(freds);
    }

    public static void TestWithdraw(BankAccount acc)
    {
        Console.Write("Enter amount to withdraw: ");
        decimal amount = decimal.Parse(Console.ReadLine());
        if (!acc.Withdraw(amount))
        {
            Console.WriteLine("Insufficient funds.");
        }
    }

    public static void TestDeposit(BankAccount acc)
    {
        Console.Write("Enter amount to deposit: ");
        decimal amount = decimal.Parse(Console.ReadLine());
        acc.Deposit(amount);
    }

    static BankAccount NewBankAccount()
    {       
        BankAccount created = new BankAccount();
        
        Console.Write("Enter the account balance! : ");
        decimal balance = decimal.Parse(Console.ReadLine());
        
        created.Populate(balance);
        
        return created;
    }
    
    static void Write(BankAccount acc)
    {
        Console.WriteLine("Account number is {0}",  acc.Number());
        Console.WriteLine("Account balance is {0}", acc.Balance());
        Console.WriteLine("Account type is {0}", acc.Type());
    }
}
