using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace iStudy
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Preview : ContentPage
    {

        public Preview()
        {
            InitializeComponent();
            ChamarMainTabbed();
        }

        private async void ChamarMainTabbed()
        {
            await Task.Delay(1000);
            App.Current.MainPage = new MainTabbed();
        }
    }
}