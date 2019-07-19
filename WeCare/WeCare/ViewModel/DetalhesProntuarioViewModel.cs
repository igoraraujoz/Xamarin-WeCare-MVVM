using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeCare.Model;
using WeCare.Services;
using WeCare.Services.Interfaces;
using Xamarin.Forms;

namespace WeCare.ViewModel
{
    public class DetalhesProntuarioViewModel : BaseVM
    {
        ProntuarioService prontuarioService;
        INavigationService _serviceNavigation;
        EspecialidadeService especialidadeService;

        public DetalhesProntuarioViewModel(INavigationService serviceNavigation)
        {
            prontuarioService = new ProntuarioService();
            especialidadeService = new EspecialidadeService();
            _serviceNavigation = serviceNavigation;
        }

        public ICommand AtualizarCommand
        {
            get
            {
                return new Command(() =>
                {
                    Atualizar();
                });
            }
        }

        public override Task InitializeAsync(object navigationData)
        {
            if (navigationData is ProntuarioModel)
            {
                var detalhe = prontuarioService.GetById(((ProntuarioModel)navigationData).Id);
                var listaEspecilidades = especialidadeService.GetAll();

                this.Id = detalhe.Id;
                this.Data = detalhe.Data;
                this.Descricao = detalhe.Descricao;
                this.Especialidade = listaEspecilidades;
                this.Medico = detalhe.Medico;
                this.UnidadeClinica = detalhe.UnidadeClinica;
                this.SelectedEspecialidade = listaEspecilidades.Find(x=> x.Id == detalhe.EspecialidadeId);
                this.EspecialidadeId = detalhe.EspecialidadeId;
            }
            return base.InitializeAsync(navigationData);
        }

        public async void Atualizar()
        {
            ProntuarioModel model = new ProntuarioModel();
            model.Data = this.Data;
            model.Descricao = this.Descricao;
            model.Especialidade = this.Especialidade;
            model.SelectedEspecialidade = this.selectedEspecialidade;
            model.Id = this.Id;
            model.Medico = this.Medico;
            model.UnidadeClinica = this.UnidadeClinica;
            model.EspecialidadeId = this.selectedEspecialidade.Id;

            var validado = ValidarItens(model);
            if (validado)
            {
                var result = await prontuarioService.Atualizar(model);
                if (result)
                    await _serviceNavigation.NavigateToAsync<HomeViewModel>();
                else
                    await Application.Current.MainPage.DisplayAlert("Erro !", "Houve um problema no cadastro, contate o administrador", "Ok");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Erro !", "Usuario ou senha nao podem ser vazios", "Ok");
            }
        }

        private bool ValidarItens(ProntuarioModel model)
        {
            bool validate = true;
            return validate;
        }


        private DateTime data = DateTime.Now;
        public DateTime Data { get { return data; } set { this.Set("Data", ref data, value); } }

        private List<EspecialidadeModel> especialidade = new EspecialidadeService().GetAll();


        public List<EspecialidadeModel> Especialidade { get { return especialidade; } set { this.Set("Especialidade", ref especialidade, value); } }

        private EspecialidadeModel selectedEspecialidade = null;
        public EspecialidadeModel SelectedEspecialidade { get { return selectedEspecialidade; } set { this.Set("SelectedEspecialidade", ref selectedEspecialidade, value); } }


        private string unidadeClinica = string.Empty;
        public string UnidadeClinica { get { return unidadeClinica; } set { this.Set("UnidadeClinica", ref unidadeClinica, value); } }

        private string medico = string.Empty;
        public string Medico { get { return medico; } set { this.Set("Medico", ref medico, value); } }

        private string descricao = string.Empty;
        public string Descricao { get { return descricao; } set { this.Set("Descricao", ref descricao, value); } }

        private Guid id = Guid.Empty;
        public Guid Id { get { return id; } set { this.Set("Id", ref id, value); } }

        private Guid especialidadeId = Guid.Empty;
        public Guid EspecialidadeId { get { return especialidadeId; } set { this.Set("EspecialidadeId", ref especialidadeId, value); } }
    }
}
