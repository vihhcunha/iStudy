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
    public partial class MainTabbed : TabbedPage
    {
        public MainTabbed(int page = 1, int orderCalendario=0)
        {
            InitializeComponent();

            var navigationPage = new NavigationPage(new Materias());
            navigationPage.Icon = "icon_livros.png";
            navigationPage.Title = "Matérias";
            navigationPage.BackgroundColor = Color.Black;
           
            Children.Add(navigationPage);

            navigationPage = new NavigationPage(new Calendario(orderCalendario));
            navigationPage.Icon = "icone_calendario.png";
            navigationPage.Title = "Calendário";
            navigationPage.BackgroundColor = Color.Black;

            Children.Add(navigationPage);

            if (page == 2)
            {
                var pages = Children.GetEnumerator();
                pages.MoveNext(); // First page
                pages.MoveNext(); // Second page
                CurrentPage = pages.Current;
            }
            
        }
    }
}