using CarDealership.MVVM.Views;
using CarDealership.Service;

namespace CarDealership
{
    public partial class App : Application
    {
        public App(LocalDbService dbService)
        {
            InitializeComponent();
            MainPage = new Homepage(dbService);
        }
    }
}