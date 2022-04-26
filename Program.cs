using System;

namespace CSharp.LabExercise3
{
    class TellerMachine
    {
        public decimal accountBalance { get; set; }

        public TellerMachine()
        {
            this.accountBalance = 0;
        }
    }

   
    class CashBalanceChecker
    {
        TellerMachine tellerMachine;

        public CashBalanceChecker  (TellerMachine tellerMachine)
        {
            this.tellerMachine = tellerMachine;
        }
        public void checkBalance()
        {
            Console.WriteLine($"\nYOUR ACCOUNT BALANCE IS: {String.Format("{0:N}", tellerMachine.accountBalance)}\n");
        }
    }

    class CashWithdrawer
    {
        TellerMachine tellerMachine;

        public CashWithdrawer(TellerMachine tellerMachine)
        {
            this.tellerMachine = tellerMachine;
        }


        public void withdrawCash()
        {
            Console.Write("\nEnter cash amount to WITHDRAW: ");
            var cashWithdrawString = (Console.ReadLine());
            decimal cashWithdraw;

            bool parseSuccess = decimal.TryParse(cashWithdrawString, out cashWithdraw);

            if (parseSuccess == false)
            {
                Console.WriteLine("\nINVALID! Must enter a number.\n");
            }
            else if (tellerMachine.accountBalance == 0)
            {
                Console.WriteLine("\nYour account balance is ZERO.\n");
            }
            else if (cashWithdraw > tellerMachine.accountBalance)
            {
                Console.WriteLine("\nINSUFFICIENT BALANCE!\n");
            }
            else if (cashWithdraw < 100)
            {
                Console.WriteLine("\nINVALID! Amount must be more than 100\n");
            }
            else if (cashWithdraw % 100 != 0)
            {
                Console.WriteLine("\nINVALID! Amount must be multiples of 100.\n");
            }
            else
            {
                this.tellerMachine.accountBalance -= cashWithdraw;
                Console.WriteLine("\nTRANSACTION SUCCESSFUL!\n");
                Console.WriteLine($"YOUR ACCOUNT BALANCE IS: {String.Format("{0:N}", tellerMachine.accountBalance)}\n");
            }
        }
    }

    class CashDepositor
    {
        TellerMachine tellerMachine;

        public CashDepositor(TellerMachine tellerMachine)
        {
            this.tellerMachine = tellerMachine;
        }
        public void depositCash()
        {
            Console.Write("\nEnter cash amount to DEPOSIT: ");
            var cashDepositString = (Console.ReadLine());
            decimal cashDeposit;

            bool parseSuccess = decimal.TryParse(cashDepositString, out cashDeposit);

            if (parseSuccess == false)
            {
                Console.WriteLine("\nINVALID! Must enter a number.\n");
            }
            else if (cashDeposit < 0)
            {
                Console.WriteLine("\nINVALID! Cannot accept negative amount.\n");
            }
            else
            {
                this.tellerMachine.accountBalance += cashDeposit;
                Console.WriteLine("\nTRANSACTION SUCCESSFUL!\n");
                Console.WriteLine($"ACCOUNT BALANCE: {String.Format("{0:N}", tellerMachine.accountBalance)}\n");
            }
        }
    }

    class Program
    {

        static void Main()
        {
            TellerMachine tellerMachine = new TellerMachine();
            CashBalanceChecker cashBalanceChecker = new CashBalanceChecker (tellerMachine);
            CashWithdrawer cashWithdrawer = new CashWithdrawer (tellerMachine);
            CashDepositor cashDepositor = new CashDepositor (tellerMachine);
            

            while (true)
            {
                Console.WriteLine("~*~*~*~*~*~* WELCOME to ATM SERVICE *~*~*~*~*~*~ \n");
                Console.WriteLine("[1] Check Balance \n");
                Console.WriteLine("[2] Withdraw Cash \n");
                Console.WriteLine("[3] Deposit Cash \n");
                Console.WriteLine("[4] Exit \n");

                Console.Write("SELECT TRANSACTION: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("\n* * * * * * * * * * * * * * * * * * * * * * * * *");
                        cashBalanceChecker.checkBalance();
                        Console.Write("press any key...");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "2":
                        Console.WriteLine("\n* * * * * * * * * * * * * * * * * * * * * * * * *");
                        cashWithdrawer.withdrawCash();
                        Console.Write("press any key...");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "3":
                        Console.WriteLine("\n* * * * * * * * * * * * * * * * * * * * * * * * *");
                        cashDepositor.depositCash();
                        Console.Write("press any key...");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "4":
                        Console.WriteLine("\n* * * * * * * * * * * * * * * * * * * * * * * * *");
                        Console.WriteLine("\nThank you!");
                        Environment.Exit(-1);
                        break;

                    default:
                        Console.Write("\nInvalid Selection! Please select a valid key.\npress any key...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
