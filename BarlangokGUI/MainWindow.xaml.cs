using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Barlangok;

namespace BarlangokGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static int barlangDB;
        static Barlang kivalasztottBarlang;
        public MainWindow()
        {
            InitializeComponent();
            barlangDB = Program.Feladat3("barlangok.txt");

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (tbxAzon.Text != "")
            {
                int i = 0;
                while (i < barlangDB && Program.barlangok[i].Azon != int.Parse(tbxAzon.Text))
                {
                    i++;
                }

                if (i < barlangDB)
                {
                    kivalasztottBarlang = Program.barlangok[i];
                    lBarlangNev.Content = kivalasztottBarlang.Nev;
                    tbxHossz.Text = kivalasztottBarlang.Hossz.ToString();
                    tbxMely.Text = kivalasztottBarlang.Melyseg.ToString();
                    bMentes.IsEnabled = true;
                }
                else
                {
                    MessageBox.Show("Ezzel az azonosítóval nem létezik barlang!");
                    tbxAzon.Text = "";
                    lBarlangNev.Content = "";
                    tbxHossz.Text = "";
                    tbxMely.Text = "";
                }
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (int.Parse(tbxHossz.Text) < kivalasztottBarlang.Hossz)
            {
                MessageBox.Show("A hossz nem lehet kisebb a korábbi értéknél!");
                tbxAzon.Text = "";
                lBarlangNev.Content = "";
                tbxHossz.Text = "";
                tbxMely.Text = "";
            }
            else if (int.Parse(tbxMely.Text) < kivalasztottBarlang.Melyseg)
            {
                MessageBox.Show("A mélység nem lehet kisebb a korábbi értéknél!");
                tbxAzon.Text = "";
                lBarlangNev.Content = "";
                tbxHossz.Text = "";
                tbxMely.Text = "";
            }
            else 
            { 
                kivalasztottBarlang.Hossz = int.Parse(tbxHossz.Text);
                kivalasztottBarlang.Melyseg = int.Parse(tbxMely.Text);
                bFelvitel.IsEnabled = true;
            }


        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string solutionRoot = System.IO.Path.GetFullPath(System.IO.Path.Combine(baseDir, @"..\..\..\..\"));
            string mappa = "Barlangok";              
            string fajlNeve = "barlangok.txt";


            string teljesUtvonal = System.IO.Path.Combine(
                solutionRoot,
                mappa,
                fajlNeve
            );

            using (StreamWriter sr = new StreamWriter(teljesUtvonal))
            {
                sr.WriteLine("azon;nev;hossz;melyseg;telepules;vedettseg");
                for (int i = 0; i < barlangDB; i++)
                {
                    Barlang barlang = Program.barlangok[i];
                    sr.WriteLine($"{barlang.Azon};{barlang.Nev};{barlang.Hossz};{barlang.Melyseg};{barlang.Telepules};{barlang.Vedettseg}");
                }
                

            }
            bFelvitel.IsEnabled = false;
            bMentes.IsEnabled = false;

        }


    }
}