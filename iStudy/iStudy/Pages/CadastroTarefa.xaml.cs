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
	public partial class CadastroTarefa : PopupPage
	{
        MateriaCRUD crud = new MateriaCRUD();
        ModeloEventos evento = new ModeloEventos();
    

        public CadastroTarefa ()
		{
			InitializeComponent ();
		}

        private void AdicionarNoBancoTarefas(object sender, EventArgs e)
        {

            if(Nome.Text == ""|| Nome.Text == null || Nome.Text == String.Empty)
            {
                DisplayAlert("Aviso!", "Por favor, insira um nome para sua tarefa", "Entendi!");
            }
            else if (Descri.Text == "" || Descri.Text == null || Descri.Text == String.Empty)
            {
                DisplayAlert("Aviso!", "Por favor, insira uma descrição para sua tarefa", "Entendi!");
            }
            else
            {
                evento.NomeEvento = Nome.Text;
                evento.DataEvento = Data.Date.ToString("dd/MM/yyyy");
                evento.DescEvento = Descri.Text;
                bool tentativaInserir = crud.InserirEvento(evento);

                if (tentativaInserir == false)
                {
                    DisplayAlert("Erro", "Algo deu errado, tente colocar um nome que não exista", "OK");
                }
                else
                {
                    DisplayAlert("Parabéns", Nome.Text + " foi inserido com sucesso!", "Entendi!");
                    VoltarPagina();
                }
            }
            
        }

        public async void VoltarPagina()
        {
            PopupNavigation.PopAllAsync(true);
            App.Current.MainPage = new MainTabbed(2);
        }
    }
}