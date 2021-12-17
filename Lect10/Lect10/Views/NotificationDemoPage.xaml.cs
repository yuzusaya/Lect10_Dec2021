using Lect10.Models;
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
    public partial class NotificationDemoPage : ContentPage
    {
        public NotificationDemoPage()
        {
            InitializeComponent();
        }
        private void OnSendClick(object sender, EventArgs e)
        {
            DependencyService.Get<INotificationManager>().SendNotification("Hello","World");
        }
        private void OnScheduleClick(object sender, EventArgs e)
        {

        }
    }
}