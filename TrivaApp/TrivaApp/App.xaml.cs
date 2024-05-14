using System;
using TrivaApp.Services;
using Xamarin.Forms;

namespace TrivaApp
{
    public partial class App : Application
    {
        public App ()
        {
            InitializeComponent();

            RegisterServices();

            MainPage = new NavigationPage(new MainPage());
        }

        private void RegisterServices()
        {
            DependencyService.Register<ITriviaService, TriviaService>();
            DependencyService.Register<IApiService, ApiService>();
            DependencyService.Register<ILocalStorageService, LocalStorageService>();

        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

