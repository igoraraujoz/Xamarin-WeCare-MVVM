using System;
using System.Collections.Generic;
using System.Text;
using Unity;
using WeCare.Services;
using WeCare.Services.Interfaces;

namespace WeCare.ViewModel.ViewModelLocator
{
    public class Locator
    {
        private readonly IUnityContainer _container;
        private static readonly Locator _instance = new Locator();

        public static Locator Instance
        {
            get { return _instance; }
        }


        public Locator()
        {
            _container = new UnityContainer();

            //Registro de Interfaces no locator do container
            _container.RegisterType<INavigationService, NavigationService>();
            _container.RegisterType<IProntuarioService, ProntuarioService>();
            _container.RegisterType<IEspecialidadeService, EspecialidadeService>();
            _container.RegisterType<ILoginService, LoginService>();

        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public object Resolve(Type type)
        {
            return _container.Resolve(type);
        }
    }
}
