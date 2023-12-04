using CarDealership.Database;
using CarDealership.Service;
using Microsoft.Web.Mvc.Controls;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CarDealership.MVVM.Views;

public partial class SignUp : ContentPage
{
	private readonly LocalDbService _dbService;
    private int _editUsersId;


    public SignUp(LocalDbService dbService)
	{
		InitializeComponent();
        _dbService = dbService;

    }

    private async void signup_Clicked(object sender, EventArgs e)
    {
        //Creates a new user
        if (_editUsersId == 0)
        {
            await _dbService.Create(new Users
            {
                Fullname = fullnameEntryFeild.Text,
                Number = numberEntryFeild.Text,
                Email = emailEntryFeild.Text,
                Password = passwordEntryFeild.Text

            });
        }
        else
        {
            //Edit Customer
            await _dbService.Update(new Users
            {
                Id = _editUsersId,
                Fullname = fullnameEntryFeild.Text,
                Number = numberEntryFeild.Text,
                Email = emailEntryFeild.Text,
                Password = passwordEntryFeild.Text
            });

            _editUsersId = 0;
        }

        //Clears the feild with a displayalert
        fullnameEntryFeild.Text = string.Empty;
        numberEntryFeild.Text = string.Empty;
        emailEntryFeild.Text = string.Empty;
        passwordEntryFeild.Text = string.Empty;

        await DisplayAlert("Registration", "Successfully SignedUp", "OK");
    }

    private async void login_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new login(_dbService));
    }
}