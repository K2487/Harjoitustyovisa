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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Tietovisa
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private MediaElement mediaElement, mediaElement2;
        public MainPage()
        {
            this.InitializeComponent();
            InitAudio();
        }

        private async void InitAudio()
        {
            try
            {
                // äänet
                mediaElement = new MediaElement();
            StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
            StorageFile file = await folder.GetFileAsync("click1.wav");
            var stream = await file.OpenAsync(FileAccessMode.Read);
            mediaElement.AutoPlay = false;
            mediaElement.SetSource(stream, file.ContentType);

            mediaElement2 = new MediaElement();
            StorageFolder folder2 = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
            StorageFile file2 = await folder.GetFileAsync("musik.wav");
            var stream2 = await file2.OpenAsync(FileAccessMode.Read);
            mediaElement2.AutoPlay = true;
            mediaElement2.IsLooping = true;
            mediaElement2.SetSource(stream2, file2.ContentType);
            }
            catch (System.IO.FileNotFoundException)
            {
                //Jos ääntä ei löydy ei sitä soiteta ollenkaan
            }
        }

        //Navigointi painikkeet kategorioille
        private void button2_Click_1(object sender, RoutedEventArgs e)
        {
            mediaElement.Play();
            Frame.Navigate(typeof(maantieto));
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Play();
            Frame.Navigate(typeof(urheilu));
        }


        private void button3_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Play();
            Frame.Navigate(typeof(ruoka));
        }
    }
}
