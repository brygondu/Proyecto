﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyecto.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewGeolocationPage : ContentPage
    {
        public NewGeolocationPage()
        {
            InitializeComponent();

            //title.Text = "";
            //description.Text = "";
            //latitud.Text = "";
            //longitud.Text = "";
            //datePicker.Date = DateTime.Today;

        }
    }
}
