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

namespace Kalkulator
{
    public partial class MainWindow : Window
    {
        string operacja = "";
        double liczba1 = 0;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Numeric_Button_click(object sender, RoutedEventArgs e)
        {
            if(dol.Text=="0")
                dol.Text = (sender as Button).Content.ToString();
            else
            {
                dol.Text += (sender as Button).Content.ToString();

            }
        }

        private void textBox_dolny_TextChanged(object sender, TextChangedEventArgs e)
        {
          if(dol.LineCount>1)
            {
                dol.FontSize-=5;
            }

        }
        private void function_button_click(object sender, RoutedEventArgs e)
        {
            if((dol.Text=="") || (dol.Text == "-"))
            {
                if((dol.Text == ""))
                {
                    if ((sender as Button).Content.ToString() == "-")
                        dol.Text += (sender as Button).Content.ToString();
                }
                else
                {
                    if ((sender as Button).Content.ToString() == "-")
                        dol.Text = "";
                }
                
            }
            else
            {
                switch ((sender as Button).Content)
                {
                    case "+": gora.Text = dol.Text; liczba1=Double.Parse(gora.Text); dol.Text = ""; operacja = "+"; break;
                    case "-": gora.Text = dol.Text; liczba1 = Double.Parse(gora.Text); dol.Text = ""; operacja = "-"; break;
                    case "*": gora.Text = dol.Text; liczba1 = Double.Parse(gora.Text); dol.Text = ""; operacja = "*"; break;
                    case "/": gora.Text = dol.Text; liczba1 = Double.Parse(gora.Text); dol.Text = ""; operacja = "/"; break;
                    case "^": gora.Text = dol.Text; liczba1 = Double.Parse(gora.Text); dol.Text = ""; operacja = "^"; break;
                    default:
                        break;
                }
            }
        }

        private void oblicz_click(object sender, RoutedEventArgs e)
        {
            double wynik = 0;
            try
            {
                switch (operacja)
                {
                    case "+": wynik = liczba1 + Double.Parse(dol.Text); break;
                    case "-": wynik = liczba1 - Double.Parse(dol.Text); break;
                    case "*": wynik = liczba1 * Double.Parse(dol.Text); break;
                    case "/": wynik = liczba1 / Double.Parse(dol.Text); break;
                    case "^": wynik = Math.Pow(liczba1, Double.Parse(dol.Text)); break;

                    default:
                        break;
                }

                dol.Text = wynik.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd - " + ex.Message.ToString());
                
            }

        }

        private void change_sign(object sender, RoutedEventArgs e)
        {
            if (dol.Text[0] == '-')
                dol.Text = dol.Text.Replace("-","");
            else
                dol.Text = dol.Text.Insert(0, "-");

        }

        private void button_clear_click(object sender, RoutedEventArgs e)
        {
            dol.Text = "";
            gora.Text = "";
            liczba1 = 0;
        }

        private void button_Copy1_Click(object sender, RoutedEventArgs e)
        {
            if (dol.Text.Length > 0)
                dol.Text= dol.Text.Remove(dol.Text.Length-1, 1);
        }

        private void Przecinek_click(object sender, RoutedEventArgs e)
        {
            if (!dol.Text.Contains(","))
                dol.Text += ",";
        }
    }
}
