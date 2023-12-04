using CarDealership.Database;
using CarDealership.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.MVVM.ViewModels
{
    public class HomepageViewModel
    {
        private readonly LocalDbService _localDbService;

        public ObservableCollection<Car> Cars { get; set; }

        public HomepageViewModel()
        {
            _localDbService = new LocalDbService();
            Cars = new ObservableCollection<Car>();
            LoadCarsAsync();
        }

        private async Task LoadCarsAsync()
        {
            var cars = await _localDbService.GetCars();
            Cars.Clear();

            foreach (var car in cars)
            {
                Cars.Add(car);
            }
        }

        public async Task RemoveCarAsync(Car selectedCar)
        {
            // Implement logic to remove the car from the collection
            if (Cars.Contains(selectedCar))
            {
                Cars.Remove(selectedCar);
                // Implement logic to update the database or perform any other necessary actions
                await _localDbService.DeleteCar(selectedCar);
            }
        }
    }
}
