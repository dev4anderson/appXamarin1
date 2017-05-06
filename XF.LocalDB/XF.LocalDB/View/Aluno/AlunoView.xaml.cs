using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.LocalDB.ViewModel;

namespace XF.LocalDB.View.Aluno
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlunoView : ContentPage
    {
        AlunoViewModel vmAluno;    
        public AlunoView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            vmAluno = new AlunoViewModel();
            BindingContext = vmAluno;

            base.OnAppearing();
        }

        private void OnNovo(object sender, EventArgs args)
        {
            Navigation.PushAsync(new NovoView());
        }

        private void OnAlunoTapped(object sender, ItemTappedEventArgs args)
        {
            var selecionado = args.Item as XF.LocalDB.Model.Aluno;
            Navigation.PushAsync(new NovoView(selecionado.Id));
            //DisplayAlert("Aluno selecionado", "Aluno: " + selecionado.Id, "OK");
        }
    }
}
