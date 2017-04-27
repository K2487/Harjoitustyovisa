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
    public sealed partial class ruoka : Page
    {
        private MediaElement mediaElement;
        int score = 0;
        public ruoka()
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
            question.Text = "Mikä omena on?";
            answerbutton1.Content = "Hedelmä"; //Oikea
            answerbutton2.Content = "Juures";  
            answerbutton3.Content = "Marja";
            answerbutton4.Content = "Salaattikasvi";
        }

        private void Question2()
        {
            question.Text = "Suomen myydyin lenkkimakkara on:";
            answerbutton1.Content = "Atrian punainen";
            answerbutton2.Content = "HK:n kevyt sininen";
            answerbutton3.Content = "Atrian uunilenkki";
            answerbutton4.Content = "HK:n sininen"; //oikea
        }

        private void Question3()
        {
            question.Text = "Mikä seuraavista kuuluu moussakaan?";
            answerbutton1.Content = "Kirsikka";
            answerbutton2.Content = "Munakoiso"; //oikea
            answerbutton3.Content = "Kaali"; 
            answerbutton4.Content = "Kurpitsa";
        }

        private void Question4()
        {
            question.Text = "Mitä muistuttaa kuskus?";
            answerbutton1.Content = "Mannaryynejä"; //Oikea
            answerbutton2.Content = "Lihaliemikuutiota";
            answerbutton3.Content = "Vehnäleseitä"; 
            answerbutton4.Content = "Suolaa";
        }

        private void Question5()
        {
            question.Text = "Mistä wakame-merilevä on kotoisin?";
            answerbutton1.Content = "Grönlannista";
            answerbutton2.Content = "Amerikasta";
            answerbutton3.Content = "Japanista";//Oikea
            answerbutton4.Content = "Kreikan saaristosta";
        }
        private void Question6()
        {
            question.Text = "Mistä maasta pita leipä on kotoisin?";
            answerbutton1.Content = "Amerikasta";
            answerbutton2.Content = "Puolasta";
            answerbutton3.Content = "Kreikasta";//Oikea
            answerbutton4.Content = "Turkista";
        }
        private void Question7()
        {
            question.Text = "Minkä nimistä juustoa perinteisesti laitetaan pizzaan?";
            answerbutton1.Content = "Mozzarellaa";//Oikea
            answerbutton2.Content = "Feta";
            answerbutton3.Content = "Emmentalia";
            answerbutton4.Content = "Parmesania";
        }
        private void Question8()
        {
            question.Text = "Mikä seuraavista on energia juoma?";
            answerbutton1.Content = "Fanta";
            answerbutton2.Content = "Coca Cola";
            answerbutton3.Content = "Red Bull";//Oikea
            answerbutton4.Content = "Sprite";
        }
        private void Question9()
        {
            question.Text = "Kuuluisa Irlantilainen olut on nimeltään";
            answerbutton1.Content = "Heineken";
            answerbutton2.Content = "Cruzcampo";
            answerbutton3.Content = "Korona";
            answerbutton4.Content = "Guiness";//Oikea
        }
        private void Question10()
        {
            question.Text = "Mistä maasta mojito on lähtöisin?";
            answerbutton1.Content = "Kuubasta"; //Oikea
            answerbutton2.Content = "Amerikasta";
            answerbutton3.Content = "Japanista";
            answerbutton4.Content = "Hawajilta";
        }


        private void answerbutton1_Click(object sender, RoutedEventArgs e)
        {
            //Väärät vastaukset
            if ((num.Text == "2" || num.Text == "3" || num.Text == "5" || num.Text == "6" || num.Text == "8" || num.Text == "9"))
            {
                Frame.Navigate(typeof(lose));
            }

            //Oikeat vastaukset
            if (num.Text == "1" || num.Text == "4" || num.Text == "7" || num.Text == "10")
            {
                Next();
            }

        }

        private void answerbutton2_Click(object sender, RoutedEventArgs e)
        {

            //Väärät vastaukset
            if (num.Text == "1" || num.Text == "2" || num.Text == "4" || num.Text == "5" || num.Text == "6" || num.Text == "7" || num.Text == "8" || num.Text == "9" || num.Text == "10")
            {
                Frame.Navigate(typeof(lose));
            }
            //Oikeat vastaukset
            if (num.Text == "3")
            {
                Next();
            }
        }

        private void answerbutton3_Click(object sender, RoutedEventArgs e)
        {

            //Väärät vastaukset
            if ((num.Text == "1" || num.Text == "2" || num.Text == "3" || num.Text == "4" || num.Text == "7" || num.Text == "9" || num.Text == "10"))
            {
                Frame.Navigate(typeof(lose));
            }

            //Oikeat vastaukset
            if (num.Text == "5" || num.Text == "6" || num.Text == "8")
            {
                Next();
            }

        }

        private void answerbutton4_Click(object sender, RoutedEventArgs e)
        {

            //Väärät vastaukset
            if ((num.Text == "1" || num.Text == "3" || num.Text == "4" || num.Text == "5" || num.Text == "6" || num.Text == "7" || num.Text == "8" || num.Text == "10"))
            {
                Frame.Navigate(typeof(lose));
            }

            //Oikeat vastaukset
            if (num.Text == "2" || num.Text == "9")
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
                answerbutton2.Visibility = Visibility.Collapsed;
                answerbutton3.Visibility = Visibility.Collapsed;
            }
            if (num.Text == "3")
            {
                answerbutton4.Visibility = Visibility.Collapsed;
                answerbutton3.Visibility = Visibility.Collapsed;
            }
            if (num.Text == "4")
            {
                answerbutton4.Visibility = Visibility.Collapsed;
                answerbutton3.Visibility = Visibility.Collapsed;
            }
            if (num.Text == "5")
            {
                answerbutton1.Visibility = Visibility.Collapsed;
                answerbutton2.Visibility = Visibility.Collapsed;
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
                answerbutton2.Visibility = Visibility.Collapsed;
            }
            if (num.Text == "9")
            {
                answerbutton3.Visibility = Visibility.Collapsed;
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