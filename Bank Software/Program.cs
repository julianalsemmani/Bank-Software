using System;
using System.Threading;

namespace Bank_Software
{
    class Program
    {
        public static double balance = 0;
        public static string name = "Admin";
        public static string username = "Admin";
        public static string password = "Admin";
        public static string option;

        static void Main(string[] args)
        {
            Console.Title = "Bank Software by JillOk";
            Console.WriteLine("+----------------------+");
            Console.WriteLine("|      MAIN MENU       |");
            Console.WriteLine("+----------------------+");
            Console.WriteLine("|                      |");
            Console.WriteLine("|1.) Login             |");
            Console.WriteLine("|2.) Register          |");
            Console.WriteLine("|3.) Exit              |");
            Console.WriteLine("|                      |");
            Console.WriteLine("+----------------------+");

            Console.Write("\n\nSelection: ");
            string option = Console.ReadLine();

            if (option == "1") Login();
            else if (option == "2") Register();
            else if (option == "3") Environment.Exit(0);



        }

        public static void Select()
        {
            Console.Title = "Bank Software - Select";
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Welcome, {0}\n\n", name);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Your Current Balance is ${0}\n\n", balance);
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("\n\n1. Deposit Money");
            Console.WriteLine("2. Withdraw money");
            Console.WriteLine("3. Send Money");
            Console.Write("Option: ");
            option = Console.ReadLine();

            if (option == "1")
            {
                Console.Clear();
                Console.WriteLine("Please wait... ");
                Thread.Sleep(2500);
                Deposit_Money();
            }
            else if (option == "2")
            {
                Console.Clear();
                Console.WriteLine("Please wait... ");
                Thread.Sleep(2500);
                Withdraw_Money();
            }
            else if (option == "3")
            {
                Console.Clear();
                Console.WriteLine("Please wait... ");
                Thread.Sleep(2500);
                Send_Money();
            }


        }

        public static void Login()
        {
            Console.Title = "Bank Software - Login";
            Console.Clear();
            Console.WriteLine("Username: ");
            if (username == Console.ReadLine())
            {
                Console.WriteLine("Password: ");
                if (password == Console.ReadLine())
                {
                    Select();
                }
                else
                {
                    Console.WriteLine("Wrong Password. ");
                    Thread.Sleep(2500);
                    Login();
                }

            }
            else
            {
                Console.WriteLine("Wrong Username. ");
                Thread.Sleep(2500);
                Login();
            }
            Console.Read();
        }

        public static void Register()
        {
            Console.Title = "Bank Software - Register";
            Console.Clear();
            Console.WriteLine("Registration");
            Console.WriteLine("\n\n-------------\n\n");
            Console.WriteLine("Full name: ");
            name = Console.ReadLine();
            Console.WriteLine("Username: ");
            username = Console.ReadLine();
            Console.WriteLine("Password: ");
            password = Console.ReadLine();

            Random rnd = new Random();
            int captcha = rnd.Next(1, 2000);

            Console.WriteLine("Write this in: {0}", captcha);
            string captchaInput = Console.ReadLine();
            int.TryParse(captchaInput, out int captchaInt);


            if (captcha == captchaInt)
            {
                Console.WriteLine("Registering.. Please wait... ");
                Thread.Sleep(5000);
                Console.Clear();

                Console.WriteLine("\n\nRegistration Successful. Please wait... ");

                Thread.Sleep(5000);


                Login();
            }

        }

        public static void Deposit_Money()
        {
            Console.Title = "Bank Software - Deposit Money";
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Welcome, {0}\n\n", name);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Your Current Balance is ${0}\n\n", balance);
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("How much do you want to deposit?");
            Console.Write("$");
            string moneyDeposited = Console.ReadLine();
            double moneyDeposit = Double.Parse(moneyDeposited);

            if (moneyDeposit < 0.1)
            {
                Console.Clear();
                Console.WriteLine("You have to deposit $0.1 or more.");
                Thread.Sleep(2500);
                Select();
            }

            Console.Clear();
            balance = balance + moneyDeposit;
            Console.WriteLine("Please wait.. Depositting money... ");

            Thread.Sleep(2500);

            Select();
        }

        public static void Withdraw_Money()
        {
            Console.Title = "Bank Software - Withdraw Money";
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Welcome, {0}\n\n", name);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Your Current Balance is ${0}\n\n", balance);
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("How much do you want to withdraw?");
            Console.Write("$");
            string moneyWithdrewString = Console.ReadLine();
            double moneyWithdrew = Double.Parse(moneyWithdrewString);

            if (balance < moneyWithdrew)
            {
                Console.Clear();
                Console.WriteLine("You're not able to withdraw ${0}. Your balance is ${1}.", moneyWithdrew, balance);
                Thread.Sleep(2500);
            }

            Console.WriteLine("Are you sure you want to withdraw {0}? Type 'Cancel' to cancel the withdrawing.", moneyWithdrew);

            // Will generate a random number between 1, 2000
            Random rnd = new Random();
            int captcha = rnd.Next(1, 2000);

            // Kinda a Captcha
            Console.WriteLine("Write this in: {0}", captcha);
            string captchaInput = Console.ReadLine();
            int.TryParse(captchaInput, out int captchaInt);


            // This will check if the random number is equal to the userInput.
            if (captcha == captchaInt)
            {
                Console.Clear();
                Console.WriteLine("Withdrawing.. Please wait... ");
                Thread.Sleep(5000);
                Console.Clear();

                Console.WriteLine("\n\nWithdrawing Successful. Please wait... ");

                Thread.Sleep(5000);


                Select();
            }
            else if (captchaInput.ToUpper() == "CANCEL")
            {
                Console.WriteLine("Canceling Withdrawing. Please wait... ");

                Thread.Sleep(2500);

                Select();
            }



            balance = balance - moneyWithdrew;
            Console.WriteLine("Please wait.. Withdrawing money... ");

            Thread.Sleep(2500);

            Select();
        }

        public static void Send_Money()
        {
            Console.Title = "Bank Software - Send Money";
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Welcome, {0}\n\n", name);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Your Current Balance is ${0}\n\n", balance);
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("How much do you want to send?");
            Console.Write("$");
            string moneySending = Console.ReadLine();
            double moneySend = Double.Parse(moneySending);

            if (balance < moneySend)
            {
                Console.Clear();
                Console.WriteLine("You're not able to send {0}, when your balance is {1}.", moneySend, balance);
            }



            // Will generate a random number between 1, 2000
            Random rnd = new Random();
            int captcha = rnd.Next(1, 2000);

            // Kinda a Captcha
            Console.WriteLine("Write this in: {0}", captcha);
            string captchaInput = Console.ReadLine();
            int.TryParse(captchaInput, out int captchaInt);


            // This will check if the random number is equal to the userInput.
            if (captcha == captchaInt)
            {
                Console.Clear();
                Console.WriteLine("Sending.. Please wait... ");
                Thread.Sleep(5000);
                Console.Clear();



                Console.WriteLine("\n\nSending Successful. Please wait... ");

                Thread.Sleep(5000);


                Select();
            }
            else if (captchaInput.ToUpper() == "CANCEL")
            {
                Console.WriteLine("Canceling Sending. Please wait... ");

                Thread.Sleep(2500);

                Select();
            }

            balance = balance - moneySend;
            Console.WriteLine("Please wait.. Sending money... ");

            Thread.Sleep(2500);

            Select();


        }
    }
}
