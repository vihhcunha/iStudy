using iStudy.Model;
using iStudy.ModeloBanco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace iStudy.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditorMateria : ContentPage
	{
        MateriaCRUD crud = new MateriaCRUD();
        string nome;

		public EditorMateria (string _nome)
		{
			InitializeComponent ();
            this.nome = _nome;
            var pegarConteudo = crud.GetMateria(_nome);
            materia.Text = nome;
            editor.Text = pegarConteudo[0].ConteudoMateria;
		}

        private void Salvar(object sender, EventArgs e)
        {
            ModeloMateria materia = new ModeloMateria();
            materia.NomeMateria = nome;
            materia.ConteudoMateria = editor.Text;
            crud.AtualizarMateria(materia);
            DisplayAlert("Salvo", "Suas anotações foram salvas com sucesso!", "OK");
        }

        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new MainTabbed();

            return true;
        }

        private void Fechar(object sender, EventArgs e)
        {
            OnBackButtonPressed();
        }
    }
}