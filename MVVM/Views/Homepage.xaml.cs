using CarDealership.Database;
using CarDealership.MVVM.ViewModels;
using CarDealership.Service;
using CarDealership.MVVM.Views;

namespace CarDealership.MVVM.Views;

public partial class Homepage : ContentPage
{
    private readonly LocalDbService _localDbService;
    private HomepageViewModel _viewModel;


    public Homepage(LocalDbService dbService)
	{
		InitializeComponent();
        _viewModel = new HomepageViewModel();
        BindingContext = _viewModel;
    }

    private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item is Car selectedCar)
        {
            string message = $"Details:\n\nManufacturer: {selectedCar.Manufacturer}\nModel: {selectedCar.Model}\nYear: {selectedCar.Year}\nTransmission: {selectedCar.Transmission}\nFuel: {selectedCar.Fuel}\nNumber Plate: {selectedCar.NumberPlate}\nBody Style: {selectedCar.Bodystyle}\nPrice: {selectedCar.Price}\nMillage: {selectedCar.Millage}";

            bool buyCar = await DisplayAlert("Car Details", message, "Buy", "Cancel");

            if (buyCar)
            {
                await DisplayAlert("Success", "Car successfully purchased!", "OK");

                var viewModel = (HomepageViewModel)BindingContext;
                await viewModel.RemoveCarAsync(selectedCar);
            }
            else
            {

            }
        }
    }

    private async void signin_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new login(_localDbService));
    }

    private async void signup_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new SignUp(_localDbService));
    }

    private async void publish_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Publish(_localDbService));
    }

    private async void review_Clicked(object sender, EventArgs e)
    {
        string url = "https://forms.gle/qXY7CLd2VC5WDMEv5";
        await Launcher.OpenAsync(new Uri(url));
    }

    private async void stats_Clicked(object sender, EventArgs e)
    {

    }
}