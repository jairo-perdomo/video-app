using System;
using System.Collections.Generic;
using System.Linq;
using PhotoApp.Models;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;

namespace PhotoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListVideoView : ContentPage
    {
        public List<Photo> AllVideos { get; set; }
        string pathSelectedVideo;
        public ListVideoView()
        {
            InitializeComponent();
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            chargeListView();
        }
        
        
        private async void chargeListView()
        {
            /* 
            var ListViewPersons = await App.BaseDatos.getListVideos();
            // Si la lista no esta vacia, cargar los elementos de ListViewPersons a listPersons que es un ListView que esta en el ShowPersons.xaml
            if (ListViewPersons != null)
            {
                listVideos.ItemsSource = ListViewPersons;
            }

            */
            AllVideos = await App.BaseDatos.getListVideos();
            ListVideos.ItemsSource = AllVideos;
        } 

         
        private async void SwipeItem_Invoked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ViewVideoSelected(pathSelectedVideo));
            pathSelectedVideo = null;
        } 

        /* 
        private async void listVideos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var videoSelected = (Photo)e.SelectedItem;

            if (videoSelected.code != 0)
            {
                var videoObtained = await App.BaseDatos.getVideoByCode(videoSelected.code);

                string pathVideoObtained = videoObtained.pathFile;
                await Navigation.PushAsync(new ViewVideoSelected(pathVideoObtained));
            }

        } */

        private void ListVideos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateSelectionData(e.PreviousSelection, e.CurrentSelection);
        }

        private void UpdateSelectionData(IEnumerable<object> previousSelectedContact, IEnumerable<object> currentSelectedContact)
        {
            var selectedContact = currentSelectedContact.FirstOrDefault() as Photo;
            // await DisplayAlert("Titulo", "Ruta Seleccionada:" + selectedContact.pathFile, "OK");
            pathSelectedVideo = selectedContact.pathFile;
            Console.WriteLine(pathSelectedVideo); 
            /* Debug.WriteLine("FullName: " + selectedContact.name);
            Debug.WriteLine("Email: " + selectedContact.descripcion);
            Debug.WriteLine("Phone: " + selectedContact.Phone);
            Debug.WriteLine("Country: " + selectedContact.Country); */
        }
    }
}