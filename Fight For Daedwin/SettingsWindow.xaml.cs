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
    /// Логика взаимодействия для SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            UIClass.ReadSettings();
            InitializeComponent();
            PlayerNameBox.Text = GameState.PlayerName;
        }

        private void ApplySettings_Click(object sender, RoutedEventArgs e)
        {
            GameState.PlayerName = PlayerNameBox.Text;
            ApplySettings.IsEnabled = false;
            ApplySettings.Content = "Применено!";
            UIClass.WriteSettings();
        }

        private void CloseSettings_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
