using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ToolbarPopBug2Crash
{
    public class GolferPage : ContentPage
    {
        public GolferPage()
        {
            Label label = new Label();
            label.Text = "Using either Done button causes a crash in iOS 8.1, but not in the latest iOS.  " +
                "However using Xamarin Forms v2.3.4.270 will NOT cause a crash.";

            Button buttonDone = new Button();
            buttonDone.Text = "Done";
            buttonDone.Clicked += async (sender, e) => await DoneAsync();

            AddDoneButton();

            StackLayout stackLayout = new StackLayout
            {
                VerticalOptions = LayoutOptions.StartAndExpand,
                Padding = new Thickness(20),
                Children = {
                    label,
                    buttonDone
                }
            };

            Content = new ScrollView
            {
                Content = stackLayout
            };
        }

        public void AddDoneButton()
        {
            var btnDone = new ToolbarItem
            {
                Text = "Done",
                Priority = 0
            };

            btnDone.Clicked += async (sender, e) => await DoneAsync();
            ToolbarItems.Add(btnDone);
        }

        protected async Task<Page> DoneAsync()
        {
            return await Navigation.PopModalAsync();
        }
    }
}
