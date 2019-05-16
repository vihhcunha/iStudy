using iStudy.ModeloBanco;
using iStudy.Pages;
using Rg.Plugins.Popup.Services;
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
    public partial class Calendario : ContentPage
    {
        List<ModeloEventos> modeloEventos = new List<ModeloEventos>();
        MateriaCRUD crud = new MateriaCRUD();

        int OrdenarCalendario;

        public Calendario(int OrdenarCalendario = 2)
        {
            InitializeComponent();

            this.OrdenarCalendario = OrdenarCalendario;

            crud.CriarBancoDeDadosEventos();
            AtualizarLista(this.OrdenarCalendario);
        }

        private void AtualizarLista(int n, string pesquisa = null)
        {
            lista.IsRefreshing = true;
            if (n == 0)
            {
                modeloEventos = crud.GetEventosByDecrescent();
            }
            else if (n == 1)
            {
                modeloEventos = crud.GetEventosByCrescent();
            }
            else if(n == 2)
            {
                modeloEventos = crud.GetEventosByName();
            }
            
            if(pesquisa == null)
            {
                lista.ItemsSource = modeloEventos;
            }
            else
            {
                lista.ItemsSource = modeloEventos.Where(t => t.NomeEvento.ToUpper().Contains(pesquisa)).ToList(); 
            }
            
            lista.IsRefreshing = false;
        }

        private async void Cadastrar_Tarefa(object sender, EventArgs e)
        {
            await PopupNavigation.PushAsync(new CadastroTarefa());
        }


        private async void OnDelete(object sender, EventArgs e)
        {
            modeloEventos = crud.GetEventos();
            var eventoExcluir = (sender as MenuItem).CommandParameter as ModeloEventos;
            var confirmacao = await DisplayAlert("Aviso!", "Você realmente deseja excluir a matéria: " + eventoExcluir.NomeEvento + "? Todo seu conteúdo será apagado.", "Sim", "Não");

            if (confirmacao)
            {
                crud.DeletarEvento(eventoExcluir);
            }

            AtualizarLista(OrdenarCalendario);
        }

        private void Ordenar_Tarefa(object sender, EventArgs e)
        {
            PopupNavigation.PushAsync(new OrdenarPage());
        }

        private void AtualizarLista2(object sender, EventArgs e)
        {
            AtualizarLista(OrdenarCalendario);
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            AtualizarLista(OrdenarCalendario, e.NewTextValue.ToUpper());
        }
    }
}


