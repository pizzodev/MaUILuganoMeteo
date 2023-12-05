using System.ComponentModel;
using System.Runtime.CompilerServices;
using MaUILuganoMeteo.Model;
using MaUILuganoMeteo.Services;

namespace MaUILuganoMeteo.ViewModels
{
    public class ForecastViewModel : INotifyPropertyChanged
    {

        private readonly IForecastService _forecastService;

        private List<DailyForecast> _forecasts;

        public List<DailyForecast> forecasts
        {
            get => _forecasts;
            set
            {
                if (_forecasts != value)
                {
                    _forecasts = value;
                    OnPropertyChanged();
                }
            }
        }

        public ForecastViewModel() { }
        
        public ForecastViewModel(IForecastService forecastService)
        {
            _forecastService = forecastService;
            GetForecastData();
        }

        public async void GetForecastData()
        {
            forecasts = await _forecastService.GetForecastsData();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}

