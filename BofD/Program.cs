using System.Security;

namespace BofD
{
    internal class Program
    {
        static void Main(string[] args)
        {

            bool mainLoop = true;
            while (mainLoop)
            {
                Console.Clear();
                Console.WriteLine("\n:::::::::::::::::::::::::::::::::::::::::::::::::::::::: Welcome to ::::::::::::::::::::::::::::::::::::::::::::::::::::");
                Console.WriteLine("\r\n /$$$$$$$                      /$$                        /$$$$$$        /$$$$$$$                      /$$ /$$          \r\n| $$__  $$                    | $$                       /$$__  $$      | $$__  $$                    |__/| $$          \r\n| $$  \\ $$  /$$$$$$  /$$$$$$$ | $$   /$$        /$$$$$$ | $$  \\__/      | $$  \\ $$  /$$$$$$  /$$$$$$$  /$$| $$  /$$$$$$ \r\n| $$$$$$$  |____  $$| $$__  $$| $$  /$$/       /$$__  $$| $$$$          | $$  | $$ |____  $$| $$__  $$| $$| $$ /$$__  $$\r\n| $$__  $$  /$$$$$$$| $$  \\ $$| $$$$$$/       | $$  \\ $$| $$_/          | $$  | $$  /$$$$$$$| $$  \\ $$| $$| $$| $$  \\ $$\r\n| $$  \\ $$ /$$__  $$| $$  | $$| $$_  $$       | $$  | $$| $$            | $$  | $$ /$$__  $$| $$  | $$| $$| $$| $$  | $$\r\n| $$$$$$$/|  $$$$$$$| $$  | $$| $$ \\  $$      |  $$$$$$/| $$            | $$$$$$$/|  $$$$$$$| $$  | $$| $$| $$|  $$$$$$/\r\n|_______/  \\_______/|__/  |__/|__/  \\__/       \\______/ |__/            |_______/  \\_______/|__/  |__/|__/|__/ \\______/ \r\n                                                                                                                        \r                                                                                                                        \r                                                                                                                        \r");
                Console.WriteLine(":::::::::::::::::::::::::::::::::::::::::::::: Where money has never ment more :::::::::::::::::::::::::::::::::::::::::");
                Console.WriteLine();
                loginSection();
            }

        }

        static void loginSection()
        {
            string[] userAccount = new string[5] { "Danilo", "Pablo", "Chucky", "Maria", "Dania" };
            int[] userPassword = new int[5] { 1111, 2222, 3333, 4444, 5555 };

            bool loginActive = true;
            int loginRetries = 3;
            while (loginActive)
            {
                Console.Write("Please enter account name: ");
                string inputName = Console.ReadLine();
                Console.Write("Please enter PIN: ");

                SecureString pin = hidePin();
                string pinCode = new System.Net.NetworkCredential(String.Empty, pin).Password;
                Console.WriteLine();

                int inputPIN = 0;
                bool success = int.TryParse(pinCode, out inputPIN);

                if(success)
                {
                    if (inputName.ToLower() == userAccount[0].ToLower() && inputPIN == userPassword[0])
                    {
                        Console.WriteLine("\nLogin successfull!");
                        Console.WriteLine("\nWelcome back {0} ", userAccount[0]);
                        Thread.Sleep(1000);
                        Console.WriteLine();
                        accountOptions();
                        break;

                    }
                    else if (inputName.ToLower() == userAccount[1].ToLower() && inputPIN == userPassword[1])
                    {
                        Console.WriteLine("Login successfull!");
                        Console.WriteLine();
                        Console.WriteLine("Welcome back {0} ", userAccount[1]);
                        Thread.Sleep(1000);
                        Console.WriteLine();
                        accountOptions();
                        break;
                    }
                    else if (inputName.ToLower() == userAccount[2].ToLower() && inputPIN == userPassword[2])
                    {
                        Console.WriteLine("Login successfull!");
                        Console.WriteLine();
                        Console.WriteLine("Welcome back {0} ", userAccount[2]);
                        Thread.Sleep(1000);
                        Console.WriteLine();
                        accountOptions();
                        break;
                    }
                    else if (inputName.ToLower() == userAccount[3].ToLower() && inputPIN == userPassword[3])
                    {
                        Console.WriteLine("Login successfull!");
                        Console.WriteLine();
                        Console.WriteLine("Welcome back {0} ", userAccount[3]);
                        Thread.Sleep(1000);
                        Console.WriteLine();
                        accountOptions();
                        break;
                    }
                    else if (inputName.ToLower() == userAccount[4].ToLower() && inputPIN == userPassword[4])
                    {
                        Console.WriteLine("Login successfull!");
                        Console.WriteLine();
                        Console.WriteLine("Welcome back {0}", userAccount[4]);
                        Thread.Sleep(1000);
                        Console.WriteLine();
                        accountOptions();
                        break;
                    }
                    else
                    {
                        loginRetries--;
                        Console.WriteLine("Unsuccessful login, Please try again");
                        Console.WriteLine("You have {0} tries left", loginRetries);
                        Thread.Sleep(2000);

                        if (loginRetries == 0)
                        {
                            Console.WriteLine("Login tries expired, system is shutting down.");
                            Thread.Sleep(1000);
                            Console.WriteLine("Thank you for using Bank of Danilo. We look forward to your next visit.");
                            Thread.Sleep(2000);
                            Environment.Exit(0);

                        }
                    }
                }
                else
                {
                    Console.WriteLine("\nPlease enter whole numbers only!\n");
                }
            }
        }

