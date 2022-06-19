using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Hearthfire
{
    /// <summary>
    /// Interaction logic for InitWindow.xaml
    /// </summary>
    public partial class InitWindow : Window
    {
        private App _app;

        public InitWindow(App app)
        {
            InitializeComponent();
            _app = app;
        }

        private void Hvorostovsky_Click(object sender, RoutedEventArgs e)
        {
            _app.ToMainWindow("Hvorostovsky");
        }

        private void Zavrel_Click(object sender, RoutedEventArgs e)
        {
            _app.ToMainWindow("Zavrel");

        }
    }
}
