using Plugin.Media;
using System;
using Xamarin.Forms;
using PhotoApp.Models;
using Xamarin.Forms.Xaml;
using SQLite;
using System.IO;

namespace PhotoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PhotosView : ContentPage
    {
        string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PM02VideoApp.db3");
        string rutaDeVideo;
        public PhotosView()
        {
            InitializeComponent();
            btnvideo.Clicked += Btnvideo_Clicked;
        }

        private async void Btnvideo_Clicked(object sender, EventArgs e)
        {
            try
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("No hay camara", "No se detecta la camara.", "Ok");
                    return;
                }

                var file = await CrossMedia.Current.TakeVideoAsync(new Plugin.Media.Abstractions.StoreVideoOptions
                {
                    Name = "video.mp4",
                    Directory = "DefaultVideos",
                });

                if (file == null)
                    return;

                await DisplayAlert("Video grabado", "Ubicacion: " + file.Path, "OK");
                rutaDeVideo = file.Path;
                file.Dispose();

            }
            catch (Exception ex)
            {
                await DisplayAlert("Permiso denegado", "Da permisos de cámara al dispositivo.\nError: " + ex.Message, "Ok");
            }
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteAsyncConnection(dbPath);

            var video = new Photo
            {
                name = txtName.Text,
                description = txtDescription.Text,
                pathFile = rutaDeVideo
            };

            var result = await App.BaseDatos.saveVideo(video);
            if(result == 1)
            {
                await DisplayAlert("Grabacion", "Video guardado correctamente", "OK");
                await Navigation.PopAsync();
            }
        }
    }
}