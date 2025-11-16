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
                    lBarlangNev.Content = Program.barlangok[i].Nev;
                    tbxHossz.Text = Program.barlangok[i].Hossz.ToString();
                    tbxMely.Text = Program.barlangok[i].Melyseg.ToString();
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

        }


    }
}