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
    /// Логика взаимодействия для UseItemWindow.xaml
    /// </summary>
    public partial class UseItemWindow : Window
    {
        public UseItemWindow()
        {
            InitializeComponent();
            UIClass.UIRefreshCrew(PlayerCrew1, ImageCrew1, PlayerCrew2, ImageCrew2, PlayerCrew3, ImageCrew3,
                                PlayerCrew4, ImageCrew4, PlayerCrew5, ImageCrew5);
        }

        private void UseItemOnCrew1_Click(object sender, RoutedEventArgs e)
        {
            if(CrewClass.Slot1.Name == "Убит" || CrewClass.Slot1.Name == "Не выбрано")
            {
                UIClass.AddTextToLog(((MainWindow)Application.Current.MainWindow).GameLog, 
                    $"Вы не можете применить предмет к этому отряду");
            }
            else
            {
                CrewClass.Slot1.Health += InventoryClass.ChosenItem.HealthBuff;
                CrewClass.Slot1.Attack += InventoryClass.ChosenItem.AttackBuff;
                CrewClass.Slot1.Vitality += InventoryClass.ChosenItem.VitalityBuff;
                DialogResult = true;
            }
        }

        private void UseItemOnCrew2_Click(object sender, RoutedEventArgs e)
        {
            if (CrewClass.Slot2.Name == "Убит" || CrewClass.Slot2.Name == "Не выбрано")
            {
                UIClass.AddTextToLog(((MainWindow)Application.Current.MainWindow).GameLog,
                    $"Вы не можете применить предмет к этому отряду");
            }
            else
            {
                CrewClass.Slot2.Health += InventoryClass.ChosenItem.HealthBuff;
                CrewClass.Slot2.Attack += InventoryClass.ChosenItem.AttackBuff;
                CrewClass.Slot2.Vitality += InventoryClass.ChosenItem.VitalityBuff;
                DialogResult = true;
            }
        }

        private void UseItemOnCrew3_Click(object sender, RoutedEventArgs e)
        {
            if (CrewClass.Slot3.Name == "Убит" || CrewClass.Slot3.Name == "Не выбрано")
            {
                UIClass.AddTextToLog(((MainWindow)Application.Current.MainWindow).GameLog,
                    $"Вы не можете применить предмет к этому отряду");
            }
            else
            {
                CrewClass.Slot3.Health += InventoryClass.ChosenItem.HealthBuff;
                CrewClass.Slot3.Attack += InventoryClass.ChosenItem.AttackBuff;
                CrewClass.Slot3.Vitality += InventoryClass.ChosenItem.VitalityBuff;
                DialogResult = true;
            }
        }

        private void UseItemOnCrew4_Click(object sender, RoutedEventArgs e)
        {
            if (CrewClass.Slot4.Name == "Убит" || CrewClass.Slot4.Name == "Не выбрано")
            {
                UIClass.AddTextToLog(((MainWindow)Application.Current.MainWindow).GameLog,
                    $"Вы не можете применить предмет к этому отряду");
            }
            else
            {
                CrewClass.Slot4.Health += InventoryClass.ChosenItem.HealthBuff;
                CrewClass.Slot4.Attack += InventoryClass.ChosenItem.AttackBuff;
                CrewClass.Slot4.Vitality += InventoryClass.ChosenItem.VitalityBuff;
                DialogResult = true;
            }
        }

        private void UseItemOnCrew5_Click(object sender, RoutedEventArgs e)
        {
            if (CrewClass.Slot5.Name == "Убит" || CrewClass.Slot5.Name == "Не выбрано")
            {
                UIClass.AddTextToLog(((MainWindow)Application.Current.MainWindow).GameLog,
                    $"Вы не можете применить предмет к этому отряду");
            }
            else
            {
                CrewClass.Slot5.Health += InventoryClass.ChosenItem.HealthBuff;
                CrewClass.Slot5.Attack += InventoryClass.ChosenItem.AttackBuff;
                CrewClass.Slot5.Vitality += InventoryClass.ChosenItem.VitalityBuff;
                DialogResult = true;
            }
        }
    }
}
