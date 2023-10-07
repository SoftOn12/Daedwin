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
    /// Логика взаимодействия для RewardWindow.xaml
    /// </summary>
    public partial class RewardWindow : Window
    {
        public RewardWindow()
        {
            InitializeComponent();

            MonsterFightClass.RewardAction();

            //UIClass.AddTextToLog(((MainWindow)Application.Current.MainWindow).GameLog, "Стадия вербовки персонажей началась");

            Shop.Visibility = Visibility.Visible;
            MoneyTitle.Visibility = Visibility.Visible;

            MoneyCounter.Visibility = Visibility.Visible;
            MoneyCounter.Content = GameState.Money.ToString();

            RewardClass.RandomItemToReward();

            UIClass.UIAddItemToSlotInShop(FirstSlot, ImageFirstSlot, RewardClass.FirstItemSlot,
                                            CardHealth1, CardVitality1, CardAttack1);
            UIClass.UIAddItemToSlotInShop(SecondSlot, ImageSecondSlot, RewardClass.SecondItemSlot,
                                            CardHealth2, CardVitality2, CardAttack2);
            UIClass.UIAddItemToSlotInShop(ThirdSlot, ImageThirdSlot, RewardClass.ThirdItemSlot,
                                            CardHealth3, CardVitality3, CardAttack3);

            BuyFirstSlot.IsEnabled = true;
            BuySecondSlot.IsEnabled = true;
            BuyThirdSlot.IsEnabled = true;
        }

        private void BuyFirstSlot_Click_1(object sender, RoutedEventArgs e)
        {
            if (GameState.Money >= RewardClass.FirstItemSlot.Cost && InventoryClass.InventorySize <= 5)
            {
                GameState.Money -= RewardClass.FirstItemSlot.Cost;
                MoneyCounter.Content = GameState.Money.ToString();
                BuyFirstSlot.IsEnabled = false;
                BuyFirstSlot.Content = "Куплено!";
                RewardClass.FromRewardToInventory(RewardClass.FirstItemSlot);

                UIClass.UIRefreshInventory(((MainWindow)Application.Current.MainWindow).Item1, ((MainWindow)Application.Current.MainWindow).ImageItem1,
                    ((MainWindow)Application.Current.MainWindow).Item2, ((MainWindow)Application.Current.MainWindow).ImageItem2,
                    ((MainWindow)Application.Current.MainWindow).Item3, ((MainWindow)Application.Current.MainWindow).ImageItem3,
                    ((MainWindow)Application.Current.MainWindow).Item4, ((MainWindow)Application.Current.MainWindow).ImageItem4,
                    ((MainWindow)Application.Current.MainWindow).Item5, ((MainWindow)Application.Current.MainWindow).ImageItem5,
                    ((MainWindow)Application.Current.MainWindow).Item6, ((MainWindow)Application.Current.MainWindow).ImageItem6,
                    ((MainWindow)Application.Current.MainWindow).ItemHealthBuff1, ((MainWindow)Application.Current.MainWindow).ItemVitalityBuff1, ((MainWindow)Application.Current.MainWindow).ItemAttackBuff1,
                    ((MainWindow)Application.Current.MainWindow).ItemHealthBuff2, ((MainWindow)Application.Current.MainWindow).ItemVitalityBuff2, ((MainWindow)Application.Current.MainWindow).ItemAttackBuff2,
                    ((MainWindow)Application.Current.MainWindow).ItemHealthBuff3, ((MainWindow)Application.Current.MainWindow).ItemVitalityBuff3, ((MainWindow)Application.Current.MainWindow).ItemAttackBuff3,
                    ((MainWindow)Application.Current.MainWindow).ItemHealthBuff4, ((MainWindow)Application.Current.MainWindow).ItemVitalityBuff4, ((MainWindow)Application.Current.MainWindow).ItemAttackBuff4,
                    ((MainWindow)Application.Current.MainWindow).ItemHealthBuff5, ((MainWindow)Application.Current.MainWindow).ItemVitalityBuff5, ((MainWindow)Application.Current.MainWindow).ItemAttackBuff5,
                    ((MainWindow)Application.Current.MainWindow).ItemHealthBuff6, ((MainWindow)Application.Current.MainWindow).ItemVitalityBuff6, ((MainWindow)Application.Current.MainWindow).ItemAttackBuff6);
            }
            else if (InventoryClass.InventorySize > 5)
            {
                UIClass.AddTextToLog(((MainWindow)Application.Current.MainWindow).GameLog, "Места в инвентаре нет");
                //BuyThirdSlot.IsEnabled = false;
            }
            else
            {
                UIClass.AddTextToLog(((MainWindow)Application.Current.MainWindow).GameLog, "Не хватает валюты!");
            }
        }

        private void BuySecondSlot_Click(object sender, RoutedEventArgs e)
        {
            if (GameState.Money >= RewardClass.SecondItemSlot.Cost && InventoryClass.InventorySize <= 5)
            {
                GameState.Money -= RewardClass.SecondItemSlot.Cost;
                MoneyCounter.Content = GameState.Money.ToString();
                BuySecondSlot.IsEnabled = false;
                BuySecondSlot.Content = "Куплено!";
                RewardClass.FromRewardToInventory(RewardClass.SecondItemSlot);

                UIClass.UIRefreshInventory(((MainWindow)Application.Current.MainWindow).Item1, ((MainWindow)Application.Current.MainWindow).ImageItem1,
                    ((MainWindow)Application.Current.MainWindow).Item2, ((MainWindow)Application.Current.MainWindow).ImageItem2,
                    ((MainWindow)Application.Current.MainWindow).Item3, ((MainWindow)Application.Current.MainWindow).ImageItem3,
                    ((MainWindow)Application.Current.MainWindow).Item4, ((MainWindow)Application.Current.MainWindow).ImageItem4,
                    ((MainWindow)Application.Current.MainWindow).Item5, ((MainWindow)Application.Current.MainWindow).ImageItem5,
                    ((MainWindow)Application.Current.MainWindow).Item6, ((MainWindow)Application.Current.MainWindow).ImageItem6,
                    ((MainWindow)Application.Current.MainWindow).ItemHealthBuff1, ((MainWindow)Application.Current.MainWindow).ItemVitalityBuff1, ((MainWindow)Application.Current.MainWindow).ItemAttackBuff1,
                    ((MainWindow)Application.Current.MainWindow).ItemHealthBuff2, ((MainWindow)Application.Current.MainWindow).ItemVitalityBuff2, ((MainWindow)Application.Current.MainWindow).ItemAttackBuff2,
                    ((MainWindow)Application.Current.MainWindow).ItemHealthBuff3, ((MainWindow)Application.Current.MainWindow).ItemVitalityBuff3, ((MainWindow)Application.Current.MainWindow).ItemAttackBuff3,
                    ((MainWindow)Application.Current.MainWindow).ItemHealthBuff4, ((MainWindow)Application.Current.MainWindow).ItemVitalityBuff4, ((MainWindow)Application.Current.MainWindow).ItemAttackBuff4,
                    ((MainWindow)Application.Current.MainWindow).ItemHealthBuff5, ((MainWindow)Application.Current.MainWindow).ItemVitalityBuff5, ((MainWindow)Application.Current.MainWindow).ItemAttackBuff5,
                    ((MainWindow)Application.Current.MainWindow).ItemHealthBuff6, ((MainWindow)Application.Current.MainWindow).ItemVitalityBuff6, ((MainWindow)Application.Current.MainWindow).ItemAttackBuff6);
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

        private void BuyThirdSlot_Click(object sender, RoutedEventArgs e)
        {
            if (GameState.Money >= RewardClass.ThirdItemSlot.Cost && InventoryClass.InventorySize <= 5)
            {
                GameState.Money -= RewardClass.ThirdItemSlot.Cost;
                MoneyCounter.Content = GameState.Money.ToString();
                BuyThirdSlot.IsEnabled = false;
                BuyThirdSlot.Content = "Куплено!";
                RewardClass.FromRewardToInventory(RewardClass.ThirdItemSlot);

                UIClass.UIRefreshInventory(((MainWindow)Application.Current.MainWindow).Item1, ((MainWindow)Application.Current.MainWindow).ImageItem1,
                    ((MainWindow)Application.Current.MainWindow).Item2, ((MainWindow)Application.Current.MainWindow).ImageItem2,
                    ((MainWindow)Application.Current.MainWindow).Item3, ((MainWindow)Application.Current.MainWindow).ImageItem3,
                    ((MainWindow)Application.Current.MainWindow).Item4, ((MainWindow)Application.Current.MainWindow).ImageItem4,
                    ((MainWindow)Application.Current.MainWindow).Item5, ((MainWindow)Application.Current.MainWindow).ImageItem5,
                    ((MainWindow)Application.Current.MainWindow).Item6, ((MainWindow)Application.Current.MainWindow).ImageItem6,
                    ((MainWindow)Application.Current.MainWindow).ItemHealthBuff1, ((MainWindow)Application.Current.MainWindow).ItemVitalityBuff1, ((MainWindow)Application.Current.MainWindow).ItemAttackBuff1,
                    ((MainWindow)Application.Current.MainWindow).ItemHealthBuff2, ((MainWindow)Application.Current.MainWindow).ItemVitalityBuff2, ((MainWindow)Application.Current.MainWindow).ItemAttackBuff2,
                    ((MainWindow)Application.Current.MainWindow).ItemHealthBuff3, ((MainWindow)Application.Current.MainWindow).ItemVitalityBuff3, ((MainWindow)Application.Current.MainWindow).ItemAttackBuff3,
                    ((MainWindow)Application.Current.MainWindow).ItemHealthBuff4, ((MainWindow)Application.Current.MainWindow).ItemVitalityBuff4, ((MainWindow)Application.Current.MainWindow).ItemAttackBuff4,
                    ((MainWindow)Application.Current.MainWindow).ItemHealthBuff5, ((MainWindow)Application.Current.MainWindow).ItemVitalityBuff5, ((MainWindow)Application.Current.MainWindow).ItemAttackBuff5,
                    ((MainWindow)Application.Current.MainWindow).ItemHealthBuff6, ((MainWindow)Application.Current.MainWindow).ItemVitalityBuff6, ((MainWindow)Application.Current.MainWindow).ItemAttackBuff6);
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

        private void NextStageButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
