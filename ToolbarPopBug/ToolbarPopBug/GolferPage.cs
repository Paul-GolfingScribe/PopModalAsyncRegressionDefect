using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ToolbarPopBug
{
    public class GolferPage : ContentPage
    {
        public GolferPage()
        {
            Label label = new Label();
            label.Text = "Using either Done button, using Xamarin Forms v2.3.4.270, does not cause a crash in iOS 8.1  " +
                "However upgrading to the current Xamarin Forms will then cause a crash.";
                
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
