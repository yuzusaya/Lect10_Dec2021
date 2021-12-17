using Lect10.Models;
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
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel(Navigation);
        }

        public ItemDetailPage(Item item)
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel(Navigation,item);

        }
    }
}