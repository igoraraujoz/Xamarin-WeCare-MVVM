using DLToolkit.Forms.Controls;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WeCare.Model;
using WeCare.Services;
using WeCare.Services.Interfaces;
using Xamarin.Forms;

namespace WeCare.ViewModel
{
   public  class HistoricoViewModel : BaseVM
    {
        INavigationService _serviceNavigation;
        ProntuarioService prontuarioService;
        public FlowObservableCollection<ProntuarioModel> ItensHistorico { get; set; }

        public HistoricoViewModel(INavigationService serviceNavigation)
        {
            _serviceNavigation = serviceNavigation;
            prontuarioService = new ProntuarioService();
            ItensHistorico = new FlowObservableCollection<ProntuarioModel>();
            CarregarHistorico();
        }

        public void CarregarHistorico()
        {
            var lista = prontuarioService.GetAll();

            foreach (var item in lista)
            {
                ItensHistorico.Add(item);
            }
        }

        public ICommand ItemSelectedCommand
        {
            get
            {
                return new Command(async (value) =>
                {
                    ProntuarioModel item = value as ProntuarioModel;
                    await _serviceNavigation.NavigateToAsync<DetalhesProntuarioViewModel>(item);
                });
            }
        }       
    }
}
