using System.Globalization;
using System.Security; //System.Security finns för att kunna anropa SecureString classen

namespace BofD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Arryer som agerar databas
            //Jagged arrays har konton och saldon: totalt finns det 5 konton.
            string[] userNames = new string[5];
            int[] userPINs = new int[5];
            string[][] userAccounts = new string[5][];
            double[][] userBalances = new double[5][];


            userNames[0] = "Danilo";
            userPINs[0] = 1111;
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

            //Datum och tid finns av kosmetiska skäl
            string[] months = {"Januari", "Februari", "Mars", "April", "Maj",
            "Juni", "Juli", "Augusti", "September", "Oktober", "November", "December"};

            //Antal försök är satt till 3, förändras längre ned
            int loginRetries = 3;
            bool logOut = true; 
            //LogOut boolen finns för att bestämma om en person -
            //har anget fel pinkod vid inlogging eller om det var en utloggning

            bool mainLoop = true;
            while (mainLoop)
            {
                //Jag ville ha möjligheten att skicka fram skylten Bank of Danilo, på olika ställen.
                
                welcomeSign();
                loginSection(); 
                
                //Inloggningsfunktion tror inte att denna behövs egentligen,
                //men tyckte att det såg mer ordnat ut så
            }
            
            void welcomeSign()
            {
                Console.Clear();
                Console.WriteLine("Bank of Danilo LTD banking application version 5.0.0.9, all rights reserved.");
                Console.WriteLine("\n::::::::::::::::::::::::::::::::::::::::::::::::::: Välkommen till :::::::::::::::::::::::::::::::::::::::::::::::::::::");
                Console.WriteLine("\r\n /$$$$$$$                      /$$                        /$$$$$$        /$$$$$$$                      /$$ /$$          \r\n| $$__  $$                    | $$                       /$$__  $$      | $$__  $$                    |__/| $$          \r\n| $$  \\ $$  /$$$$$$  /$$$$$$$ | $$   /$$        /$$$$$$ | $$  \\__/      | $$  \\ $$  /$$$$$$  /$$$$$$$  /$$| $$  /$$$$$$ \r\n| $$$$$$$  |____  $$| $$__  $$| $$  /$$/       /$$__  $$| $$$$          | $$  | $$ |____  $$| $$__  $$| $$| $$ /$$__  $$\r\n| $$__  $$  /$$$$$$$| $$  \\ $$| $$$$$$/       | $$  \\ $$| $$_/          | $$  | $$  /$$$$$$$| $$  \\ $$| $$| $$| $$  \\ $$\r\n| $$  \\ $$ /$$__  $$| $$  | $$| $$_  $$       | $$  | $$| $$            | $$  | $$ /$$__  $$| $$  | $$| $$| $$| $$  | $$\r\n| $$$$$$$/|  $$$$$$$| $$  | $$| $$ \\  $$      |  $$$$$$/| $$            | $$$$$$$/|  $$$$$$$| $$  | $$| $$| $$|  $$$$$$/\r\n|_______/  \\_______/|__/  |__/|__/  \\__/       \\______/ |__/            |_______/  \\_______/|__/  |__/|__/|__/ \\______/ \r\n                                                                                                                        \r                                                                                                                        \r                                                                                                                        \r");
                Console.WriteLine("::::::::::::::::::::::::::::::::::::::::: Vi älskar dina pengar mer än dig :::::::::::::::::::::::::::::::::::::::::::::");
                Console.WriteLine();
                DateTime now = DateTime.Now;
                Console.WriteLine($"Den {now.Day} {months[now.Month - 1]} {now.Year} {now:HH:mm:ss}");
            }

            void loginSection()
            {
                bool loginActive = true;
                while (loginActive)
                {
                    welcomeSign();
                    if (logOut != true)
                    {
                        loginRetries--;
                        Console.WriteLine("Inloggning misslyckades, var god försök igen.");
                        Console.WriteLine($"Du har {loginRetries} försök kvar");
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
                    //Inloggningsförsöks systemet finns här
                    //Systemet ska kunna veta om man har anget rätt siffror vid pinkod
                    //eller om det var en sträng - i så fall räknas det inte som fel pin, man får försöka igen.

                    logOut = false;

                    Console.Write("\nVar god och ange användarnamn: ");
                    string inputName = Console.ReadLine();
                    Console.Write("Var god och ange PIN-kod: ");

                    //Koden nedan är för att dölja pinkoden,
                    //int konverteras till char ersätts med en asterisk *
                    SecureString pin = hidePin();
                    string pinCode = new System.Net.NetworkCredential(String.Empty, pin).Password;
                    Console.WriteLine();

                    int inputPIN = 0;
                    bool success = int.TryParse(pinCode, out inputPIN);
                    if (success)
                    {
                        try
                        {   //Här testast det inmatade användarnamnet och pinkod mot våran "databas"
                            for (int i = 0; i < userNames.Length; i++)
                            {
                                if (inputName.ToLower() == userNames[i].ToLower() && inputPIN == userPINs[i])
                                {
                                    //När det finns en matchning skickas allt som finns på rätt index in i denna funktion
                                    mainMenu(userNames[i], userPINs[i], userAccounts[i], userBalances[i]);
                                    logOut = true;
                                    loginRetries = 3; 
                                    //Här vet systemet att det är en giltig inloggning
                                    //och antal försök ställs om till 3
                                }
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Ojsan! Ett fel inträffade, var god försök igen.");
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("\nOgiltigt val. Var god och ange heltal endast!\n");
                        logOut = true;
                    }
                }
            }
        }

        //Menyfunktionen som tar in indexerad användarnamn, pinkod, rätt array av konton och saldon

        static void mainMenu(string userName, int pinCode, string[] accountNames, double[] accountBalances)
        {
            Console.Clear();
            Console.WriteLine("Bank of Danilo LTD banking application version 5.0.0.9, all rights reserved.\n\n");
            Console.WriteLine("Inloggning lyckades!");
            Console.WriteLine($"\nVälkommen tillbaka {userName}!");
            
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
                        
                        case 1: //För att se konton och saldon itereras de jagged arrays som togs in
                            Console.WriteLine("\nKonton och saldon\n");
                            for (int i = 0; i < accountNames.Length; i++)
                            {
                                Console.WriteLine($"{accountNames[i]}: {Math.Round(accountBalances[i], 2)} kr");
                            }
                            Console.WriteLine("\nTryck enter för att komma till huvudmenyn");
                            Console.ReadKey();
                            break;
                        case 2://Här kallas en funktion för överföring mellan konton, de jagged arrays som redan har tagits in, tas in igen.
                            Console.WriteLine("\nÖverföring mellan konton\n");
                            transferMoney(accountNames, accountBalances);
                            break;
                        case 3: //Funktion för att ta ut pengar, ganska likt överföring mellan konton
                            Console.WriteLine("\nTa ut pengar\n");
                            withdrawMoney(pinCode, accountNames, accountBalances);
                            //Thread.Sleep(2000);
                            break;
                        case 4: //Logga ut stoppar helt enkelt while loopen för att menyn ska loopa klart.
                            Console.WriteLine("\nLogga ut");
                            //Thread.Sleep(1000);
                            Console.WriteLine("Tack för att du använder Bank of Danilo!");
                            //Thread.Sleep(1000);
                            Console.WriteLine("Vi ser fram emot ditt nästa besök hos oss :)");
                            //Thread.Sleep(2000);
                            optionsRunning = false;
                            break;
                        default:
                            Console.WriteLine("\nOgiltigt val. Var god och ange siffran 1, 2, 3 eller 4.\n");
                            break;
                    }
                }
                else //Felhantering finns i olika former, TryParse och TryCatche eller i switchsatsen
                {
                    Console.WriteLine("\nOgiltigt val. Var god och ange siffran 1, 2, 3 eller 4.\n");
                }
            }
        }

        //Nedan kommer överföring mellan konton

        static void transferMoney(string[] accounts, double[] balances)
        {
            bool transferMenu = true;
            while (transferMenu)
            {
                try
                {   //Itererar mellan inhämtade konton och saldon
                    for (int i = 0; i < accounts.Length; i++)
                    {   
                        //Math.Round(double,int) används för att visa max två decimaler
                        //dessa decimaler representar ören.

                        Console.WriteLine($"{i + 1}. {accounts[i]}: {Math.Round(balances[i], 2)} kr");
                    }

                    //Instruktioner för användaren
                    
                    Console.WriteLine("\nOBS! Välj ett konto genom att mata in siffran till vänster om kontonamnet.");
                    Console.WriteLine("-- Eller lämna blankt och tryck enter för att avbryta.\n");
                    Console.Write("Skicka från: ");
                    string fromAccount = Console.ReadLine();
                    int from = int.Parse(fromAccount);

                    Console.Write("Skicka till: ");
                    string toAccount = Console.ReadLine();
                    int to = int.Parse(toAccount);
                    Console.WriteLine();
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
                            Console.WriteLine("Täckning saknas på kontot.");
                            Console.WriteLine();
                        }
                        else if(transferAmount <= 0) 
                        {
                            Console.WriteLine();
                            Console.WriteLine("Beloppet var för lågt.");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine();
                            balances[from - 1] = balances[from - 1] - transferAmount;
                            balances[to - 1] = balances[to - 1] + transferAmount;
                            Console.WriteLine("Överföring lyckades!");
                            Console.WriteLine($"\nÖverföring på {Math.Round(transferAmount, 2)} kr från {accounts[from - 1]} till {accounts[to - 1]}");
                            Console.WriteLine($"Det finns nu totalt: {Math.Round(balances[to - 1], 2)} kr på {accounts[to - 1]}");
                            Console.WriteLine($"och totalt: {Math.Round(balances[from - 1], 2)} kr på {accounts[from - 1]}.");
                            Console.WriteLine();
                            Console.WriteLine("Tryck enter för att komma till huvudmenyn");
                            Console.ReadKey();
                            transferMenu = false;
                        }
                    }
                    else if (yesNo.ToLower() == "n")
                    {
                        Console.WriteLine();
                        continue;
                    }
                    else
                    {
                        
                        Console.WriteLine("Var god och mata in \"J\" eller \"N\"" );
                        Console.WriteLine();
                        continue;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Ogiltigt val.");
                    Console.Write("Tillbaka till huvudmenyn? J/N: ");
                    string yesNo = Console.ReadLine();
                    if (yesNo.ToLower() == "j")
                    {
                        transferMenu = false;
                    }
                    else if (yesNo.ToLower() == "n")
                    {
                        Console.WriteLine();
                        continue;
                    }
                    
                }
            }
        }

        //Funktion för att ta ut pengar nedan
        //Tar in pinkoden från inloggningen, konton och saldon
        static void withdrawMoney(int pinCode, string[] accounts, double[] balances)
        {
            bool withDrawRunning = true;
            while(withDrawRunning)
            {
                try
                {
                    for (int i = 0; i < accounts.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}. {accounts[i]}: {balances[i]} kr");
                    }
                    Console.WriteLine("\nOBS! Välj ett konto genom att mata in siffran till vänster om kontonamnet.");
                    Console.WriteLine("-- Eller lämna blankt och tryck enter för att avbryta.\n"); 

                    //Lite workaround för den som vill kunna avbryta mitt i

                    Console.Write("Ta ut från: ");
                    string chooseAccount = Console.ReadLine();
                    int chosenAccount = int.Parse(chooseAccount);
                    Console.WriteLine();
                    Console.WriteLine($"Ta ut från {accounts[chosenAccount - 1]}.");
                    Console.WriteLine("Är detta korrekt?");
                    Console.Write("Mata in \"J\" eller \"N\": ");
                    string yesNo = Console.ReadLine();

                    if (yesNo.ToLower() == "j")
                    {
                        //Användare måste ange PIN för att göra uttag, annars går det inte
                        //PINkoden använder samma metod som vid inloggingen.

                        Console.WriteLine("OBS! Ange PIN-kod för att fortsätta uttag");
                        Console.Write("--> ");
                        SecureString pin = hidePin();
                        string pinCheck = new System.Net.NetworkCredential(String.Empty, pin).Password;
                        Console.WriteLine();
                        int inputPIN = 0;
                        bool success = int.TryParse(pinCheck, out inputPIN);
                        if (success)
                        {
                            if (inputPIN == pinCode)
                            {
                                Console.Write($"Ange belopp: ");
                                double withdrawAmount = double.Parse(Console.ReadLine());
                                if (withdrawAmount > balances[chosenAccount - 1])
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Täckning saknas på kontot.");
                                    Console.WriteLine();
                                }
                                else if (withdrawAmount <= 0)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Beloppet var för lågt.");
                                    Console.WriteLine();
                                }
                                else
                                {
                                    Console.WriteLine();
                                    balances[chosenAccount - 1] = balances[chosenAccount - 1] - withdrawAmount;
                                    Console.WriteLine("Uttag lyckades!");
                                    Console.WriteLine($"\nTog ut {Math.Round(withdrawAmount, 2)} kr från {accounts[chosenAccount - 1]}.");
                                    Console.WriteLine($"Det finns {Math.Round(balances[chosenAccount - 1], 2)} kr kvar på kontot");
                                    Console.WriteLine();
                                    Console.WriteLine("Tryck enter för att komma till huvudmenyn");
                                    Console.ReadKey();
                                    withDrawRunning = false;
                                }
                            }
                            else if (inputPIN != pinCode) { Console.WriteLine(); Console.WriteLine("Ogiltig PIN"); }

                        }
                        else 
                        { 
                            Console.WriteLine("Ett fel inträffade, var god försök igen.");
                            Console.WriteLine();
                        }

                    }
                    else if (yesNo.ToLower() == "n")
                    {
                        Console.Write("Tillbaka till huvudmenyn? J/N: ");
                        yesNo = Console.ReadLine();
                        if (yesNo.ToLower() == "j")
                        {
                            withDrawRunning = false;
                        }
                        else if (yesNo.ToLower() == "n")
                        {
                            Console.WriteLine();
                            continue;
                        }
                    }
                    else 
                    {
                        Console.Write("Tillbaka till huvudmenyn? J/N: ");
                        yesNo = Console.ReadLine();
                        if (yesNo.ToLower() == "j")
                        {
                            withDrawRunning = false;
                        }
                        else if(yesNo.ToLower() == "n")
                        {
                            Console.WriteLine();
                            continue;
                        }
                        
                    }


                }
                catch (Exception)
                {
                    Console.WriteLine("Ogiltigt val.");
                    Console.Write("Tillbaka till huvudmenyn? J/N: ");
                    string yesNo = Console.ReadLine();
                    if (yesNo.ToLower() == "j")
                    {
                        withDrawRunning = false;
                    }
                    else if (yesNo.ToLower() == "n")
                    {
                        Console.WriteLine();
                        continue;
                    }
                }
            }

        }

        //Funktionen för att dölja PINkoden

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