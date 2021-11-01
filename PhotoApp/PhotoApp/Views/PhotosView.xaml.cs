using Plugin.Media;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhotoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PhotosView : ContentPage
    {
        public PhotosView()
        {
            InitializeComponent();
            btnfoto.Clicked += Btnfoto_Clicked;
            btnvideo.Clicked += Btnvideo_Clicked;
        }

        private async void Btnfoto_Clicked(object sender, EventArgs e)
        {
            try
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("No hay camara", "No se deteca la camara.", "Ok");
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                
                {
                    // Variable para guardar la foto en el album público
                    SaveToAlbum = true
                });

                if (file == null)
                    return;

                this.imgcamara.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    return stream;
                });

                await DisplayAlert("Foto realizada", "Localización: " + file.AlbumPath, "Ok");

            }
            catch (Exception ex)
            {
                await DisplayAlert("Permiso denegado", "Da permisos de cámara al dispositivo.\nError: " + ex.Message, "Ok");
            }
        }

        private async void Btnvideo_Clicked(object sender, EventArgs e)
        {
            try
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("No hay camara", "No se deteca la camara.", "Ok");
                    return;
                }

                var file = await CrossMedia.Current.TakeVideoAsync(new Plugin.Media.Abstractions.StoreVideoOptions
                {
                    Name = "video.mp4",
                    Directory = "DefaultVideos",
                });

                if (file == null)
                    return;

                await DisplayAlert("Video Recorded", "Location: " + file.Path, "OK");

                file.Dispose();

            }
            catch (Exception ex)
            {
                await DisplayAlert("Permiso denegado", "Da permisos de cámara al dispositivo.\nError: " + ex.Message, "Ok");
            }
        }

    }
}