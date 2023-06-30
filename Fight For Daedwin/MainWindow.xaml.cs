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
            StartButton.IsEnabled = false;
            GameLogParent.Visibility = Visibility.Visible;

            UIClass.AddTextToLog(GameLog, "Игра началась");

            string FileName = "CardDeck.xml";
            string Path = AppContext.BaseDirectory + @"\" + FileName;

            //Card Test = new Card("Боба");

            ShopClass.CardList =  ShopClass.XMLParser(Path);
            
            Shop.Visibility = Visibility.Visible;
            MoneyTitle.Visibility = Visibility.Visible;

            MoneyCounter.Visibility = Visibility.Visible;
            MoneyCounter.Content = ShopClass.Money.ToString();

            ShopClass.RandomCardToShop();

            UIClass.UIAddToSlotInShop(FirstSlot, ShopClass.FirstSlot);
            UIClass.UIAddToSlotInShop(SecondSlot, ShopClass.SecondSlot);
            UIClass.UIAddToSlotInShop(ThirdSlot, ShopClass.ThirdSlot);

            BuyFirstSlot.IsEnabled = true;
            BuySecondSlot.IsEnabled = true;
            BuyThirdSlot.IsEnabled = true;
        }

        private void BuyFirstSlot_Click_1(object sender, RoutedEventArgs e)
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
                BuyFirstSlot.IsEnabled = false;
            }
            else
            {
                UIClass.AddTextToLog(GameLog, "Нехватает валюты!");
            }

        }

        private void BuySecondSlot_Click(object sender, RoutedEventArgs e)
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
                BuySecondSlot.IsEnabled = false;
            }
            else
            {
                UIClass.AddTextToLog(GameLog, "Нехватает валюты!");
            }
        }

        private void BuyThirdSlot_Click(object sender, RoutedEventArgs e)
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
            else if(CrewClass.CrewSize > 4)
            {
                UIClass.AddTextToLog(GameLog, "Отряд укомплектован");
                BuyThirdSlot.IsEnabled = false;
            }
            else
            {
                UIClass.AddTextToLog(GameLog, "Нехватает валюты!");
            }
        }

        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            if (ShopClass.Money >= 2)
            {
                ShopClass.Money -= 2;
                MoneyCounter.Content = ShopClass.Money.ToString();

                ShopClass.RandomCardToShop();

                Console.WriteLine(CrewClass.Slot1.Name);

                UIClass.UIAddToSlotInShop(FirstSlot, ShopClass.FirstSlot);
                UIClass.UIAddToSlotInShop(SecondSlot, ShopClass.SecondSlot);
                UIClass.UIAddToSlotInShop(ThirdSlot, ShopClass.ThirdSlot);

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
}
