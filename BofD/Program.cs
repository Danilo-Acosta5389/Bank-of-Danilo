using System.Security;

namespace BofD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] userNames = new string[5];
            int[] userPINs = new int[5];
            string[][] userAccounts = new string[5][];
            double[][] userBalances = new double[5][];


            userNames[0] = "D";
            userPINs[0] = 1;
            userAccounts[0] = new string[] { "Personkonto", "Kapitalkonto", "Aktie- och fondkonto" };
            userBalances[0] = new double[] { 1500, 25000, 75000  };
            

            userNames[1] = "Pablo";
            userPINs[1] = 2222;
            userAccounts[1] = new string[] { "Personkonto", "Sparkonto", "Bostadssparande" };
            userBalances[1] = new double[] { 12000, 185000, 2 };
            

            userNames[2] = "Chucky";
            userPINs[2] = 3333;
            userAccounts[2] = new string[] { "Personkonto", "Lånekonto", "ISK-konto", "Chuckybygg" };
            userBalances[2] = new double[] { 1500, 85000, 150000, 1367000};


            userNames[3] = "Maria";
            userPINs[3] = 4444;
            userAccounts[3] = new string[] { "Personkonto", "Cabal Pupuseria", "ISK-konto", "Företagskonto", "Pensionspar" };
            userBalances[3] = new double[] { 1500, 103400, 23000, 500000, 250000 };


            userNames[4] = "Dania";
            userPINs[4] = 5555;
            userAccounts[4] = new string[] { "Personkonto", "Sparkonto", "Bobby"};
            userBalances[4] = new double[] { 32600, 250000, 1000000};


            bool logOut = false;
            int loginRetries = 3;
            bool mainLoop = true;
            while (mainLoop)
            {

                Console.Clear();
                Console.WriteLine("\n::::::::::::::::::::::::::::::::::::::::::::::::::: Välkommen till :::::::::::::::::::::::::::::::::::::::::::::::::::::");
                Console.WriteLine("\r\n /$$$$$$$                      /$$                        /$$$$$$        /$$$$$$$                      /$$ /$$          \r\n| $$__  $$                    | $$                       /$$__  $$      | $$__  $$                    |__/| $$          \r\n| $$  \\ $$  /$$$$$$  /$$$$$$$ | $$   /$$        /$$$$$$ | $$  \\__/      | $$  \\ $$  /$$$$$$  /$$$$$$$  /$$| $$  /$$$$$$ \r\n| $$$$$$$  |____  $$| $$__  $$| $$  /$$/       /$$__  $$| $$$$          | $$  | $$ |____  $$| $$__  $$| $$| $$ /$$__  $$\r\n| $$__  $$  /$$$$$$$| $$  \\ $$| $$$$$$/       | $$  \\ $$| $$_/          | $$  | $$  /$$$$$$$| $$  \\ $$| $$| $$| $$  \\ $$\r\n| $$  \\ $$ /$$__  $$| $$  | $$| $$_  $$       | $$  | $$| $$            | $$  | $$ /$$__  $$| $$  | $$| $$| $$| $$  | $$\r\n| $$$$$$$/|  $$$$$$$| $$  | $$| $$ \\  $$      |  $$$$$$/| $$            | $$$$$$$/|  $$$$$$$| $$  | $$| $$| $$|  $$$$$$/\r\n|_______/  \\_______/|__/  |__/|__/  \\__/       \\______/ |__/            |_______/  \\_______/|__/  |__/|__/|__/ \\______/ \r\n                                                                                                                        \r                                                                                                                        \r                                                                                                                        \r");
                Console.WriteLine("::::::::::::::::::::::::::::::::::::::::: Vi älskar dina pengar mer än dig :::::::::::::::::::::::::::::::::::::::::::::");
                Console.WriteLine();
                loginSection();
            }

            void loginSection()
            {
                bool loginActive = true;
                while (loginActive)
                {
                    logOut = false;

                    Console.Write("\nVar god och ange användarnamn: ");
                    string inputName = Console.ReadLine();
                    Console.Write("Var god och ange PIN-kod: ");

                    SecureString pin = hidePin();
                    string pinCode = new System.Net.NetworkCredential(String.Empty, pin).Password;
                    Console.WriteLine();

                    int inputPIN = 0;
                    bool success = int.TryParse(pinCode, out inputPIN);
                    if (success)
                    {

                        // todo: loopa igenom alla userName och userPassword
                        // om du hittar en matchning, = sucess. anropa en funktion som heter mainMenu(userName, pinCode, string[] accountNames, double[] accountBalances)

                        try
                        {
                            for (int i = 0; i < userNames.Length; i++)
                            {
                                if (inputName.ToLower() == userNames[i].ToLower() && inputPIN == userPINs[i])
                                {
                                    Console.WriteLine("\nLyckad inloggning!");
                                    //Thread.Sleep(1000);
                                    Console.WriteLine();
                                    mainMenu(userNames[i], userPINs[i], userAccounts[i], userBalances[i]);

                                }

                                //Console.WriteLine(i);
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Ojsan! Ett fel inträffade, var god försök igen.");
                        }


                        
                        if (logOut == true)
                        {
                            loginRetries--;
                            Console.WriteLine("Inloggning misslyckades, var god försök igen.");
                            Console.WriteLine("Du har {0} försök kvar", loginRetries);
                            //Thread.Sleep(2000);


                            if (loginRetries == 0)
                            {
                                Console.WriteLine("Antal försök tog slut, systemet stängs ned.");
                                Thread.Sleep(1000);
                                Console.WriteLine("Tack för att du använder Bank of Danilo, vi ser fram emot ditt nästa besök hos oss :).");
                                Thread.Sleep(2000);
                                Environment.Exit(0);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nVar god och ange heltal endast!\n");
                    }
                }
            }
        }

        static void mainMenu(string userName, int pinCode, string[] accountNames, double[] accountBalances)
        {
            Console.WriteLine($"Välkommen tillbaka {userName}!");

            bool optionsRunning = true;
            while (optionsRunning)
            {
                Console.WriteLine();
                Console.WriteLine("Ange 1 för att se konton och saldon");
                Console.WriteLine("Ange 2 för överföring mellan konton");
                Console.WriteLine("Ange 3 för att ta ut pengar");
                Console.WriteLine("Ange 4 för att logga ut");
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
                            Console.WriteLine("\nKonton och saldon\n");
                            for (int i = 0; i < accountNames.Length; i++)
                            {
                                Console.WriteLine($"{accountNames[i]}: {accountBalances[i]} kr");
                            }
                            Console.WriteLine("\nTryck någonstans för att gå tillbaka");
                            Console.ReadKey();
                            break;
                        case 2:
                            Console.WriteLine("\nÖverföring mellan konton\n");
                            transferMoney(accountNames, accountBalances);
                            break;
                        case 3:
                            Console.WriteLine("\nTa ut pengar\n");
                            withdrawMoney(pinCode, accountNames, accountBalances);
                            //Thread.Sleep(2000);
                            break;
                        case 4:
                            Console.WriteLine("\nLogga ut");
                            
                            //Thread.Sleep(1000);
                            Console.WriteLine("Tack för att du använder Bank of Danilo!");
                            //Thread.Sleep(1000);
                            Console.WriteLine("Vi ser fram emot ditt nästa besök hos oss :)");
                            //Thread.Sleep(2000);
                            //logOut = true;
                            //loginRetries = 3;
                            optionsRunning = false;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nVar god och ange siffrorna 1, 2, 3 eller 4.\n");
                }
            }


            // menu
            // withDraw (testa detta först, kolla att överföringen syns i lista konton, kolla att den överlever en logout

            // om det inte funkar:
            // skapa en ny variabel tempAccountBalances = accountBalances
            // tempAccountBalances = withDraw(...,tempACcountBalances)
        }

        
        static void transferMoney(string[] accounts, double[] balances)
        {
            bool transferMenu = true;
            while (transferMenu)
            {
                try
                {
                    for (int i = 0; i < accounts.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}. {accounts[i]}: {balances[i]} kr");
                    }
                    
                    Console.WriteLine("\nOBS! Välj ett konto genom att mata in siffran till vänster om kontonamnet.");
                    Console.WriteLine("     Lämna blankt för att gå tillbaka.\n");
                    Console.Write("Skicka från: ");
                    string fromAccount = Console.ReadLine();
                    int from = int.Parse(fromAccount);

                    Console.Write("Skicka till: ");
                    string toAccount = Console.ReadLine();
                    int to = int.Parse(toAccount);


                    Console.WriteLine($"Du valde skicka från {accounts[from -1]} till {accounts[to -1]}.");
                    Console.WriteLine("Är detta korrekt?");
                    Console.Write("Mata in J eller N: ");
                    string yesNo = Console.ReadLine();


                    if (yesNo.ToLower() == "j")
                    {
                        Console.Write($"Ange belopp: ");
                        double transferAmount = double.Parse(Console.ReadLine());
                        
                        if(transferAmount > balances[from -1])
                        {
                            Console.WriteLine();
                            Console.WriteLine("Ojsan! Det gick inte att överföra.");
                            Console.WriteLine("Täckning saknas på kontot.");
                            Console.WriteLine();
                        }
                        else if(transferAmount < 0) 
                        {
                            Console.WriteLine();
                            Console.WriteLine("Ojsan! Det gick inte att överföra.");
                            Console.WriteLine("Beloppet var för lågt!");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine();
                            balances[from - 1] = balances[from - 1] - transferAmount;
                            balances[to - 1] = balances[to - 1] + transferAmount;
                            Console.WriteLine("Yippi! Överföring lyckades!");
                            Console.WriteLine();
                            
                        }
                    }
                    else if (yesNo.ToLower() == "n")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Var god och mata in \"J\" eller \"N\"" );
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Ojsan! Mata in rätt värde.");
                }

                Console.WriteLine("Tryck någonstans för att gå tillbaka");
                Console.ReadKey();
                transferMenu = false;
            }
        }

        static void withdrawMoney(int pinCode, string[] accounts, double[] balances)
        {
            try
            {
                for (int i = 0; i < accounts.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {accounts[i]}: {balances[i]} kr");
                }
                Console.WriteLine("\nOBS! Välj ett konto genom att mata in siffran till vänster om kontonamnet.");
                Console.WriteLine("     Lämna blankt för att gå tillbaka.\n");
                Console.Write("Ta ut från: ");
                string chooseAccount = Console.ReadLine();
                int chosenAccount = int.Parse(chooseAccount);

                Console.WriteLine($"Ta ut från {accounts[chosenAccount - 1]}.");
                Console.WriteLine("Är detta korrekt?");
                Console.Write("Mata in \"J\" eller \"N\": ");
                string yesNo = Console.ReadLine();

                if (yesNo.ToLower() == "j")
                {

                    Console.WriteLine("OBS! Ange PIN-kod för att fortsätta uttag");
                    Console.Write("--> ");
                    SecureString pin = hidePin();
                    string pinCheck = new System.Net.NetworkCredential(String.Empty, pin).Password;
                    Console.WriteLine();
                    int inputPIN = 0;
                    bool success = int.TryParse(pinCheck, out inputPIN);
                    if (success)
                    {
                        if(inputPIN == pinCode)
                        {
                            Console.Write($"Ange belopp: ");
                            double withdrawAmount = double.Parse(Console.ReadLine());
                            if (withdrawAmount > balances[chosenAccount - 1])
                            {
                                Console.WriteLine();
                                Console.WriteLine("Ojsan! Det gick inte att överföra.");
                                Console.WriteLine("Täckning saknas på kontot.");
                                Console.WriteLine();
                            }
                            else if (withdrawAmount < 0)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Ojsan! Det gick inte att överföra.");
                                Console.WriteLine("Beloppet var för lågt!");
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine();
                                balances[chosenAccount - 1] = balances[chosenAccount - 1] - withdrawAmount;
                                Console.WriteLine("Uttag lyckades!");
                                Console.WriteLine($"\nTog ut {withdrawAmount} kr från {accounts[chosenAccount - 1]}.");
                                Console.WriteLine($"Det finns {balances[chosenAccount - 1]} kr kvar på kontot");
                                Console.WriteLine();
                                Console.WriteLine("Tryck enter för att komma till huvudmenyn");
                                Console.ReadKey();

                            }
                        }
                        else if(inputPIN != pinCode)
                        { 
                            Console.WriteLine(); Console.WriteLine("Fel PIN."); 
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("Error");
                    }

                    
                }
                else if(yesNo.ToLower() == "n")
                {
                    Console.WriteLine("nej");
                }
                else
                {
                    Console.WriteLine("ok");
                }

                
            }
            catch (Exception)
            { Console.WriteLine("Fel! Försök igen."); }

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