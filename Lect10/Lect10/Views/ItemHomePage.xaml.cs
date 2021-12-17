using Lect10.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lect10.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemHomePage : ContentPage
    {
        ItemHomeViewModel ViewModel;
        public ItemHomePage()
        {
            InitializeComponent();
            BindingContext = ViewModel = new ItemHomeViewModel(Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel?.GetItemsCommand.ExecuteAsync();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ItemDetailPage());
        }
    }
}