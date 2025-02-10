/*Author: Victor Flores
 Course: COMP-003A
Faculty: Jonathon Cruz
Purpose: Demonstrate encapsulation using private properties in C#*/
namespace COMP003A.LectureActivity5_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //create new BankAccount object
            BankAccount myAccount = new BankAccount("12345678", 500.00);
            //display account num and intitial balance
            Console.WriteLine($"Account Number: {myAccount.AccountNumber}");
            Console.WriteLine($"Initial Balance: {myAccount.Balance:C}");

            //deposit and withdraw money
            myAccount.Deposit(150.00);
            myAccount.Withdraw(50.00);
            myAccount.Withdraw(700.00);//should print insufficent funds message but does not. Instead displays ($100.00)
        }
    }
    internal class BankAccount
    {
        //fields 
        private string _accountNumber;
        private double _balance;

        //properties
        /// <summary>
        /// Gets account number
        /// </summary>
        public string AccountNumber
        {
            get { return _accountNumber; }
            
        }
        /// <summary>
        /// Gets or sets the account balance with validation
        /// </summary>
        public double Balance
        {
            get { return _balance; }
            set
            {
                if (value >= 0)
                {
                    _balance = value;
                }
            }
        }

        /// <summary>
        /// Initializes a new isntance of BankAccount with an account number and inital balance 
        /// </summary>
        public BankAccount(string accountNumber, double initialBalance)
        {
            //set account number and initial balance
            _accountNumber = accountNumber;
            //validate the initial balance 
            Balance = initialBalance;
        }

        /// <summary>
        /// Deposit money into account
        /// </summary>
        /// <param name="amount">Amount to deposit</param>
        public void Deposit(double amount)
        {
            if (amount > 0)

            {
                _balance += amount;
                Console.WriteLine($"Deposited:{amount:C}. New Balance: {_balance:C}");
            }        
        }

        /// <summary>
        /// Withdraws money from the account if sufficient balance is available
        /// </summary>
        /// <param name="amount">Amount to withdraw</param>
        public void Withdraw(double amount)
        {
            if (amount > 0 && _balance >= 0)
            {
                _balance -= amount;
                Console.WriteLine($"Withdrawn: {amount:C}. New Balance: {_balance:C}");
            }
            else 
            {
                Console.WriteLine("Insufficient funds.");
            }

        }
    }
}
