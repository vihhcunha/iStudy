using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iStudy;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using iStudy.ModeloBanco;
using iStudy.Model;
using Rg.Plugins.Popup.Services;
using iStudy.Pages;

namespace iStudy
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroMateria : PopupPage
    {
        MateriaCRUD crud = new MateriaCRUD();

        public CadastroMateria()
        {
            InitializeComponent();
        }

        ModeloMateria materiaParaInserir = new ModeloMateria();

        private void AdicionarNoBancoMaterias(object sender, EventArgs e)
        {
            if (Nome.Text == "" || Nome.Text == null || Nome.Text == String.Empty)
            {
                DisplayAlert("Aviso!", "Por favor, insira o nome da sua matéria!","Ok");
            }
            else
            {
                materiaParaInserir.ConteudoMateria = "";
                materiaParaInserir.NomeMateria = Nome.Text;
                bool tentativaInserir = crud.InserirMateria(materiaParaInserir);

                if(tentativaInserir == false)
                {
                    DisplayAlert("Erro", "Algo deu errado, tente colocar um nome que não exista", "OK");
                }
                else
                {
                    DisplayAlert("Parabéns", Nome.Text + " foi inserido com sucesso!", "Entendi!");
                    VoltarPagina(Nome.Text);
                }
            }    
        }

        private async void VoltarPagina(string nome)
        {
            Navigation.PushModalAsync(new EditorMateria(nome));
            PopupNavigation.PopAllAsync();
        }
    }
}