using GalaSoft.MvvmLight.Command;
using Proyecto.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Proyecto.ViewModel
{
    public class MenuItemViewModel
    {

        public string Icon { get; set; }

        public string Title { get; set; }

        public string PageName { get; set; }


        public ICommand NavigateCommand
        {
            get { return new RelayCommand(Navigate); }
        }

        private void Navigate()
        {
            App.Master.IsPresented = false;
            switch (PageName)
            {

                case "MainPage":
                    App.Navigator.PopToRootAsync();
                    App.Navigator.PushAsync(new MainPage());
                    break;
                case "Prueba1":
                    App.Navigator.PushAsync(new Prueba_1());
                    break;
                default:
                    break;
            }
        }

    }
}
