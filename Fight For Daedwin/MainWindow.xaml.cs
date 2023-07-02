using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Fight_For_Daedwin
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //Доделать покупку + сделать интерфейс отряда
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GameState.CurentStage = GameState.Stage.UnitShopStage;

            StartButton.IsEnabled = false;
            GameLogParent.Visibility = Visibility.Visible;

            UIClass.AddTextToLog(GameLog, "Игра началась");

            string FileName = "CardDeck.xml";
            string Path = AppContext.BaseDirectory + @"\" + FileName;

            //Card Test = new Card("Боба");
            
            Shop.Visibility = Visibility.Visible;
            MoneyTitle.Visibility = Visibility.Visible;

            MoneyCounter.Visibility = Visibility.Visible;
            MoneyCounter.Content = ShopClass.Money.ToString();

            ShopClass.UnitList = ShopClass.XMLParser(Path);
            ShopClass.RandomUnitToShop();

            UIClass.UIAddUnitToSlotInShop(FirstSlot, ShopClass.FirstSlot);
            UIClass.UIAddUnitToSlotInShop(SecondSlot, ShopClass.SecondSlot);
            UIClass.UIAddUnitToSlotInShop(ThirdSlot, ShopClass.ThirdSlot);

            BuyFirstSlot.IsEnabled = true;
            BuySecondSlot.IsEnabled = true;
            BuyThirdSlot.IsEnabled = true;

            Console.WriteLine(GameState.CurentStage);
        }

        private void BuyFirstSlot_Click_1(object sender, RoutedEventArgs e)
        {
            if (GameState.CurentStage == GameState.Stage.UnitShopStage)
            {
                if (ShopClass.Money >= ShopClass.FirstSlot.Cost && CrewClass.CrewSize <= 4)
                {
                    ShopClass.Money -= ShopClass.FirstSlot.Cost;
                    MoneyCounter.Content = ShopClass.Money.ToString();
                    BuyFirstSlot.IsEnabled = false;
                    BuyFirstSlot.Content = "Куплено!";
                    ShopClass.FromShopToCrew(ShopClass.FirstSlot);

                    UIClass.UIRefreshCrew(PlayerCrew1, PlayerCrew2, PlayerCrew3, PlayerCrew4, PlayerCrew5);
                }
                else if (CrewClass.CrewSize > 4)
                {
                    UIClass.AddTextToLog(GameLog, "Отряд укомплектован");
                    //BuyFirstSlot.IsEnabled = false;
                }
                else
                {
                    UIClass.AddTextToLog(GameLog, "Нехватает валюты!");
                }
            }
            else if (GameState.CurentStage == GameState.Stage.ItemShopStage)
            {
                if (ShopClass.Money >= ShopClass.FirstItemSlot.Cost && InventoryClass.InventorySize <= 5)
                {
                    ShopClass.Money -= ShopClass.FirstItemSlot.Cost;
                    MoneyCounter.Content = ShopClass.Money.ToString();
                    BuyFirstSlot.IsEnabled = false;
                    BuyFirstSlot.Content = "Куплено!";
                    ShopClass.FromShopToInventory(ShopClass.FirstItemSlot);

                    UIClass.UIRefreshInventory(Item1, Item2, Item3, Item4, Item5, Item6);
                }
                else if (InventoryClass.InventorySize > 5)
                {
                    UIClass.AddTextToLog(GameLog, "Места в инвентаре нет");
                    //BuyThirdSlot.IsEnabled = false;
                }
                else
                {
                    UIClass.AddTextToLog(GameLog, "Нехватает валюты!");
                }
            }

        }

        private void BuySecondSlot_Click(object sender, RoutedEventArgs e)
        {
            if (GameState.CurentStage == GameState.Stage.UnitShopStage)
            {
                if (ShopClass.Money >= ShopClass.SecondSlot.Cost && CrewClass.CrewSize <= 4)
                {
                    ShopClass.Money -= ShopClass.SecondSlot.Cost;
                    MoneyCounter.Content = ShopClass.Money.ToString();
                    BuySecondSlot.IsEnabled = false;
                    BuySecondSlot.Content = "Куплено!";
                    ShopClass.FromShopToCrew(ShopClass.SecondSlot);

                    UIClass.UIRefreshCrew(PlayerCrew1, PlayerCrew2, PlayerCrew3, PlayerCrew4, PlayerCrew5);
                }
                else if (CrewClass.CrewSize > 4)
                {
                    UIClass.AddTextToLog(GameLog, "Отряд укомплектован");
                    //BuySecondSlot.IsEnabled = false;
                }
                else
                {
                    UIClass.AddTextToLog(GameLog, "Нехватает валюты!");
                }
            }
            else if (GameState.CurentStage == GameState.Stage.ItemShopStage)
            {
                if (ShopClass.Money >= ShopClass.SecondItemSlot.Cost && InventoryClass.InventorySize <= 5)
                {
                    ShopClass.Money -= ShopClass.SecondItemSlot.Cost;
                    MoneyCounter.Content = ShopClass.Money.ToString();
                    BuySecondSlot.IsEnabled = false;
                    BuySecondSlot.Content = "Куплено!";
                    ShopClass.FromShopToInventory(ShopClass.SecondItemSlot);

                    UIClass.UIRefreshInventory(Item1, Item2, Item3, Item4, Item5, Item6);
                }
                else if (InventoryClass.InventorySize > 5)
                {
                    UIClass.AddTextToLog(GameLog, "Места в инвентаре нет");
                    //BuyThirdSlot.IsEnabled = false;
                }
                else
                {
                    UIClass.AddTextToLog(GameLog, "Нехватает валюты!");
                }
            }
        }

        private void BuyThirdSlot_Click(object sender, RoutedEventArgs e)
        {
            if (GameState.CurentStage == GameState.Stage.UnitShopStage)
            {
                if (ShopClass.Money >= ShopClass.ThirdSlot.Cost && CrewClass.CrewSize <= 4)
                {
                    ShopClass.Money -= ShopClass.ThirdSlot.Cost;
                    MoneyCounter.Content = ShopClass.Money.ToString();
                    BuyThirdSlot.IsEnabled = false;
                    BuyThirdSlot.Content = "Куплено!";
                    ShopClass.FromShopToCrew(ShopClass.ThirdSlot);

                    UIClass.UIRefreshCrew(PlayerCrew1, PlayerCrew2, PlayerCrew3, PlayerCrew4, PlayerCrew5);
                }
                else if (CrewClass.CrewSize > 4)
                {
                    UIClass.AddTextToLog(GameLog, "Отряд укомплектован");
                    //BuyThirdSlot.IsEnabled = false;
                }
                else
                {
                    UIClass.AddTextToLog(GameLog, "Нехватает валюты!");
                }
            }
            else if (GameState.CurentStage == GameState.Stage.ItemShopStage)
            {
                if (ShopClass.Money >= ShopClass.ThirdItemSlot.Cost && InventoryClass.InventorySize <= 5)
                {
                    ShopClass.Money -= ShopClass.ThirdItemSlot.Cost;
                    MoneyCounter.Content = ShopClass.Money.ToString();
                    BuyThirdSlot.IsEnabled = false;
                    BuyThirdSlot.Content = "Куплено!";
                    ShopClass.FromShopToInventory(ShopClass.ThirdItemSlot);

                    UIClass.UIRefreshInventory(Item1, Item2, Item3, Item4, Item5, Item6);
                }
                else if (InventoryClass.InventorySize > 5)
                {
                    UIClass.AddTextToLog(GameLog, "Места в инвентаре нет");
                    //BuyThirdSlot.IsEnabled = false;
                }
                else
                {
                    UIClass.AddTextToLog(GameLog, "Нехватает валюты!");
                }
            }
        }

        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            if (GameState.CurentStage == GameState.Stage.UnitShopStage)
            {
                if (ShopClass.Money >= 2)
                {
                    ShopClass.Money -= 2;
                    MoneyCounter.Content = ShopClass.Money.ToString();

                    ShopClass.RandomUnitToShop();

                    UIClass.UIAddUnitToSlotInShop(FirstSlot, ShopClass.FirstSlot);
                    UIClass.UIAddUnitToSlotInShop(SecondSlot, ShopClass.SecondSlot);
                    UIClass.UIAddUnitToSlotInShop(ThirdSlot, ShopClass.ThirdSlot);

                    BuyFirstSlot.Content = "Купить";
                    BuySecondSlot.Content = "Купить";
                    BuyThirdSlot.Content = "Купить";

                    BuyFirstSlot.IsEnabled = true;
                    BuySecondSlot.IsEnabled = true;
                    BuyThirdSlot.IsEnabled = true;
                }
                else
                {
                    UIClass.AddTextToLog(GameLog, "Нехватает валюты!");
                }
            }
            else if (GameState.CurentStage == GameState.Stage.ItemShopStage)
            {
                if (ShopClass.Money >= 2)
                {
                    ShopClass.Money -= 2;
                    MoneyCounter.Content = ShopClass.Money.ToString();

                    ShopClass.RandomItemToShop();

                    UIClass.UIAddItemToSlotInShop(FirstSlot, ShopClass.FirstItemSlot);
                    UIClass.UIAddItemToSlotInShop(SecondSlot, ShopClass.SecondItemSlot);
                    UIClass.UIAddItemToSlotInShop(ThirdSlot, ShopClass.ThirdItemSlot);

                    BuyFirstSlot.Content = "Купить";
                    BuySecondSlot.Content = "Купить";
                    BuyThirdSlot.Content = "Купить";

                    BuyFirstSlot.IsEnabled = true;
                    BuySecondSlot.IsEnabled = true;
                    BuyThirdSlot.IsEnabled = true;
                }
                else
                {
                    UIClass.AddTextToLog(GameLog, "Нехватает валюты!");
                }
            }
        }

        private void NextStageButton_Click(object sender, RoutedEventArgs e)
        {
            GameState.CurentStage++;
            if(GameState.CurentStage == GameState.Stage.ItemShopStage)
            {

                string FileName = "ItemDeck.xml";
                string Path = AppContext.BaseDirectory + @"\" + FileName;
                ShopClass.ItemList = ShopClass.XMLItemParser(Path);
                ShopClass.RandomItemToShop();

                UIClass.UIAddItemToSlotInShop(FirstSlot, ShopClass.FirstItemSlot);
                UIClass.UIAddItemToSlotInShop(SecondSlot, ShopClass.SecondItemSlot);
                UIClass.UIAddItemToSlotInShop(ThirdSlot, ShopClass.ThirdItemSlot);

                BuyFirstSlot.Content = "Купить";
                BuySecondSlot.Content = "Купить";
                BuyThirdSlot.Content = "Купить";

                BuyFirstSlot.IsEnabled = true;
                BuySecondSlot.IsEnabled = true;
                BuyThirdSlot.IsEnabled = true;
            }
        }
    }
}
