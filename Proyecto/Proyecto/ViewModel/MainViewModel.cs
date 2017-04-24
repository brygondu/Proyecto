using GalaSoft.MvvmLight.Command;
using Proyecto.Models;
using Proyecto.Pages;
using Proyecto.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Proyecto.ViewModel
{
    public class MainViewModel
    {
        public GeolocationViewModel GeoModel { get; set; }

        NavigationService navigationService;
        ApiService apiService;

        public MainViewModel()
        {
            navigationService = new NavigationService();
            apiService = new ApiService();

            Geolocations = new ObservableCollection<GeolocationViewModel>();

            //GeolocationsSpecific = new ObservableCollection<GeolocationViewModel>();

            LoadMenu();
            LoadData();
        }

        public ObservableCollection<MenuItemViewModel> Menu { get; set; }
        public ObservableCollection<GeolocationViewModel> Geolocations { get; set; }

        public GeolocationViewModel NewGeolocation { get; private set; }

        //public ObservableCollection<GeolocationViewModel> GeolocationsSpecific { get; set; }

        public ICommand GoToCommand
        {
            get { return new RelayCommand<string>(GoTo); }
        }


        private void GoTo(string pageName)
        {
            switch (pageName)
            {
                case "NewGeolocationPage":
                    NewGeolocation = new GeolocationViewModel();
                    App.Navigator.PushAsync(new NewGeolocationPage());
                    break;
                default:
                    break;
            }
        }

        private void LoadMenu()
        {
            Menu = new ObservableCollection<MenuItemViewModel>();

            Menu.Add(new MenuItemViewModel()
            {
                Icon = "icon",
                Title = "Pagina Principal",
                PageName = "MainPage"
            });

            Menu.Add(new MenuItemViewModel()
            {
                Icon = "icon",
                Title = "Pagina de Geolocalizacion",
                PageName = "Geolocations"
            });

            Menu.Add(new MenuItemViewModel()
            {
                Icon = "icon",
                Title = "Prueba 1",
                PageName = "Prueba1"
            });
        }

        private async void LoadData()
        {

            var list = await apiService.GetAllGeolocation();

            Geolocations.Clear();

            foreach (var item in list)
            {
                Geolocations.Add(new GeolocationViewModel()
                {
                    Title = item.Title,
                    Description = item.Description,
                    Latitud = item.Latitud,
                    Longitud = item.Longitud,
                    FechaCreacion = item.FechaCreacion
                });
            }

            //,FechaCreacion = item.FechaCreacion

            //Geolocations = new ObservableCollection<GeolocationViewModel>();

            //for (int i = 0; i < 4; i++)
            //{
            //    Geolocations.Add(new GeolocationViewModel()
            //    {
            //        Title = "Sevilla",
            //        Description = "Espana",
            //        CreationDate = DateTime.Today,
            //        Latitud = "Lat 1",
            //        Longitud = "Long 2"
            //    });
            //}
        }


        


        //private async void LoadSpecificData()
        //{

        //    //Geolocations.

        //    //foreach (var item in list)
        //    //{
        //    //    Geolocations.Add(new GeolocationViewModel()
        //    //    {
        //    //        Title = item.Title,
        //    //        Description = item.Description,
        //    //        Latitud = item.Latitud,
        //    //        Longitud = item.Longitud
        //    //    });
        //    //}

        //}

    }
}
