using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms.Xaml;
using iStudy.ModeloBanco;
using iStudy.Model;
using iStudy.Pages;

namespace iStudy
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Materias : ContentPage
    {
        List<ModeloMateria> modeloMateria = new List<ModeloMateria>();
        MateriaCRUD criandoBanco = new MateriaCRUD();

        public Materias()
        {
            InitializeComponent();

            criandoBanco.CriarBancoDeDadosMaterias();
            AtualizarLista();
        }

        public void AtualizarLista(string pesquisa = null)
        {
            modeloMateria = criandoBanco.GetMaterias();

            if(pesquisa == null)
            {
                lista.ItemsSource = modeloMateria;
            }
            else
            {
                lista.ItemsSource = modeloMateria.Where(t => t.NomeMateria.ToUpper().Contains(pesquisa)).ToList();
            }   
        }

        public void AtualizarLista2(object sender, EventArgs e)
        {
            modeloMateria = criandoBanco.GetMaterias();
            lista.ItemsSource = modeloMateria;
            lista.IsRefreshing = false;
        }


        private async void Cadastrar_Materia(object sender, EventArgs e)
        {
            AtualizarLista();
            await PopupNavigation.PushAsync(new CadastroMateria());
        }

        private async void OnDelete(object sender, EventArgs e)
        {
            
            modeloMateria = criandoBanco.GetMaterias();
            var materiaExcluir = (sender as MenuItem).CommandParameter as ModeloMateria;
            var confirmacao = await  DisplayAlert("Aviso!", "Você realmente deseja excluir a matéria: "+materiaExcluir.NomeMateria+"? Todo seu conteúdo será apagado.", "Sim", "Não");

            if (confirmacao)
            {
                criandoBanco.DeletarMateria(materiaExcluir);
            }
            
            AtualizarLista();
        }

        private async void lista_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            AtualizarLista();
            var x = criandoBanco.GetMaterias();
            await Navigation.PushModalAsync(new EditorMateria(x[e.SelectedItemIndex].NomeMateria));
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            AtualizarLista(e.NewTextValue.ToUpper());
        }
    }
}