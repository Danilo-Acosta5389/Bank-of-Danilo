using System.Security;

namespace BofD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] userName = new string[5];
            int[] userPassword = new int[5];
            string[] userAccounts = new string[5];
            double[] userBalance = new double[5];

            //string[][] newUserAccountNames = new string[5][];
            //newUserAccountNames[0] = new string[] { "Main account", "Savings account" };
            //double[][] newUserBalances = new double[5][];
            //newUserBalances[0] = new double[] { 1500, 85000 };

            userName[0] = "Danilo";
            userPassword[0] = 1111;
            string[] firstUserAccounts = new string[] { "Main account", "Savings account" };
            double[] firstUserBalance = new double[] { 1500, 85000 };

            userName[1] = "Pablo";
            userPassword[1] = 2222;
            string[] secondUserAccounts = new string[] { "Main account", "Savings account" };
            double[] secondUserBalance = new double[] { 1500, 85000 };

            userName[2] = "Chucky";
            userPassword[2] = 3333;
            userAccounts[2] = "Main account";
            userBalance[2] = 0;

            userName[3] = "Maria";
            userPassword[3] = 4444;
            userAccounts[3] = "Main account";
            userBalance[3] = 0;

            userName[4] = "Dania";
            userPassword[4] = 5555;
            userAccounts[4] = "Main account";
            userBalance[4] = 0;


            bool logOut = false;
            int loginRetries = 3;
            bool mainLoop = true;
            while (mainLoop)
            {
                
                Console.Clear();
                Console.WriteLine("\n:::::::::::::::::::::::::::::::::::::::::::::::::::::::: Welcome to ::::::::::::::::::::::::::::::::::::::::::::::::::::");
                Console.WriteLine("\r\n /$$$$$$$                      /$$                        /$$$$$$        /$$$$$$$                      /$$ /$$          \r\n| $$__  $$                    | $$                       /$$__  $$      | $$__  $$                    |__/| $$          \r\n| $$  \\ $$  /$$$$$$  /$$$$$$$ | $$   /$$        /$$$$$$ | $$  \\__/      | $$  \\ $$  /$$$$$$  /$$$$$$$  /$$| $$  /$$$$$$ \r\n| $$$$$$$  |____  $$| $$__  $$| $$  /$$/       /$$__  $$| $$$$          | $$  | $$ |____  $$| $$__  $$| $$| $$ /$$__  $$\r\n| $$__  $$  /$$$$$$$| $$  \\ $$| $$$$$$/       | $$  \\ $$| $$_/          | $$  | $$  /$$$$$$$| $$  \\ $$| $$| $$| $$  \\ $$\r\n| $$  \\ $$ /$$__  $$| $$  | $$| $$_  $$       | $$  | $$| $$            | $$  | $$ /$$__  $$| $$  | $$| $$| $$| $$  | $$\r\n| $$$$$$$/|  $$$$$$$| $$  | $$| $$ \\  $$      |  $$$$$$/| $$            | $$$$$$$/|  $$$$$$$| $$  | $$| $$| $$|  $$$$$$/\r\n|_______/  \\_______/|__/  |__/|__/  \\__/       \\______/ |__/            |_______/  \\_______/|__/  |__/|__/|__/ \\______/ \r\n                                                                                                                        \r                                                                                                                        \r                                                                                                                        \r");
                Console.WriteLine("::::::::::::::::::::::::::::::::::::::::::: Where money has never meant more :::::::::::::::::::::::::::::::::::::::::::");
                Console.WriteLine();
                loginSection();
            }

            void loginSection()
            {
                bool loginActive = true;
                while (loginActive)
                {
                    logOut = false;

                    Console.Write("\nPlease enter account name: ");
                    string inputName = Console.ReadLine();
                    Console.Write("Please enter PIN: ");

                    SecureString pin = hidePin();
                    string pinCode = new System.Net.NetworkCredential(String.Empty, pin).Password;
                    Console.WriteLine();
                    
                    int inputPIN = 0;
                    bool success = int.TryParse(pinCode, out inputPIN);
                    if (success)
                    {

                        // todo: loopa igenom alla userName och userPassword
                        // om du hittar en matchning, = sucess. anropa en funktion som heter mainMenu(userName, pinCode, string[] accountNames, double[] accountBalances)

                        for (int i = 0; i < userName.Length; i++)
                        {
                            if (inputName.ToLower() == userName[i].ToLower() && inputPIN == userPassword[i])
                            {
                                Console.WriteLine("\nLogin successfull!");
                                Console.WriteLine("\nWelcome back {0} ", userName[i]);
                                Thread.Sleep(1000);
                                Console.WriteLine();
                                //mainMenu();
                                firstUser();
                            }
                            //Console.WriteLine(i);
                        }
                        if (logOut != true)
                        {
                            loginRetries--;
                            Console.WriteLine("Unsuccessful login, Please try again");
                            Console.WriteLine("You have {0} tries left", loginRetries);
                            //Thread.Sleep(2000);


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

            void firstUser()
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
                                Console.WriteLine("\nAccounts and balance");
                                Console.WriteLine("{0}: {1} kr", firstUserAccounts[0], firstUserBalance[0]);
                                Console.WriteLine("{0}: {1} kr", firstUserAccounts[1], firstUserBalance[1]);
                                Console.WriteLine("\nPress any key to return");
                                Console.ReadKey();
                                break;
                            case 2:
                                Console.WriteLine("\nTransfer between accounts");

                                bool transferMenu = true;
                                while (transferMenu)
                                {
                                    Console.WriteLine("1. {0}: {1} kr", firstUserAccounts[0], firstUserBalance[0]);
                                    Console.WriteLine("2. {0}: {1} kr", firstUserAccounts[1], firstUserBalance[1]);
                                    Console.Write("\nChoose from account: ");
                                    int from = int.Parse(Console.ReadLine());
                                    Console.Write("Choose to account: ");
                                    int to = int.Parse(Console.ReadLine());

                                    if (from == 1 && to == 2)
                                    {
                                        Console.WriteLine("You've selected from: {0} to {1}", firstUserAccounts[0], firstUserAccounts[1]);
                                        Console.Write("Is this correct? Y/N: ");
                                        string yesNo = Console.ReadLine();
                                        if (yesNo.ToLower() == "y")
                                        {
                                            Console.WriteLine("Enter amount you would like to transfer: ");
                                            double transferAmount = double.Parse(Console.ReadLine());
                                            if (transferAmount > firstUserBalance[0])
                                            {
                                                Console.WriteLine("Not enough money in account");
                                            }
                                            else if (transferAmount < 0)
                                            {
                                                Console.WriteLine("Cannot transfer ammount");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Transfer was successful!");
                                                firstUserBalance[0] = firstUserBalance[0] - transferAmount;
                                                firstUserBalance[1] = transferAmount + firstUserBalance[1];
                                                Console.WriteLine("Press anywhere to return");
                                                Console.ReadKey();
                                                transferMenu = false;
                                            }
                                        }
                                        else if (yesNo.ToLower() == "n") { break; }
                                        else { Console.WriteLine("Please enter Y or N to continue"); }
                                    }
                                }

                                break;
                            case 3:
                                Console.WriteLine("\nYou've choosed option 3");
                                Console.WriteLine("\nOops! This page is still under construction, please come again soon :) \n");
                                Thread.Sleep(2000);
                                break;
                            case 4:
                                Console.WriteLine("\nYou've choosed option 4");
                                //Thread.Sleep(1000);
                                Console.WriteLine("Logging out now...");
                                //Thread.Sleep(1000);
                                Console.WriteLine("Thanks for using Bank of Danilo!");
                                //Thread.Sleep(1000);
                                Console.WriteLine("Look forward to your next visit ;)");
                                //Thread.Sleep(2000);
                                logOut = true;
                                loginRetries = 3;
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

            void secondUser()
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
                                Console.WriteLine("\nAccounts and balance");
                                Console.WriteLine("{0}: {1} kr", firstUserAccounts[0], firstUserBalance[0]);
                                Console.WriteLine("{0}: {1} kr", firstUserAccounts[1], firstUserBalance[1]);
                                Console.WriteLine("\nPress any key to return");
                                Console.ReadKey();
                                break;
                            case 2:
                                Console.WriteLine("\nTransfer between accounts");

                                bool transferMenu = true;
                                while (transferMenu)
                                {
                                    Console.WriteLine("1. {0}: {1} kr", firstUserAccounts[0], firstUserBalance[0]);
                                    Console.WriteLine("2. {0}: {1} kr", firstUserAccounts[1], firstUserBalance[1]);
                                    Console.Write("\nChoose from account: ");
                                    int from = int.Parse(Console.ReadLine());
                                    Console.Write("Choose to account: ");
                                    int to = int.Parse(Console.ReadLine());

                                    if (from == 1 && to == 2)
                                    {
                                        Console.WriteLine("You've selected from: {0} to {1}", firstUserAccounts[0], firstUserAccounts[1]);
                                        Console.Write("Is this correct? Y/N: ");
                                        string yesNo = Console.ReadLine();
                                        if (yesNo.ToLower() == "y")
                                        {
                                            Console.WriteLine("Enter amount you would like to transfer: ");
                                            double transferAmount = double.Parse(Console.ReadLine());
                                            if (transferAmount > firstUserBalance[0])
                                            {
                                                Console.WriteLine("Not enough money in account");
                                            }
                                            else if (transferAmount < 0)
                                            {
                                                Console.WriteLine("Cannot transfer ammount");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Transfer was successful!");
                                                firstUserBalance[0] = firstUserBalance[0] - transferAmount;
                                                firstUserBalance[1] = transferAmount + firstUserBalance[1];
                                                Console.WriteLine("Press anywhere to return");
                                                Console.ReadKey();
                                                transferMenu = false;
                                            }
                                        }
                                        else if (yesNo.ToLower() == "n")
                                        {
                                            break;
                                        }
                                        else
                                        { Console.WriteLine("Please enter Y or N to continue"); }
                                    }
                                }

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

            void thirdUser()
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


            void fourthUser()
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
                                Console.WriteLine("Looking forward to your next visit ;)");
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

            void fifthUser()
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

            //void mainMenu()
            //{

            //}

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