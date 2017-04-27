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
    public sealed partial class maantieto : Page
    {
        private MediaElement mediaElement;
        int score = 0;

        public maantieto()
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
            // äänet
            try
            {
                mediaElement = new MediaElement();
                StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
                StorageFile file = await folder.GetFileAsync("click2.wav");
                var stream = await file.OpenAsync(FileAccessMode.Read);
                mediaElement.AutoPlay = false;
                mediaElement.SetSource(stream, file.ContentType);
            }
            catch(System.IO.FileNotFoundException)
            {
   //Jos ääntä ei löydy ei sitä soiteta ollenkaan
            }
        }

        //Kysymykset
        private void Question1()
        {
            question.Text = "Missä maanosassa Islanti sijaitsee?";
            answerbutton1.Content = "Euroopassa"; //oikea
            answerbutton2.Content = "Africassa";
            answerbutton3.Content = "Etelä-Amerikassa";
            answerbutton4.Content = "Pohjois-Amerikassa";
        }

        private void Question2()
        {
            question.Text = "Mikä on Alankomaiden pääkaupunki?";
            answerbutton1.Content = "Praha";
            answerbutton2.Content = "Amsterdam"; //oikea
            answerbutton3.Content = "Helsinki";
            answerbutton4.Content = "Rotterdam";
        }

        private void Question3()
        {
            question.Text = "Mikä seuraavista ei ole saarivaltio?";
            answerbutton1.Content = "Kuuba";
            answerbutton2.Content = "Jamaika";
            answerbutton3.Content = "Japani";
            answerbutton4.Content = "Kiina"; //oikea
        }

        private void Question4()
        {
            question.Text = "Kuinka monta rajanaapuria Mongolialla on?";
            answerbutton1.Content = "2"; //oikea
            answerbutton2.Content = "3";
            answerbutton3.Content = "4";
            answerbutton4.Content = "0";
        }

        private void Question5()
        {
            question.Text = "Mille valtiolle Tasmania kuuluu?";
            answerbutton1.Content = "Ranskalle";
            answerbutton2.Content = "Australialle"; //Oikea
            answerbutton3.Content = "Venäjälle";
            answerbutton4.Content = "Espanjalle";
        }
        private void Question6()
        {
            question.Text = "Mikä on Espanjan pääkaupunki?";
            answerbutton1.Content = "Amsterdam";
            answerbutton2.Content = "Berliini";
            answerbutton3.Content = "Madrid";//Oikea
            answerbutton4.Content = "Barcelona";
        }
        private void Question7()
        {
            question.Text = "Mikä seuraavista maista ei ole Eurooppassa";
            answerbutton1.Content = "Ranska";
            answerbutton2.Content = "Turkki";
            answerbutton3.Content = "Saksa";
            answerbutton4.Content = "Iso Britannia";//Oikea
        }
        private void Question8()
        {
            question.Text = "Kuinka monta osavaltiota Pohjois Amerikassa on";
            answerbutton1.Content = "21";
            answerbutton2.Content = "22";
            answerbutton3.Content = "23";//Oikea
            answerbutton4.Content = "19";
        }
        private void Question9()
        {
            question.Text = "Minkä maan pääkaupunki on Tokio";
            answerbutton1.Content = "Kiinan";
            answerbutton2.Content = "Saksan";
            answerbutton3.Content = "Japanin"; //Oikea
            answerbutton4.Content = "Thaimaan";
        }
        private void Question10()
        {
            question.Text = "Montako maataa kuuluu pohjoismaihin";
            answerbutton1.Content = "7";
            answerbutton2.Content = "4";
            answerbutton3.Content = "5"; //Oikea
            answerbutton4.Content = "6";
        }
        private void answerbutton1_Click(object sender, RoutedEventArgs e)
        {
            //Väärät vastaukset
            if ((num.Text == "2" || num.Text == "3" || num.Text == "5" || num.Text == "6" || num.Text == "7" || num.Text == "8" || num.Text == "9" || num.Text == "10"))
            {
                Frame.Navigate(typeof(lose));
            }

            //Oikeat vastaukset
            if (num.Text == "1")
            {
                Next();
            }
            if (num.Text == "4")
            {
                Next();
            }

        }

        private void answerbutton2_Click(object sender, RoutedEventArgs e)
        {

            //Väärät vastaukset
            if (num.Text == "1" || num.Text == "3" || num.Text == "4" || num.Text == "6" || num.Text == "7" || num.Text == "8" || num.Text == "9" || num.Text == "10")
            {
                Frame.Navigate(typeof(lose));
            }
            //Oikeat vastaukset
            if (num.Text == "2" || num.Text == "5")
            {
                Next();
            }
        }

        private void answerbutton3_Click(object sender, RoutedEventArgs e)
        {

            //Väärät vastaukset
            if ((num.Text == "1" || num.Text == "2" || num.Text == "3" || num.Text == "4" || num.Text == "5" || num.Text == "7"))
            {
                Frame.Navigate(typeof(lose));
            }
            //Oikeat vastaukset
            if (num.Text == "3" || num.Text == "6" || num.Text == "8" || num.Text == "9" || num.Text == "10")
            {
                Next();
            }
        }

        private void answerbutton4_Click(object sender, RoutedEventArgs e)
        {

            //Väärät vastaukset
            if ((num.Text == "1" || num.Text == "2" || num.Text == "4" || num.Text == "5" || num.Text == "6" || num.Text == "8" || num.Text == "9" || num.Text == "10"))
            {
                Frame.Navigate(typeof(lose));
            }

            //Oikeat vastaukset
            if (num.Text == "3" || num.Text == "7")
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
                answerbutton2.Visibility = Visibility.Collapsed;
                answerbutton3.Visibility = Visibility.Collapsed;
            }
            if (num.Text == "2")
            {
                answerbutton1.Visibility = Visibility.Collapsed;
                answerbutton4.Visibility = Visibility.Collapsed;
            }
            if (num.Text == "3")
            {
                answerbutton2.Visibility = Visibility.Collapsed;
                answerbutton3.Visibility = Visibility.Collapsed;
            }
            if (num.Text == "4")
            {
                answerbutton4.Visibility = Visibility.Collapsed;
                answerbutton3.Visibility = Visibility.Collapsed;
            }
            if (num.Text == "5")
            {
                answerbutton4.Visibility = Visibility.Collapsed;
                answerbutton3.Visibility = Visibility.Collapsed;
            }
            if (num.Text == "6")
            {
                answerbutton1.Visibility = Visibility.Collapsed;
                answerbutton2.Visibility = Visibility.Collapsed;
            }
            if (num.Text == "7")
            {
                answerbutton1.Visibility = Visibility.Collapsed;
                answerbutton2.Visibility = Visibility.Collapsed;
            }
            if (num.Text == "8")
            {
                answerbutton1.Visibility = Visibility.Collapsed;
                answerbutton2.Visibility = Visibility.Collapsed;
            }
            if (num.Text == "9")
            {
                answerbutton4.Visibility = Visibility.Collapsed;
                answerbutton2.Visibility = Visibility.Collapsed;
            }
            if (num.Text == "10")
            {
                answerbutton1.Visibility = Visibility.Collapsed;
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

