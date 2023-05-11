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
using Desktop.Models;

namespace Desktop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Web.QueryPostSync("Registration/Auth", 
                new []
                {
                    new KeyValuePair<string, string>("login", Login.Text),
                    new KeyValuePair<string, string>("password", Password.Text),
                }, 
                (obj) =>
            {
                if (obj.Contains("Не"))
                {
                    MessageBox.Show(obj);
                    return;
                }
                else
                {
                    Web.Token = obj;
                    MessageBox.Show("Авторизация прошла успешно!");
                    Web.QueryGetSync<List<Client>>("Clients", 
                        Array.Empty<KeyValuePair<string, string>>(),
                        (ret) =>
                    {
                        MessageBox.Show($"Ret: {ret.Count}");
                    });
                }
            });
        }
    }
}