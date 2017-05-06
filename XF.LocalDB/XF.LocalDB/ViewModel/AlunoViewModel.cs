using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XF.LocalDB.Model;

namespace XF.LocalDB.ViewModel
{
    public class AlunoViewModel
    {
        public AlunoViewModel()
        {
            OnAdicionar = new AdicionarAluno(this);
            OnSalvarAluno = new SalvarAluno(this);
        }

        #region Propriedades
        public AdicionarAluno OnAdicionar { get; }
        public SalvarAluno OnSalvarAluno { get; }
        public Aluno Selecionado { get; set; }
        public string RM { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public List<Aluno> Alunos
        {
            get
            {
                return App.AlunoModel.GetAlunos().ToList();
            }
        }
        #endregion

        public void OnNovo()
        {
            App.Current.MainPage.Navigation.PushAsync(new View.Aluno.NovoView());
        }

        public void OnSalvar()
        {
            Aluno aluno = new Aluno()
            {
                Nome = txtNome.Text,
                RM = txtRM.Text,
                Email = txtEmail.Text,
                Aprovado = IsAprovado.IsToggled,
                Id = alunoId
            };
            Limpar();
            App.AlunoModel.SalvarAluno(aluno);
            App.Current.MainPage.Navigation.PopAsync();
        }

    }

    public class AdicionarAluno : ICommand
    {
        private AlunoViewModel vmAluno;
        public AdicionarAluno(AlunoViewModel paramVM)
        {
            vmAluno = paramVM;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            vmAluno.OnNovo();
        }
    }

    public class SalvarAluno : ICommand
    {
        private AlunoViewModel vmAluno;
        public SalvarAluno(AlunoViewModel paramVM)
        {
            vmAluno = paramVM;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            vmAluno.OnSalvar();
        }
    }

}
