using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode.Videos.Streams;
using YoutubeExplode;
using System.Windows.Input;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;

namespace TubeTest
{
    public class MainViewModel : BindableObject
    {
        public ICommand PlayCommand => new Command(async () => await Task.Run(PlayVideo));

        private IEnumerable<MuxedStreamInfo> streamInfo;
        private const string baseYouTubeUrl = "https://www.youtube.com/watch?v=";
        private const string baseYouTubeMobileUrl = "https://m.youtube.com/watch?v=";

        private string vTubeSource;
        public string VTubeSource
        {
            get
            {
                return vTubeSource;
            }
            set
            {
                vTubeSource = value;
                OnPropertyChanged(nameof(VTubeSource));
            }
        }

        private string adress = "";
        public string Adress
        {
            get
            {
                return adress;
            }
            set
            {
                adress = value;
                OnPropertyChanged(nameof(Adress));
            }
        }

        private readonly IPopupService popupService;

        public MainViewModel(IPopupService popupService)
        {
            this.popupService = popupService;
        }

        private async Task PlayVideo()
        {
            var popup = new IndicatorPopup(new IndicatorViewModel());
            try
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    Application.Current.MainPage.ShowPopup(popup);
                });

                var youtube = new YoutubeClient();

                var videoUrl = adress.Contains(baseYouTubeUrl) || adress.Contains(baseYouTubeMobileUrl) ? adress : $"{baseYouTubeUrl}{adress}";

                var streamManifest = await youtube.Videos.Streams.GetManifestAsync(videoUrl);
                streamInfo = streamManifest.GetMuxedStreams();

                var vidoePlayerStream = streamInfo.First(video => video.VideoQuality.Label is "240p" or "360p" or "480p");
                VTubeSource = vidoePlayerStream.Url;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    popup.Close();
                });
            }
        }

    }
}
