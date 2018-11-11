using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ToolbarPopBug
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void GolferModalNavigationOnClicked(object sender, EventArgs e)
        {
            GolferPage golferPage = new GolferPage();
            var page = golferPage;
            await this.Navigation.PushModalAsync(new NavigationPage(page));
        }
    }
}
