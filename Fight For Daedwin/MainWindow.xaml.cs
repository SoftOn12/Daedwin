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
            string FileName = "CardDeck.xml";
            string Path = AppContext.BaseDirectory + @"\" + FileName;

            Card Test = new Card("Боба");

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

            Console.WriteLine(CrewClass.Slot1.Name);
            Console.WriteLine(CrewClass.Slot2.Name);
            Console.WriteLine(CrewClass.Slot3.Name);
            Console.WriteLine(CrewClass.Slot4.Name);
            Console.WriteLine(CrewClass.Slot5.Name);
        }

        private void BuyFirstSlot_Click_1(object sender, RoutedEventArgs e)
        {
            ShopClass.Money -= ShopClass.FirstSlot.Cost;
            MoneyCounter.Content = ShopClass.Money.ToString();
            BuyFirstSlot.IsEnabled = false;
            BuyFirstSlot.Content = "Куплено!";
            ShopClass.FromShopToCrew(ShopClass.FirstSlot);

            UIClass.UIRefreshCrew(PlayerCrew1, PlayerCrew2, PlayerCrew3, PlayerCrew4, PlayerCrew5);
            Console.WriteLine(CrewClass.CrewSize);

            Console.WriteLine(CrewClass.Slot1.Name);
            Console.WriteLine(CrewClass.Slot2.Name);
            Console.WriteLine(CrewClass.Slot3.Name);
            Console.WriteLine(CrewClass.Slot4.Name);
            Console.WriteLine(CrewClass.Slot5.Name);
        }

        private void BuySecondSlot_Click(object sender, RoutedEventArgs e)
        {
            ShopClass.Money -= ShopClass.SecondSlot.Cost;
            MoneyCounter.Content = ShopClass.Money.ToString();
            BuySecondSlot.IsEnabled = false;
            BuySecondSlot.Content = "Куплено!";
            ShopClass.FromShopToCrew(ShopClass.SecondSlot);

            UIClass.UIRefreshCrew(PlayerCrew1, PlayerCrew2, PlayerCrew3, PlayerCrew4, PlayerCrew5);
            Console.WriteLine(CrewClass.CrewSize);
        }

        private void BuyThirdSlot_Click(object sender, RoutedEventArgs e)
        {
            ShopClass.Money -= ShopClass.ThirdSlot.Cost;
            MoneyCounter.Content = ShopClass.Money.ToString();
            BuyThirdSlot.IsEnabled = false;
            BuyThirdSlot.Content = "Куплено!";
            ShopClass.FromShopToCrew(ShopClass.ThirdSlot);

            UIClass.UIRefreshCrew(PlayerCrew1, PlayerCrew2, PlayerCrew3, PlayerCrew4, PlayerCrew5);
            Console.WriteLine(CrewClass.CrewSize);
        }
    }
}
