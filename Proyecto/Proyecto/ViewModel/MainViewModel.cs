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
using Xamarin.Forms;

namespace Proyecto.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public GeolocationViewModel GeoModel { get; set; }


        NavigationService navigationService;
        ApiService apiService;

        public MainViewModel()
        {
            navigationService = new NavigationService();
            apiService = new ApiService();

            Geolocations = new ObservableCollection<GeolocationViewModel>();

            //_refreshCommand = new Command(RefreshListView);

            //GeolocationsSpecific = new ObservableCollection<GeolocationViewModel>();

            LoadMenu();
            LoadData();
        }

        //async void RefreshListView()
        //{
        //    LoadData();
        //}

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
                Title = "Nueva Geolocalización",
                PageName = "NewGeolocationPage"
            });

            Menu.Add(new MenuItemViewModel()
            {
                Icon = "icon",
                Title = "Acerca de",
                PageName = "Acerca_de"
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


        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                if (_isRefreshing == value)
                    return;

                _isRefreshing = value;
                OnPropertyChanged("IsRefreshing");
            }
        }

        public ICommand RefreshCommand
        {
            get { return new RelayCommand(RefreshLV); }
        }

        private async void RefreshLV()
        {

            IsRefreshing = true;

            LoadData();

            IsRefreshing = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;


        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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
