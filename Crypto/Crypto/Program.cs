using Crypto.Classes.Assets;
using Crypto.Classes.Wallets;
using System;

namespace Crypto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int UserChoice = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("1 - Kreiraj wallet");
                Console.WriteLine("2 - Pristupi walletu");
                UserChoice = ParsingUserInput(1,2);
                switch (UserChoice) {
                    case 1:
                        CreateWallet();
                        continue;
                    case 2:
                        ListOfWallets.Disp();
                        Console.WriteLine("Unesi adresu walleta kojem želiš pristupiti");
                        string InputedAdress = "";
                        do
                        {
                            InputedAdress = Console.ReadLine();
                            if (!ListOfWallets.CheckingIfWalletExists(InputedAdress))
                                Console.WriteLine("Nepostojeća Adresa");
                        } while (!ListOfWallets.CheckingIfWalletExists(InputedAdress));

                        Console.WriteLine("1 - Portfolio");
                        Console.WriteLine("2 - Transfer");
                        Console.WriteLine("3 - Povijest Transakcija");
                        Console.WriteLine("4 - Povratak na inicijalni meni");
                        Wallet EnteredWallet = ListOfWallets.GetWalletByAdress(Guid.Parse(InputedAdress));
                        UserChoice = ParsingUserInput(1, 4);
                        switch (UserChoice)
                        {
                            case 1:
                                EnteredWallet.Portfolio();
                                Console.WriteLine("Pritisni bilokoji botun za povratak na pocetni meni");
                                Console.ReadKey();
                                continue;
                            case 2:
                                string AdressORecievingWallet = "";
                                do
                                {
                                    AdressORecievingWallet = Console.ReadLine();
                                    if (!ListOfWallets.CheckingIfWalletExists(AdressORecievingWallet))
                                        Console.WriteLine("Nepostojeća Adresa");
                                } while (!ListOfWallets.CheckingIfWalletExists(AdressORecievingWallet));

                                string AdressOfAssetBeingSent = "";
                                do
                                {
                                    AdressOfAssetBeingSent = Console.ReadLine();
                                    if (!ListsOfValidAssets.CheckIfAssetExists(AdressOfAssetBeingSent))
                                        Console.WriteLine("Nepostojeća Adresa");
                                } while (!ListOfWallets.CheckingIfWalletExists(AdressOfAssetBeingSent));
                                continue;
                                if (ListsOfValidAssets.CheckIfAdressIsPointingToAFungibleAsset(Guid.Parse(AdressOfAssetBeingSent)))
                                {
                                    Console.WriteLine("Unesi kolicinu fungable asseta");
                                    double quantity = ParseQuantity();

                                    EnteredWallet.FungibleTransaction(EnteredWallet.AdressOfWallet, Guid.Parse(AdressORecievingWallet), Guid.Parse(AdressOfAssetBeingSent), quantity);
                                }
                                else
                                {
                                    WalletsContainingNonFungable EnteredWalletCasted = EnteredWallet as WalletsContainingNonFungable;
                                    EnteredWalletCasted.NonFungibleTransaction(EnteredWalletCasted.AdressOfWallet, Guid.Parse(AdressORecievingWallet), Guid.Parse(AdressOfAssetBeingSent));
                                }
                            case 3:
                                EnteredWallet.AllDoneTransactions();
                                Console.WriteLine("Pritisni bilokoji botun za povratak na pocetni meni");
                                Console.ReadKey();
                                continue;
                            default:
                                continue;

                        }
                        continue;
                    default:
                        continue;
                }
            } while (true);
        }

        static void CreateWallet()
        {
            int UserInput = 0;
            Console.WriteLine("1 - Create Bitcoin Wallet");
            Console.WriteLine("2 - Create Ethereum Waller");
            Console.WriteLine("3 - Create Solana Wallet");
            UserInput = ParsingUserInput(1,3);
            switch (UserInput) {
                case 1:
                    BitcoinWallet NewBTCWallet = new BitcoinWallet();
                    ListOfWallets.AddNewWallet(NewBTCWallet);
                    break;
                case 2:
                    EthereumWallet NewETHWallet = new EthereumWallet();
                    ListOfWallets.AddNewWallet(NewETHWallet);
                    break;
                case 3:
                    SolanaWallet NewSOLWallet = new SolanaWallet();
                    ListOfWallets.AddNewWallet(NewSOLWallet);
                    break;
            }

        }

        static bool YesNoInput()
        {
            Console.WriteLine("(D/N)");
            string unos = "";
            do
            {
                unos = Console.ReadLine();
                if (unos.ToUpper() != "D" && unos.ToUpper() != "N")
                {
                    Console.WriteLine("Unos ne oznacava ništa");
                }
            } while (unos.ToUpper() != "D" && unos.ToUpper() != "N");
            if (unos.ToUpper() == "D")
                return true;
            else
                return false;
        }

        static int ParsingUserInput(int FirstChoice, int LastChoice) {
            int ParsedValue = 0;
            do
            {
                bool IfSucceded;
                IfSucceded = int.TryParse(Console.ReadLine(), out ParsedValue);
                if (!IfSucceded)
                {
                    Console.WriteLine("Neispravan unos");
                    ParsedValue = -1;
                }
                else if (ParsedValue < FirstChoice || ParsedValue > LastChoice)
                    Console.WriteLine("Uneseni broj ne označava ni jednu moguću radnju");
            } while (ParsedValue < FirstChoice || ParsedValue > LastChoice);
            return ParsedValue;
        }
        static double ParseQuantity() {
            bool IfSucceded = false;
            double ParsedValue = 0;
            do {
                IfSucceded = double.TryParse(Console.ReadLine(), out ParsedValue);
                if (!IfSucceded) {
                    Console.WriteLine("Neispravan unos");
                }
            }while (!IfSucceded);
            return ParsedValue;
        }

    }
}