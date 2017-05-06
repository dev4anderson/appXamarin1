using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XF.LocalDB.View.Aluno
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NovoView : ContentPage
    {
        public NovoView()
        {
            InitializeComponent();
        }

        private int alunoId = 0;
        public NovoView(int Id)
        {
            InitializeComponent();

            var aluno = App.AlunoModel.GetAluno(Id);
            txtNome.Text = aluno.Nome;
            txtRM.Text = aluno.RM;
            txtEmail.Text = aluno.Email;
            IsAprovado.IsToggled = aluno.Aprovado;
            alunoId = aluno.Id;
        }

        public void OnCancelar(object sender, EventArgs args)
        {
            Limpar();
            Navigation.PopAsync();
        }

        public void Limpar()
        {
            txtNome.Text = txtRM.Text = txtEmail.Text = string.Empty;
            IsAprovado.IsToggled = false;
        }


    }
}
