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
    public sealed partial class lose : Page
    {
        private MediaElement mediaElement, mediaElement2;

        public lose()
        {
            this.InitializeComponent();
            InitAudio();
        }

        private async void InitAudio()
        {
            // äänet
            try
            {
                mediaElement = new MediaElement();
            StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
            StorageFile file = await folder.GetFileAsync("lose.wav");
            var stream = await file.OpenAsync(FileAccessMode.Read);
            mediaElement.AutoPlay = true;
            mediaElement.SetSource(stream, file.ContentType);
            }
            catch (System.IO.FileNotFoundException)
            {     //Jos ääntä ei löydy ei sitä soiteta ollenkaan
            }
            try
            {
                mediaElement2 = new MediaElement();
            StorageFolder folder2 = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
            StorageFile file2 = await folder2.GetFileAsync("click1.wav");
            var stream2 = await file2.OpenAsync(FileAccessMode.Read);
            mediaElement2.AutoPlay = false;
            mediaElement2.SetSource(stream2, file2.ContentType);
            }
            catch (System.IO.FileNotFoundException)
            {
                //Jos ääntä ei löydy ei sitä soiteta ollenkaan
            }
        }

        private void buttonback_Click(object sender, RoutedEventArgs e)
        {
            mediaElement2.Play();
            if (this.Frame != null && this.Frame.CanGoBack) this.Frame.GoBack();
        }

        private void buttonmenu_Click(object sender, RoutedEventArgs e)
        {
            mediaElement2.Play();
            Frame.Navigate(typeof(MainPage));
        }


    }
}
