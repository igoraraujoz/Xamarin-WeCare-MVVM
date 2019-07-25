using DLToolkit.Forms.Controls;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        IProntuarioService _prontuarioService;
        public FlowObservableCollection<ProntuarioModel> ItensHistorico { get; set; }

        public HistoricoViewModel(INavigationService serviceNavigation, IProntuarioService prontuarioService)
        {
            _serviceNavigation = serviceNavigation;
            _prontuarioService = prontuarioService;
            ItensHistorico = new FlowObservableCollection<ProntuarioModel>();
            CarregarHistorico();
        }

        public void CarregarHistorico()
        {
            var lista = _prontuarioService.GetAll();

            foreach (var item in lista)
            {
                item.DateTimeString = item.Data.ToString("dd/MM/yyyy");
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
