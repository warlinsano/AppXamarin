using AppXamarin.Models;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace AppXamarin.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {

        private bool _isEnabled;
        private DelegateCommand _agregarButton;
        private DelegateCommand _btnListarNacionalidades;
        private DelegateCommand _btnListarEmpleados;
        private readonly INavigationService _NavigationService;


        public LoginPageViewModel(INavigationService navigationService)
      : base(navigationService)
        {
            Title = "Iniciar Seccion";
            IsEnabled = true;
            _NavigationService = navigationService;
        }

        public DelegateCommand agregarButton => _agregarButton ?? (_agregarButton = new DelegateCommand(Agregar));
        public DelegateCommand btnListarNacionalidades => _btnListarNacionalidades ?? (_btnListarNacionalidades = new DelegateCommand(IrNacionalidades));
        public DelegateCommand btnListarEmpleados => _btnListarEmpleados ?? (_btnListarEmpleados = new DelegateCommand(IrListarEmpleados));



        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        public string Nombre { get; set; }
        public bool Estado { get; set; }

        public bool Apellidos { get; set; }

        private async void Agregar()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                IsEnabled = true;
                await App.Current.MainPage.DisplayAlert("Error", "Deve llenar el Nombre.", "Acceptar");
                return;
            }

            IsEnabled = false;
            var Nacionalidad = new Nacionalidades
            {
                //NacionalidadID = null,
                Nombre = this.Nombre.ToUpper(),
                Estado = true
            };

            //consumir web api   http://vbpuntonet.blogspot.com/2018/06/api-rest-consumiendo-un-api-rest-en-c.html
            var  UrlWebApi = "http://warlinsano.somee.com/";
            HttpClient ClientWebApi = new HttpClient();
            ClientWebApi.BaseAddress = new Uri(UrlWebApi);
            ClientWebApi.DefaultRequestHeaders.Clear();
            ClientWebApi.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("aplication/json"));

            //var response = new HttpResponseMessage();
            try
            {
            var requestString = JsonConvert.SerializeObject(Nacionalidad);
            var content = new StringContent(requestString, Encoding.UTF8, "application/json");
            var response = await ClientWebApi.PostAsync("api/Nacionalidades", content);
            var result = await response.Content.ReadAsStringAsync();

             if (!response.IsSuccessStatusCode)
               {
                    IsEnabled = true;
                    await App.Current.MainPage.DisplayAlert("Error", "De API response.", "Acceptar");
                    return;
                }

                //var token = JsonConvert.DeserializeObject<Nacionalidades>(result);
                //return new Response<TokenResponse>
                //{
                //    IsSuccess = true,
                //    Result = token
                //};
                IsEnabled = true;
                this.Nombre = string.Empty;
                await App.Current.MainPage.DisplayAlert("Error", "Guardado Con Exito....", "Acceptar");
                return;
            }
            catch (Exception ex)
            {
                IsEnabled = true;
                await App.Current.MainPage.DisplayAlert("Error", "Del try catch.: "+ ex, "Acceptar");
                return;
            }
            //var naci = response.Content.ReadAsStringAsync().Result;
            //var ListaEmpleados = JsonConvert.DeserializeObject<Nacionalidades>(naci);
        }


        private async void IrNacionalidades()
        {
            await _NavigationService.NavigateAsync("ListNacionalidadesPage");

        }

        private async void IrListarEmpleados()
        {
            await _NavigationService.NavigateAsync("ListEmployeesPage");

        }
        


    }
}
