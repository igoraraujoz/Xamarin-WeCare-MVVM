﻿using System;
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

            //Registro de Interfaces
            _container.RegisterType<INavigationService, NavigationService>();
            // _container.RegisterType<IServiceMessages, ServiceMessages>();
            //registro de ViewModel
            //_container.RegisterType<LoginViewModel>();
            //_container.RegisterType<DetalhesViewModel>();
            //_container.RegisterType<HomeViewModel>();

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
