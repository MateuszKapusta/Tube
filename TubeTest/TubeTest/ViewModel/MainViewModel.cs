﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode.Videos.Streams;
using YoutubeExplode;
using System.Windows.Input;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using TubeTest.Services.NativeProcess;

namespace TubeTest.ViewModel
{
    public class MainViewModel : BindableObject
    {
        public ICommand PlayCommand => new Command(async () => await Task.Run(PlayVideo));

        public ICommand AppearingCommand => new Command(OnAppearing);

        public ICommand DisappearingCommand => new Command(OnDisappearing);

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
        private readonly INativeProcessService nativeProcessService;

        public MainViewModel(
            IPopupService popupService
            , INativeProcessService nativeProcessService)
        {
            this.popupService = popupService;
            this.nativeProcessService = nativeProcessService;
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

                nativeProcessService.StartProcess(typeof(MediaElement), Constants.ACTION_START_SERVICE);
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


        private void OnDisappearing()
        {
            //nativeProcessService.StartProcess(typeof(MediaElement), Constants.ACTION_START_SERVICE);
        }

        private void OnAppearing()
        {
            //nativeProcessService.StopProcess(typeof(MediaElement), Constants.ACTION_STOP_SERVICE);
        }
    }
}
