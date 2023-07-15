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
using System.Windows.Shapes;

namespace Fight_For_Daedwin
{
    /// <summary>
    /// Логика взаимодействия для ShopWindow.xaml
    /// </summary>
    public partial class ShopWindow : Window
    {
        public ShopWindow()
        {
            InitializeComponent();

            GameState.CurentStage = GameState.Stage.UnitShopStage;

            UIClass.AddTextToLog(((MainWindow)Application.Current.MainWindow).GameLog, "Игра началась");

            string FileName = "CardDeck.xml";
            string Path = AppContext.BaseDirectory + @"\" + FileName;

            //Card Test = new Card("Боба");

            Shop.Visibility = Visibility.Visible;
            MoneyTitle.Visibility = Visibility.Visible;

            MoneyCounter.Visibility = Visibility.Visible;
            MoneyCounter.Content = ShopClass.Money.ToString();

            ShopClass.UnitList = ShopClass.XMLParser(Path);
            ShopClass.RandomUnitToShop();

            UIClass.UIAddUnitToSlotInShop(FirstSlot, ImageFirstSlot, ShopClass.FirstSlot);
            UIClass.UIAddUnitToSlotInShop(SecondSlot, ImageSecondSlot, ShopClass.SecondSlot);
            UIClass.UIAddUnitToSlotInShop(ThirdSlot, ImageThirdSlot, ShopClass.ThirdSlot);

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

                    UIClass.UIRefreshCrew(((MainWindow)Application.Current.MainWindow).PlayerCrew1, 
                        ((MainWindow)Application.Current.MainWindow).PlayerCrew2, 
                        ((MainWindow)Application.Current.MainWindow).PlayerCrew3, 
                        ((MainWindow)Application.Current.MainWindow).PlayerCrew4, 
                        ((MainWindow)Application.Current.MainWindow).PlayerCrew5);
                }
                else if (CrewClass.CrewSize > 4)
                {
                    UIClass.AddTextToLog(((MainWindow)Application.Current.MainWindow).GameLog, "Отряд укомплектован");
                    //BuyFirstSlot.IsEnabled = false;
                }
                else
                {
                    UIClass.AddTextToLog(((MainWindow)Application.Current.MainWindow).GameLog, "Нехватает валюты!");
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

                    UIClass.UIRefreshInventory(((MainWindow)Application.Current.MainWindow).Item1,
                        ((MainWindow)Application.Current.MainWindow).Item2,
                        ((MainWindow)Application.Current.MainWindow).Item3,
                        ((MainWindow)Application.Current.MainWindow).Item4,
                        ((MainWindow)Application.Current.MainWindow).Item5,
                        ((MainWindow)Application.Current.MainWindow).Item6);
                }
                else if (InventoryClass.InventorySize > 5)
                {
                    UIClass.AddTextToLog(((MainWindow)Application.Current.MainWindow).GameLog, "Места в инвентаре нет");
                    //BuyThirdSlot.IsEnabled = false;
                }
                else
                {
                    UIClass.AddTextToLog(((MainWindow)Application.Current.MainWindow).GameLog, "Нехватает валюты!");
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

                    UIClass.UIRefreshCrew(((MainWindow)Application.Current.MainWindow).PlayerCrew1,
                        ((MainWindow)Application.Current.MainWindow).PlayerCrew2,
                        ((MainWindow)Application.Current.MainWindow).PlayerCrew3,
                        ((MainWindow)Application.Current.MainWindow).PlayerCrew4,
                        ((MainWindow)Application.Current.MainWindow).PlayerCrew5);
                }
                else if (CrewClass.CrewSize > 4)
                {
                    UIClass.AddTextToLog(((MainWindow)Application.Current.MainWindow).GameLog, "Отряд укомплектован");
                    //BuySecondSlot.IsEnabled = false;
                }
                else
                {
                    UIClass.AddTextToLog(((MainWindow)Application.Current.MainWindow).GameLog, "Нехватает валюты!");
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

                    UIClass.UIRefreshInventory(((MainWindow)Application.Current.MainWindow).Item1,
                        ((MainWindow)Application.Current.MainWindow).Item2,
                        ((MainWindow)Application.Current.MainWindow).Item3,
                        ((MainWindow)Application.Current.MainWindow).Item4,
                        ((MainWindow)Application.Current.MainWindow).Item5,
                        ((MainWindow)Application.Current.MainWindow).Item6);
                }
                else if (InventoryClass.InventorySize > 5)
                {
                    UIClass.AddTextToLog(((MainWindow)Application.Current.MainWindow).GameLog, "Места в инвентаре нет");
                    //BuyThirdSlot.IsEnabled = false;
                }
                else
                {
                    UIClass.AddTextToLog(((MainWindow)Application.Current.MainWindow).GameLog, "Нехватает валюты!");
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

                    UIClass.UIRefreshCrew(((MainWindow)Application.Current.MainWindow).PlayerCrew1,
                        ((MainWindow)Application.Current.MainWindow).PlayerCrew2,
                        ((MainWindow)Application.Current.MainWindow).PlayerCrew3,
                        ((MainWindow)Application.Current.MainWindow).PlayerCrew4,
                        ((MainWindow)Application.Current.MainWindow).PlayerCrew5);
                }
                else if (CrewClass.CrewSize > 4)
                {
                    UIClass.AddTextToLog(((MainWindow)Application.Current.MainWindow).GameLog, "Отряд укомплектован");
                    //BuyThirdSlot.IsEnabled = false;
                }
                else
                {
                    UIClass.AddTextToLog(((MainWindow)Application.Current.MainWindow).GameLog, "Нехватает валюты!");
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

                    UIClass.UIRefreshInventory(((MainWindow)Application.Current.MainWindow).Item1,
                        ((MainWindow)Application.Current.MainWindow).Item2,
                        ((MainWindow)Application.Current.MainWindow).Item3,
                        ((MainWindow)Application.Current.MainWindow).Item4,
                        ((MainWindow)Application.Current.MainWindow).Item5,
                        ((MainWindow)Application.Current.MainWindow).Item6);
                }
                else if (InventoryClass.InventorySize > 5)
                {
                    UIClass.AddTextToLog(((MainWindow)Application.Current.MainWindow).GameLog, "Места в инвентаре нет");
                    //BuyThirdSlot.IsEnabled = false;
                }
                else
                {
                    UIClass.AddTextToLog(((MainWindow)Application.Current.MainWindow).GameLog, "Нехватает валюты!");
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

                    UIClass.UIAddUnitToSlotInShop(FirstSlot, ImageFirstSlot, ShopClass.FirstSlot);
                    UIClass.UIAddUnitToSlotInShop(SecondSlot, ImageSecondSlot, ShopClass.SecondSlot);
                    UIClass.UIAddUnitToSlotInShop(ThirdSlot, ImageThirdSlot, ShopClass.ThirdSlot);

                    BuyFirstSlot.Content = "Купить";
                    BuySecondSlot.Content = "Купить";
                    BuyThirdSlot.Content = "Купить";

                    BuyFirstSlot.IsEnabled = true;
                    BuySecondSlot.IsEnabled = true;
                    BuyThirdSlot.IsEnabled = true;
                }
                else
                {
                    UIClass.AddTextToLog(((MainWindow)Application.Current.MainWindow).GameLog, "Нехватает валюты!");
                }
            }
            else if (GameState.CurentStage == GameState.Stage.ItemShopStage)
            {
                if (ShopClass.Money >= 2)
                {
                    ShopClass.Money -= 2;
                    MoneyCounter.Content = ShopClass.Money.ToString();

                    ShopClass.RandomItemToShop();

                    UIClass.UIAddItemToSlotInShop(FirstSlot, ImageFirstSlot, ShopClass.FirstItemSlot);
                    UIClass.UIAddItemToSlotInShop(SecondSlot, ImageSecondSlot, ShopClass.SecondItemSlot);
                    UIClass.UIAddItemToSlotInShop(ThirdSlot, ImageThirdSlot, ShopClass.ThirdItemSlot);

                    BuyFirstSlot.Content = "Купить";
                    BuySecondSlot.Content = "Купить";
                    BuyThirdSlot.Content = "Купить";

                    BuyFirstSlot.IsEnabled = true;
                    BuySecondSlot.IsEnabled = true;
                    BuyThirdSlot.IsEnabled = true;
                }
                else
                {
                    UIClass.AddTextToLog(((MainWindow)Application.Current.MainWindow).GameLog, "Нехватает валюты!");
                }
            }
        }

        private void NextStageButton_Click(object sender, RoutedEventArgs e)
        {
            GameState.CurentStage++;
            if (GameState.CurentStage == GameState.Stage.ItemShopStage)
            {

                string FileName = "ItemDeck.xml";
                string Path = AppContext.BaseDirectory + @"\" + FileName;
                ShopClass.ItemList = ShopClass.XMLItemParser(Path);
                ShopClass.RandomItemToShop();

                UIClass.UIAddItemToSlotInShop(FirstSlot, ImageFirstSlot, ShopClass.FirstItemSlot);
                UIClass.UIAddItemToSlotInShop(SecondSlot, ImageSecondSlot, ShopClass.SecondItemSlot);
                UIClass.UIAddItemToSlotInShop(ThirdSlot, ImageThirdSlot, ShopClass.ThirdItemSlot);

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
