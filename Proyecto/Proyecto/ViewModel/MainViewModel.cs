using GalaSoft.MvvmLight.Command;
using Proyecto.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Proyecto.ViewModel
{
    public class MainViewModel
    {

        public MainViewModel()
        {
            LoadMenu();
            LoadData();
        }

        public ObservableCollection<MenuItemViewModel> Menu { get; set; }
        public ObservableCollection<GeolocationViewModel> Geolocations { get; set; }

        public ICommand GoToCommand
        {
            get { return new RelayCommand<string>(GoTo); }
        }

        private void GoTo(string pageName)
        {
            switch (pageName)
            {
                case "NewGeolocationPage":
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

        private void LoadData()
        {
            Geolocations = new ObservableCollection<GeolocationViewModel>();

            for (int i = 0; i < 4; i++)
            {
                Geolocations.Add(new GeolocationViewModel()
                {
                    Title = "Sevilla",
                    Description = "Espana",
                    CreationDate = DateTime.Today,
                    Coordinates = "Lat 1 Long 2"
                });
            }
        }

    }
}
