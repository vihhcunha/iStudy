using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iStudy.ModeloBanco;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace iStudy.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OrdenarPage : PopupPage
	{
        MateriaCRUD crud = new MateriaCRUD();
		public OrdenarPage ()
		{
			InitializeComponent ();
		}

        private async void Ordenar(object sender, EventArgs e)
        {
            var escolhida = picker.SelectedIndex;

            if(escolhida == -1)
            {
                DisplayAlert("Erro", "Escolha alguma opção!", "OK");
            }
            else
            {
                PopupNavigation.PopAsync();

                App.Current.MainPage = new MainTabbed(2, escolhida);
            }
        }
    }
}