using System;
using System.Collections.Generic;
using System.Linq;
using PhotoApp.Models;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhotoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListVideoView : ContentPage
    {

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

            var ListViewPersons = await App.BaseDatos.getListVideos();
            // Si la lista no esta vacia, cargar los elementos de ListViewPersons a listPersons que es un ListView que esta en el ShowPersons.xaml
            if (ListViewPersons != null)
            {
                listVideos.ItemsSource = ListViewPersons;
            }
        }
        private async void SwipeItem_Invoked(object sender, EventArgs e)
        {
            // var label = Grid.Children.OfType<Label>().FirstOrDefault();
            
            await Navigation.PushAsync(new ViewVideoSelected());
        }
        
    }
}