        static void accountOptions()
        {
            bool optionsRunning = true;
            while (optionsRunning)
            {
                Console.WriteLine("Press 1 to check accounts and balance");
                Console.WriteLine("Press 2 to transfer between accounts");
                Console.WriteLine("Press 3 to withdraw");
                Console.WriteLine("Press 4 to log out");
                Console.Write("--> ");
                string options = Console.ReadLine();
                int numKey = 0;
                bool success = Int32.TryParse(options, out numKey);
                if (success)
                {
                    Console.WriteLine(numKey);
                    switch (numKey)
                    {
                        case 1:
                            Console.WriteLine("\nYou've choosed option 1");
                            Console.WriteLine("\nOops! This page is still under construction, please come again soon :) \n");
                            Thread.Sleep(2000);
                            break;
                        case 2:
                            Console.WriteLine("\nYou've choosed option 2");
                            Console.WriteLine("\nOops! This page is still under construction, please come again soon :) \n");
                            Thread.Sleep(2000);
                            break;
                        case 3:
                            Console.WriteLine("\nYou've choosed option 1");
                            Console.WriteLine("\nOops! This page is still under construction, please come again soon :) \n");
                            Thread.Sleep(2000);
                            break;
                        case 4:
                            Console.WriteLine("\nYou've choosed option 4");
                            Thread.Sleep(1000);
                            Console.WriteLine("Logging out now...");
                            Thread.Sleep(1000);
                            Console.WriteLine("Thanks for using Bank of Danilo!");
                            Thread.Sleep(1000);
                            Console.WriteLine("Look forward to your next visit ;)");
                            Thread.Sleep(2000);
                            optionsRunning = false;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nPlease enter keys 1, 2, 3 or 4 only.\n");
                }
            }
        }

        static SecureString hidePin()
        {
            SecureString pin = new SecureString();
            ConsoleKeyInfo keyInfo;

            do
            {
                keyInfo = Console.ReadKey(true);
                if (!char.IsControl(keyInfo.KeyChar))
                {
                    pin.AppendChar(keyInfo.KeyChar);
                    Console.Write("*");
                }
                else if (keyInfo.Key == ConsoleKey.Backspace && pin.Length > 0)
                {
                    pin.RemoveAt(pin.Length - 1);
                    Console.Write("\b \b");
                }
            }
            while (keyInfo.Key != ConsoleKey.Enter);
            {
                return pin;
            }
        }
    }
}