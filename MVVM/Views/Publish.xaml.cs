using CarDealership.Database;
using CarDealership.Service;
using System.Diagnostics;
using System.Formats.Tar;

namespace CarDealership.MVVM.Views;

public partial class Publish : ContentPage
{
    private readonly LocalDbService _dbService;
    private int _editCarId;

    public Publish(LocalDbService dbService)
	{
		InitializeComponent();
        _dbService = dbService;
    }

    private async void publish_Clicked(object sender, EventArgs e)
    {
        // Validate and publish the car
        if (_editCarId == 0)
        {
            var newCar = new Car
            {
                Model = model.Text,
                Manufacturer = make.Text,
                Year = int.Parse(year.Text),
                Transmission = transmission.Text,
                Fuel = fuel.Text,
                NumberPlate = plate.Text,
                Bodystyle = style.Text,
                Price = price.Text,
                Millage = millage.Text
            };

            //When successfull, DisplayAlert shows up and the feilds get cleared
            await _dbService.CreateCar(newCar);
            await DisplayAlert("Success", "Car published successfully", "OK");
            model.Text = string.Empty;
            make.Text = string.Empty;
            year.Text = string.Empty;
            transmission.Text = string.Empty;
            fuel.Text = string.Empty;
            plate.Text = string.Empty;
            style.Text = string.Empty;
            price.Text = string.Empty;
            millage.Text = string.Empty;

        }
    }

}