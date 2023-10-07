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

            UIClass.AddTextToLog(((MainWindow)Application.Current.MainWindow).GameLog, "Стадия вербовки персонажей началась");

            string FileName1 = "CardDeck.xml";
            string PathLevel1 = GameState.ResourcePath + FileName1;

            string FileName2 = "CardDeckLevel2.xml";
            string PathLevel2 = GameState.ResourcePath + FileName2;

            string FileName3 = "CardDeckLevel3.xml";
            string PathLevel3 = GameState.ResourcePath + FileName3;

            //Card Test = new Card("Боба");

            Shop.Visibility = Visibility.Visible;
            MoneyTitle.Visibility = Visibility.Visible;

            MoneyCounter.Visibility = Visibility.Visible;
            MoneyCounter.Content = GameState.Money.ToString();

            ShopClass.UnitList = ShopClass.XMLParser(PathLevel1);
            ShopClass.UnitListLevel2 = ShopClass.XMLParser(PathLevel2);
            ShopClass.UnitListLevel3 = ShopClass.XMLParser(PathLevel3);
            ShopClass.RandomUnitToShop();

            UIClass.UIAddUnitToSlotInShop(FirstSlot, ImageFirstSlot, ShopClass.FirstSlot,
                                            CardHealth1, CardVitality1, CardAttack1);
            UIClass.UIAddUnitToSlotInShop(SecondSlot, ImageSecondSlot, ShopClass.SecondSlot,
                                            CardHealth2, CardVitality2, CardAttack2);
            UIClass.UIAddUnitToSlotInShop(ThirdSlot, ImageThirdSlot, ShopClass.ThirdSlot,
                                            CardHealth3, CardVitality3, CardAttack3);

            BuyFirstSlot.IsEnabled = true;
            BuySecondSlot.IsEnabled = true;
            BuyThirdSlot.IsEnabled = true;             
        }

        private void BuyFirstSlot_Click_1(object sender, RoutedEventArgs e)
        {
            if (GameState.CurentStage == GameState.Stage.UnitShopStage)
            {
                if (GameState.Money >= ShopClass.FirstSlot.Cost && CrewClass.CrewSize <= 4)
                {
                    GameState.Money -= ShopClass.FirstSlot.Cost;
                    MoneyCounter.Content = GameState.Money.ToString();
                    BuyFirstSlot.IsEnabled = false;
                    BuyFirstSlot.Content = "Куплено!";
                    ShopClass.FromShopToCrew(ShopClass.FirstSlot);

                    UIClass.UIRefreshCrew(((MainWindow)Application.Current.MainWindow).PlayerCrew1, ((MainWindow)Application.Current.MainWindow).ImageCrew1,
                        ((MainWindow)Application.Current.MainWindow).PlayerCrew2, ((MainWindow)Application.Current.MainWindow).ImageCrew2,
                        ((MainWindow)Application.Current.MainWindow).PlayerCrew3, ((MainWindow)Application.Current.MainWindow).ImageCrew3,
                    ((MainWindow)Application.Current.MainWindow).PlayerCrew4, ((MainWindow)Application.Current.MainWindow).ImageCrew4,
                    ((MainWindow)Application.Current.MainWindow).PlayerCrew5, ((MainWindow)Application.Current.MainWindow).ImageCrew5,
                    ((MainWindow)Application.Current.MainWindow).CrewHealth1, ((MainWindow)Application.Current.MainWindow).CrewVitality1, ((MainWindow)Application.Current.MainWindow).CrewAttack1,
                    ((MainWindow)Application.Current.MainWindow).CrewHealth2, ((MainWindow)Application.Current.MainWindow).CrewVitality2, ((MainWindow)Application.Current.MainWindow).CrewAttack2,
                    ((MainWindow)Application.Current.MainWindow).CrewHealth3, ((MainWindow)Application.Current.MainWindow).CrewVitality3, ((MainWindow)Application.Current.MainWindow).CrewAttack3,
                    ((MainWindow)Application.Current.MainWindow).CrewHealth4, ((MainWindow)Application.Current.MainWindow).CrewVitality4, ((MainWindow)Application.Current.MainWindow).CrewAttack4,
                    ((MainWindow)Application.Current.MainWindow).CrewHealth5, ((MainWindow)Application.Current.MainWindow).CrewVitality5, ((MainWindow)Application.Current.MainWindow).CrewAttack5);
                }
                else
                {
                    UIClass.AddTextToLog(((MainWindow)Application.Current.MainWindow).GameLog, "Нехватает валюты!");
                }

                if (CrewClass.CrewSize > 4)
                {
                    UIClass.AddTextToLog(((MainWindow)Application.Current.MainWindow).GameLog, "Отряд укомплектован");

                    BuyFirstSlot.IsEnabled = false;
                    BuySecondSlot.IsEnabled = false;
                    BuyThirdSlot.IsEnabled = false;
                }
            }
            else if (GameState.CurentStage == GameState.Stage.ItemShopStage)
            {
                if (GameState.Money >= ShopClass.FirstItemSlot.Cost && InventoryClass.InventorySize <= 5)
                {
                    GameState.Money -= ShopClass.FirstItemSlot.Cost;
                    MoneyCounter.Content = GameState.Money.ToString();
                    BuyFirstSlot.IsEnabled = false;
                    BuyFirstSlot.Content = "Куплено!";
                    ShopClass.FromShopToInventory(ShopClass.FirstItemSlot);

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
                else
                {
                    UIClass.AddTextToLog(((MainWindow)Application.Current.MainWindow).GameLog, "Нехватает валюты!");
                }

                if (InventoryClass.InventorySize > 5)
                {
                    UIClass.AddTextToLog(((MainWindow)Application.Current.MainWindow).GameLog, "Места в инвентаре нет");

                    BuyFirstSlot.IsEnabled = false;
                    BuySecondSlot.IsEnabled = false;
                    BuyThirdSlot.IsEnabled = false;
                }
            }
            else if (GameState.CurentStage == GameState.Stage.SpellChoiseStage)
            {
                if (GameState.Money >= ShopClass.FirstSpellSlot.Cost && SpellBookClass.SpellBookSize == 0)
                {
                    GameState.Money -= ShopClass.FirstSpellSlot.Cost;
                    MoneyCounter.Content = GameState.Money.ToString();
                    BuyFirstSlot.IsEnabled = false;
                    BuyFirstSlot.Content = "Куплено!";
                    ShopClass.FromShopToSpellBook(ShopClass.FirstSpellSlot);

                    UIClass.UIAddToSlotInSpellBook(((MainWindow)Application.Current.MainWindow).SpellText,
                                                   ((MainWindow)Application.Current.MainWindow).SpellImage,
                                                   ((MainWindow)Application.Current.MainWindow).SpellTitle,
                                                   ShopClass.FirstSpellSlot);

                    UIClass.UIRefreshCrew(((MainWindow)Application.Current.MainWindow).PlayerCrew1, ((MainWindow)Application.Current.MainWindow).ImageCrew1,
                        ((MainWindow)Application.Current.MainWindow).PlayerCrew2, ((MainWindow)Application.Current.MainWindow).ImageCrew2,
                        ((MainWindow)Application.Current.MainWindow).PlayerCrew3, ((MainWindow)Application.Current.MainWindow).ImageCrew3,
                    ((MainWindow)Application.Current.MainWindow).PlayerCrew4, ((MainWindow)Application.Current.MainWindow).ImageCrew4,
                    ((MainWindow)Application.Current.MainWindow).PlayerCrew5, ((MainWindow)Application.Current.MainWindow).ImageCrew5,
                    ((MainWindow)Application.Current.MainWindow).CrewHealth1, ((MainWindow)Application.Current.MainWindow).CrewVitality1, ((MainWindow)Application.Current.MainWindow).CrewAttack1,
                    ((MainWindow)Application.Current.MainWindow).CrewHealth2, ((MainWindow)Application.Current.MainWindow).CrewVitality2, ((MainWindow)Application.Current.MainWindow).CrewAttack2,
                    ((MainWindow)Application.Current.MainWindow).CrewHealth3, ((MainWindow)Application.Current.MainWindow).CrewVitality3, ((MainWindow)Application.Current.MainWindow).CrewAttack3,
                    ((MainWindow)Application.Current.MainWindow).CrewHealth4, ((MainWindow)Application.Current.MainWindow).CrewVitality4, ((MainWindow)Application.Current.MainWindow).CrewAttack4,
                    ((MainWindow)Application.Current.MainWindow).CrewHealth5, ((MainWindow)Application.Current.MainWindow).CrewVitality5, ((MainWindow)Application.Current.MainWindow).CrewAttack5);

                    ((MainWindow)Application.Current.MainWindow).GoToFightAllSlot.IsEnabled = true;

                    UIClass.AddTextToLog(((MainWindow)Application.Current.MainWindow).GameLog, "Стадия сражений началась");
                    ((MainWindow)Application.Current.MainWindow).BattleBoard.Visibility = Visibility.Visible;
                    Close();
                }
                else if (SpellBookClass.SpellBookSize > 0)
                {
                    UIClass.AddTextToLog(((MainWindow)Application.Current.MainWindow).GameLog, "Заклинание уже куплено!");
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
                if (GameState.Money >= ShopClass.SecondSlot.Cost && CrewClass.CrewSize <= 4)
                {
                    GameState.Money -= ShopClass.SecondSlot.Cost;
                    MoneyCounter.Content = GameState.Money.ToString();
                    BuySecondSlot.IsEnabled = false;
                    BuySecondSlot.Content = "Куплено!";
                    ShopClass.FromShopToCrew(ShopClass.SecondSlot);
                    UIClass.UIRefreshCrew(((MainWindow)Application.Current.MainWindow).PlayerCrew1, ((MainWindow)Application.Current.MainWindow).ImageCrew1,
                        ((MainWindow)Application.Current.MainWindow).PlayerCrew2, ((MainWindow)Application.Current.MainWindow).ImageCrew2,
                        ((MainWindow)Application.Current.MainWindow).PlayerCrew3, ((MainWindow)Application.Current.MainWindow).ImageCrew3,
                    ((MainWindow)Application.Current.MainWindow).PlayerCrew4, ((MainWindow)Application.Current.MainWindow).ImageCrew4,
                    ((MainWindow)Application.Current.MainWindow).PlayerCrew5, ((MainWindow)Application.Current.MainWindow).ImageCrew5,
                    ((MainWindow)Application.Current.MainWindow).CrewHealth1, ((MainWindow)Application.Current.MainWindow).CrewVitality1, ((MainWindow)Application.Current.MainWindow).CrewAttack1,
                    ((MainWindow)Application.Current.MainWindow).CrewHealth2, ((MainWindow)Application.Current.MainWindow).CrewVitality2, ((MainWindow)Application.Current.MainWindow).CrewAttack2,
                    ((MainWindow)Application.Current.MainWindow).CrewHealth3, ((MainWindow)Application.Current.MainWindow).CrewVitality3, ((MainWindow)Application.Current.MainWindow).CrewAttack3,
                    ((MainWindow)Application.Current.MainWindow).CrewHealth4, ((MainWindow)Application.Current.MainWindow).CrewVitality4, ((MainWindow)Application.Current.MainWindow).CrewAttack4,
                    ((MainWindow)Application.Current.MainWindow).CrewHealth5, ((MainWindow)Application.Current.MainWindow).CrewVitality5, ((MainWindow)Application.Current.MainWindow).CrewAttack5);
                }
                else
                {
                    UIClass.AddTextToLog(((MainWindow)Application.Current.MainWindow).GameLog, "Нехватает валюты!");
                }

                if (CrewClass.CrewSize > 4)
                {
                    UIClass.AddTextToLog(((MainWindow)Application.Current.MainWindow).GameLog, "Отряд укомплектован");

                    BuyFirstSlot.IsEnabled = false;
                    BuySecondSlot.IsEnabled = false;
                    BuyThirdSlot.IsEnabled = false;
                }
            }
            else if (GameState.CurentStage == GameState.Stage.ItemShopStage)
            {
                if (GameState.Money >= ShopClass.SecondItemSlot.Cost && InventoryClass.InventorySize <= 5)
                {
                    GameState.Money -= ShopClass.SecondItemSlot.Cost;
                    MoneyCounter.Content = GameState.Money.ToString();
                    BuySecondSlot.IsEnabled = false;
                    BuySecondSlot.Content = "Куплено!";
                    ShopClass.FromShopToInventory(ShopClass.SecondItemSlot);

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
                else
                {
                    UIClass.AddTextToLog(((MainWindow)Application.Current.MainWindow).GameLog, "Нехватает валюты!");
                }

                if (InventoryClass.InventorySize > 5)
                {
                    UIClass.AddTextToLog(((MainWindow)Application.Current.MainWindow).GameLog, "Места в инвентаре нет");

                    BuyFirstSlot.IsEnabled = false;
                    BuySecondSlot.IsEnabled = false;
                    BuyThirdSlot.IsEnabled = false;
                }
            }
            else if (GameState.CurentStage == GameState.Stage.SpellChoiseStage)
            {
                if (GameState.Money >= ShopClass.SecondSpellSlot.Cost && SpellBookClass.SpellBookSize == 0)
                {
                    GameState.Money -= ShopClass.SecondSpellSlot.Cost;
                    MoneyCounter.Content = GameState.Money.ToString();
                    BuySecondSlot.IsEnabled = false;
                    BuySecondSlot.Content = "Куплено!";
                    ShopClass.FromShopToSpellBook(ShopClass.SecondSpellSlot);

                    UIClass.UIAddToSlotInSpellBook(((MainWindow)Application.Current.MainWindow).SpellText,
                                                   ((MainWindow)Application.Current.MainWindow).SpellImage,
                                                   ((MainWindow)Application.Current.MainWindow).SpellTitle,
                                                   ShopClass.SecondSpellSlot);

                    UIClass.UIRefreshCrew(((MainWindow)Application.Current.MainWindow).PlayerCrew1, ((MainWindow)Application.Current.MainWindow).ImageCrew1,
                        ((MainWindow)Application.Current.MainWindow).PlayerCrew2, ((MainWindow)Application.Current.MainWindow).ImageCrew2,
                        ((MainWindow)Application.Current.MainWindow).PlayerCrew3, ((MainWindow)Application.Current.MainWindow).ImageCrew3,
                    ((MainWindow)Application.Current.MainWindow).PlayerCrew4, ((MainWindow)Application.Current.MainWindow).ImageCrew4,
                    ((MainWindow)Application.Current.MainWindow).PlayerCrew5, ((MainWindow)Application.Current.MainWindow).ImageCrew5,
                    ((MainWindow)Application.Current.MainWindow).CrewHealth1, ((MainWindow)Application.Current.MainWindow).CrewVitality1, ((MainWindow)Application.Current.MainWindow).CrewAttack1,
                    ((MainWindow)Application.Current.MainWindow).CrewHealth2, ((MainWindow)Application.Current.MainWindow).CrewVitality2, ((MainWindow)Application.Current.MainWindow).CrewAttack2,
                    ((MainWindow)Application.Current.MainWindow).CrewHealth3, ((MainWindow)Application.Current.MainWindow).CrewVitality3, ((MainWindow)Application.Current.MainWindow).CrewAttack3,
                    ((MainWindow)Application.Current.MainWindow).CrewHealth4, ((MainWindow)Application.Current.MainWindow).CrewVitality4, ((MainWindow)Application.Current.MainWindow).CrewAttack4,
                    ((MainWindow)Application.Current.MainWindow).CrewHealth5, ((MainWindow)Application.Current.MainWindow).CrewVitality5, ((MainWindow)Application.Current.MainWindow).CrewAttack5);

                    ((MainWindow)Application.Current.MainWindow).GoToFightAllSlot.IsEnabled = true;

                    UIClass.AddTextToLog(((MainWindow)Application.Current.MainWindow).GameLog, "Стадия сражений началась");
                    ((MainWindow)Application.Current.MainWindow).BattleBoard.Visibility = Visibility.Visible;
                    Close();
                }
                else if (SpellBookClass.SpellBookSize > 0)
                {
                    UIClass.AddTextToLog(((MainWindow)Application.Current.MainWindow).GameLog, "Заклинание уже куплено!");
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
                if (GameState.Money >= ShopClass.ThirdSlot.Cost && CrewClass.CrewSize <= 4)
                {
                    GameState.Money -= ShopClass.ThirdSlot.Cost;
                    MoneyCounter.Content = GameState.Money.ToString();
                    BuyThirdSlot.IsEnabled = false;
                    BuyThirdSlot.Content = "Куплено!";
                    ShopClass.FromShopToCrew(ShopClass.ThirdSlot);

                    UIClass.UIRefreshCrew(((MainWindow)Application.Current.MainWindow).PlayerCrew1, ((MainWindow)Application.Current.MainWindow).ImageCrew1,
                        ((MainWindow)Application.Current.MainWindow).PlayerCrew2, ((MainWindow)Application.Current.MainWindow).ImageCrew2,
                        ((MainWindow)Application.Current.MainWindow).PlayerCrew3, ((MainWindow)Application.Current.MainWindow).ImageCrew3,
                    ((MainWindow)Application.Current.MainWindow).PlayerCrew4, ((MainWindow)Application.Current.MainWindow).ImageCrew4,
                    ((MainWindow)Application.Current.MainWindow).PlayerCrew5, ((MainWindow)Application.Current.MainWindow).ImageCrew5,
                    ((MainWindow)Application.Current.MainWindow).CrewHealth1, ((MainWindow)Application.Current.MainWindow).CrewVitality1, ((MainWindow)Application.Current.MainWindow).CrewAttack1,
                    ((MainWindow)Application.Current.MainWindow).CrewHealth2, ((MainWindow)Application.Current.MainWindow).CrewVitality2, ((MainWindow)Application.Current.MainWindow).CrewAttack2,
                    ((MainWindow)Application.Current.MainWindow).CrewHealth3, ((MainWindow)Application.Current.MainWindow).CrewVitality3, ((MainWindow)Application.Current.MainWindow).CrewAttack3,
                    ((MainWindow)Application.Current.MainWindow).CrewHealth4, ((MainWindow)Application.Current.MainWindow).CrewVitality4, ((MainWindow)Application.Current.MainWindow).CrewAttack4,
                    ((MainWindow)Application.Current.MainWindow).CrewHealth5, ((MainWindow)Application.Current.MainWindow).CrewVitality5, ((MainWindow)Application.Current.MainWindow).CrewAttack5);
                }
                else
                {
                    UIClass.AddTextToLog(((MainWindow)Application.Current.MainWindow).GameLog, "Нехватает валюты!");
                }

                if (CrewClass.CrewSize > 4)
                {
                    UIClass.AddTextToLog(((MainWindow)Application.Current.MainWindow).GameLog, "Отряд укомплектован");

                    BuyFirstSlot.IsEnabled = false;
                    BuySecondSlot.IsEnabled = false;
                    BuyThirdSlot.IsEnabled = false;
                }
            }
            else if (GameState.CurentStage == GameState.Stage.ItemShopStage)
            {
                if (GameState.Money >= ShopClass.ThirdItemSlot.Cost && InventoryClass.InventorySize <= 5)
                {
                    GameState.Money -= ShopClass.ThirdItemSlot.Cost;
                    MoneyCounter.Content = GameState.Money.ToString();
                    BuyThirdSlot.IsEnabled = false;
                    BuyThirdSlot.Content = "Куплено!";
                    ShopClass.FromShopToInventory(ShopClass.ThirdItemSlot);

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
                else
                {
                    UIClass.AddTextToLog(((MainWindow)Application.Current.MainWindow).GameLog, "Нехватает валюты!");
                }

                if (InventoryClass.InventorySize > 5)
                {
                    UIClass.AddTextToLog(((MainWindow)Application.Current.MainWindow).GameLog, "Места в инвентаре нет");

                    BuyFirstSlot.IsEnabled = false;
                    BuySecondSlot.IsEnabled = false;
                    BuyThirdSlot.IsEnabled = false;
                }
            }
            else if (GameState.CurentStage == GameState.Stage.SpellChoiseStage)
            {
                if (GameState.Money >= ShopClass.ThirdSpellSlot.Cost && SpellBookClass.SpellBookSize == 0)
                {
                    GameState.Money -= ShopClass.ThirdSpellSlot.Cost;
                    MoneyCounter.Content = GameState.Money.ToString();
                    BuyThirdSlot.IsEnabled = false;
                    BuyThirdSlot.Content = "Куплено!";
                    ShopClass.FromShopToSpellBook(ShopClass.ThirdSpellSlot);

                    UIClass.UIAddToSlotInSpellBook(((MainWindow)Application.Current.MainWindow).SpellText, 
                                                   ((MainWindow)Application.Current.MainWindow).SpellImage,
                                                   ((MainWindow)Application.Current.MainWindow).SpellTitle,
                                                   ShopClass.ThirdSpellSlot);

                    UIClass.UIRefreshCrew(((MainWindow)Application.Current.MainWindow).PlayerCrew1, ((MainWindow)Application.Current.MainWindow).ImageCrew1,
                        ((MainWindow)Application.Current.MainWindow).PlayerCrew2, ((MainWindow)Application.Current.MainWindow).ImageCrew2,
                        ((MainWindow)Application.Current.MainWindow).PlayerCrew3, ((MainWindow)Application.Current.MainWindow).ImageCrew3,
                    ((MainWindow)Application.Current.MainWindow).PlayerCrew4, ((MainWindow)Application.Current.MainWindow).ImageCrew4,
                    ((MainWindow)Application.Current.MainWindow).PlayerCrew5, ((MainWindow)Application.Current.MainWindow).ImageCrew5,
                    ((MainWindow)Application.Current.MainWindow).CrewHealth1, ((MainWindow)Application.Current.MainWindow).CrewVitality1, ((MainWindow)Application.Current.MainWindow).CrewAttack1,
                    ((MainWindow)Application.Current.MainWindow).CrewHealth2, ((MainWindow)Application.Current.MainWindow).CrewVitality2, ((MainWindow)Application.Current.MainWindow).CrewAttack2,
                    ((MainWindow)Application.Current.MainWindow).CrewHealth3, ((MainWindow)Application.Current.MainWindow).CrewVitality3, ((MainWindow)Application.Current.MainWindow).CrewAttack3,
                    ((MainWindow)Application.Current.MainWindow).CrewHealth4, ((MainWindow)Application.Current.MainWindow).CrewVitality4, ((MainWindow)Application.Current.MainWindow).CrewAttack4,
                    ((MainWindow)Application.Current.MainWindow).CrewHealth5, ((MainWindow)Application.Current.MainWindow).CrewVitality5, ((MainWindow)Application.Current.MainWindow).CrewAttack5);

                    ((MainWindow)Application.Current.MainWindow).GoToFightAllSlot.IsEnabled = true;

                    UIClass.AddTextToLog(((MainWindow)Application.Current.MainWindow).GameLog, "Стадия сражений началась");
                    ((MainWindow)Application.Current.MainWindow).BattleBoard.Visibility = Visibility.Visible;
                    Close();
                }
                else if (SpellBookClass.SpellBookSize > 0)
                {
                    UIClass.AddTextToLog(((MainWindow)Application.Current.MainWindow).GameLog, "Заклинание уже куплено!");
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
                if (GameState.Money >= 2)
                {
                    GameState.Money -= 2;
                    MoneyCounter.Content = GameState.Money.ToString();

                    ShopClass.RandomUnitToShop();

                    UIClass.UIAddUnitToSlotInShop(FirstSlot, ImageFirstSlot, ShopClass.FirstSlot,
                                                    CardHealth1, CardVitality1, CardAttack1);
                    UIClass.UIAddUnitToSlotInShop(SecondSlot, ImageSecondSlot, ShopClass.SecondSlot,
                                                    CardHealth2, CardVitality2, CardAttack2);
                    UIClass.UIAddUnitToSlotInShop(ThirdSlot, ImageThirdSlot, ShopClass.ThirdSlot,
                                                    CardHealth3, CardVitality3, CardAttack3);

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
                if (GameState.Money >= 2)
                {
                    GameState.Money -= 2;
                    MoneyCounter.Content = GameState.Money.ToString();

                    ShopClass.RandomItemToShop();

                    UIClass.UIAddItemToSlotInShop(FirstSlot, ImageFirstSlot, ShopClass.FirstItemSlot,
                                                    CardHealth1, CardVitality1, CardAttack1);
                    UIClass.UIAddItemToSlotInShop(SecondSlot, ImageSecondSlot, ShopClass.SecondItemSlot,
                                                    CardHealth2, CardVitality2, CardAttack2);
                    UIClass.UIAddItemToSlotInShop(ThirdSlot, ImageThirdSlot, ShopClass.ThirdItemSlot,
                                                    CardHealth3, CardVitality3, CardAttack3);

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
            else if (GameState.CurentStage == GameState.Stage.SpellChoiseStage)
            {
                if (GameState.Money >= 2)
                {
                    GameState.Money -= 2;
                    MoneyCounter.Content = GameState.Money.ToString();

                    ShopClass.RandomSpellToShop();

                    UIClass.UIAddSpellToSlotInShop(SpellFirstSlot, SpellCostFirstSlot, ImageFirstSlot, ShopClass.FirstSpellSlot);
                    UIClass.UIAddSpellToSlotInShop(SpellSecondSlot, SpellCostSecondSlot, ImageSecondSlot, ShopClass.SecondSpellSlot);
                    UIClass.UIAddSpellToSlotInShop(SpellThirdSlot, SpellCostThirdSlot, ImageThirdSlot, ShopClass.ThirdSpellSlot);

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
            if(CrewClass.CrewSize == 0)
            {
                UIClass.AddTextToLog(((MainWindow)Application.Current.MainWindow).GameLog, "Необходимо выбрать хотя бы один отряд!");
                return;
            }

            GameState.CurentStage++;

            if (GameState.CurentStage == GameState.Stage.ItemShopStage)
            {
                UIClass.AddTextToLog(((MainWindow)Application.Current.MainWindow).GameLog, "Стадия покупки предметов началась");

                string FileName = "ItemDeck.xml";
                string Path = GameState.ResourcePath + FileName;
                ShopClass.ItemList = ShopClass.XMLItemParser(Path);
                ShopClass.RandomItemToShop();

                UIClass.UIAddItemToSlotInShop(FirstSlot, ImageFirstSlot, ShopClass.FirstItemSlot,
                                                CardHealth1, CardVitality1, CardAttack1);
                UIClass.UIAddItemToSlotInShop(SecondSlot, ImageSecondSlot, ShopClass.SecondItemSlot,
                                                CardHealth2, CardVitality2, CardAttack2);
                UIClass.UIAddItemToSlotInShop(ThirdSlot, ImageThirdSlot, ShopClass.ThirdItemSlot,
                                                CardHealth3, CardVitality3, CardAttack3);

                BuyFirstSlot.Content = "Купить";
                BuySecondSlot.Content = "Купить";
                BuyThirdSlot.Content = "Купить";

                BuyFirstSlot.IsEnabled = true;
                BuySecondSlot.IsEnabled = true;
                BuyThirdSlot.IsEnabled = true;
            }
            else if(GameState.CurentStage == GameState.Stage.SpellChoiseStage)
            {
                BorderImageCard1.Visibility = Visibility.Hidden;
                BorderImageCard2.Visibility = Visibility.Hidden;
                BorderImageCard3.Visibility = Visibility.Hidden;
                CardHealth1.Content = "";
                CardVitality1.Content = "";
                CardAttack1.Content = "";
                CardHealth2.Content = "";
                CardVitality2.Content = "";
                CardAttack2.Content = "";
                CardHealth3.Content = "";
                CardVitality3.Content = "";
                CardAttack3.Content = "";

                UIClass.AddTextToLog(((MainWindow)Application.Current.MainWindow).GameLog, "Стадия покупки заклинания началась");

                string FileName = "SpellDeck.xml";
                string Path = GameState.ResourcePath + FileName;
                ShopClass.SpellList = ShopClass.XMLSpellParser(Path);
                ShopClass.RandomSpellToShop();

                FirstSlot.Visibility = Visibility.Hidden;
                SecondSlot.Visibility = Visibility.Hidden;
                ThirdSlot.Visibility = Visibility.Hidden;

                SpellFirstSlot.Visibility = Visibility.Visible;
                SpellSecondSlot.Visibility = Visibility.Visible;
                SpellThirdSlot.Visibility = Visibility.Visible;
                SpellCostFirstSlot.Visibility = Visibility.Visible;
                SpellCostSecondSlot.Visibility = Visibility.Visible;
                SpellCostThirdSlot.Visibility = Visibility.Visible;
                LabelSpellCostFirstSlot.Visibility = Visibility.Visible;
                LabelSpellCostSecondSlot.Visibility = Visibility.Visible;
                LabelSpellCostThirdSlot.Visibility = Visibility.Visible;

                UIClass.UIAddSpellToSlotInShop(SpellFirstSlot, SpellCostFirstSlot, ImageFirstSlot, ShopClass.FirstSpellSlot);
                UIClass.UIAddSpellToSlotInShop(SpellSecondSlot, SpellCostSecondSlot, ImageSecondSlot, ShopClass.SecondSpellSlot);
                UIClass.UIAddSpellToSlotInShop(SpellThirdSlot, SpellCostThirdSlot, ImageThirdSlot, ShopClass.ThirdSpellSlot);

                BuyFirstSlot.Content = "Купить";
                BuySecondSlot.Content = "Купить";
                BuyThirdSlot.Content = "Купить";

                BuyFirstSlot.IsEnabled = true;
                BuySecondSlot.IsEnabled = true;
                BuyThirdSlot.IsEnabled = true;
                
            }
            else if (GameState.CurentStage == GameState.Stage.FightStage)
            {

                ((MainWindow)Application.Current.MainWindow).GoToFightAllSlot.IsEnabled = true;

                UIClass.AddTextToLog(((MainWindow)Application.Current.MainWindow).GameLog, "Стадия сражений началась");
                ((MainWindow)Application.Current.MainWindow).BattleBoard.Visibility = Visibility.Visible;
                Close();
            }
        }
    }
}
