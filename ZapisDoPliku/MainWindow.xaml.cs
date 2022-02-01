using System;
using System.Collections.Generic;
using System.IO;
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

namespace ZapisDoPliku
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BT_Zapisz_Click(object sender, RoutedEventArgs e)
        {
            string tekst = TB_PoleTekstowe.Text;
            string sciezka = TB_Sciezka.Text;
           
            if(sciezka != string.Empty)
            {                
                ZapiszDo(tekst, sciezka);
                //komunikat
                MessageBox.Show($"Zapisano do: {sciezka}");
                //czyszczenie
                CzyszczeniePol();
            }
            else
            {
                MessageBox.Show("Sciezka nie może być pusta");
            }
            
        }

        private void ZapiszDo(string tekst,string sciezkaDoPliku)
        {
            StreamWriter sw = new StreamWriter(sciezkaDoPliku);
            sw.Write(tekst);
            sw.Close();
        }

        private void BT_Reset_Click(object sender, RoutedEventArgs e)
        {
            CzyszczeniePol();
        }

        private void CzyszczeniePol()
        {
            TB_PoleTekstowe.Text = string.Empty;
            TB_Sciezka.Text = string.Empty;
        }
        private string WczytajPlik()
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "Document"; // Default file name
            dialog.DefaultExt = ".txt"; // Default file extension
            dialog.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension
            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                // Open document
                string filename = dialog.FileName;               
                return filename;
            }
           
            return null;
        }

        private void BT_Wczytaj_Click(object sender, RoutedEventArgs e)
        {            
            string sciezka = WczytajPlik();
            if(sciezka != null)
            {
                TB_Sciezka.Text = sciezka;
                PokazZawrtosc(sciezka);
            }
        }
        private void PokazZawrtosc(string pathFile)
        {
            StreamReader a = new StreamReader(pathFile);
            var tekst = a.ReadToEnd();
            TB_PoleTekstowe.Text = tekst;

        }
    }
}
