using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Tietovisa
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class urheilu : Page

    {
        private MediaElement mediaElement;
        int score = 0;

        public urheilu()
        {
            this.InitializeComponent();
            InitAudio();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e) //Sivun latautuessa otetaan ensimmäinen kysymys näytille
        {
            Question1();
            num.Text = "1";
        }

        private async void InitAudio()
        {
            try
            {
                // äänet
                mediaElement = new MediaElement();
                StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
                StorageFile file = await folder.GetFileAsync("click2.wav");
                var stream = await file.OpenAsync(FileAccessMode.Read);
                mediaElement.AutoPlay = false;
                mediaElement.SetSource(stream, file.ContentType);

            }
            catch (System.IO.FileNotFoundException)
            {
                //Jos ääntä ei löydy ei sitä soiteta ollenkaan
            }
        }

        //Kysymykset
        private void Question1()
        {
            question.Text = "Mihin urheilulajiin kunnari liittyy?";
            answerbutton1.Content = "Koripalloon"; 
            answerbutton2.Content = "Pesäpalloon";  //oikea
            answerbutton3.Content = "Uppopalloon";
            answerbutton4.Content = "Jalkapalloon";
        }

        private void Question2()
        {
            question.Text = "Mikä on Ottawan NHL-joukkoeen nimi?";
            answerbutton1.Content = "Nordiques";
            answerbutton2.Content = "Canadiens"; 
            answerbutton3.Content = "Maple leafs";
            answerbutton4.Content = "Senators"; //oikea
        }

        private void Question3()
        {
            question.Text = "Minkä maalainen kilpa-autoilija on Daniil Kvjat?";
            answerbutton1.Content = "Tanskalainen";
            answerbutton2.Content = "Tsekkiläinen";
            answerbutton3.Content = "Venäläinen"; //oikea
            answerbutton4.Content = "Turkkilainen"; 
        }

        private void Question4()
        {
            question.Text = "Missä sijaitsee Kansainvälisen Olympiakomitean päämaja?";
            answerbutton1.Content = "Lyonissa"; 
            answerbutton2.Content = "Tukholmassa";
            answerbutton3.Content = "Lausanneessa"; //oikea
            answerbutton4.Content = "Dublinissa";
        }

        private void Question5()
        {
            question.Text = "Missä joukkoeessa jalkapalloilija Ronaldinho pelaa?";
            answerbutton1.Content = "Ac Milanissa";
            answerbutton2.Content = "Manchester United "; 
            answerbutton3.Content = "FC Barcelonassa";//Oikea
            answerbutton4.Content = "Ei missään ";
        }
        private void Question6()
        {
            question.Text = "Minkä värinen perinteinen tennis pallo on";
            answerbutton1.Content = "Vihreä";
            answerbutton2.Content = "Punainen";
            answerbutton3.Content = "Keltainen";//Oikea
            answerbutton4.Content = "Sininen";
        }
        private void Question7()
        {
            question.Text = "Mihin lajiin liittyy termi par?";
            answerbutton1.Content = "Golfiin";//Oikea
            answerbutton2.Content = "Jalkapalloon";
            answerbutton3.Content = "Koripalloon";
            answerbutton4.Content = "Pesäpalloon";
        }
        private void Question8() 
        {
            question.Text = "Mikä on taitoluistelun aikaisempi nimitys?";
            answerbutton1.Content = "Kainoluistelu";
            answerbutton2.Content = "Kaunoluistelu";//Oikea
            answerbutton3.Content = "Taideluistelu";
            answerbutton4.Content = "Taitajaluistelu";
        }
        private void Question9()
        {
            question.Text = "Mikä seuraavista on voimistelu liike?";
            answerbutton1.Content = "Spagaatti"; //Oikea
            answerbutton2.Content = "Spagetti";
            answerbutton3.Content = "Spillari";
            answerbutton4.Content = "Zumba";
        }
        private void Question10()
        {
            question.Text = "Mihin peliin räpylä kuuluu?";
            answerbutton1.Content = "Pesäpalloon"; //Oikea
            answerbutton2.Content = "Jääkiekkoon";
            answerbutton3.Content = "Tennikseen";
            answerbutton4.Content = "Sulkapalloon";
        }

        private void answerbutton1_Click(object sender, RoutedEventArgs e)
        {
            //Väärät vastaukset
            if ((num.Text == "1" || num.Text == "2" || num.Text == "3" || num.Text == "4" || num.Text == "5" || num.Text == "6" || num.Text == "8"))
            {
                Frame.Navigate(typeof(lose));
            }

            //Oikeat vastaukset
            if (num.Text == "7" || num.Text == "9" || num.Text == "10")
            {
                Next();
            }

        }

        private void answerbutton2_Click(object sender, RoutedEventArgs e)
        {

            //Väärät vastaukset
            if (num.Text == "2" || num.Text == "3" || num.Text == "4" || num.Text == "5" || num.Text == "6" || num.Text == "7" || num.Text == "9" || num.Text == "10")
            {
                Frame.Navigate(typeof(lose));
            }
            //Oikeat vastaukset
            if (num.Text == "1" || num.Text == "8")
            {
                Next();
            }
        }

        private void answerbutton3_Click(object sender, RoutedEventArgs e)
        {

            //Väärät vastaukset
            if ((num.Text == "1" || num.Text == "2" || num.Text == "7" || num.Text == "8" || num.Text == "9" || num.Text == "10"))
            {
                Frame.Navigate(typeof(lose));
            }

            //Oikeat vastaukset
            if (num.Text == "3" || num.Text == "4" || num.Text == "5" || num.Text == "6")
            {
                Next();
            }

        }

        private void answerbutton4_Click(object sender, RoutedEventArgs e)
        {

            //Väärät vastaukset
            if ((num.Text == "1" || num.Text == "3" || num.Text == "4" || num.Text == "5" || num.Text == "6" || num.Text == "7" || num.Text == "8" || num.Text == "9" || num.Text == "10"))
            {
                Frame.Navigate(typeof(lose));
            }

            //Oikeat vastaukset
            if (num.Text == "2")
            {
                Next();
            }


        }







        private void Next() //Pisteiden laskua + seuraavat kysymykset
        {
        
            answerbutton1.Visibility = Visibility.Visible; //kaikki nappulat  näkyville mikäli skippausta on käytetty
            answerbutton2.Visibility = Visibility.Visible;
            answerbutton3.Visibility = Visibility.Visible;
            answerbutton4.Visibility = Visibility.Visible;

            mediaElement.Play();
            score = score + 1;
            switch (score)
            {

                case 1:
                    num.Text = "2";
                    Question2();
                    break;
                case 2:
                    num.Text = "3";
                    Question3();
                    break;
                case 3:
                    num.Text = "4";
                    Question4();
                    break;
                case 4:
                    num.Text = "5";
                    Question5();
                    break;
                case 5:
                    num.Text = "6";
                    Question6();
                    break;
                case 6:
                    num.Text = "7";
                    Question7();
                    break;
                case 7:
                    num.Text = "8";
                    Question8();
                    break;
                case 8:
                    num.Text = "9";
                    Question9();
                    break;
                case 9:
                    num.Text = "10";
                    Question10();
                    break;
                case 10:
                    Frame.Navigate(typeof(win)); //Voitto ruutu
                    break;
            }


        }
        private void takaisinbutton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        //Poistaa kaksi väärää vastausta
        private void rembutton_Click(object sender, RoutedEventArgs e)
        {
            if (num.Text == "1")
            {
                answerbutton1.Visibility = Visibility.Collapsed;
                answerbutton3.Visibility = Visibility.Collapsed;
            }
            if (num.Text == "2")
            {
                answerbutton1.Visibility = Visibility.Collapsed;
                answerbutton2.Visibility = Visibility.Collapsed;
            }
            if (num.Text == "3")
            {
                answerbutton2.Visibility = Visibility.Collapsed;
                answerbutton1.Visibility = Visibility.Collapsed;
            }
            if (num.Text == "4")
            {
                answerbutton4.Visibility = Visibility.Collapsed;
                answerbutton2.Visibility = Visibility.Collapsed;
            }
            if (num.Text == "5")
            {
                answerbutton4.Visibility = Visibility.Collapsed;
                answerbutton1.Visibility = Visibility.Collapsed;
            }
            if (num.Text == "6")
            {
                answerbutton4.Visibility = Visibility.Collapsed;
                answerbutton2.Visibility = Visibility.Collapsed;
            }
            if (num.Text == "7")
            {
                answerbutton3.Visibility = Visibility.Collapsed;
                answerbutton2.Visibility = Visibility.Collapsed;
            }
            if (num.Text == "8")
            {
                answerbutton4.Visibility = Visibility.Collapsed;
                answerbutton3.Visibility = Visibility.Collapsed;
            }
            if (num.Text == "9")
            {
                answerbutton3.Visibility = Visibility.Collapsed;
                answerbutton2.Visibility = Visibility.Collapsed;
            }
            if (num.Text == "10")
            {
                answerbutton4.Visibility = Visibility.Collapsed;
                answerbutton2.Visibility = Visibility.Collapsed;
            }

            rembutton.Visibility = Visibility.Collapsed; //Vain kerran saa käyttää!!

        }
        //Hypää kysymyksen ohi
        private void skipbutton_Click(object sender, RoutedEventArgs e)
        {
            skipbutton.Visibility = Visibility.Collapsed; //Vain kerran saa käyttää!!
            Next();
        }

    }
}

    

