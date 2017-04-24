using Proyecto.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Proyecto.Services
{
    public class NavigationService
    {

        public async void Navigate(string pageName)
        {
            App.Master.IsPresented = false;
            switch (pageName)
            {

                case "MainPage":
                    await App.Navigator.PopToRootAsync();
                    break;
                case "NewGeolocationPage":
                    await Navigate(new NewGeolocationPage());
                    //await App.Navigator.PushAsync(new Prueba_1());
                    break;
                case "Acerca_de":
                    await Navigate(new Acerca_de());
                    //await App.Navigator.PushAsync(new Prueba_1());
                    break;
                default:
                    break;
            }
        }

        private static async Task Navigate<T>(T page) where T : Page
        {
            NavigationPage.SetHasBackButton(page, true);
            NavigationPage.SetBackButtonTitle(page, "Atrás");

            await App.Navigator.PushAsync(page);
        }

        //public void Navigate()
        //{
        //    App.Master.IsPresented = false;

        //}

    }
}
