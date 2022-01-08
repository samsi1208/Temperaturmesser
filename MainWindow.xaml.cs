using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace MaxTemp
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void BtnAuswerten_Click(object sender, RoutedEventArgs e)
        {




            FileStream fs = File.Open(@"temps.csv", FileMode.Open); //Die Datei wird geöffnet
            StreamReader sr = new StreamReader(fs); //Die Datei wird gelesen


            string variable_k = sr.ReadLine(); //Linie kann ausgelesen werden
            string[] variable_k1 = variable_k.Split(','); //Linie wird gesplittet (3 Teile)
            string temp_vergleich_string_k = variable_k1[2].Replace(".", ",");  //Mit "zeile" wird nun nur der 3te Teil ausgelesen
            double temp_vergleich_k = Convert.ToDouble(temp_vergleich_string_k);


            double temp_vergleich_g;
            temp_vergleich_g = temp_vergleich_k;

            int anzahl = 0;

            double alles = 0;


            while (sr.EndOfStream == false) //Mit dieser while-Schleife, wird die Datei Zeile für Zeile bis zum Ende des Streams ausgelesen
            {
                //zahl auslesen
                string line = sr.ReadLine(); //Linie kann ausgelesen werden
                string[] nowline = line.Split(','); //Linie wird gesplittet (3 Teile)
                string temp_string = nowline[2].Replace(".", ",");  //Mit "temp" wird nun nur der 3te Teil ausgelesen
                double temp = Convert.ToDouble(temp_string); //temp ist nun eine Zahl


                if (temp < temp_vergleich_k) //Wenn die temp kleiner als die temp_vergleich ist, dann...
                {
                    temp_vergleich_k = temp;     //... soll temp_vergleich zu temp werden, sodass der Wert von temp das neue temp_vergleich ist. 
                }




                if (temp > temp_vergleich_g) //Wenn die temp größer als die temp_vergleich ist, dann...
                {
                    temp_vergleich_g = temp; //... soll temp_vergleich zu temp werden, sodass der Wert von temp das neue temp_vergleich ist. 
                }





                anzahl = anzahl + 1;

                alles = alles + temp;

            }

            double durschnitt = alles / anzahl;
            durschnitt = Math.Round(durschnitt, 2);

            string durschnittTemp = Convert.ToString(durschnitt);
            string kleinsteTemp = Convert.ToString(temp_vergleich_k);
            string größteTemp = Convert.ToString(temp_vergleich_g);

            MessageBox.Show(kleinsteTemp, "Kleinste Temperatur: ");
            MessageBox.Show(größteTemp, "Größte Temperatatur: ");
            MessageBox.Show(durschnittTemp, "Durschnitt Temperatatur: ");

            fs.Close();
            sr.Close();





        }


    }
}
