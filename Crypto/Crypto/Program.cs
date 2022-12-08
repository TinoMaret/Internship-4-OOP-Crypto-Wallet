using Crypto.Classes.Assets;
using Crypto.Classes.Transactions;
using Crypto.Classes.Wallets;

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
                                Console.WriteLine("Unesi adresu waleta kojemu želiš poslat asset");
                                string AdressORecievingWallet = "";
                                do
                                {
                                    AdressORecievingWallet = Console.ReadLine();
                                    if (!ListOfWallets.CheckingIfWalletExists(AdressORecievingWallet))
                                        Console.WriteLine("Nepostojeća Adresa");
                                    else if (Guid.Parse(AdressORecievingWallet) == EnteredWallet.AdressOfWallet)
                                        Console.WriteLine("Nije moguce poslati assete samom sebi");
                                } while ((!ListOfWallets.CheckingIfWalletExists(AdressORecievingWallet)) && Guid.Parse(AdressORecievingWallet) == EnteredWallet.AdressOfWallet);
                                Console.WriteLine("Unesi adresu asseta kojeg saljes");
                                string AdressOfAssetBeingSent = "";
                                do
                                {
                                    AdressOfAssetBeingSent = Console.ReadLine();
                                    if (!ListsOfValidAssets.CheckIfAssetExists(AdressOfAssetBeingSent))
                                        Console.WriteLine("Nepostojeća Adresa");
                                } while (!ListOfWallets.CheckingIfWalletExists(AdressOfAssetBeingSent));
                                if (ListsOfValidAssets.CheckIfAdressIsPointingToAFungibleAsset(Guid.Parse(AdressOfAssetBeingSent)))
                                {
                                    Console.WriteLine("Unesi kolicinu fungable asseta");
                                    double quantity = ParseQuantity();
                                    Console.WriteLine("Izvrsiti transakciju?");
                                    if (YesNoInput())
                                        EnteredWallet.FungibleTransaction(EnteredWallet.AdressOfWallet, Guid.Parse(AdressORecievingWallet), Guid.Parse(AdressOfAssetBeingSent), quantity);
                                    else
                                        Console.WriteLine("Transakcija nije izvrsena");
                                }
                                else
                                {
                                    WalletsContainingNonFungable EnteredWalletCasted = (WalletsContainingNonFungable) EnteredWallet;
                                    if (YesNoInput())
                                        EnteredWalletCasted.NonFungibleTransaction(EnteredWalletCasted.AdressOfWallet, Guid.Parse(AdressORecievingWallet), Guid.Parse(AdressOfAssetBeingSent));
                                    else
                                        Console.WriteLine("Transakcija nije izvrsena");
                                }
                                continue;
                            case 3:
                                EnteredWallet.AllDoneTransactions();
                                Console.WriteLine("Opozovi neku od transakcija");
                                if (YesNoInput()) {
                                    Console.WriteLine("Unesi adresu tranakcije koju zelis opozvati");
                                    string InputedAdressOfTransactionToRemove = "";
                                    do
                                    {
                                        InputedAdressOfTransactionToRemove = Console.ReadLine();
                                        if (!ListOfTransactions.CheckIfTransactionExists(Guid.Parse(InputedAdressOfTransactionToRemove)))
                                            Console.WriteLine("Ne postoji transakcija s tom adresom");
                                    } while (!ListOfTransactions.CheckIfTransactionExists(Guid.Parse(InputedAdressOfTransactionToRemove)));

                                    Transaction TransactionToRemove = ListOfTransactions.GetTransactionByAdress(Guid.Parse(InputedAdressOfTransactionToRemove));

                                    Console.WriteLine("Opozovi unesetu transakciju?");
                                    if (!(TransactionToRemove.SendingAdress == EnteredWallet.AdressOfWallet) && (TransactionToRemove.TimeOfTransaction - DateTime.Now).TotalSeconds > 45 && YesNoInput())
                                    {
                                        Console.WriteLine("Nije moguce izvrsiti transakciju");
                                        if (!(TransactionToRemove.SendingAdress == EnteredWallet.AdressOfWallet))
                                            Console.WriteLine("Vi niste poslali tu transakciju");
                                        if ((TransactionToRemove.TimeOfTransaction - DateTime.Now).TotalSeconds > 45)
                                            Console.WriteLine("Proslo je previse vremena od transakcije");
                                    }
                                    else {
                                        Wallet WalletToRevokeFrom = ListOfWallets.GetWalletByAdress(TransactionToRemove.RecievingAdress);
                                        Asset AssetToRevoke = ListsOfValidAssets.GetFungibleAssetByAdress(TransactionToRemove.AssetAdress);
                                        NonFungibleAssetTransaction NonFungibleCastedTransactionToRemove = TransactionToRemove as NonFungibleAssetTransaction;
                                        if (NonFungibleCastedTransactionToRemove == null)
                                        {
                                            FungibleAssetTransaction FungibleCastedTransactionToRemove = TransactionToRemove as FungibleAssetTransaction;
                                            EnteredWallet.ReturnBalance(AssetToRevoke, FungibleCastedTransactionToRemove.FungibleAssetValueBeforeSending);
                                            WalletToRevokeFrom.ReturnBalance(AssetToRevoke, FungibleCastedTransactionToRemove.FungibleAssetValueBeforeRecieving);
                                        }
                                        else {
                                            WalletsContainingNonFungable CastedEnteredWallet = EnteredWallet as WalletsContainingNonFungable;
                                            WalletsContainingNonFungable CastedWalletToRevokeFrom = WalletToRevokeFrom as WalletsContainingNonFungable;
                                            CastedEnteredWallet.RestoreNonFungibleTransaction(AssetToRevoke);
                                            CastedWalletToRevokeFrom.RevokeNonFungibleTransaction(AssetToRevoke);
                                        }
                                        ListOfTransactions.RemoveTransaction(TransactionToRemove);
                                    }
                                }

                                continue;
                            default:
                                continue;

                        }
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