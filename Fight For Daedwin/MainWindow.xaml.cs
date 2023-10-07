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
using System.Threading;

namespace Fight_For_Daedwin
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            UIClass.ReadSettings();
            InitializeComponent();

            UIClass.UIRefreshCrew(PlayerCrew1, ImageCrew1, PlayerCrew2, ImageCrew2, PlayerCrew3, ImageCrew3,
                                PlayerCrew4, ImageCrew4, PlayerCrew5, ImageCrew5,
                                CrewHealth1, CrewVitality1, CrewAttack1,
                                CrewHealth2, CrewVitality2, CrewAttack2,
                                CrewHealth3, CrewVitality3, CrewAttack3,
                                CrewHealth4, CrewVitality4, CrewAttack4,
                                CrewHealth5, CrewVitality5, CrewAttack5);

            UIClass.UIRefreshInventory(Item1, ImageItem1, Item2, ImageItem2, Item3, ImageItem3,
                                            Item4, ImageItem4, Item5, ImageItem5, Item6, ImageItem6,
                                            ItemHealthBuff1, ItemVitalityBuff1, ItemAttackBuff1,
                                            ItemHealthBuff2, ItemVitalityBuff2, ItemAttackBuff2,
                                            ItemHealthBuff3, ItemVitalityBuff3, ItemAttackBuff3,
                                            ItemHealthBuff4, ItemVitalityBuff4, ItemAttackBuff4,
                                            ItemHealthBuff5, ItemVitalityBuff5, ItemAttackBuff5,
                                            ItemHealthBuff6, ItemVitalityBuff6, ItemAttackBuff6);

            UIClass.UIAddToSlotInSpellBook(SpellText, SpellImage, SpellTitle, SpellBookClass.PlayerSpell);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UIClass.AddTextToLog(GameLog, $"----------------------------------------------------");
            UIClass.AddTextToLog(GameLog, $"Начало новой игры");
            GameState.CurentStage = GameState.Stage.GameStart;
            //GameState.MonsterProgressionIncValue = 1;

            ShopWindow shopWindow = new ShopWindow();
            shopWindow.ShowDialog();

            UseItem1.Visibility = Visibility.Visible;
            UseItem2.Visibility = Visibility.Visible;
            UseItem3.Visibility = Visibility.Visible;
            UseItem4.Visibility = Visibility.Visible;
            UseItem5.Visibility = Visibility.Visible;
            UseItem6.Visibility = Visibility.Visible;
            StartButton.IsEnabled = false;
            GameLogParent.Visibility = Visibility.Visible;
        }

        private void NextFightButton_Click(object sender, RoutedEventArgs e)
        {
            if(GameState.CurentStage == GameState.Stage.EndStage)
            {
                UIClass.WriteRecordList();

                GoToFightSlot1.Visibility = Visibility.Hidden;
                GoToFightSlot2.Visibility = Visibility.Hidden;
                GoToFightSlot3.Visibility = Visibility.Hidden;
                GoToFightSlot4.Visibility = Visibility.Hidden;
                GoToFightSlot5.Visibility = Visibility.Hidden;
                GoToFightAllSlot.Visibility = Visibility.Hidden;

                BattleBoard.Visibility = Visibility.Hidden;
                BattleBoard.Visibility = Visibility.Hidden;
                StartButton.IsEnabled = true;

                MonsterFightClass.Stage = 0;
                GameState.Money = 50;

                CrewClass.RefreshCrew();
                InventoryClass.RefreshInventory();
                SpellBookClass.RefreshSpellBook();
                BattleEnviroment.RefreshBattleEnviroment();

                UIClass.UIRefreshCrew(PlayerCrew1, ImageCrew1, PlayerCrew2, ImageCrew2, PlayerCrew3, ImageCrew3,
                                    PlayerCrew4, ImageCrew4, PlayerCrew5, ImageCrew5,
                                    CrewHealth1, CrewVitality1, CrewAttack1,
                                    CrewHealth2, CrewVitality2, CrewAttack2,
                                    CrewHealth3, CrewVitality3, CrewAttack3,
                                    CrewHealth4, CrewVitality4, CrewAttack4,
                                    CrewHealth5, CrewVitality5, CrewAttack5);

                UIClass.UIRefreshInventory(Item1, ImageItem1, Item2, ImageItem2, Item3, ImageItem3,
                                                Item4, ImageItem4, Item5, ImageItem5, Item6, ImageItem6,
                                                ItemHealthBuff1, ItemVitalityBuff1, ItemAttackBuff1,
                                                ItemHealthBuff2, ItemVitalityBuff2, ItemAttackBuff2,
                                                ItemHealthBuff3, ItemVitalityBuff3, ItemAttackBuff3,
                                                ItemHealthBuff4, ItemVitalityBuff4, ItemAttackBuff4,
                                                ItemHealthBuff5, ItemVitalityBuff5, ItemAttackBuff5,
                                                ItemHealthBuff6, ItemVitalityBuff6, ItemAttackBuff6);

                UIClass.UIAddToSlotInSpellBook(SpellText, SpellImage, SpellTitle, SpellBookClass.PlayerSpell);

                return;
            }

            NextFightButton.IsEnabled = false;
            GoToFightSlot1.IsEnabled = true;
            GoToFightSlot2.IsEnabled = true;
            GoToFightSlot3.IsEnabled = true;
            GoToFightSlot4.IsEnabled = true;
            GoToFightSlot5.IsEnabled = true;
            GoToFightAllSlot.IsEnabled = true;

            MonsterFightClass.Stage++;
            CutentStage.Text = $"Уровень: {MonsterFightClass.Stage}";
            UIClass.AddTextToLog(GameLog, $"----------------------------------------------------");
            UIClass.AddTextToLog(GameLog, $"Уровень: {MonsterFightClass.Stage}");

            if (MonsterFightClass.Stage % 5 == 0)
            {
                MonsterFightClass.ChangeEnviroment();

                RewardWindow rewardWindow = new RewardWindow();
                rewardWindow.ShowDialog();

                UIClass.UIRefreshCrew(PlayerCrew1, ImageCrew1, PlayerCrew2, ImageCrew2, PlayerCrew3, ImageCrew3,
                                    PlayerCrew4, ImageCrew4, PlayerCrew5, ImageCrew5,
                                    CrewHealth1, CrewVitality1, CrewAttack1,
                                    CrewHealth2, CrewVitality2, CrewAttack2,
                                    CrewHealth3, CrewVitality3, CrewAttack3,
                                    CrewHealth4, CrewVitality4, CrewAttack4,
                                    CrewHealth5, CrewVitality5, CrewAttack5);
            }

            if (MonsterFightClass.Stage == 1)
            {
                if (CrewClass.Slot1.Name != "Не выбрано")
                    GoToFightSlot1.Visibility = Visibility.Visible;
                if (CrewClass.Slot2.Name != "Не выбрано")
                    GoToFightSlot2.Visibility = Visibility.Visible;
                if (CrewClass.Slot3.Name != "Не выбрано")
                    GoToFightSlot3.Visibility = Visibility.Visible;
                if (CrewClass.Slot4.Name != "Не выбрано")
                    GoToFightSlot4.Visibility = Visibility.Visible;
                if (CrewClass.Slot5.Name != "Не выбрано")
                    GoToFightSlot5.Visibility = Visibility.Visible;
                GoToFightAllSlot.Visibility = Visibility.Visible;


                string FileName = "MonsterDeck.xml";
                string Path = GameState.ResourcePath + FileName;
                MonsterFightClass.MonsterList = MonsterFightClass.XMLParser(Path);

                FileName = "EnviromentDeck.xml";
                Path = GameState.ResourcePath + FileName;
                MonsterFightClass.EnviromentList = MonsterFightClass.XMLEnviromentParser(Path);
                MonsterFightClass.ChangeEnviroment();

                UIClass.UIRefreshCrew(PlayerCrew1, ImageCrew1, PlayerCrew2, ImageCrew2, PlayerCrew3, ImageCrew3,
                    PlayerCrew4, ImageCrew4, PlayerCrew5, ImageCrew5,
                    CrewHealth1, CrewVitality1, CrewAttack1,
                    CrewHealth2, CrewVitality2, CrewAttack2,
                    CrewHealth3, CrewVitality3, CrewAttack3,
                    CrewHealth4, CrewVitality4, CrewAttack4,
                    CrewHealth5, CrewVitality5, CrewAttack5);
            }


            if (CrewClass.Slot1.Vitality <= 0)
                GoToFightSlot1.Visibility = Visibility.Hidden;
            else
            {
                GameState.GoToFightSlot1Clicked = false;
                GoToFightSlot1.Content = "Отправить в бой!";
                GoToFightSlot1.Visibility = Visibility.Visible;
            }
            if (CrewClass.Slot2.Vitality <= 0)
                GoToFightSlot2.Visibility = Visibility.Hidden;
            else
            {
                GameState.GoToFightSlot2Clicked = false;
                GoToFightSlot2.Content = "Отправить в бой!";
                GoToFightSlot2.Visibility = Visibility.Visible;
            }
            if (CrewClass.Slot3.Vitality <= 0)
                GoToFightSlot3.Visibility = Visibility.Hidden;
            else
            {
                GameState.GoToFightSlot3Clicked = false;
                GoToFightSlot3.Content = "Отправить в бой!";
                GoToFightSlot3.Visibility = Visibility.Visible;
            }
            if (CrewClass.Slot4.Vitality <= 0)
                GoToFightSlot4.Visibility = Visibility.Hidden;
            else
            {
                GameState.GoToFightSlot4Clicked = false;
                GoToFightSlot4.Content = "Отправить в бой!";
                GoToFightSlot4.Visibility = Visibility.Visible;
            }
            if (CrewClass.Slot5.Vitality <= 0)
                GoToFightSlot5.Visibility = Visibility.Hidden;
            else
            {
                GameState.GoToFightSlot5Clicked = false;
                GoToFightSlot5.Content = "Отправить в бой!";
                GoToFightSlot5.Visibility = Visibility.Visible;
            }

            MonsterFightClass.RandomMonsterToFight();
            UIClass.UIRefreshMonsterCrew(Monster1, MonsterImage1,
                    Monster2, MonsterImage2, Monster3, MonsterImage3, 
                    EnemyHealth1, EnemyAttack1, EnemyHealth2, EnemyAttack2, EnemyHealth3, EnemyAttack3);

            UIClass.UIAddEnviromentToBattelEnviroment(EnviromentText, EnviromentImage, BattleEnviroment.CurrentEnviroment);
        }

        private void GoToFightSlot1_Click(object sender, RoutedEventArgs e)
        {
            if (!GameState.GoToFightSlot1Clicked)
            {
                CrewClass.CardInActionList.Add(CrewClass.Slot1);
                GoToFightSlot1.Content = "Вернуть отряд!";
                GoToFightAllSlot.IsEnabled = false;
                UIClass.UIUpdateSumCrewAttack(CrewDamage);
                GameState.GoToFightSlot1Clicked = true;
            }
            else
            {
                CrewClass.CardInActionList.Remove(CrewClass.Slot1);
                GoToFightSlot1.Content = "Отправить в бой!";
                UIClass.UIUpdateSumCrewAttack(CrewDamage);
                GameState.GoToFightSlot1Clicked = false;
            }
        }

        private void GoToFightSlot2_Click(object sender, RoutedEventArgs e)
        {
            if (!GameState.GoToFightSlot2Clicked)
            {
                CrewClass.CardInActionList.Add(CrewClass.Slot2);
                GoToFightSlot2.Content = "Вернуть отряд!";
                GoToFightAllSlot.IsEnabled = false;
                UIClass.UIUpdateSumCrewAttack(CrewDamage);
                GameState.GoToFightSlot2Clicked = true;
            }
            else
            {
                CrewClass.CardInActionList.Remove(CrewClass.Slot2);
                GoToFightSlot2.Content = "Отправить в бой!";
                UIClass.UIUpdateSumCrewAttack(CrewDamage);
                GameState.GoToFightSlot2Clicked = false;
            }
        }

        private void GoToFightSlot3_Click(object sender, RoutedEventArgs e)
        {
            if (!GameState.GoToFightSlot3Clicked)
            {
                CrewClass.CardInActionList.Add(CrewClass.Slot3);
                GoToFightSlot3.Content = "Вернуть отряд!";
                GoToFightAllSlot.IsEnabled = false;
                UIClass.UIUpdateSumCrewAttack(CrewDamage);
                GameState.GoToFightSlot3Clicked = true;
            }
            else
            {
                CrewClass.CardInActionList.Remove(CrewClass.Slot3);
                GoToFightSlot3.Content = "Отправить в бой!";
                UIClass.UIUpdateSumCrewAttack(CrewDamage);
                GameState.GoToFightSlot3Clicked = false;
            }
        }

        private void GoToFightSlot4_Click(object sender, RoutedEventArgs e)
        {
            if (!GameState.GoToFightSlot4Clicked)
            {
                CrewClass.CardInActionList.Add(CrewClass.Slot4);
                GoToFightSlot4.Content = "Вернуть отряд!";
                GoToFightAllSlot.IsEnabled = false;
                UIClass.UIUpdateSumCrewAttack(CrewDamage);
                GameState.GoToFightSlot4Clicked = true;
            }
            else
            {
                CrewClass.CardInActionList.Remove(CrewClass.Slot4);
                GoToFightSlot4.Content = "Отправить в бой!";
                UIClass.UIUpdateSumCrewAttack(CrewDamage);
                GameState.GoToFightSlot4Clicked = false;
            }
        }

        private void GoToFightSlot5_Click(object sender, RoutedEventArgs e)
        {
            if (!GameState.GoToFightSlot5Clicked)
            {
                CrewClass.CardInActionList.Add(CrewClass.Slot5);
                GoToFightSlot5.Content = "Вернуть отряд!";
                GoToFightAllSlot.IsEnabled = false;
                UIClass.UIUpdateSumCrewAttack(CrewDamage);
                GameState.GoToFightSlot5Clicked = true;
            }
            else
            {
                CrewClass.CardInActionList.Remove(CrewClass.Slot5);
                GoToFightSlot5.Content = "Отправить в бой!";
                UIClass.UIUpdateSumCrewAttack(CrewDamage);
                GameState.GoToFightSlot5Clicked = false;
            }
        }

        private void GoToFightAllSlot_Click(object sender, RoutedEventArgs e)
        {
            int SumAttack = 0;
            foreach (Card card in CrewClass.CrewList)
            {
                if (card.Name != "Убит" && card.Name != "Не выбрано" && card.Vitality > 0)
                {
                    CrewClass.CardInActionList.Add(card);
                    SumAttack += card.Attack;
                }
            }
            CrewDamage.Text = SumAttack.ToString();
            UIClass.AddTextToLog(GameLog, $"Все отряды готовы к бою");
            GoToFightSlot1.IsEnabled = false;
            GoToFightSlot2.IsEnabled = false;
            GoToFightSlot3.IsEnabled = false;
            GoToFightSlot4.IsEnabled = false;
            GoToFightSlot5.IsEnabled = false;
            GoToFightAllSlot.IsEnabled = false;
        }

        private void FightButton_Click(object sender, RoutedEventArgs e)
        {
            if (CrewClass.CardInActionList.Count == 0)
            {
                UIClass.AddTextToLog(GameLog, $"Выберете бойцов для боя!");
            }
            else 
            {
                int crew1Health = CrewClass.Slot1.Health;
                int crew2Health = CrewClass.Slot2.Health;
                int crew3Health = CrewClass.Slot3.Health;
                int crew4Health = CrewClass.Slot4.Health;
                int crew5Health = CrewClass.Slot5.Health;

                MonsterFightClass.FightAction();

                UIClass.UIRefreshCrew(PlayerCrew1, ImageCrew1, PlayerCrew2, ImageCrew2, PlayerCrew3, ImageCrew3,
                                    PlayerCrew4, ImageCrew4, PlayerCrew5, ImageCrew5,
                                    CrewHealth1, CrewVitality1, CrewAttack1,
                                    CrewHealth2, CrewVitality2, CrewAttack2,
                                    CrewHealth3, CrewVitality3, CrewAttack3,
                                    CrewHealth4, CrewVitality4, CrewAttack4,
                                    CrewHealth5, CrewVitality5, CrewAttack5);

                UIClass.UIRefreshMonsterCrew(Monster1, MonsterImage1,
                        Monster2, MonsterImage2, Monster3, MonsterImage3,
                        EnemyHealth1, EnemyAttack1, EnemyHealth2, EnemyAttack2, EnemyHealth3, EnemyAttack3);

                if (CrewClass.Slot1.Name == "Убит" || CrewClass.Slot1.Name == "Не выбрано")
                    GoToFightSlot1.Visibility = Visibility.Hidden;
                if (CrewClass.Slot2.Name == "Убит" || CrewClass.Slot2.Name == "Не выбрано")
                    GoToFightSlot2.Visibility = Visibility.Hidden;
                if (CrewClass.Slot3.Name == "Убит" || CrewClass.Slot3.Name == "Не выбрано")
                    GoToFightSlot3.Visibility = Visibility.Hidden;
                if (CrewClass.Slot4.Name == "Убит" || CrewClass.Slot4.Name == "Не выбрано")
                    GoToFightSlot4.Visibility = Visibility.Hidden;
                if (CrewClass.Slot5.Name == "Убит" || CrewClass.Slot5.Name == "Не выбрано")
                    GoToFightSlot5.Visibility = Visibility.Hidden;

                List<string> BattleInfoList = new List<string>
            {
                $"Первый отряд потерял {crew1Health - CrewClass.Slot1.Health} HP",
                $"Второй отряд потерял {crew2Health - CrewClass.Slot2.Health} HP",
                $"Третий отряд потерял {crew3Health - CrewClass.Slot3.Health} HP",
                $"Четвертый отряд потерял {crew4Health - CrewClass.Slot4.Health} HP",
                $"Пятый отряд потерял {crew5Health - CrewClass.Slot5.Health} HP",
            };
                BattleInfo.ItemsSource = BattleInfoList;

                NextFightButton.IsEnabled = true;
                CrewClass.CardInActionList.Clear();
            }

            CrewDamage.Text = "0";
        }

        private void UseItem1_Click(object sender, RoutedEventArgs e)
        {
            InventoryClass.ChosenItem = InventoryClass.Slot1;
            if (InventoryClass.ChosenItem.Type == "Одна цель")
            {
                UseItemWindow useItemWindow = new UseItemWindow();
                useItemWindow.ShowDialog();
            }
            else if (InventoryClass.ChosenItem.Type == "Весь отряд")
                InventoryClass.ChosenItem.UseItemOnAllCrew();

            InventoryClass.InventorySize--;
            InventoryClass.Slot1 = new Item();
            InventoryClass.ChosenItem = null;
            InventoryClass.SortSlots();

            if (CrewClass.Slot1.Vitality <= 0)
                GoToFightSlot1.Visibility = Visibility.Hidden;
            else
            {
                GoToFightSlot1.Visibility = Visibility.Visible;
                UIClass.UIUpdateSumCrewAttack(CrewDamage);
            }
            if (CrewClass.Slot2.Vitality <= 0)
                GoToFightSlot2.Visibility = Visibility.Hidden;
            else
            {
                GoToFightSlot2.Visibility = Visibility.Visible;
                UIClass.UIUpdateSumCrewAttack(CrewDamage);
            }
            if (CrewClass.Slot3.Vitality <= 0)
                GoToFightSlot3.Visibility = Visibility.Hidden;
            else
            {
                GoToFightSlot3.Visibility = Visibility.Visible;
                UIClass.UIUpdateSumCrewAttack(CrewDamage);
            }
            if (CrewClass.Slot4.Vitality <= 0)
                GoToFightSlot4.Visibility = Visibility.Hidden;
            else
            {
                GoToFightSlot4.Visibility = Visibility.Visible;
                UIClass.UIUpdateSumCrewAttack(CrewDamage);
            }
            if (CrewClass.Slot5.Vitality <= 0)
                GoToFightSlot5.Visibility = Visibility.Hidden;
            else
            {
                GoToFightSlot5.Visibility = Visibility.Visible;
                UIClass.UIUpdateSumCrewAttack(CrewDamage);
            }

            UIClass.UIRefreshCrew(PlayerCrew1, ImageCrew1, PlayerCrew2, ImageCrew2, PlayerCrew3, ImageCrew3,
                                PlayerCrew4, ImageCrew4, PlayerCrew5, ImageCrew5,
                                CrewHealth1, CrewVitality1, CrewAttack1,
                                CrewHealth2, CrewVitality2, CrewAttack2,
                                CrewHealth3, CrewVitality3, CrewAttack3,
                                CrewHealth4, CrewVitality4, CrewAttack4,
                                CrewHealth5, CrewVitality5, CrewAttack5);
            UIClass.UIRefreshInventory(Item1, ImageItem1, Item2, ImageItem2, Item3, ImageItem3,
                                            Item4, ImageItem4, Item5, ImageItem5, Item6, ImageItem6,
                                            ItemHealthBuff1, ItemVitalityBuff1, ItemAttackBuff1,
                                            ItemHealthBuff2, ItemVitalityBuff2, ItemAttackBuff2,
                                            ItemHealthBuff3, ItemVitalityBuff3, ItemAttackBuff3,
                                            ItemHealthBuff4, ItemVitalityBuff4, ItemAttackBuff4,
                                            ItemHealthBuff5, ItemVitalityBuff5, ItemAttackBuff5,
                                            ItemHealthBuff6, ItemVitalityBuff6, ItemAttackBuff6);
        }

        private void UseItem2_Click(object sender, RoutedEventArgs e)
        {
            InventoryClass.ChosenItem = InventoryClass.Slot2;
            if (InventoryClass.ChosenItem.Type == "Одна цель")
            {
                UseItemWindow useItemWindow = new UseItemWindow();
                useItemWindow.ShowDialog();
            }
            else if (InventoryClass.ChosenItem.Type == "Весь отряд")
                InventoryClass.ChosenItem.UseItemOnAllCrew();

            InventoryClass.InventorySize--;
            InventoryClass.Slot2 = new Item();
            InventoryClass.ChosenItem = null;
            InventoryClass.SortSlots();

            if (CrewClass.Slot1.Vitality <= 0)
                GoToFightSlot1.Visibility = Visibility.Hidden;
            else
            {
                GoToFightSlot1.Visibility = Visibility.Visible;
                UIClass.UIUpdateSumCrewAttack(CrewDamage);
            }
            if (CrewClass.Slot2.Vitality <= 0)
                GoToFightSlot2.Visibility = Visibility.Hidden;
            else
            {
                GoToFightSlot2.Visibility = Visibility.Visible;
                UIClass.UIUpdateSumCrewAttack(CrewDamage);
            }
            if (CrewClass.Slot3.Vitality <= 0)
                GoToFightSlot3.Visibility = Visibility.Hidden;
            else
            {
                GoToFightSlot3.Visibility = Visibility.Visible;
                UIClass.UIUpdateSumCrewAttack(CrewDamage);
            }
            if (CrewClass.Slot4.Vitality <= 0)
                GoToFightSlot4.Visibility = Visibility.Hidden;
            else
            {
                GoToFightSlot4.Visibility = Visibility.Visible;
                UIClass.UIUpdateSumCrewAttack(CrewDamage);
            }
            if (CrewClass.Slot5.Vitality <= 0)
                GoToFightSlot5.Visibility = Visibility.Hidden;
            else
            {
                GoToFightSlot5.Visibility = Visibility.Visible;
                UIClass.UIUpdateSumCrewAttack(CrewDamage);
            }

            UIClass.UIRefreshCrew(PlayerCrew1, ImageCrew1, PlayerCrew2, ImageCrew2, PlayerCrew3, ImageCrew3,
                                PlayerCrew4, ImageCrew4, PlayerCrew5, ImageCrew5,
                                CrewHealth1, CrewVitality1, CrewAttack1,
                                CrewHealth2, CrewVitality2, CrewAttack2,
                                CrewHealth3, CrewVitality3, CrewAttack3,
                                CrewHealth4, CrewVitality4, CrewAttack4,
                                CrewHealth5, CrewVitality5, CrewAttack5);
            UIClass.UIRefreshInventory(Item1, ImageItem1, Item2, ImageItem2, Item3, ImageItem3,
                                            Item4, ImageItem4, Item5, ImageItem5, Item6, ImageItem6,
                                            ItemHealthBuff1, ItemVitalityBuff1, ItemAttackBuff1,
                                            ItemHealthBuff2, ItemVitalityBuff2, ItemAttackBuff2,
                                            ItemHealthBuff3, ItemVitalityBuff3, ItemAttackBuff3,
                                            ItemHealthBuff4, ItemVitalityBuff4, ItemAttackBuff4,
                                            ItemHealthBuff5, ItemVitalityBuff5, ItemAttackBuff5,
                                            ItemHealthBuff6, ItemVitalityBuff6, ItemAttackBuff6);
        }

        private void UseItem3_Click(object sender, RoutedEventArgs e)
        {
            InventoryClass.ChosenItem = InventoryClass.Slot3;
            if (InventoryClass.ChosenItem.Type == "Одна цель")
            {
                UseItemWindow useItemWindow = new UseItemWindow();
                useItemWindow.ShowDialog();
            }
            else if(InventoryClass.ChosenItem.Type == "Весь отряд")
                InventoryClass.ChosenItem.UseItemOnAllCrew();

            InventoryClass.InventorySize--;
            InventoryClass.Slot3 = new Item();
            InventoryClass.ChosenItem = null;
            InventoryClass.SortSlots();

            if (CrewClass.Slot1.Vitality <= 0)
                GoToFightSlot1.Visibility = Visibility.Hidden;
            else
            {
                GoToFightSlot1.Visibility = Visibility.Visible;
                UIClass.UIUpdateSumCrewAttack(CrewDamage);
            }
            if (CrewClass.Slot2.Vitality <= 0)
                GoToFightSlot2.Visibility = Visibility.Hidden;
            else
            {
                GoToFightSlot2.Visibility = Visibility.Visible;
                UIClass.UIUpdateSumCrewAttack(CrewDamage);
            }
            if (CrewClass.Slot3.Vitality <= 0)
                GoToFightSlot3.Visibility = Visibility.Hidden;
            else
            {
                GoToFightSlot3.Visibility = Visibility.Visible;
                UIClass.UIUpdateSumCrewAttack(CrewDamage);
            }
            if (CrewClass.Slot4.Vitality <= 0)
                GoToFightSlot4.Visibility = Visibility.Hidden;
            else
            {
                GoToFightSlot4.Visibility = Visibility.Visible;
                UIClass.UIUpdateSumCrewAttack(CrewDamage);
            }
            if (CrewClass.Slot5.Vitality <= 0)
                GoToFightSlot5.Visibility = Visibility.Hidden;
            else
            {
                GoToFightSlot5.Visibility = Visibility.Visible;
                UIClass.UIUpdateSumCrewAttack(CrewDamage);
            }

            UIClass.UIRefreshCrew(PlayerCrew1, ImageCrew1, PlayerCrew2, ImageCrew2, PlayerCrew3, ImageCrew3,
                                PlayerCrew4, ImageCrew4, PlayerCrew5, ImageCrew5,
                                CrewHealth1, CrewVitality1, CrewAttack1,
                                CrewHealth2, CrewVitality2, CrewAttack2,
                                CrewHealth3, CrewVitality3, CrewAttack3,
                                CrewHealth4, CrewVitality4, CrewAttack4,
                                CrewHealth5, CrewVitality5, CrewAttack5);
            UIClass.UIRefreshInventory(Item1, ImageItem1, Item2, ImageItem2, Item3, ImageItem3,
                                            Item4, ImageItem4, Item5, ImageItem5, Item6, ImageItem6,
                                            ItemHealthBuff1, ItemVitalityBuff1, ItemAttackBuff1,
                                            ItemHealthBuff2, ItemVitalityBuff2, ItemAttackBuff2,
                                            ItemHealthBuff3, ItemVitalityBuff3, ItemAttackBuff3,
                                            ItemHealthBuff4, ItemVitalityBuff4, ItemAttackBuff4,
                                            ItemHealthBuff5, ItemVitalityBuff5, ItemAttackBuff5,
                                            ItemHealthBuff6, ItemVitalityBuff6, ItemAttackBuff6);
        }

        private void UseItem4_Click(object sender, RoutedEventArgs e)
        {
            InventoryClass.ChosenItem = InventoryClass.Slot4;
            if (InventoryClass.ChosenItem.Type == "Одна цель")
            {
                UseItemWindow useItemWindow = new UseItemWindow();
                useItemWindow.ShowDialog();
            }
            else if (InventoryClass.ChosenItem.Type == "Весь отряд")
                InventoryClass.ChosenItem.UseItemOnAllCrew();

            InventoryClass.InventorySize--;
            InventoryClass.Slot4 = new Item();
            InventoryClass.ChosenItem = null;
            InventoryClass.SortSlots();

            if (CrewClass.Slot1.Vitality <= 0)
                GoToFightSlot1.Visibility = Visibility.Hidden;
            else
            {
                GoToFightSlot1.Visibility = Visibility.Visible;
                UIClass.UIUpdateSumCrewAttack(CrewDamage);
            }
            if (CrewClass.Slot2.Vitality <= 0)
                GoToFightSlot2.Visibility = Visibility.Hidden;
            else
            {
                GoToFightSlot2.Visibility = Visibility.Visible;
                UIClass.UIUpdateSumCrewAttack(CrewDamage);
            }
            if (CrewClass.Slot3.Vitality <= 0)
                GoToFightSlot3.Visibility = Visibility.Hidden;
            else
            {
                GoToFightSlot3.Visibility = Visibility.Visible;
                UIClass.UIUpdateSumCrewAttack(CrewDamage);
            }
            if (CrewClass.Slot4.Vitality <= 0)
                GoToFightSlot4.Visibility = Visibility.Hidden;
            else
            {
                GoToFightSlot4.Visibility = Visibility.Visible;
                UIClass.UIUpdateSumCrewAttack(CrewDamage);
            }
            if (CrewClass.Slot5.Vitality <= 0)
                GoToFightSlot5.Visibility = Visibility.Hidden;
            else
            {
                GoToFightSlot5.Visibility = Visibility.Visible;
                UIClass.UIUpdateSumCrewAttack(CrewDamage);
            }

            UIClass.UIRefreshCrew(PlayerCrew1, ImageCrew1, PlayerCrew2, ImageCrew2, PlayerCrew3, ImageCrew3,
                                PlayerCrew4, ImageCrew4, PlayerCrew5, ImageCrew5,
                                CrewHealth1, CrewVitality1, CrewAttack1,
                                CrewHealth2, CrewVitality2, CrewAttack2,
                                CrewHealth3, CrewVitality3, CrewAttack3,
                                CrewHealth4, CrewVitality4, CrewAttack4,
                                CrewHealth5, CrewVitality5, CrewAttack5);
            UIClass.UIRefreshInventory(Item1, ImageItem1, Item2, ImageItem2, Item3, ImageItem3,
                                            Item4, ImageItem4, Item5, ImageItem5, Item6, ImageItem6,
                                            ItemHealthBuff1, ItemVitalityBuff1, ItemAttackBuff1,
                                            ItemHealthBuff2, ItemVitalityBuff2, ItemAttackBuff2,
                                            ItemHealthBuff3, ItemVitalityBuff3, ItemAttackBuff3,
                                            ItemHealthBuff4, ItemVitalityBuff4, ItemAttackBuff4,
                                            ItemHealthBuff5, ItemVitalityBuff5, ItemAttackBuff5,
                                            ItemHealthBuff6, ItemVitalityBuff6, ItemAttackBuff6);
        }

        private void UseItem5_Click(object sender, RoutedEventArgs e)
        {
            InventoryClass.ChosenItem = InventoryClass.Slot5;
            if (InventoryClass.ChosenItem.Type == "Одна цель")
            {
                UseItemWindow useItemWindow = new UseItemWindow();
                useItemWindow.ShowDialog();
            }
            else if (InventoryClass.ChosenItem.Type == "Весь отряд")
                InventoryClass.ChosenItem.UseItemOnAllCrew();

            InventoryClass.InventorySize--;
            InventoryClass.Slot5 = new Item();
            InventoryClass.ChosenItem = null;
            InventoryClass.SortSlots();

            if (CrewClass.Slot1.Vitality <= 0)
                GoToFightSlot1.Visibility = Visibility.Hidden;
            else
            {
                GoToFightSlot1.Visibility = Visibility.Visible;
                UIClass.UIUpdateSumCrewAttack(CrewDamage);
            }
            if (CrewClass.Slot2.Vitality <= 0)
                GoToFightSlot2.Visibility = Visibility.Hidden;
            else
            {
                GoToFightSlot2.Visibility = Visibility.Visible;
                UIClass.UIUpdateSumCrewAttack(CrewDamage);
            }
            if (CrewClass.Slot3.Vitality <= 0)
                GoToFightSlot3.Visibility = Visibility.Hidden;
            else
            {
                GoToFightSlot3.Visibility = Visibility.Visible;
                UIClass.UIUpdateSumCrewAttack(CrewDamage);
            }
            if (CrewClass.Slot4.Vitality <= 0)
                GoToFightSlot4.Visibility = Visibility.Hidden;
            else
            {
                GoToFightSlot4.Visibility = Visibility.Visible;
                UIClass.UIUpdateSumCrewAttack(CrewDamage);
            }
            if (CrewClass.Slot5.Vitality <= 0)
                GoToFightSlot5.Visibility = Visibility.Hidden;
            else
            {
                GoToFightSlot5.Visibility = Visibility.Visible;
                UIClass.UIUpdateSumCrewAttack(CrewDamage);
            }

            UIClass.UIRefreshCrew(PlayerCrew1, ImageCrew1, PlayerCrew2, ImageCrew2, PlayerCrew3, ImageCrew3,
                                PlayerCrew4, ImageCrew4, PlayerCrew5, ImageCrew5,
                                CrewHealth1, CrewVitality1, CrewAttack1,
                                CrewHealth2, CrewVitality2, CrewAttack2,
                                CrewHealth3, CrewVitality3, CrewAttack3,
                                CrewHealth4, CrewVitality4, CrewAttack4,
                                CrewHealth5, CrewVitality5, CrewAttack5);
            UIClass.UIRefreshInventory(Item1, ImageItem1, Item2, ImageItem2, Item3, ImageItem3,
                                            Item4, ImageItem4, Item5, ImageItem5, Item6, ImageItem6,
                                            ItemHealthBuff1, ItemVitalityBuff1, ItemAttackBuff1,
                                            ItemHealthBuff2, ItemVitalityBuff2, ItemAttackBuff2,
                                            ItemHealthBuff3, ItemVitalityBuff3, ItemAttackBuff3,
                                            ItemHealthBuff4, ItemVitalityBuff4, ItemAttackBuff4,
                                            ItemHealthBuff5, ItemVitalityBuff5, ItemAttackBuff5,
                                            ItemHealthBuff6, ItemVitalityBuff6, ItemAttackBuff6);
        }

        private void UseItem6_Click(object sender, RoutedEventArgs e)
        {
            InventoryClass.ChosenItem = InventoryClass.Slot6;
            if (InventoryClass.ChosenItem.Type == "Одна цель")
            {
                UseItemWindow useItemWindow = new UseItemWindow();
                useItemWindow.ShowDialog();
            }
            else if (InventoryClass.ChosenItem.Type == "Весь отряд")
                InventoryClass.ChosenItem.UseItemOnAllCrew();

            InventoryClass.InventorySize--;
            InventoryClass.Slot6 = new Item();
            InventoryClass.ChosenItem = null;
            InventoryClass.SortSlots();

            if (CrewClass.Slot1.Vitality <= 0)
                GoToFightSlot1.Visibility = Visibility.Hidden;
            else
            {
                GoToFightSlot1.Visibility = Visibility.Visible;
                UIClass.UIUpdateSumCrewAttack(CrewDamage);
            }
            if (CrewClass.Slot2.Vitality <= 0)
                GoToFightSlot2.Visibility = Visibility.Hidden;
            else
            {
                GoToFightSlot2.Visibility = Visibility.Visible;
                UIClass.UIUpdateSumCrewAttack(CrewDamage);
            }
            if (CrewClass.Slot3.Vitality <= 0)
                GoToFightSlot3.Visibility = Visibility.Hidden;
            else
            {
                GoToFightSlot3.Visibility = Visibility.Visible;
                UIClass.UIUpdateSumCrewAttack(CrewDamage);
            }
            if (CrewClass.Slot4.Vitality <= 0)
                GoToFightSlot4.Visibility = Visibility.Hidden;
            else
            {
                GoToFightSlot4.Visibility = Visibility.Visible;
                UIClass.UIUpdateSumCrewAttack(CrewDamage);
            }
            if (CrewClass.Slot5.Vitality <= 0)
                GoToFightSlot5.Visibility = Visibility.Hidden;
            else
            {
                GoToFightSlot5.Visibility = Visibility.Visible;
                UIClass.UIUpdateSumCrewAttack(CrewDamage);
            }

            UIClass.UIRefreshCrew(PlayerCrew1, ImageCrew1, PlayerCrew2, ImageCrew2, PlayerCrew3, ImageCrew3,
                                PlayerCrew4, ImageCrew4, PlayerCrew5, ImageCrew5,
                                CrewHealth1, CrewVitality1, CrewAttack1,
                                CrewHealth2, CrewVitality2, CrewAttack2,
                                CrewHealth3, CrewVitality3, CrewAttack3,
                                CrewHealth4, CrewVitality4, CrewAttack4,
                                CrewHealth5, CrewVitality5, CrewAttack5);
            UIClass.UIRefreshInventory(Item1, ImageItem1, Item2, ImageItem2, Item3, ImageItem3,
                                            Item4, ImageItem4, Item5, ImageItem5, Item6, ImageItem6,
                                            ItemHealthBuff1, ItemVitalityBuff1, ItemAttackBuff1,
                                            ItemHealthBuff2, ItemVitalityBuff2, ItemAttackBuff2,
                                            ItemHealthBuff3, ItemVitalityBuff3, ItemAttackBuff3,
                                            ItemHealthBuff4, ItemVitalityBuff4, ItemAttackBuff4,
                                            ItemHealthBuff5, ItemVitalityBuff5, ItemAttackBuff5,
                                            ItemHealthBuff6, ItemVitalityBuff6, ItemAttackBuff6);
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close(); // ))
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow settingsWindow = new SettingsWindow();
            settingsWindow.ShowDialog();
        }

        private void RecordsButton_Click(object sender, RoutedEventArgs e)
        {
            RecordWindow recordWindow = new RecordWindow();
            recordWindow.ShowDialog();
        }
    }
}
