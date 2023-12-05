using MaUILuganoMeteo.ViewModels;

namespace MaUILuganoMeteo;

public partial class MainPage : ContentPage
{
    private readonly ForecastViewModel _forecastViewModel;

    public MainPage(ForecastViewModel forecastViewModel)
    { 
        InitializeComponent();

        BindingContext = forecastViewModel;

        _forecastViewModel = forecastViewModel;

        GetForecastsData();
    }

    void GetForecastsData()
    {
        _forecastViewModel.GetForecastData();
    }

    void RefreshForecastsBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        ((ForecastViewModel)this.Handler.MauiContext.Services.GetServices<ForecastViewModel>()).GetForecastData();
    }
}


