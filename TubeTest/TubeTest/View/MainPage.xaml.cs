using YoutubeExplode;
using YoutubeExplode.Videos.Streams;
using System.Linq;
using TubeTest.ViewModel;
using CommunityToolkit.Mvvm.Messaging;
using TubeTest.Messages;

namespace TubeTest
{
    public partial class MainPage : ContentPage
    {
       
        public MainPage(MainViewModel bindingContext)
        {
            InitializeComponent();
            BindingContext = bindingContext;
            DeviceDisplay.Current.MainDisplayInfoChanged += Current_MainDisplayInfoChanged;

            // Register a message in some module
            WeakReferenceMessenger.Default.Register<MediaPlayerMessage>(this, (r, m) =>
            {
                if (m.Value.Play)
                {
                    VideoPlayer.Play();
                }
                else
                {
                    VideoPlayer.Pause();
                }
            });
        }

        private void Current_MainDisplayInfoChanged(object? sender, DisplayInfoChangedEventArgs e)
        {
            switch (e.DisplayInfo.Orientation)
            {
                case DisplayOrientation.Landscape:
                    SearchBar.HeightRequest = 0;
                    break;
                case DisplayOrientation.Portrait:
                case DisplayOrientation.Unknown:
                    SearchBar.HeightRequest = 50;
                    break;

            }
        }

        private void ContentPage_Unloaded(object sender, EventArgs e)
        {
            // Stop and cleanup MediaElement when we navigate away
            VideoPlayer.Handler?.DisconnectHandler();
        }
    }

}
