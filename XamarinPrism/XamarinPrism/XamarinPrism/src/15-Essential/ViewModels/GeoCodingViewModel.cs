using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using System.Linq;
namespace XamarinPrism.src._15_Essential.ViewModels
{
    public class GeoCodingViewModel : BindableBase
    {
        private string _latitude = "47.673988";
        public string Latitude
        {
            get { return _latitude; }
            set { SetProperty(ref _latitude, value); }
        }

        private string _longtitude = "-122.121513";
        public string Longtitude
        {
            get { return _longtitude; }
            set { SetProperty(ref _longtitude, value); }
        }
        private string _address = "Microsoft Building 25 Redmond WA USA";
        public string Address
        {
            get { return _address; }
            set { SetProperty(ref _address, value); }
        }

        private string _geocodeAddress;
        public string GeocodeAddress
        {
            get { return _geocodeAddress; }
            set { SetProperty(ref _geocodeAddress, value); }
        }

        private string _eocodePosition;
        public string GeocodePosition
        {
            get { return _eocodePosition; }
            set { SetProperty(ref _eocodePosition, value); }
        }

        private DelegateCommand _getAddressCommand;
        public DelegateCommand GetAddressCommand =>
            _getAddressCommand ?? (_getAddressCommand = new DelegateCommand(async () => await ExecuteGetAddress()));



        private DelegateCommand _getPositionCommand;
        public DelegateCommand GetPositionCommand =>
            _getPositionCommand ?? (_getPositionCommand = new DelegateCommand(async () => await ExecuteGetPosition()));
        private async Task ExecuteGetAddress()
        {
            try
            {
                //double.TryParse(Latitude, out double lat);
                //double.TryParse(Longtitude, out double lon);


                var placeMarks = await Geocoding.GetPlacemarksAsync(47.673988, -122.121513);
                Placemark placemark = placeMarks.FirstOrDefault();
                if (placemark == null)
                {
                    GeocodeAddress = "Unable to detect placemark";
                }
                else
                {
                    GeocodeAddress =
                        $"AdminArea:       {placemark.AdminArea}\n" +
                        $"CountryCode:     {placemark.CountryCode}\n" +
                        $"CountryName:     {placemark.CountryName}\n" +
                        $"FeatureName:     {placemark.FeatureName}\n" +
                        $"Locality:        {placemark.Locality}\n" +
                        $"PostalCode:      {placemark.PostalCode}\n" +
                        $"SubAdminArea:    {placemark.SubAdminArea}\n" +
                        $"SubLocality:     {placemark.SubLocality}\n" +
                        $"SubThoroughfare: {placemark.SubThoroughfare}\n" +
                        $"Thoroughfare:    {placemark.Thoroughfare}\n";
                }
            }
            catch (Exception)
            {

            }
        }
        private async Task ExecuteGetPosition()
        {
            try
            {
                var locations = await Geocoding.GetLocationsAsync(Address);
                Location location = locations.FirstOrDefault();
                if (location == null)
                {
                    GeocodeAddress = "Unable to detect location";
                }
                else
                {
                    GeocodePosition = $"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}";
                }
            }
            catch (Exception)
            {

            }

        }
    }
}
