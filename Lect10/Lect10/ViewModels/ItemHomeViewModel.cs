using Lect10.Models;
using Lect10.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace Lect10.ViewModels
{
    public class ItemHomeViewModel
    {
        INavigation Navigation;
        public ObservableCollection<Item> Items { get; set; }= new ObservableCollection<Item>();
        public ItemHomeViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        public IAsyncCommand GetItemsCommand => new AsyncCommand(async () =>
        {
            var items = await App.Database.GetItemsAsync();
            Items.Clear();
            foreach(var item in items)
            {
                Items.Add(item);
            }
        }, allowsMultipleExecutions: false);

        public IAsyncCommand<Item> GoToItemDetailPageCommand => new AsyncCommand<Item>(async (item) =>
        {
            await Navigation.PushAsync(new ItemDetailPage(item));
        }, allowsMultipleExecutions: false);

        public IAsyncCommand<Item> DeleteItemCommand => new AsyncCommand<Item>(async (item) =>
        {
            if(await App.Current.MainPage.DisplayAlert("","Are you sure you want to delete?","Ok","Cancel"))
            {
                var count = await App.Database.DeleteItemAsync(item);
                if(count > 0)
                {
                    Items.Remove(item);
                }
            }
        }, allowsMultipleExecutions: false);
    }
}
