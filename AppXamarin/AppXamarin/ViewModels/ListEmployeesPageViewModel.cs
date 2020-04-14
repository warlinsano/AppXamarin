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

namespace AppXamarin.ViewModels
{
    public class ListEmployeesPageViewModel : ViewModelBase
    {

        public IList<Employees> ListEmployees { get; set; }

        public ListEmployeesPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Lista De Empleados";

            string UrlWebApi = "http://warlinsano.somee.com/";
            HttpClient ClientWebApi = new HttpClient();
            ClientWebApi.BaseAddress = new Uri(UrlWebApi);
            ClientWebApi.DefaultRequestHeaders.Clear();
            ClientWebApi.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("aplication/json"));

            var response = new HttpResponseMessage();
            response = ClientWebApi.GetAsync("api/EmployeesAPI/").Result;
            if (response.IsSuccessStatusCode)
            {
                var Lista = response.Content.ReadAsStringAsync().Result;
                ListEmployees = (JsonConvert.DeserializeObject<List<Employees>>(Lista));
            }
        }


    }
}
