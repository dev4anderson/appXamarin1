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
            refresh();
            base.OnAppearing();
        }

        private void OnAlunoTapped(object sender, ItemTappedEventArgs args)
        {
            vmAluno.Selecionado = args.Item as XF.LocalDB.Model.Aluno;
            Navigation.PushAsync(new NovoView(vmAluno.Selecionado.Id));
        }

        private async void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);

            var aluno = (mi.CommandParameter as XF.LocalDB.Model.Aluno);

            var resposta = await DisplayAlert("Atenção", "Tenha certeza que deseja excluir esse Aluno?", "Sim", "Não");
            if (resposta){
                App.AlunoModel.RemoverAluno(aluno.Id);
                refresh();
            }
        }

        private void refresh()
        {
            vmAluno = new AlunoViewModel();
            BindingContext = vmAluno;
        }
    }
}
