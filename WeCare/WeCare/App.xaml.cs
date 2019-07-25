using DLToolkit.Forms.Controls;
using System;
using System.Threading.Tasks;
using WeCare.Services;
using WeCare.Services.Interfaces;
using WeCare.ViewModel.ViewModelLocator;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace WeCare
{
    public partial class App : Application
    {
        public App()
        {
            //Registro da injeção de dependecia para as classes de services
            DependencyService.Register<INavigationService, NavigationService>();
            DependencyService.Register<IEspecialidadeService, EspecialidadeService>();
            DependencyService.Register<IProntuarioService, ProntuarioService>();
            DependencyService.Register<ILoginService, LoginService>();

            InitializeComponent();
            InitPlugins();
            InitNavigation();
        }

        public Task InitNavigation()
        {
            var navigationService = Locator.Instance.Resolve<INavigationService>();
            return navigationService.InitializeAsync();
        }

        public void InitPlugins()
        {
            FlowListView.Init();

            Plugin.Iconize.Iconize.With(new Plugin.Iconize.Fonts.FontAwesomeRegularModule())
                      .With(new Plugin.Iconize.Fonts.FontAwesomeBrandsModule())
                      .With(new Plugin.Iconize.Fonts.FontAwesomeSolidModule());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
