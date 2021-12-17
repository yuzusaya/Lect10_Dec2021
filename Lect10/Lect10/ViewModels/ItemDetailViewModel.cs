using Lect10.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace Lect10.ViewModels
{
    public class ItemDetailViewModel
    {
        INavigation Navigation;
        public Item CurrentItem { get; set; } = new Item();
        public ItemDetailViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }

        public ItemDetailViewModel(INavigation navigation,Item item)
        {
            CurrentItem = item;
            Navigation = navigation;
        }


        public IAsyncCommand SaveCommand => new AsyncCommand(async () =>
        {
            var count = await App.Database.AddOrUpdateItemAsync(CurrentItem);
            if(count == 0)
            {
                await App.Current.MainPage.DisplayAlert("", "Failed to save!", "Ok");
            }
            else
            {
                await Navigation.PopAsync();
            }
        }, allowsMultipleExecutions: false);
    }
}
