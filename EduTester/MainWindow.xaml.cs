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

namespace EduTester
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Matematyka MTester= new Matematyka(20, 20, 10);

        public MainWindow()
        {
            InitializeComponent();
            DataContext = MTester;

        }

        private void Result_KeyDown(object sender, KeyEventArgs e)
        {
            String wynik = Result.Text;
            bool Rezultat = false;
            if (e.Key == Key.Return)
            {
                Rezultat=MTester.ZadanieCheck(Convert.ToInt32(wynik));
                if (Rezultat)
                {
                    Result.Text = "";
                   
                    MessageBox.Show("Zdobyłeś kolejny punkt!");
                }
                else
                {
                    MessageBox.Show("Zła odpowiedź! Nowe Zadanie");
                    Result.Text = "";
                }
                if (MTester.EndOfTestCheck())
                {

                }
                else MTester.Losuj();
            }
            

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MTester.Losuj();
            //Num1.Content = Matematyka.AktLiczby.A;
            // Num2.Content = Matematyka.AktLiczby.B;
            Result.Text = "";
            if (Matematyka.bDodawanie) Sign.Content = "+";
            else Sign.Content = "-";
        }
    }

 
}
