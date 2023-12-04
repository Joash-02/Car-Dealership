using CarDealership.Database;
using CarDealership.Service;

namespace CarDealership.MVVM.Views;

public partial class login : ContentPage
{
    private readonly LocalDbService _dbService;
    public login(LocalDbService dbService)
	{
		InitializeComponent();
        _dbService = dbService;
    }

    private async void Login_Clicked(object sender, EventArgs e)
    {
        // Retrieve user from the database based on the entered email
        Users user = await _dbService.GetUserByEmail(emailEntryFeild.Text);

        if (user != null && user.Password == passwordEntryFeild.Text)
        {
            // Successful login
            await DisplayAlert("Login", "Login successful", "OK");
            LocalDbService localDbService = new LocalDbService();
            Publish publishInstance = new Publish(localDbService);
        }
        else
        {
            // Failed login
            await DisplayAlert("Login", "Invalid email or password", "OK");
        }

        // Clears the input fields
        emailEntryFeild.Text = string.Empty;
        passwordEntryFeild.Text = string.Empty;
    }

    private async void register_Clicked(object sender, EventArgs e)
    {
        try
        {
            // Debugging: Ensure that _dbService is not null before passing it to SignUp
            if (_dbService == null)
            {
                throw new InvalidOperationException("_dbService is null");
            }

            // Debugging: Log a message before navigating
            Console.WriteLine("Navigating to SignUp page...");

            // Pass the LocalDbService parameter when creating an instance of SignUp
            SignUp signUpPage = new SignUp(_dbService);

            // Debugging: Ensure that signUpPage is not null
            if (signUpPage == null)
            {
                throw new InvalidOperationException("signUpPage is null");
            }

            // Navigate to the SignUp page
            await Navigation.PushAsync(signUpPage);

            // Debugging: Log a message after navigating
            Console.WriteLine("Navigation to SignUp page successful");
        }
        catch (Exception ex)
        {
            // Debugging: Log or display the exception message
            Console.WriteLine($"Error in register_Clicked: {ex.Message}");
            throw; // Rethrow the exception for further analysis
        }
    }
}