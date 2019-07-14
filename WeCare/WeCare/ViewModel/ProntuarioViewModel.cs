﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WeCare.Model;
using WeCare.Services;
using WeCare.Services.Interfaces;
using Xamarin.Forms;

namespace WeCare.ViewModel
{
    
    public class ProntuarioViewModel : BaseVM
    {
        ProntuarioService prontuarioService;
        INavigationService _serviceNavigation;

        public ProntuarioViewModel(INavigationService serviceNavigation)
        {
            prontuarioService = new ProntuarioService();
            _serviceNavigation = serviceNavigation;
        }

        public ICommand CadastrarCommand
        {
            get
            {
                return new Command(() =>
                {

                    Cadastrar();
                });
            }
        }


        public async void Cadastrar()
        {
            ProntuarioModel model = new ProntuarioModel();
            model.Data = this.Data;
            model.Descricao = this.Descricao;
            model.Especialidade = this.Especialidade;
            model.SelectedEspecialidade = this.selectedEspecialidade;
            model.Id = Guid.NewGuid();
            model.Medico = this.Medico;
            model.UnidadeClinica = this.UnidadeClinica;

            var validado = ValidarItens(model);
            if (validado)
            {
                var result = await prontuarioService.Cadastrar(model);
                if(result)
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

        private List<EspecialidadeModel> especialidade = new List<EspecialidadeModel>() {
        new EspecialidadeModel() {  Id = new Guid("6009f71f-11db-4f1d-b2f7-2c2bfe859a74"), Descricao = "Clinico Geral" },
        new EspecialidadeModel() {Id= new Guid("1bb1ee8d-9b06-48bd-8417-2f405cf539bb"), Descricao = "Dermatologista" } };


        public List<EspecialidadeModel> Especialidade { get { return especialidade; } set { this.Set("Especialidade", ref especialidade, value); } }

        private EspecialidadeModel selectedEspecialidade = null;
        public EspecialidadeModel SelectedEspecialidade { get { return selectedEspecialidade; } set { this.Set("SelectedEspecialidade", ref selectedEspecialidade, value); } }


        private string unidadeClinica = string.Empty;
        public string UnidadeClinica { get { return unidadeClinica; } set { this.Set("UnidadeClinica", ref unidadeClinica, value); } }

        private string medico = string.Empty;
        public string Medico { get { return medico; } set { this.Set("Medico", ref medico, value); } }

        private string descricao = string.Empty;
        public string Descricao { get { return descricao; } set { this.Set("Descricao", ref descricao, value); } }

    }
}
