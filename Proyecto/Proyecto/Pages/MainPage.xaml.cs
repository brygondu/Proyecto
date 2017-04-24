using Proyecto.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Proyecto.Pages
{
    public partial class MainPage : ContentPage
    {

        //public GeolocationViewModel Model { get; set; }

        public MainPage()
        {
            //Results = new ObservableCollection<GeolocationViewModel>();

            InitializeComponent();

        }

        //private void MainSearchBar_SearchButtonPressed(object sender, EventArgs e)
        //{

        //    string keyword = MainSearchBar.Text;

        //    IEnumerable<string> searchResult = from 

        //}

        //private string _searchText;
        //public string SearchText
        //{
        //    get { return _searchText; }
        //    set
        //    {
        //        _searchText = value;
        //        OnPropertyChanged(nameof(SearchText));
        //        Filter();

        //    }
        //}

        //public ObservableCollection<GeolocationViewModel> Results { get; private set; }


        //private ObservableCollection<GeolocationViewModel> _geolocation;
        //public ObservableCollection<GeolocationViewModel> Geolocation
        //{
        //    get { return _geolocation; }
        //    set
        //    {
        //        _geolocation = value;
        //        OnPropertyChanged(nameof(Geolocation));

        //        SearchText = string.Empty;
        //    }
        //}

        //private void Filter()
        //{
        //    Results.Clear();

        //    var query = string.IsNullOrEmpty(SearchText) ?
        //                      Geolocation.ToArray()
        //                      : Geolocation.Where(item => item.Matches(SearchText)).ToArray();

        //    foreach (var item in query)
        //    {
        //        Results.Add(item);
        //    }
        //}

        //internal bool Matches(string searchText)
        //{
        //    return Model != null &&
        //        (Model.Title ?? string.Empty).ToLowerInvariant().Contains(searchText.ToLowerInvariant());
        //}
    }
}
