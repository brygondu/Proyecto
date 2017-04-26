using GalaSoft.MvvmLight.Command;
using Proyecto.Models;
using Proyecto.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Proyecto.ViewModel
{
    public class GeolocationViewModel
    {
        ApiService apiService;
        DialogService dialogService;

        public GeolocationViewModel()
        {
            apiService = new ApiService();
            dialogService = new DialogService();
            FechaCreacion = DateTime.Today;
        }

        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string Latitud { get; set; }

        public string Longitud { get; set; }

        public ICommand BrowseCommand { get; set; }

        public ICommand SaveCommand
        {
            get { return new RelayCommand(Save); }
        }

        private async void Save()
        {
            try
            {
                await apiService.CreateGeolocation(new Geolocations()
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = this.Title,
                    Description = this.Description,
                    FechaCreacion = this.FechaCreacion,
                    Latitud = this.Latitud,
                    Longitud = this.Longitud

                });

                await dialogService.ShowMessage("El pedido ha sido creado.", "Informacion");

                await App.Navigator.PopToRootAsync();

            }
            catch
            {

                await dialogService.ShowMessage("Ha ocurrido un error inesperado.", "Error");
            }

        }

        

        //internal bool Matches(string searchText)
        //{
        //    throw new NotImplementedException();
        //}

        //public string Coordinates { get; set; }

    }
}
